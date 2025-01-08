using UTA.FISEI.FlightsReservations.Domain;

namespace UTA.FISEI.FlightsReservations.Interfaces
{
    public interface IPaymentMethod
    {
        PaymentMethod getPaymentById(int id);
    }
}
