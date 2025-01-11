using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;

namespace UTA.FISEI.FlightsReservations.Contract
{
    [ServiceContract]
    public interface IClientService
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/clients/{id}", BodyStyle = WebMessageBodyStyle.Bare)]
        Client getClientById(string id);
        
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/clients", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Client> getClients();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/clients", BodyStyle = WebMessageBodyStyle.Bare)]
        Client createClient(CreateClientDto clientDto);
    }
}
