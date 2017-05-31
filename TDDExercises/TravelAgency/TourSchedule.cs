using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{

    public class TourSchedule
    {
        public List<Tour> ToursList { get; set; } = new List<Tour>();
   


        public void CreateTour(string name, DateTime dateOfTour, int numberOfSeats)
        {
            var date = new DateTime(dateOfTour.Year, dateOfTour.Month, dateOfTour.Day);

            var result = ToursList.Where(x => x.DateOfTour.Date == dateOfTour).ToList();

            if (result.Count >= 2)
            {
                throw new TourAllocationException();
            }
            else
            {
                ToursList.Add(new Tour(name, dateOfTour, numberOfSeats));
            }
        }

   

        public List<Tour> GetToursFor(DateTime date)
        {
            var toursDate = ToursList.Where(x => x.DateOfTour.Date == date.Date).ToList();
            return toursDate;
        }
    }
}