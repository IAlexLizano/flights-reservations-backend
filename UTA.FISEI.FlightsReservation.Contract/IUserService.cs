using System.Collections.Generic;
using System.ServiceModel.Web;
using System.ServiceModel;
using UTA.FISEI.FlightsReservations.Domain;

namespace UTA.FISEI.FlightsReservations.Contract
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/users/{id}", BodyStyle = WebMessageBodyStyle.Bare)]
        User getUserById(string id);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/users", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<User> getUsers();
    }
}
