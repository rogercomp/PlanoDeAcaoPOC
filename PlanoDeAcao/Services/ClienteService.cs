using PlanoDeAcao.Data;
using PlanoDeAcao.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlanoDeAcao.Services
{
    public class ClienteService
    {
        private readonly PlanoDeAcaoContext _context;
        private object Nome;

        public ClienteService(PlanoDeAcaoContext context)
        { 
            _context = context;
        }

        public List<Cliente> FindAll()
        {
            return _context.Cliente.ToList();  
            
        }


    }
}
