using Lirmi.Challenge.API.Models;
using Lirmi.Challenge.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Lirmi.Challenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListadoController : ControllerBase
    {
        private readonly DataContext _context;

        public ListadoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetListado")]
        public async Task<IActionResult> Get()
        {
            var colegios = await _context.Colegios
                .Include(colegio => colegio.Cursos)
                .ThenInclude(curso => curso.Asignaturas).ToListAsync();

            var colegiosDto = MapearColegios(colegios);

            return Ok(colegiosDto);
        }

        private IEnumerable<ColegioDto> MapearColegios(IEnumerable<Colegio> colegios)
        {
            return colegios.Select(colegio => new ColegioDto
            { 
                IdColegio = colegio.Id,
                Nombre = colegio.Descripcion,
                MostrarDetalle = false,
                Cursos = colegio.Cursos.Select(curso => new CursoDto
                {
                    IdCurso = curso.Id,
                    Nombre = curso.Descripcion,
                    MostrarDetalle = false,
                    Asignaturas = curso.Asignaturas.Select(asignatura => new AsignaturaDto
                    {
                        IdAsignatura = asignatura.Id,
                        Nombre = asignatura.Descripcion
                    })
                })
            });
        }
    }
}
