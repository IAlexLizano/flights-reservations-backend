using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;

namespace UTA.FISEI.FlightsReservations.Contract
{
    [ServiceContract]
    public interface IReservationService
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/reservations", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<ReservationResponse> GetAllReservations();

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/reservations/{id}", BodyStyle = WebMessageBodyStyle.Bare)]
        Reservation GetReservationById(string id);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/reservations/client/{clientId}", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Reservation> GetReservationsByClient(string clientId);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/reservations", BodyStyle = WebMessageBodyStyle.Bare)]
        Reservation CreateReservation(CreateReservationDto reservationDto);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/reservations/{id}", BodyStyle = WebMessageBodyStyle.Bare)]
        Reservation UpdateReservation(string id, UpdateReservationDto reservationDto);

        [OperationContract]
        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/reservations/{id}", BodyStyle = WebMessageBodyStyle.Bare)]
        string CancelReservation(string id);
    }
}
