using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Theatre.Web.Helpers;

namespace Theatre.Web.Models
{
    public class BookingDay : BaseEntity
    {
        #region Constructor
        public BookingDay()
        {
            BookingItems = new List<BookingItem>();
        }
        #endregion Constructor

        #region Properties
        [Index]
        public DateTime BookingDate { get; set; }

        public int BookingCount
        {
            get
            {
                return BookingItems.Sum(b => b.Quantity);
            }
        }

        public int BookingsAvailable
        {
            get
            {
                return Common.MaxBookings - BookingCount;
            }
        }

        public bool CanMakeBooking
        {
            get
            {
                return Common.MaxBookings > BookingCount;
            }
        }
        #endregion Properties

        #region NavigationItems
        public IEnumerable<BookingItem> BookingItems { get; set; }
        #endregion NavigationItems
    }
}