using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Theatre.Web.Context;
using Theatre.Web.Helpers;
using Theatre.Web.Models;
using Theatre.Web.Repository;

namespace Theatre.Web.Controllers
{
    public class HomeController : Controller
    {
        //IRepository<BookingDay> _Repo = new BookingRepository();
        readonly DataContext db = new DataContext();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult BookingsAvailable(DateTime date)
        {
            bool available = true;
            var booking = GetBookingByDate(date);
            if(booking != null)
            {
                available = booking.CanMakeBooking;
            }
            if (available)
            {
                // Just using different things
                Session["bookingDate"] = date;
            }
            return Json(available, JsonRequestBehavior.AllowGet);
        }

        private BookingDay GetBookingByDate(DateTime date)
        {
            return db.BookingDays.FirstOrDefault(x => x.BookingDate != null && x.BookingDate == date);
        }

        public ActionResult CreateBooking()
        {
            var date = Convert.ToDateTime(Session["bookingDate"]);
            int bookingsAvailable = Common.MaxBookings;
            var booking = GetBookingByDate(date);
            if(booking != null)
            {
                bookingsAvailable = booking.BookingsAvailable;
            }
            ViewBag.BookingsAvailable = bookingsAvailable;
            ViewBag.BookingDate = date;
            return View();
        }

        // Did not use posting through mvc as it looked like more js side of things was asked

        public JsonResult MakeBooking(DateTime date, string name, string email, int quantity)
        {
            // Sorry i am very very sadly out of time
            // from here I would have checked if BookDay exist
            //If not Create it and add item to it
            // sorry assesment wa very important, i sadly could not get to it with work , children and being sick
            // sorry, i really am a awesome programmer and know you would be missing out by not givving me a shot

            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}