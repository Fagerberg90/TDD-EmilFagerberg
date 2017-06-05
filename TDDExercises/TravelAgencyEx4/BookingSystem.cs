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
     private List<Booking> BookingList { get; set; } = new List<Booking>();

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

            booking.DateOfTour = dateOfTour;
            booking.Passengers = stubPassenger;
            booking.TourName = name;
            booking.NumberOfSeats = numberOfSeats;
            BookingList.Add(booking);
       }

        public List<Booking> GetBookingsFor(Passenger stubPassenger)
        {

            return BookingList.Where(x => x.Passengers.Fname == stubPassenger.Fname &&
                                          x.Passengers.Lname == stubPassenger.Lname).ToList();

        }

    }
}
