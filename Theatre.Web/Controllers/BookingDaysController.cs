using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Theatre.Web.Context;
using Theatre.Web.Models;
using Theatre.Web.Repository;

namespace Theatre.Web.Controllers
{
    public class BookingDaysController : Controller
    {
        // As requested, just creating new instance and not injecting it
        IRepository<BookingDay> _Repo = new BookingRepository();

        public async Task<ActionResult> Index()
        {
            return View(await _Repo.GetAll());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingDay bookingDay = await _Repo.GetById(id ?? 0);
            if (bookingDay == null)
            {
                return HttpNotFound();
            }
            return View(bookingDay);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,BookingDate")] BookingDay bookingDay)
        {
            if (ModelState.IsValid)
            {
                await _Repo.Create(bookingDay);
                return RedirectToAction("Index");
            }

            return View(bookingDay);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingDay bookingDay = await _Repo.GetById(id ?? 0);
            if (bookingDay == null)
            {
                return HttpNotFound();
            }
            return View(bookingDay);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,BookingDate")] BookingDay bookingDay)
        {
            if (ModelState.IsValid)
            {
                await _Repo.Update(bookingDay);
                return RedirectToAction("Index");
            }
            return View(bookingDay);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingDay bookingDay = await _Repo.GetById(id ?? 0);
            if (bookingDay == null)
            {
                return HttpNotFound();
            }
            return View(bookingDay);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BookingDay bookingDay = await _Repo.GetById(id);
            await _Repo.Delete(bookingDay);
            return RedirectToAction("Index");
        }
    }
}
