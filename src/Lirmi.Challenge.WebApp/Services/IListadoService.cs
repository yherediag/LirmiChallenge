using Lirmi.Challenge.Models.Dtos;

namespace Lirmi.Challenge.WebApp.Services
{
    public interface IListadoService
    {
        Task<IEnumerable<ColegioDto>> GetColegios();
    }
}
