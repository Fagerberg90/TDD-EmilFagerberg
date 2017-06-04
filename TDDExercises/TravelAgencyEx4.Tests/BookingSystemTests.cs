using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TravelAgencyEx4;

namespace TravelAgencyEx4.Tests
{
    [TestFixture]
    public class BookingSystemTests
    {
        private BookingSystem sut;
        private TourScheduleStub TourScheduleStub { get; set; }
        private Passenger PassengerStub;

        [SetUp]
        public void SetUp()
        {
            TourScheduleStub = new TourScheduleStub();
            sut = new BookingSystem(TourScheduleStub);
            PassengerStub = new Passenger()
            {
                Fname = "Emil",
                Lname = "Fagerberg"
            };
        }


        [Test]
        public void CanCreateBooking()
        {

            TourScheduleStub.ToursList = new List<Tour>();

            TourScheduleStub.ToursList.Add(new Tour
            {
                Name = "CrazyLoco",
                DateOfTour = new DateTime(2017, 06, 10),
                NumberOfSeats = 40
            });


            sut.CreateBooking("CrazyLoco", new DateTime(2017, 06, 10), 40, PassengerStub);


            List<Booking> bookingList = sut.GetBookingsFor(PassengerStub);


            var model = bookingList[0];

            Assert.AreEqual(1,bookingList.Count);
            Assert.AreEqual("CrazyLoco",model.tourName);
            Assert.AreEqual(PassengerStub,model.passengers);
            Assert.AreEqual(TourScheduleStub.ToursList[0].Name,model.tourName);
        }

        [Test]
        public void NoSeatsLeftOnBookingTourExceptionThrowException()
        {
            
            TourScheduleStub.ToursList = new List<Tour>();
            TourScheduleStub.ToursList.Add(new Tour
            {
                DateOfTour = new DateTime(2017, 06, 10),
                Name = "CrazyLoco",
                NumberOfSeats = 40
            });

            Assert.Throws<NoSeatsLeftOnBookingTourException>(() => sut.CreateBooking("CrazyLoco",
                new DateTime(2017, 06, 10), 43,PassengerStub));

        }

        [Test]
        public void TourDoesentExistOnBookedPersonExceptionThrowException()
        {
         
            TourScheduleStub.ToursList = new List<Tour>();

            Assert.Throws<TourDoesentExistOnBookedPersoException>(() => sut.CreateBooking("CrazyLoco",
                new DateTime(2017, 06, 10), 40, PassengerStub));


        }
    }
}
