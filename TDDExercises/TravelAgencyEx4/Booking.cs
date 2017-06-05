using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyEx4
{
    public class Booking
    {
        public Passenger Passengers { get; set; }
        public string TourName { get; set; }
        public int NumberOfSeats { get; set; }
        public DateTime DateOfTour { get; set; }

    }
}
