using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartDrivingMVC.Models;
using SmartDrivingMVCDAL.Data;

namespace SmartDrivingMVC.Controllers
{
    public class PostalDistrictController : Controller
    {
        private readonly SmartDrivingContext _context;

        public PostalDistrictController(SmartDrivingContext context)
        {
            _context = context;
        }

        // GET: PostalDistricts
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostalDistrict.ToListAsync());
        }

        // GET: PostalDistricts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postalDistrict = await _context.PostalDistrict
                .FirstOrDefaultAsync(m => m.PostalDistrictId == id);
            if (postalDistrict == null)
            {
                return NotFound();
            }

            return View(postalDistrict);
        }

        // GET: PostalDistricts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostalDistricts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostalDistrictId,City,Zipcode")] PostalDistrict postalDistrict)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postalDistrict);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postalDistrict);
        }

        // GET: PostalDistricts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postalDistrict = await _context.PostalDistrict.FindAsync(id);
            if (postalDistrict == null)
            {
                return NotFound();
            }
            return View(postalDistrict);
        }

        // POST: PostalDistricts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostalDistrictId,City,Zipcode")] PostalDistrict postalDistrict)
        {
            if (id != postalDistrict.PostalDistrictId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postalDistrict);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostalDistrictExists(postalDistrict.PostalDistrictId))
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
            return View(postalDistrict);
        }

        // GET: PostalDistricts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postalDistrict = await _context.PostalDistrict
                .FirstOrDefaultAsync(m => m.PostalDistrictId == id);
            if (postalDistrict == null)
            {
                return NotFound();
            }

            return View(postalDistrict);
        }

        // POST: PostalDistricts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postalDistrict = await _context.PostalDistrict.FindAsync(id);
            _context.PostalDistrict.Remove(postalDistrict);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostalDistrictExists(int id)
        {
            return _context.PostalDistrict.Any(e => e.PostalDistrictId == id);
        }
    }
}
