//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using SmartDrivingMVC.Models;
//using SmartDrivingMVCDAL.Data;

//namespace SmartDrivingMVC.Controllers
//{
//    public class ActivityController : Controller
//    {
//        private readonly SmartDrivingContext dataContext;

//        public ActivityController(SmartDrivingContext context)
//        {
//            dataContext = context;
//        }

//        // GET: Activity
//        public async Task<IActionResult> Index()
//        {
//            var smartDrivingContext = dataContext.Activity.Include(a => a.ActivityType).Include(a => a.BookingLog).Include(a => a.Vehicle);
//            return View(await smartDrivingContext.ToListAsync());
//        }

//        // GET: Activity/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var activity = await dataContext.Activity
//                .Include(a => a.ActivityType)
//                .Include(a => a.BookingLog)
//                .Include(a => a.Vehicle)
//                .FirstOrDefaultAsync(m => m.ActivityId == id);
//            if (activity == null)
//            {
//                return NotFound();
//            }

//            return View(activity);
//        }

//        // GET: Activity/Create
//        public IActionResult Create()
//        {
//            ViewData["ActivityTypeId"] = new SelectList(dataContext.ActivityType, "ActivityTypeId", "ActivityTypeId");
//            ViewData["BookingLogId"] = new SelectList(dataContext.BookingLog, "BookingLogId", "BookingLogId");
//            ViewData["VehicleId"] = new SelectList(dataContext.Vehicle, "VehicleId", "VehicleId");
//            return View();
//        }

//        // POST: Activity/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ActivityId,Price,StartDate,EndDate,ActivityTypeId,BookingLogId,VehicleId")] Activity activity)
//        {
//            if (ModelState.IsValid)
//            {
//                dataContext.Add(activity);
//                await dataContext.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["ActivityTypeId"] = new SelectList(dataContext.ActivityType, "ActivityTypeId", "ActivityTypeId", activity.ActivityTypeId);
//            ViewData["BookingLogId"] = new SelectList(dataContext.BookingLog, "BookingLogId", "BookingLogId", activity.BookingLogId);
//            ViewData["VehicleId"] = new SelectList(dataContext.Vehicle, "VehicleId", "VehicleId", activity.VehicleId);
//            return View(activity);
//        }

//        // GET: Activity/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var activity = await dataContext.Activity.FindAsync(id);
//            if (activity == null)
//            {
//                return NotFound();
//            }
//            ViewData["ActivityTypeId"] = new SelectList(dataContext.ActivityType, "ActivityTypeId", "ActivityTypeId", activity.ActivityTypeId);
//            ViewData["BookingLogId"] = new SelectList(dataContext.BookingLog, "BookingLogId", "BookingLogId", activity.BookingLogId);
//            ViewData["VehicleId"] = new SelectList(dataContext.Vehicle, "VehicleId", "VehicleId", activity.VehicleId);
//            return View(activity);
//        }

//        // POST: Activity/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ActivityId,Price,StartDate,EndDate,ActivityTypeId,BookingLogId,VehicleId")] Activity activity)
//        {
//            if (id != activity.ActivityId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    dataContext.Update(activity);
//                    await dataContext.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ActivityExists(activity.ActivityId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["ActivityTypeId"] = new SelectList(dataContext.ActivityType, "ActivityTypeId", "ActivityTypeId", activity.ActivityTypeId);
//            ViewData["BookingLogId"] = new SelectList(dataContext.BookingLog, "BookingLogId", "BookingLogId", activity.BookingLogId);
//            ViewData["VehicleId"] = new SelectList(dataContext.Vehicle, "VehicleId", "VehicleId", activity.VehicleId);
//            return View(activity);
//        }

//        // GET: Activity/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var activity = await dataContext.Activity
//                .Include(a => a.ActivityType)
//                .Include(a => a.BookingLog)
//                .Include(a => a.Vehicle)
//                .FirstOrDefaultAsync(m => m.ActivityId == id);
//            if (activity == null)
//            {
//                return NotFound();
//            }

//            return View(activity);
//        }

//        // POST: Activity/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var activity = await dataContext.Activity.FindAsync(id);
//            dataContext.Activity.Remove(activity);
//            await dataContext.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ActivityExists(int id)
//        {
//            return dataContext.Activity.Any(e => e.ActivityId == id);
//        }
//    }
//}
