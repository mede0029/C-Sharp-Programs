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


public partial class _Default : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        restaurants restaurantList = null;        
        if (Session ["restaurantListSession"] == null) //in case there is no session yet
        {
            //opening the xml file
            string xmlFile = MapPath(@"~/restaurant_reviews.xml");
            using (FileStream xs = new FileStream(xmlFile, FileMode.Open))
            {
                //deserializing the file (converting it into an object)
                XmlSerializer serial = new XmlSerializer(typeof(restaurants));
                restaurantList = (restaurants)serial.Deserialize(xs);
            }
            Session["restaurantListSession"] = restaurantList;
        }
        else
        {
            restaurantList = Session["restaurantListSession"] as restaurants;
        }
                
        if (!IsPostBack) //if loading for the first time, display restaurant list using DataBinding:
        {
            restaurantDropDown.DataSource = restaurantList.restaurant;
            restaurantDropDown.DataTextField = "name";
            restaurantDropDown.DataBind();
            restaurantDropDown.Items.Insert(0, new ListItem("Select One...", "0"));                 
        }
    }

    protected void restaurantDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        //creating a list of restaurants from the data stored in the session from xml file
        restaurants restaurantList = Session["restaurantListSession"] as restaurants;

        //displaying additional fields when there's something selected from dropdown list:
        if (restaurantDropDown.SelectedValue == "0")
        {
            addressLbl.Visible = false;
            addressTxt.Visible = false;
            summaryLbl.Visible = false;
            summaryTxt.Visible = false;
            ratingLbl.Visible = false;
            ratingDropDown.Visible = false;
            saveBtn.Visible = false;
            return;
        }
        else
        {
            addressLbl.Visible = true;
            addressTxt.Visible = true;
            summaryLbl.Visible = true;
            summaryTxt.Visible = true;
            addressTxt.Enabled = false;
            ratingLbl.Visible = true;
            ratingDropDown.Visible = true;
            saveBtn.Visible = true;   
            //calling function to display info on each restaurant
            displayRestaurantInfo(restaurantList.restaurant[restaurantDropDown.SelectedIndex - 1]);
        }
    }

    public void displayRestaurantInfo (restaurantsRestaurant rest)
    {
        addressTxt.Text = rest.address.street + "\n"
                        + rest.address.city + "\n"
                        + rest.address.province + "\n"
                        + rest.address.postalCode + "\n";    
        summaryTxt.Text = rest.summary;
        ratingDropDown.SelectedValue = rest.rating.Value.ToString();
        messageLbl.Visible = false;
    }
         
    protected void saveBtn_Click(object sender, EventArgs e)
    {
        //creating a restaurants object from the session
        restaurants restaurantList = Session["restaurantListSession"] as restaurants;
        if (restaurantDropDown.SelectedValue != "0") //if there is a restaurant selected
        {
            //create a restaurant object for the selected restaurant and displayin its info
            restaurantsRestaurant rest = restaurantList.restaurant[restaurantDropDown.SelectedIndex - 1];
            rest.summary = summaryTxt.Text;
            rest.rating.Value = byte.Parse(ratingDropDown.SelectedValue);

            //creating a string from the xml file
            string xmlFile = MapPath(@"~/restaurant_reviews.xml");

            // serializing (converting from object to xml) the file:
            using (FileStream xs = new FileStream(xmlFile, FileMode.Create))
            {
                XmlSerializer serializor = new XmlSerializer(typeof(restaurants));
                serializor.Serialize(xs, restaurantList);
            }

            //text message at the bottle
            messageLbl.Visible = true;
            messageLbl.Text = "Revised retaurant review has been saved to " + xmlFile;
        }
    }
}
