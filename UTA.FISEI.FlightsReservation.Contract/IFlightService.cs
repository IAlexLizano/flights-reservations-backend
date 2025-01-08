using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;

namespace UTA.FISEI.FlightsReservations.Contract
{
    [ServiceContract]
    public interface IFlightService
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/flights/{id}", BodyStyle = WebMessageBodyStyle.Bare)]
        Flight GetFlightById(string id);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/flights", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Flight> GetAllFlights();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/flights", BodyStyle = WebMessageBodyStyle.Bare)]
        string CreateFlight(CreateFlightDto flightDto);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/flights/{id}", BodyStyle = WebMessageBodyStyle.Bare)]
        string UpdateFlight(string id, UpdateFlightDto flightDto);
    }
}
