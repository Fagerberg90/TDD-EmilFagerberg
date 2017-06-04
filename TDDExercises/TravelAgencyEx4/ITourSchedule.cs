using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyEx4
{
    public interface ITourSchedule
    {
        List<Tour> ToursList { get; set; }
        List<Tour> GetToursFor(DateTime tourTime);
        void CreateTour(string tourName, DateTime dateTime, int numberOfSeats);


    }
}
