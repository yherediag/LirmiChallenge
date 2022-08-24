using Lirmi.Challenge.Models.Dtos;
using System.Net.Http.Json;

namespace Lirmi.Challenge.WebApp.Services
{
    public class ListadoService : IListadoService
    {
        private readonly HttpClient _httpClient;

        public ListadoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ColegioDto>> GetColegios()
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Listado");

                if (!response.IsSuccessStatusCode)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    return Enumerable.Empty<ColegioDto>();

                return await response.Content.ReadFromJsonAsync<IEnumerable<ColegioDto>>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
