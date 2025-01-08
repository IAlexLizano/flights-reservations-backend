using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Domain.dtos;

namespace UTA.FISEI.FlightsReservations.Interfaces
{
    public interface IClient
    {
        Client getClientById(int id); 
        IEnumerable<Client> GetClients();
        Client createClient(CreateClientDto dto);
    }
}
