using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AlgonquinCollege.OnlineService.RestaurantReview
{
    [ServiceContract]
    public interface IRestaurantService
    {
        [OperationContract]
        List<string> GetRestaurantNames();
        //string GetData(int value);

        [OperationContract]
        RestaurantInfo GetRestaurantByName(string name);

        [OperationContract]
        List<RestaurantInfo> GetRestaurantsByRating(int rating);

        [OperationContract]
        bool SaveRestaurant(RestaurantInfo restInfo);

    }
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
