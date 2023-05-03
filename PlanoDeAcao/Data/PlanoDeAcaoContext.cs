using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlanoDeAcao.Models;

namespace PlanoDeAcao.Data
{
    public class PlanoDeAcaoContext : DbContext
    {
        public PlanoDeAcaoContext (DbContextOptions<PlanoDeAcaoContext> options)
            : base(options)
        {
        }

        public DbSet<ActionPlan> ActionPlan { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Visita> Visita { get; set; }

        public DbSet<Parecer> Parecer { get; set; }

        public DbSet<ParecerFotos> ParecerFotos { get; set; }
    }
}
