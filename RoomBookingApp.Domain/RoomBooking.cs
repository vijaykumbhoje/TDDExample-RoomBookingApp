using RoomBookingApp.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingApp.Domain
{
    public class RoomBooking : RoomBookingBase
    {
        public Room Room { get; set; }
        public int RoomId { get; set; }
        public int Id { get; set; }
    }
}
