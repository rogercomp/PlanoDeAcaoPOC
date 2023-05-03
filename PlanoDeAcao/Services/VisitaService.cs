using PlanoDeAcao.Data;
using PlanoDeAcao.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PlanoDeAcao.Services
{
    public class VisitaService
    {
        private readonly PlanoDeAcaoContext _context;
     //   private readonly object Cliente;

        public VisitaService(PlanoDeAcaoContext context)
        {
            _context = context;
        }

        public List<Parecer> FindAll()
        {
         //   return _context.Visita.ToList();
           return _context.Parecer.Include(x => x.Visita).ToList();
         //  return _context.Parecer.Include(x => x.Visita).Include(x => x.Visita.Cliente).ToListAsync();
        }


    }
}

