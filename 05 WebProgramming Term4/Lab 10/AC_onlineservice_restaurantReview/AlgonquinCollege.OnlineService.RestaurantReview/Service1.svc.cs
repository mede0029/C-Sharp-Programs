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

namespace AlgonquinCollege.OnlineService.RestaurantReview
{
    public class Service1 : IRestaurantService
    {
        public List<string> GetRestaurantNames()
        {
            var names = new List<string>();

            var listOfRestaurants = GetRestaurantsFromXml();   //another method grabbing the xml code
            if (listOfRestaurants != null)
            {
                foreach (var rest in listOfRestaurants.restaurant)
                {
                    names.Add(rest.name);
                }
            }
            return names;
        }
        public RestaurantInfo GetRestaurantByName(string name)
        {
            var listOfRestaurants = GetRestaurantsFromXml();
            foreach(var rests in listOfRestaurants.restaurant)
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
                            Street = rests.location.address,
                            Province = rests.location.province,
                            City = rests.location.city,
                            PostalCode = rests.location.postal_code
                        }
                    };
                    return restInfo;
                }
            }
            //if there is nothing found, it returns a new restInfo, which is empty
            return new RestaurantInfo();
        }
        public List<RestaurantInfo> GetRestaurantsByRating(int rating)
        {
            var listOfRestaurants = GetRestaurantsFromXml();
            var restaurantInfo = new List<RestaurantInfo>();

            foreach (var rests in listOfRestaurants.restaurant)
            {
                if (rests.rating.Value >= rating)
                {
                    var restInfo = new RestaurantInfo
                    {
                        Name = rests.name,
                        Rating = rests.rating.Value.ToString(),
                        Summary = rests.summary,
                        Location = new Address
                        {
                            Street = rests.location.address,
                            Province = rests.location.province,
                            City = rests.location.city,
                            PostalCode = rests.location.postal_code
                        }
                    };
                    restaurantInfo.Add(restInfo);
                }
            }
            ////if there is nothing found, it returns a new restaurantInfo, which is empty
            return restaurantInfo;
        }
        public bool SaveRestaurant(RestaurantInfo restInfo)
        {
            var allRestaurants = GetRestaurantsFromXml();
            var restToUpdate = allRestaurants.restaurant.Where(res => res.name == restInfo.Name).FirstOrDefault();
            if (restToUpdate != null)
            {
                string xmlFile = HttpContext.Current.Server.MapPath(@"App_Data/restaurant_reviews.xml");
                restToUpdate.summary = restInfo.Summary;
                
                restToUpdate.rating.Value = byte.Parse(restInfo.Rating);
                restToUpdate.location.address = restInfo.Location.Street;
                restToUpdate.location.postal_code = restInfo.Location.PostalCode;
                restToUpdate.location.province = restInfo.Location.Province;
                restToUpdate.location.city = restInfo.Location.City;

                using (FileStream xs = new FileStream(xmlFile, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(restaurants));
                    serializer.Serialize(xs, allRestaurants);
                }
                return true;
            }
            return false;
        }
        public restaurants GetRestaurantsFromXml()  //this method makes the xml readable as an object
        {
            restaurants listOfRestaurants = null;

            string xmlFile = HttpContext.Current.Server.MapPath(@"App_Data/restaurant_reviews.xml");

            //opening the xml file and deserializing it (converting xml file into object)
            using (FileStream xs = new FileStream(xmlFile, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(restaurants));
                listOfRestaurants = (restaurants)serializer.Deserialize(xs);
            }
            return listOfRestaurants;
        }
    }
}
