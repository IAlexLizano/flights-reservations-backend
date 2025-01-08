using System;
using System.Collections.Generic;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;
using UTA.FISEI.FlightsReservations.Interfaces;
using UTA.FISEI.FlightsReservations.Repository;

namespace UTA.FISEI.FlightsReservations.Facade
{
    public class ClientFacade : IDisposable
    {
        IClient obj = new ClientRepository();
        public Client GetClientById(int id)
        {
            return obj.getClientById(id);
        }

        public IEnumerable<Client> getClients()
        {
            return obj.GetClients();
        }

        public Client CreateClient(CreateClientDto clientDto)
        {
            if (string.IsNullOrWhiteSpace(clientDto.email) || string.IsNullOrWhiteSpace(clientDto.password))
            {
                throw new ArgumentException("Email and password are required.");
            }

            return obj.createClient(clientDto);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
