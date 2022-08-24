using System.ComponentModel.DataAnnotations;

namespace Lirmi.Challenge.API.Models
{
    public class Colegio
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public IEnumerable<Curso> Cursos { get; set; }
    }
}
