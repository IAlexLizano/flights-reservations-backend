using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using UTA.FISEI.FlightsReservations.Domain;

namespace UTA.FISEI.FlightsReservations.Contract
{
    [ServiceContract]
    public interface ICityService
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/cities", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<City> GetCities();
    }
}
