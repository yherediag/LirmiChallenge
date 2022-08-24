namespace Lirmi.Challenge.API.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public IEnumerable<Asignatura> Asignaturas { get; set; }
    }
}
