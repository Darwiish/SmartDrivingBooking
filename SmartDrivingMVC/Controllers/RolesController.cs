//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using SmartDrivingMVC.Models;
//using SmartDrivingMVCDAL.Data;

//namespace SmartDrivingMVC.Controllers
//{
//    public class RolesController : Controller
//    {
//        private readonly SmartDrivingContext dataContext;

//        public RolesController(SmartDrivingContext context)
//        {
//            dataContext = context;
//        }

//        GET: Roles
//        public async Task<IActionResult> Index()
//        {
//            return View(await dataContext.Role.ToListAsync());
//        }

//        GET: Roles/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var role = await dataContext.Role
//                .FirstOrDefaultAsync(m => m.RoleId == id);
//            if (role == null)
//            {
//                return NotFound();
//            }

//            return View(role);
//        }

//        GET: Roles/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        POST: Roles/Create
//        To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//         more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("RoleId,RoleName")] Role role)
//        {
//            if (ModelState.IsValid)
//            {
//                dataContext.Add(role);
//                await dataContext.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(role);
//        }

//        GET: Roles/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var role = await dataContext.Role.FindAsync(id);
//            if (role == null)
//            {
//                return NotFound();
//            }
//            return View(role);
//        }

//        POST: Roles/Edit/5
//         To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//         more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("RoleId,RoleName")] Role role)
//        {
//            if (id != role.RoleId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    dataContext.Update(role);
//                    await dataContext.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!RoleExists(role.RoleId))
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
//            return View(role);
//        }

//        GET: Roles/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var role = await dataContext.Role
//                .FirstOrDefaultAsync(m => m.RoleId == id);
//            if (role == null)
//            {
//                return NotFound();
//            }

//            return View(role);
//        }

//        POST: Roles/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var role = await dataContext.Role.FindAsync(id);
//            dataContext.Role.Remove(role);
//            await dataContext.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool RoleExists(int id)
//        {
//            return dataContext.Role.Any(e => e.RoleId == id);
//        }
//    }
//}
