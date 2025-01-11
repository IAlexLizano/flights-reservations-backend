using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using UTA.FISEI.FlightsReservations.Domain;

namespace UTA.FISEI.FlightsReservations.Contract
{
    [ServiceContract]
    public interface IAirportService
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/airports/{id}", BodyStyle = WebMessageBodyStyle.Bare)]
        Airport GetAirportById(string id);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/airports", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Airport> GetAirports();
    }
}
