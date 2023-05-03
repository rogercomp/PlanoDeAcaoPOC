using System.Reflection.Metadata;

namespace PlanoDeAcao.Models
{
    public class ParecerFotos
    {
        public int Id { get; set; }

        public int IdParecer { get; set; }
        public Parecer Parecer { get; set; }
        public byte[] Imagem { get; set; }

        public ParecerFotos()
        {
        }

        public ParecerFotos(int id, int idParecer, Parecer parecer, byte[] imagem)
        {
            Id = id;
            IdParecer = idParecer;
            Parecer = parecer;
            Imagem = imagem;
        }
    }
}
