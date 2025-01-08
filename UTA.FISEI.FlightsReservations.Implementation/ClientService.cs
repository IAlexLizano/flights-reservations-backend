using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTA.FISEI.FlightsReservations.Contract;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;
using UTA.FISEI.FlightsReservations.Facade;

namespace UTA.FISEI.FlightsReservations.Implementation
{
    public class ClientService : IClientService
    {
        public Client createClient(CreateClientDto clientDto)
        {
            if (string.IsNullOrWhiteSpace(clientDto.email) || string.IsNullOrWhiteSpace(clientDto.password))
            {
                throw new ArgumentException("Email and password are required.");
            }

            using (var obj = new ClientFacade())
            {
                try
                {
                    return obj.CreateClient(clientDto);
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones específico
                    throw new ApplicationException("An error occurred while creating the client.", ex);
                }
            }
        }

        public Client getClientById(string id)
        {
            if (int.TryParse(id, out int clientId))
            {
                using (var obj = new ClientFacade())
                {
                    return obj.GetClientById(clientId);
                }
            }
            else
            {
                throw new ArgumentException("Invalid ID format.");
            }
        }

        public IEnumerable<Client> getClients()
        {
            using (var obj = new ClientFacade())
            {
                return obj.getClients();
            }
        }
    }
}
