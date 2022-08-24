namespace Lirmi.Challenge.Models.Dtos
{
    public class CursoDto
    {
        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public bool MostrarDetalle { get; set; }
        public IEnumerable<AsignaturaDto> Asignaturas { get; set; }
    }
}
