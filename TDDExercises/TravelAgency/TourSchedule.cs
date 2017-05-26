using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class TourSchedule
    {
        public List<Tour> ToursList = new List<Tour>();

        public void CreateTour(string name, DateTime dateOfTour, int numberOfSeats)
        {
            var result = ToursList.Count(x => x.DateOfTour.Date == dateOfTour.Date);

            if (result >= 3)
            {
                throw new TourAllocationException();
            }
            else
            {
                ToursList.Add(new Tour(name, dateOfTour, numberOfSeats));
            }
        }

        public List<Tour> GetToursFor(DateTime dateTime)
        {
            var toursDate = ToursList.Where(x => x.DateOfTour == dateTime).ToList();

            return toursDate;

        }
    }
}