using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyEx4;

namespace TravelAgencyEx4.Tests
{
    public class TourScheduleStub : ITourSchedule
    {

        public List<Tour> ToursList { get; set; }
        private List<DateTime> dateList;


        public TourScheduleStub()
        {
                
        }

        public List<Tour> GetToursFor(DateTime time)
        {

            if (dateList == null)
            {
                dateList = new List<DateTime>();

            }

            dateList.Add(time);

            return ToursList;
        }

        public void CreateTour(string name, DateTime dateOfTour, int numberOfSeats)
        {
          

        }
    }
}
