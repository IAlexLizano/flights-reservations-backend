using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;

namespace UTA.FISEI.FlightsReservations.Contract
{
    [ServiceContract]
    public interface IAirlineService
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/airlines", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Airline> GetAirlines();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/airlines", BodyStyle = WebMessageBodyStyle.Bare)]
        string AddAirline(CreateAirlineDto airlineDto);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/airlines/{id}", BodyStyle = WebMessageBodyStyle.Bare)]
        string UpdateAirline(string id, UpdateAirlineDto airlineDto);
    }
}
