using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Core.Domain;
using RoomBookingApp.Core.Enum;
using RoomBookingApp.Core.Models;

namespace RoomBookingApp.Core.Processors
{
    public class RoomBookingRequestProcessor
    {
        private readonly IRoomBookingService _roomBookingService;

        public RoomBookingRequestProcessor(IRoomBookingService roomBookingService)
        {
            this._roomBookingService = roomBookingService;
        }

        public RoomBookingResult BookRoom(RoomBookingRequest bookingRequest)
        {
            if(bookingRequest == null)
            {
                throw new ArgumentNullException(nameof(bookingRequest));
            }
      
            var availableRooms = _roomBookingService.GetAvalaibleRooms(bookingRequest.Date);
            var result = CreateRoomBookingObject<RoomBookingResult>(bookingRequest);
            if (availableRooms.Any())
            {
                //_roomBookingService.Save(CreateRoomBookingObject<RoomBooking>(bookingRequest));

                var room = availableRooms.First();
                var roomBooking = CreateRoomBookingObject<RoomBooking>(bookingRequest);
                roomBooking.RoomId = room.Id;
                _roomBookingService.Save(roomBooking);

                result.RoomBookingId = roomBooking.Id;
                result.Flag = BookingResultFlag.Success;
            }
            else
            {
                result.Flag = BookingResultFlag.Failure;
            }
            //_roomBookingService.Save(new RoomBooking
            //{
            //    FullName = bookingRequest.FullName,
            //    Date = bookingRequest.Date,
            //    Email = bookingRequest.Email,
            //});
            //return new RoomBookingResult
            //{
            //    FullName = bookingRequest.FullName,
            //    Date = bookingRequest.Date,
            //    Email = bookingRequest.Email,
            //};
            return result;
            //return CreateRoomBookingObject<RoomBookingResult>(bookingRequest);
        }

        private static TRoomBooking CreateRoomBookingObject<TRoomBooking>(RoomBookingRequest bookingRequest) 
            where TRoomBooking
         : RoomBookingBase, new()
        {
            return new TRoomBooking
            {
                FullName = bookingRequest.FullName,
                Date = bookingRequest.Date,
                Email = bookingRequest.Email,
            };
        }
    }
}