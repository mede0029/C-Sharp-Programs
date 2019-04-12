using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {       
        //Add your code to deserialize the xml file and initialize the dropdown list.
        itineraries itneraryList = null;
        if (Session["itneraryListSession"] == null) //in case there is no session yet
        {
            //opening the xml file
            string xmlFile = MapPath(@"~/itineraries.xml");
            using (FileStream xs = new FileStream(xmlFile, FileMode.Open))
            {
                //deserializing the file (converting it into an object)
                XmlSerializer serial = new XmlSerializer(typeof(itineraries));
                itneraryList = (itineraries)serial.Deserialize(xs);
            }
            Session["itneraryListSession"] = itneraryList;
        }
        else
        {
            itneraryList = Session["itneraryListSession"] as itineraries;
        }
        if (!IsPostBack) //display restaurant list using DataBinding:
        {
            drpPassenger.DataSource = itneraryList.itinerary;
            drpPassenger.DataTextField = "passenger";
            drpPassenger.DataBind();
            drpPassenger.Items.Insert(0, new ListItem("Select One...", "0"));
        }                        
    }

    protected void drpPassenger_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Add your code to handle the event when the user selects a different passenger
        //creating a list of restaurants from the data stored in the session from xml file
        itineraries itneraryList = Session["itneraryListSession"] as itineraries;

        //displaying additional fields when there's something selected from dropdown list:
        if (drpPassenger.SelectedValue == "0")
        {
            txtOutboundDeparture.Visible = false;
            txtOutboundArriving.Visible = false;
            txtReturnDeparture.Visible = false;
            txtReturnArriving.Visible = false;
            return;
        }
        else
        {
            txtOutboundDeparture.Visible = true;
            txtOutboundArriving.Visible = true;
            txtReturnDeparture.Visible = true;
            txtReturnArriving.Visible = true;

            //calling function to display info on itineraries:
            displayItineraryInfo(itneraryList.itinerary[drpPassenger.SelectedIndex - 1]);
        }
    }

    //function to display info on itineraries:
    public void displayItineraryInfo(itinerariesItinerary iti)
    {
        txtOutboundDeparture.Text = iti.outbound.departure.city;
        txtOutboundArriving.Text = iti.outbound.arriving.city;
        txtReturnDeparture.Text = iti.@return.departure.city;
        txtReturnArriving.Text = iti.@return.arriving.city;
        drpPassenger.SelectedValue = iti.passenger.ToString();
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //creating a restaurants object from the session
        itineraries itneraryList = null;
        itneraryList = Session["itneraryListSession"] as itineraries;
        
        if (drpPassenger.SelectedValue != "0") //if there is a restaurant selected
        {
            //create a restaurant object for the selected restaurant and displayin its info
            itinerariesItinerary iti = itneraryList.itinerary[drpPassenger.SelectedIndex - 1];
            iti.outbound.departure.city = txtOutboundDeparture.Text;
            iti.outbound.arriving.city = txtOutboundArriving.Text;
            iti.@return.departure.city = txtReturnDeparture.Text;
            iti.@return.arriving.city = txtReturnArriving.Text;
                                 
            //creating a string from the xml file
            string xmlFile = MapPath(@"~/itineraries.xml");

            // serializing (converting from object to xml) the file:
            using (FileStream xs = new FileStream(xmlFile, FileMode.Create))
            {
                XmlSerializer serializor = new XmlSerializer(typeof(itineraries));
                serializor.Serialize(xs, itneraryList);
            }

            //showing the confirmation message saying that the file has been saved
            lblConfirmation.Visible = true;
            lblConfirmation.Text = "Revised Itinerary has been saved to: <br/>" + xmlFile;
        }                      
    }
}