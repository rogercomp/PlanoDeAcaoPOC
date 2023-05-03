using PlanoDeAcao.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlanoDeAcao.Models
{
    public class Visita
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DataVisita { get; set; }
        public VisitaStatus Status { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        public ICollection<Parecer> Parecer { get; set; } = new List<Parecer>();

        public Visita() { }

        public Visita(int id, DateTime dataVisita, VisitaStatus status, Cliente cliente)
        {
            Id = id;
            DataVisita = dataVisita;
            Status = status;
            Cliente = cliente;
        }
    }
}
