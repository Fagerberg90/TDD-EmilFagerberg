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
            sut.CreateTour("Monkey Safari", new DateTime(2017, 09, 08), 40);
            sut.CreateTour("Elephant Safari", new DateTime(2017, 07, 01), 40);
            sut.CreateTour("Tiger Safari", new DateTime(2017, 06, 05), 40);
            sut.CreateTour("Giraffe Safari", new DateTime(2017, 12, 20), 40);

            var result = sut.GetToursFor(new DateTime(2017, 12, 20));

            Assert.AreEqual(new DateTime(2017, 12, 20), result[0].DateOfTour.Date);
            Assert.AreEqual(1, result.Count);

        }


        public void ToursAreScheduledByDateOnly()
        {


        }




    }
}