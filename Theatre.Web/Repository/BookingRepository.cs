using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Theatre.Web.Context;
using Theatre.Web.Models;

namespace Theatre.Web.Repository
{
    public class BookingRepository : IRepository<BookingDay>, IDisposable
    {
        private readonly DataContext db = new DataContext();

        #region Booking Day
        public async Task Create(BookingDay item)
        {
            db.BookingDays.Add(item);
            await db.SaveChangesAsync();
        }

        public Task Delete(BookingDay item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookingDay>> GetAll()
        {
            return await db.BookingDays.ToListAsync();
        }

        public async Task<BookingDay> GetById(int id)
        {
            return await db.BookingDays.FindAsync(id);
        }

        public async Task Update(BookingDay item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
        #endregion BookingDay

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }

        public void Dispose()
        {
            db.Dispose();                
        }
    }
}