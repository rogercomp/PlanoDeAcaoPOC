using System.Collections.Generic;

namespace PlanoDeAcao.Models.ViewModels
{
    public class VisitaFormViewModel
    {
        public Parecer Parecer { get; set; }
        public ICollection<Visita> Visitas { get; set; }


    }
}
