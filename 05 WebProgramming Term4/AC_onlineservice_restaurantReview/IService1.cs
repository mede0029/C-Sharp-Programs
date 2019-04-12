using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AlgonquinCollege.onlineservice.restaurantReview
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    // Services offered by a WCF (methods) are declared in this INTERFACE CLASS
    
    // Services: get restaurants by name, by rate and save info
    [ServiceContract]
    public interface IRestaurantService
    {
        [OperationContract]
        List<string> GetRestaurantNames();

        [OperationContract]
        RestaurantInfo GetRestaurantByName(string name);

        [OperationContract]
        List<RestaurantInfo> GetRestaurantsByRating(int rating);

        [OperationContract]
        bool SaveRestaurant(RestaurantInfo restInfo);               
    }

    //declaring the variables for reataurant info:
    [DataContract]
    public class RestaurantInfo
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Summary { get; set; }
        [DataMember]
        public string Rating { get; set; }
        [DataMember]
        public Address Location { get; set; }
    }

    //declaring the variables for reataurant address:
    [DataContract]
    public class Address
    {
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Province { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
    }
}
