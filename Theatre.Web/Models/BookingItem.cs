using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Theatre.Web.Helpers;

namespace Theatre.Web.Models
{
    public class BookingItem : BaseEntity
    {
        #region Properties
        [Required]
        public string Name { get; set; }
        [Email]
        [Required]
        public string Email { get; set; }
        [Range(1,Common.MaxBookings)]
        public int Quantity { get; set; }
        [ForeignKey("BookingDay")]
        public int BookingDayId { get; set; }
        #endregion Properties

        #region NavigationItems
        public virtual BookingDay BookingDay { get; set; }
        #endregion NavigationItems
    }
}