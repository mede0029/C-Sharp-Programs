using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace AlgonquinCollege.onlineservice.restaurantReview
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    // Implementing operation contracts defined in the service contract
    public class RestaurantReviewService : IRestaurantService
    {        
        // Creating a list with restaurant names, using GetRestaurantsFromXML function:
        public List<string> GetRestaurantNames()
        {
            var nameList = new List<string>();
            var restaurantList = GetRestaurantsFromXml();      
            if (restaurantList != null)
            {
                foreach (var rest in restaurantList.restaurant)
                {
                    nameList.Add(rest.name);
                }
            }
            return nameList;
        }

        // Getting the information for the restaurant from the list by name
        public RestaurantInfo GetRestaurantByName(string name)
        {
            var restaurantList = GetRestaurantsFromXml();
            foreach (var rests in restaurantList.restaurant)
            {
                if (rests.name == name)
                {
                    var restInfo = new RestaurantInfo
                    {
                        Name = rests.name,
                        Rating = rests.rating.Value.ToString(),
                        Summary = rests.summary,
                        Location = new Address
                        {
                            Street = rests.address.street,
                            Province = rests.address.province,
                            City = rests.address.city,
                            PostalCode = rests.address.postalCode
                        }
                    };
                    return restInfo;
                }
            }
            //if there is nothing found, it returns an empty restinfo
            return new RestaurantInfo();
        }

        // Getting the information for the restaurant from the list by rating
        public List<RestaurantInfo> GetRestaurantsByRating(int rating)
        {
            var restaurantListXML = GetRestaurantsFromXml();
            var restaurantInfoList = new List<RestaurantInfo>();
            foreach (var rests in restaurantListXML.restaurant)
            {
                if (rests.rating.Value < rating)
                {
                    var restInfo = new RestaurantInfo
                    {
                        Name = rests.name,
                        Rating = rests.rating.Value.ToString(),
                        Summary = rests.summary,
                        Location = new Address
                        {
                            Street = rests.address.street,
                            Province = rests.address.province,
                            City = rests.address.city,
                            PostalCode = rests.address.postalCode
                        }
                    };
                    restaurantInfoList.Add(restInfo);
                }
            }
            //if there is nothing found, it returns an empty restinfo
            return restaurantInfoList;
        }

        // saving restaurant info into XML
        public bool SaveRestaurant(RestaurantInfo restInfo)
        {
            var restaurantListXML = GetRestaurantsFromXml();
            var selectedRestaurant = restaurantListXML.restaurant.Where(res => res.name == restInfo.Name).FirstOrDefault();
            if (selectedRestaurant != null)
            {
                string xmlFile = HttpContext.Current.Server.MapPath(@"App_Data/restaurant_reviews.xml");
                selectedRestaurant.summary = restInfo.Summary;
                selectedRestaurant.rating.Value = byte.Parse(restInfo.Rating);
                using (FileStream xs = new FileStream(xmlFile, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(restaurants));
                    serializer.Serialize(xs, restaurantListXML);
                }
                return true;
            }
            return false;
        }

        // Function to get the list of restaurants from XML file
        public restaurants GetRestaurantsFromXml()
        {
            restaurants restaurantList = null;
            string xmlFile = HttpContext.Current.Server.MapPath(@"App_Data/restaurant_reviews.xml");
            
            //opening the xml file and deserializing it (converting xml file into object)
            using (FileStream xs = new FileStream(xmlFile, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(restaurants));
                restaurantList = (restaurants)serializer.Deserialize(xs);
            }
            return restaurantList;
        }
    }

}
