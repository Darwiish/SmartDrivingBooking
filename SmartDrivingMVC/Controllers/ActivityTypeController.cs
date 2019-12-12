using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartDrivingMVC.Models;
using SmartDrivingMVCDAL.Data;

namespace SmartDrivingMVC.Controllers
{
    public class ActivityTypeController : Controller
    {
        private readonly SmartDrivingContext dataContext;

        public ActivityTypeController(SmartDrivingContext context)
        {
            dataContext = context;
        }

        // GET: ActivityTypes
        public async Task<IActionResult> Index()
        {
            var smartDrivingContext = dataContext.ActivityType.Include(a => a.BookingLog).Include(a => a.Vehicle);
            return View(await smartDrivingContext.ToListAsync());
        }


        // GET: ActivityTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityType = await dataContext.ActivityType
                 .Include(a => a.BookingLog)
                 .Include(a => a.Vehicle)
                .FirstOrDefaultAsync(m => m.ActivityTypeId == id);
            if (activityType == null)
            {
                return NotFound();
            }

            return View(activityType);
        }

        // GET: ActivityTypes/Create
        public IActionResult Create()
        {
            ViewData["BookingLogId"] = new SelectList(dataContext.BookingLog, "BookingLogId", "BookingLogId");
            ViewData["VehicleId"] = new SelectList(dataContext.Vehicle, "VehicleId", "VehicleModel");
            return View();
        }

        // POST: ActivityTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivityTypeId,Price,Title,StartDate,EndDate,BookingLogId,VehicleId")] ActivityType activityType)
        {
            if (ModelState.IsValid)
            {
                dataContext.Add(activityType);
                await dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
         //   ViewData["BookingLogId"] = new SelectList(dataContext.BookingLog, "BookingLogId", "BookingLogId", activityType.BookingLogId);
            ViewData["VehicleId"] = new SelectList(dataContext.Vehicle, "VehicleId", "VehicleModel", activityType.VehicleId);
            return View(activityType);
        }

        // GET: Activity/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityType = await dataContext.ActivityType.FindAsync(id);
            if (activityType == null)
            {
                return NotFound();
            }
          //  ViewData["BookingLogId"] = new SelectList(dataContext.BookingLog, "BookingLogId", "BookingLogId", activityType.BookingLogId);
            ViewData["VehicleId"] = new SelectList(dataContext.Vehicle, "VehicleId", "VehicleModel", activityType.VehicleId);
            return View(activityType);
        }
        // POST: ActivityTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActivityId,Price,Title,StartDate,EndDate,BookingLogId,VehicleId")] ActivityType activityType)
        {
            if (id != activityType.ActivityTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dataContext.Update(activityType);
                    await dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityTypeExists(activityType.ActivityTypeId))
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
            //ViewData["BookingLogId"] = new SelectList(dataContext.BookingLog, "BookingLogId", "BookingLogId", activityType.BookingLogId);
            ViewData["VehicleId"] = new SelectList(dataContext.Vehicle, "VehicleId", "VehicleModel", activityType.VehicleId);
            return View(activityType);
        }


        // GET: ActivityTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityType = await dataContext.ActivityType
                .Include(a => a.BookingLog)
                .Include(a => a.Vehicle)
                .FirstOrDefaultAsync(m => m.ActivityTypeId == id);
            if (activityType == null)
            {
                return NotFound();
            }

            return View(activityType);
        }

        // POST: ActivityTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activityType = await dataContext.ActivityType.FindAsync(id);
            dataContext.ActivityType.Remove(activityType);
            await dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityTypeExists(int id)
        {
            return dataContext.ActivityType.Any(e => e.ActivityTypeId == id);
        }
    }
}
