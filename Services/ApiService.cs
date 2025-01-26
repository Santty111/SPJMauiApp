using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace SPJMauiApp.Services
{
    public class ApiService
    {
        private const string BaseUrl = "https://api.api-ninjas.com/v1/cars";
    private const string ApiKey = "tSAiQUiC6mtuyp8JUqs6+g==QeABJPbALgwuleo3"; // Reemplaza con tu clave API.

    private readonly HttpClient _httpClient;

    public ApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("X-Api-Key", ApiKey);
    }

    public async Task<List<Car>> GetCarsAsync(string make, string model)
    {
        var url = $"{BaseUrl}?make={make}&model={model}";

        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var cars = await response.Content.ReadFromJsonAsync<List<Car>>();
            return cars ?? new List<Car>();
        }
        catch (HttpRequestException ex)
        {
            // Manejar errores de red o de la API.
            Console.WriteLine($"Error al obtener datos: {ex.Message}");
            return new List<Car>();
        }
    }
}

// Modelo para los datos de la API
public class Car
{
    public string Make { get; set; } // Marca del coche
    public string Model { get; set; } // Modelo del coche
    public int Year { get; set; } // Año de fabricación
    public string Class { get; set; } // Clase del coche
}
}
