using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyEx4;

namespace TravelAgencyEx4.Tests
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
            sut.CreateTour("Fagerbergs Tour", new DateTime(2016, 9, 8), 40);
            List<Tour> result = sut.GetToursFor(new DateTime(2016, 9, 8));


            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Fagerbergs Tour", result[0].Name);
            Assert.AreEqual(40, result[0].NumberOfSeats);

        }


        [Test]
        public void ToursAreScheduledByDateOnly()
        {
            sut.CreateTour("Fagerbergs Tour", new DateTime(2016, 9, 8, 10, 15, 2), 40);

            var result = sut.GetToursFor(new DateTime(
                2016, 9, 8));

            Assert.AreEqual(1, result.Count);

      }



        [Test]
        public void GetToursForGivenDayOnly()
        {
            sut.CreateTour("Monkey Safari", new DateTime(2017, 9, 8), 40);
            sut.CreateTour("Elephant Safari", new DateTime(2017, 9, 8), 40);
            sut.CreateTour("Tiger Safari", new DateTime(2017, 6, 5), 40);
            sut.CreateTour("Giraffe Safari", new DateTime(2017, 12, 20), 40);

            var result = sut.GetToursFor(new DateTime(2017, 9, 8));

          
            Assert.AreEqual(2, result.Count);

        }


        [Test]
        public void ThrowExceptionOverBooking()
        {
            sut.CreateTour("Monkey Safari", new DateTime(2017, 9, 8), 40);
            sut.CreateTour("Elephant Safari", new DateTime(2017, 9, 8), 40);
         

          Assert.Throws<TourAllocationException>(() =>                                            
            {
                sut.CreateTour("Elephant Safari", new DateTime(2017, 9, 8), 40);
            });

                  

        }
    }
}