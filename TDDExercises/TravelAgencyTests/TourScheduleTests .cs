using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency;

namespace TravelAgencyTests
{
    [TestFixture]

    public class TourScheduleTests
    {
        private TourSchedule sut;

        [SetUp]
        public void Setup()
        {
            sut = new TourSchedule();
        }

        [Test]

        public void CanCreateNewTour()
        {
            sut.CreateTour("Fagerbergs Tour", new DateTime(2017, 02, 15), 40);
            var result = sut.GetToursFor(new DateTime(2017, 02, 15));


            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Fagerbergs Tour", result[0].Name);
            Assert.AreEqual(40, result[0].NumberOfSeats);

        }

        [Test]
        public void GetToursForGivenDayOnly()
        {
        
            
        }


        public void ToursAreScheduledByDateOnly()
        {
            
        }




    }
}