using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class Tour
    {
        public string Name { get; set; }
        public DateTime DateOfTour { get; set; }
        public int NumberOfSeats { get; set; }

        public Tour(string name, DateTime dateOfTour, int numberOfSeats)
        {
            this.Name = name;
            this.DateOfTour = dateOfTour;
            this.NumberOfSeats = numberOfSeats;
        }

    }
}
