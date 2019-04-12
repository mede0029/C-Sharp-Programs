using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.IO;

public class CustomErrorMessages
{
    public static List<string[]> errorList = new List<string[]> { };
}

public partial class _Default : System.Web.UI.Page
{
    //validation button
    protected void validateBtn_Click(object sender, EventArgs e)
    {
        //1. Creating variables to store the two files uploaded, defining it's name and path:
        string xmlFilePath = Server.MapPath("Files\\") + xmlUpload.FileName;
        string xsdFilePath = Server.MapPath("Files\\") + schemaUpload.FileName;

        //2. Uploading both files:
        xmlUpload.SaveAs(xmlFilePath);
        schemaUpload.SaveAs(xsdFilePath);

        //3. Calling validation funcion:
        //3.1 Sending xsd and xml file paths to the Validation function:
        if (Validation(xmlFilePath, xsdFilePath))
        {
            //if validation returns an error:
            if (CustomErrorMessages.errorList.Count > 0) 
            {
                // 3.2 Displaying the number of errors found:
                testing.Text = CustomErrorMessages.errorList.Count + " error(s) were found in " + xmlUpload.FileName + ":<br /><br />";
                testing.Text += "Validation results:";

                // 3.3 Looping through the file, outputing information to the page on each error found: 
                validationResults.Visible = true;
                foreach (string[] s in CustomErrorMessages.errorList)
                {                   
                    // table:
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();
                    cell.Text = "Error";
                    row.Cells.Add(cell);
                    cell = new TableCell();
                    cell.Text = s[0];
                    row.Cells.Add(cell);
                    cell = new TableCell();
                    cell.Text = s[1];
                    row.Cells.Add(cell);
                    cell = new TableCell();
                    cell.Text = s[2];
                    row.Cells.Add(cell);
                    validationResults.Rows.Add(row);
                }
            }
            else //if no errors were found:
            {                
                testing.Text = xmlUpload.FileName + " is valid.";
            }
        }
        else // Something went wrong loading the files:
        {
            testing.Text = "Error reading file!";
        }
    }

    static void ValidationCallBack(object sender, ValidationEventArgs returnedValidationError)
    {
        // This funcion is called to handle events everytime there is an error at the xml file inside the Validation function
        // It creates an array to store the validation errors (built in features), and adds it to the errorList
        string[] error = new string[3];
        error[0] = returnedValidationError.Exception.LineNumber.ToString();
        error[1] = returnedValidationError.Exception.LinePosition.ToString();
        error[2] = returnedValidationError.Message;
        CustomErrorMessages.errorList.Add(error);
    }

    // Validation function, sending the filepath for xml and schema files:
    static bool Validation(string xmlFilePath, string xsdFilePath)
    {
        try
        {
            // creating a new schema object:
            XmlSchemaSet schemaObject = new XmlSchemaSet();
            
            // adding the namespace and schema file to the schemaObject:
            schemaObject.Add("www.algonquincollege.com/onlineservice/reviews", xsdFilePath);
            
            // creating a settings object to describe how the xml file must be validated:
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            settings.CheckCharacters = true;
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = schemaObject;

            // every time there's an error, it triggers and event that is hadled by the ValidationCallBack function:
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            // opening xml file:
            FileStream xmlFileObject = new FileStream(xmlFilePath, FileMode.Open);

            // creating a reader that will parse through xml file, following what was stablished in settings for validation:
            XmlReader xmlFileReader = XmlReader.Create(xmlFileObject, settings);

            while (xmlFileReader.Read())
            {
                // reading each line of xml file and applying settings definition. Loops until it reaches the end of the file
            }

            // closing both files:
            xmlFileReader.Close();
            xmlFileObject.Close();
            return true;
        }
        catch (System.Exception ex)
        {
            return false;
        }
    }
}