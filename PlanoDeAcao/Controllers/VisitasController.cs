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
    public class VisitasController : Controller
    {
        private readonly PlanoDeAcaoContext _context;
        private readonly ClienteService _clienteService;

        public VisitasController(PlanoDeAcaoContext context, ClienteService clienteService)
        {
            _context = context;
            _clienteService = clienteService;
        }

        // GET: Visitas
        public async Task<IActionResult> Index()
        {
            List<Visita> listVisita = await _context.Visita.Include(x=> x.Cliente).ToListAsync();
            
            return View(listVisita);
        }

        // GET: Visitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var visita = await _context.Visita.Include(x => x.Cliente).FirstOrDefaultAsync(m => m.Id == id);
            if (visita == null)
            {
                return NotFound();
            }

            return View(visita);
        }

        // GET: Visitas/Create
        public IActionResult Create()
        {
            var clientes = _clienteService.FindAll();
            var viewModel = new ClienteFormViewModel { Clientes = clientes };
            return View(viewModel);

        }

        // POST: Visitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Visita visita)
        {
            
                _context.Add(visita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Visitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visita.FindAsync(id);
            if (visita == null)
            {
                visita = _context.Visita.Include(c => c.Cliente).FirstOrDefault();
                return NotFound();
            }

            List<Cliente> clientes = _clienteService.FindAll();
            ClienteFormViewModel viewModel = new ClienteFormViewModel { Visita = visita, Clientes = clientes };
            return View(viewModel);
        }

        // POST: Visitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Visita visita)
        {
            if (id != visita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitaExists(visita.Id))
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
            return View(visita);
        }

        // GET: Visitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           
            var visita = await _context.Visita
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visita == null)
            {
                return NotFound();
            }

            return View(visita);
        }

        // POST: Visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visita = await _context.Visita.FindAsync(id);
            _context.Visita.Remove(visita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitaExists(int id)
        {
            return _context.Visita.Any(e => e.Id == id);
        }
    }
}
