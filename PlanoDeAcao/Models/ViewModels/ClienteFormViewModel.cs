using System.Collections.Generic;

namespace PlanoDeAcao.Models.ViewModels
{
    public class ClienteFormViewModel
    {
        public Visita Visita { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    
    
    }
}
