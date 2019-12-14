using System;
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
    public class CustomerController : Controller
    {
        private readonly SmartDrivingContext dataContext;
        private readonly IAuthorizationService authorizationService;
        private readonly UserManager<IdentityUser> _userManager;

        public CustomerController(SmartDrivingContext context, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager)
        {
            dataContext = context;
            this.authorizationService = authorizationService;
            this._userManager = userManager;
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            //Get currently logged in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            //Check if its an Admin account
            bool isAdmin = await _userManager.IsInRoleAsync(user, "admin");
            if (!isAdmin)
            {
                return NotFound();
            }

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var customers = from s in dataContext.Customer
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(s => s.FirstName.Contains(searchString)
                                       || s.LastName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(s => s.FirstName);
                    break;
                case "Date":
                    customers = customers.OrderBy(s => s.DateBirth);
                    break;
                case "date_desc":
                    customers = customers.OrderByDescending(s => s.DateBirth);
                    break;
                default:
                    customers = customers.OrderBy(s => s.FirstName);
                    break;
            }

            int pageSize = 5;
            return View(await PaginatedList<Customer>.CreateAsync(customers.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await dataContext.Customer
                .Include(a => a.PostalDistrict)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["PostalDistrictId"] = new SelectList(dataContext.PostalDistrict, "PostalDistrictId", "Zipcode");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,EmailAddress,Street,DateBirth,MobilePhone,PostalDistrictId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                dataContext.Add(customer);
                await dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostalDistrictId"] = new SelectList(dataContext.PostalDistrict, "PostalDistrictId", "Zipcode");
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await dataContext.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["PostalDistrictId"] = new SelectList(dataContext.PostalDistrict, "PostalDistrictId", "Zipcode");
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,EmailAddress,Street,DateBirth,MobilePhone,PostalDistrictId")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dataContext.Update(customer);
                    await dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            ViewData["PostalDistrictId"] = new SelectList(dataContext.PostalDistrict, "PostalDistrictId", "Zipcode");
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await dataContext.Customer
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await dataContext.Customer.FindAsync(id);
            dataContext.Customer.Remove(customer);
            await dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return dataContext.Customer.Any(e => e.CustomerId == id);
        }
    }
}
