using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyEx4
{
    public class Booking
    {
        public Passenger passengers { get; set; }
        public string tourName { get; set; }
        public int NumberOfSeats { get; set; }
        public DateTime dateOfTour { get; set; }

    }
}
