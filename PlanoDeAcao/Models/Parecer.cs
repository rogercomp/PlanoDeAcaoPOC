using System.Collections.Generic;


namespace PlanoDeAcao.Models
{
    public class Parecer
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Visita Visita { get; set; }
        public int VisitaId { get; set; }


        public Parecer() { }

        public Parecer(int id, string descricao, Visita visitas)
        {
            Id = id;
            Descricao = descricao;
            Visita = visitas;
           
        }
    }
}
