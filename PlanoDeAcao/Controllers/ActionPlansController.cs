using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PlanoDeAcao.Data;
using PlanoDeAcao.Models;
using Google.DataTable.Net.Wrapper;

namespace PlanoDeAcao.Controllers
{
    public class ActionPlansController : Controller
    {
        private readonly PlanoDeAcaoContext _context;

        public ActionPlansController(PlanoDeAcaoContext context)
        {
            _context = context;
        }

        // GET: ActionPlans
        public async Task<IActionResult> Index()
        {
            var retorno = View(await _context.ActionPlan.Include(p => p.Parecer).Include(v => v.Parecer.Visita).Include(c => c.Parecer.Visita.Cliente).ToListAsync());
            return retorno;
        }

        // GET: ActionPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actionPlan = await _context.ActionPlan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actionPlan == null)
            {
                return NotFound();
            }

            return View(actionPlan);
        }

        // GET: ActionPlans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActionPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,What,Why,Who,Where,When,How,HowMuch")] ActionPlan actionPlan)
        {
         //   if (ModelState.IsValid)
        //    {
               _context.Add(actionPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           // }
         //   return View(actionPlan);
        }

        // GET: ActionPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actionPlan = await _context.ActionPlan.FindAsync(id);
            if (actionPlan == null)
            {
                return NotFound();
            }
            return View(actionPlan);
        }

        // POST: ActionPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,What,Why,Who,Where,When,How,HowMuch")] ActionPlan actionPlan)
        {
            if (id != actionPlan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actionPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActionPlanExists(actionPlan.Id))
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
            return View(actionPlan);
        }

        // GET: ActionPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actionPlan = await _context.ActionPlan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actionPlan == null)
            {
                return NotFound();
            }

            return View(actionPlan);
        }

        // POST: ActionPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actionPlan = await _context.ActionPlan.FindAsync(id);
            _context.ActionPlan.Remove(actionPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActionPlanExists(int id)
        {
            return _context.ActionPlan.Any(e => e.Id == id);
        }

        
        public IActionResult Grafico1()
        {
            //passing the ViewBag.JSON to the view.
            ViewBag.JSON = CarregaGrafico1();
            return View();
        }

        public IActionResult Grafico2()
        {
            //passing the ViewBag.JSON to the view.
            ViewBag.JSON = CarregaGrafico2();
            return View();
        }

        public string CarregaGrafico1()
        {
            var dt = new Google.DataTable.Net.Wrapper.DataTable();

            //Act -----------------
            dt.AddColumn(new Google.DataTable.Net.Wrapper.Column(ColumnType.String, "Tiers"));
            dt.AddColumn(new Google.DataTable.Net.Wrapper.Column(ColumnType.Number, "Apps"));

            var row1 = dt.NewRow();
            var row2 = dt.NewRow();
            var row3 = dt.NewRow();


            row1.AddCellRange(new[] { new Cell("Tier 1"), new Cell(20) });
            row2.AddCellRange(new[] { new Cell("Tier 1.5"), new Cell(13) });
            row3.AddCellRange(new[] { new Cell("Tier 2"), new Cell(34) });


            dt.AddRow(row1);
            dt.AddRow(row2);
            dt.AddRow(row3);

            return dt.GetJson();
        }

        public string CarregaGrafico2()
        {
            var dt = new Google.DataTable.Net.Wrapper.DataTable();

            //Act -----------------
            dt.AddColumn(new Google.DataTable.Net.Wrapper.Column(ColumnType.String, "Tiers"));
            dt.AddColumn(new Google.DataTable.Net.Wrapper.Column(ColumnType.Number, "Apps"));

            var row1 = dt.NewRow();
            var row2 = dt.NewRow();
            var row3 = dt.NewRow();


            row1.AddCellRange(new[] { new Cell("Tier 1"), new Cell(20) });
            row2.AddCellRange(new[] { new Cell("Tier 1.5"), new Cell(13) });
            row3.AddCellRange(new[] { new Cell("Tier 2"), new Cell(34) });


            dt.AddRow(row1);
            dt.AddRow(row2);
            dt.AddRow(row3);

            return dt.GetJson();
        }


    }
}
