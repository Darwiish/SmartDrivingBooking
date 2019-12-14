using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartDrivingMVC.Models;
using SmartDrivingMVCDAL.Data;

namespace SmartDrivingMVC.Controllers
{
    [Authorize]
    public class BookingLogController : Controller
    {
        private readonly SmartDrivingContext dataContext;
        private readonly UserManager<IdentityUser> _userManager;

        public BookingLogController(SmartDrivingContext context, UserManager<IdentityUser> userManager)
        {
            dataContext = context;
            _userManager = userManager;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            //Get currently logged in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var context = dataContext.BookingLog.Include(b => b.Customer).Include(b => b.Staff).Include(b => b.ActivityType).ThenInclude(b => b.Vehicle);
            List<BookingLog> availableBookingLogs = await context.Where(b => b.CustomerId == null).ToListAsync();
            List<BookingLog> bookingLogs = new List<BookingLog>();

            //Check if its an Admin account
            bool isAdmin = await _userManager.IsInRoleAsync(user, "admin");
            if (isAdmin)
            {
                //Admin get all bookings
                bookingLogs = await context.ToListAsync();
            }
            else
            {
                //Filter only this customer bookings
                int? customerID = GetCustomer(user.Id);
                if (customerID.HasValue)
                {
                    bookingLogs = await context.Where(b => b.CustomerId == customerID).ToListAsync();
                }
                else
                {
                    //throw some error
                    throw new SystemException("Something went wrong. Currently loggedin user doesnt have Customer account attached to it.");
                }
            }

            ViewBag.AvailableBookings = availableBookingLogs;

            return View(bookingLogs);
        }

        private int? GetCustomer(string userID) => dataContext.Customer.Where(c => c.AspNetUserId == userID).FirstOrDefault()?.CustomerId;

        // GET: Bookings/Selected/5
        public async Task<IActionResult> Select(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingLog = await dataContext.BookingLog
                .Include(b => b.Customer)
                .Include(b => b.Staff)
                .Include(b => b.ActivityType)
                .FirstOrDefaultAsync(m => m.BookingLogId == id);
            if (bookingLog == null)
            {
                return NotFound();
            }

            //Get currently logged in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            int? customerID = GetCustomer(user.Id);

            bookingLog.CustomerId = customerID;
            //startdate

            await dataContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingLog = await dataContext.BookingLog
                .Include(b => b.Customer)
                .Include(b => b.Staff)
                .Include(b => b.ActivityType)
                .FirstOrDefaultAsync(m => m.BookingLogId == id);
            if (bookingLog == null)
            {
                return NotFound();
            }

            return View(bookingLog);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["ActivityTypeId"] = new SelectList(dataContext.ActivityType, "ActivityTypeId", "Title");
            ViewData["CustomerId"] = new SelectList(dataContext.Customer, "CustomerId", "FirstName");
            ViewData["StaffId"] = new SelectList(dataContext.Staff, "StaffId", "FirstName");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingLogId,CreatedBy,CreatedDate,LastModifiedDate,LastModifiedBy,StaffId,CustomerId,ActivityTypeId")] BookingLog bookingLog)
        {
            if (ModelState.IsValid)
            {
                dataContext.Add(bookingLog);
                await dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivityTypeId"] = new SelectList(dataContext.ActivityType, "ActivityTypeId", "Title", bookingLog.ActivityTypeId);
            ViewData["CustomerId"] = new SelectList(dataContext.Customer, "CustomerId", "FirstName", bookingLog.CustomerId);
            ViewData["StaffId"] = new SelectList(dataContext.Staff, "StaffId", "FirstName", bookingLog.StaffId);
            return View(bookingLog);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingLog = await dataContext.BookingLog.FindAsync(id);
            if (bookingLog == null)
            {
                return NotFound();
            }
            ViewData["ActivityTypeId"] = new SelectList(dataContext.ActivityType, "ActivityTypeId", "Title", bookingLog.ActivityTypeId);
            ViewData["CustomerId"] = new SelectList(dataContext.Customer, "CustomerId", "FirstName", bookingLog.CustomerId);
            ViewData["StaffId"] = new SelectList(dataContext.Staff, "StaffId", "FirstName", bookingLog.StaffId);
            return View(bookingLog);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingLogId,CreatedBy,CreatedDate,LastModifiedDate,LastModifiedBy,StaffId,CustomerId,ActivityTypeId")] BookingLog bookingLog)
        {
            if (id != bookingLog.BookingLogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dataContext.Update(bookingLog);
                    await dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingLogExists(bookingLog.BookingLogId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivityTypeId"] = new SelectList(dataContext.ActivityType, "ActivityTypeId", "Title,Price,StartDate,EndDate,Vehicle", bookingLog.ActivityTypeId);
            ViewData["CustomerId"] = new SelectList(dataContext.Customer, "CustomerId", "FirstName", bookingLog.CustomerId);
            ViewData["StaffId"] = new SelectList(dataContext.Staff, "StaffId", "FirstName", bookingLog.StaffId);
            return View(bookingLog);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingLog = await dataContext.BookingLog
                .Include(b => b.Customer)
                .Include(b => b.Staff)
                .FirstOrDefaultAsync(m => m.BookingLogId == id);
            if (bookingLog == null)
            {
                return NotFound();
            }

            return View(bookingLog);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingLog = await dataContext.BookingLog.FindAsync(id);
            dataContext.BookingLog.Remove(bookingLog);
            await dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingLogExists(int id)
        {
            return dataContext.BookingLog.Any(e => e.BookingLogId == id);
        }

        [HttpGet]
        public async Task<IActionResult> UnAssign(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingLog = await dataContext.BookingLog
                .Include(b => b.Customer)
                .Include(b => b.Staff)
                .FirstOrDefaultAsync(m => m.BookingLogId == id);
            if (bookingLog == null)
            {
                return NotFound();
            }

            //Get currently logged in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            int? customerID = GetCustomer(user.Id);
            if (customerID.HasValue)
            {
                var customer = dataContext.Customer.FindAsync(customerID).Result;
                customer.BookingLogs.Remove(bookingLog);
                await dataContext.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
        }

    }
}
