using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlanoDeAcao.Data;
using PlanoDeAcao.Models;
using PlanoDeAcao.Models.ViewModels;
using PlanoDeAcao.Services;

namespace PlanoDeAcao.Controllers
{
    public class ParecersController : Controller
    {
        private readonly PlanoDeAcaoContext _context;
        private readonly VisitaService _visitaService;

        public ParecersController(PlanoDeAcaoContext context, VisitaService visitaService)
        {
            _context = context;
            _visitaService = visitaService;
        }


        // GET: Parecers
        public async Task<IActionResult> Index()
        {
            List<Parecer> listParecer = await _context.Parecer.Include(x => x.Visita).Include(x => x.Visita.Cliente).ToListAsync();

            return View(listParecer);
        }

        // GET: Parecers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parecer = await _context.Parecer.Include(x => x.Visita).FirstOrDefaultAsync(m => m.Id == id);
                
            if (parecer == null)
            {
                return NotFound();
            }

            return View(parecer);


        }

        // GET: Parecers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parecers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] Parecer parecer)
        {
           
                _context.Add(parecer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

        }

        // GET: Parecers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parecer = await _context.Parecer.FindAsync(id);
            if (parecer == null)
            {
                return NotFound();
            }
            return View(parecer);
        }

        // POST: Parecers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] Parecer parecer)
        {
            if (id != parecer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parecer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParecerExists(parecer.Id))
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
            return View(parecer);
        }

        // GET: Parecers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parecer = await _context.Parecer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parecer == null)
            {
                return NotFound();
            }

            return View(parecer);
        }

        // POST: Parecers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parecer = await _context.Parecer.FindAsync(id);
            _context.Parecer.Remove(parecer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParecerExists(int id)
        {
            return _context.Parecer.Any(e => e.Id == id);
        }
    }
}
