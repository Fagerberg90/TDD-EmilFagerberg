using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyEx4;

namespace TravelAgencyEx4
{
    public class BookingSystem
    {

        private List<Booking> bookingList { get; set; } = new List<Booking>();

        private ITourSchedule TourSchedule;


        public BookingSystem(ITourSchedule tourSchedule)
        {
            TourSchedule = tourSchedule;
        }


        public void CreateBooking(string name, DateTime dateOfTour, int numberOfSeats, Passenger stubPassenger)
        {
            var tour = TourSchedule.ToursList.FirstOrDefault(x => x.Name == name);
            if (tour == null)
            {
                throw new TourDoesentExistOnBookedPersoException();
            }

            if (tour.NumberOfSeats < numberOfSeats)
            {
                throw new NoSeatsLeftOnBookingTourException();
            }


            var booking = new Booking();

            booking.dateOfTour = dateOfTour;
            booking.passengers = stubPassenger;
            booking.tourName = name;
            booking.NumberOfSeats = numberOfSeats;
            bookingList.Add(booking);


        }

        public List<Booking> GetBookingsFor(Passenger stubPassenger)
        {

            return bookingList.Where(x => x.passengers.Fname == stubPassenger.Fname &&
                                          x.passengers.Lname == stubPassenger.Lname).ToList();

        }



    }
}
