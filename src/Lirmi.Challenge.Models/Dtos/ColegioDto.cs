namespace Lirmi.Challenge.Models.Dtos
{
    public class ColegioDto
    {
        public int IdColegio { get; set; }
        public string Nombre { get; set; }
        public bool MostrarDetalle { get; set; }
        public IEnumerable<CursoDto> Cursos { get; set; }
    }
}
