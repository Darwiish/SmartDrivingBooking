using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartDrivingMVC.Models;
using SmartDrivingMVCDAL.Data;

namespace SmartDrivingMVC.Controllers
{
    public class EvaluationController : Controller
    {
        private readonly SmartDrivingContext dataContext;

        public EvaluationController(SmartDrivingContext context)
        {
            dataContext = context;
        }

        // GET: Evaluations
        public async Task<IActionResult> Index()
        {
            var smartDrivingContext = dataContext.Evaluation.Include(e => e.ActivityType);
            return View(await smartDrivingContext.ToListAsync());
        }

        // GET: Evaluations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await dataContext.Evaluation
                .Include(e => e.ActivityType)
                .FirstOrDefaultAsync(m => m.EvaluationId == id);
            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        // GET: Evaluations/Create
        public IActionResult Create()
        {
            ViewData["ActivityTypeId"] = new SelectList(dataContext.ActivityType, "ActivityTypeId", "Title");
            return View();
        }

        // POST: Evaluations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvaluationId,Resulte,Title,Description,ActivityTypeId")] Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                dataContext.Add(evaluation);
                await dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivityTypeId"] = new SelectList(dataContext.ActivityType, "ActivityTypeId", "Title", evaluation.ActivityTypeId);
            return View(evaluation);
        }

        // GET: Evaluations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await dataContext.Evaluation.FindAsync(id);
            if (evaluation == null)
            {
                return NotFound();
            }
            ViewData["ActivityTypeId"] = new SelectList(dataContext.ActivityType, "ActivityTypeId", "Title", evaluation.ActivityTypeId);
            return View(evaluation);
        }

        // POST: Evaluations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EvaluationId,Resulte,Title,Description,ActivityTypeId")] Evaluation evaluation)
        {
            if (id != evaluation.EvaluationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dataContext.Update(evaluation);
                    await dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluationExists(evaluation.EvaluationId))
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
            ViewData["ActivityTypeId"] = new SelectList(dataContext.ActivityType, "ActivityTypeId", "Title", evaluation.ActivityTypeId);
            return View(evaluation);
        }

        // GET: Evaluations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await dataContext.Evaluation
                .Include(e => e.ActivityType)
                .FirstOrDefaultAsync(m => m.EvaluationId == id);
            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        // POST: Evaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluation = await dataContext.Evaluation.FindAsync(id);
            dataContext.Evaluation.Remove(evaluation);
            await dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluationExists(int id)
        {
            return dataContext.Evaluation.Any(e => e.EvaluationId == id);
        }
    }
}
