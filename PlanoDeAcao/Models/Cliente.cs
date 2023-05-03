using System.Collections.Generic;

namespace PlanoDeAcao.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Visita> Visita { get; set; } = new List<Visita>();

        public Cliente() { }

        public Cliente(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
