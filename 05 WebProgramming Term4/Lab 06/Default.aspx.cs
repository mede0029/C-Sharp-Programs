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
using System.Xml.XPath;
using System.Xml.Linq;
using System.Xml.Xsl;

public partial class _Default : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }


    protected void submitBtn_Click(object sender, EventArgs e)
    {
        // Creating variables for each file and creating a new doc:
        var input = Server.MapPath("restaurant_reviews.xml");
        var stylesheet = Server.MapPath("restaurant_reviews.xslt");
        var output = Server.MapPath("restaurant_reviews.html");
        var doc = new XPathDocument(input);

        // Creating a writer for writing the transformed file:
        var writer = XmlWriter.Create(output);
        
        // Creating and loading transform with script execution enabled:
        var transform = new XslCompiledTransform(true);
        transform.Load(stylesheet);

        // Creating an object with the rating number from user input. "ratingInput" will be used as a parameter in xslt:
        var arguments = new XsltArgumentList();
        arguments.AddParam("ratingInput", "", initialRatingTxt.Text);

        // Executing the transformation using the doc, the arguments and the writer:
        transform.Transform(doc, arguments, writer);
        writer.Close();

        using(StreamReader sr = new StreamReader(output))
        {
            outputLiteral.Text = sr.ReadToEnd();
        }
    }
}
