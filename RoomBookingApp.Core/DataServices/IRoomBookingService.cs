
using RoomBookingApp.Domain;

namespace RoomBookingApp.Core.DataServices
{
    public interface IRoomBookingService
    {
        void SaveBooking(RoomBooking roomBooking);
        IEnumerable<Room> GetAvailableRooms(DateTime date);
    }
}
