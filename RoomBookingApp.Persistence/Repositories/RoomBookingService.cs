using RoomBookingApp.Core.DataService;
using RoomBookingApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingApp.Persistence.Repositories
{
    public class RoomBookingService : IRoomBookingService
    {
        private readonly RoomBookingAppDbContext _context;

        public RoomBookingService(RoomBookingAppDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Room> GetAvailableRooms(DateTime date)
        {         
            return this._context.Rooms.Where(r => !r.RoomBookings.Any(x=> x.Date == date))
                .ToList();
        }

        public void Save(RoomBooking roomBooking)
        {
            this._context.Add(roomBooking);
            _context.SaveChanges();
        }
    }
}
