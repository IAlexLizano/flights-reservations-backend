using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using UTA.FISEI.FlightsReservations.Contract;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Facade;

namespace UTA.FISEI.FlightsReservations.Implementation
{
    public class AuthService : IAuthService
    {
        public string login(LoginRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.email) || string.IsNullOrWhiteSpace(request.password))
            {
                throw new ArgumentException("Username and Password are required.");
            }
            using (var obj = new AuthFacade())
            {
                try
                {
                    return obj.login(request.email, request.password);
                }
                catch (UnauthorizedAccessException ex)
                {
                    throw new WebFaultException<string>("Invalid credentials", System.Net.HttpStatusCode.Unauthorized);
                }
                catch (Exception ex)
                {
                    throw new FaultException(ex.ToString());
                }
            }
        }
    }
}
