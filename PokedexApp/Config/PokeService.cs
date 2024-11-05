using System;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using PokedexApp.Models;

namespace PokedexApp.Config
{
    public class PokeService
    {
        private const string URL = "https://pokeapi.co/api/v2/";
        public async Pokemon PokeRequest() 
        {
            try
            {
                // Initialize HttpClient
                using (HttpClient client = new HttpClient())
                {
                    // Send a GET request
                    HttpResponseMessage response = await client.GetAsync(URL);
                    response.EnsureSuccessStatusCode(); // Throw if the status code is not 2xx.

                    // Read the response content as a string
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON into a C# object
                    var result = JsonSerializer.Deserialize<Pokemon>(jsonResponse);

                    // Print out the result (or use it in your program)
                    return result;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
            catch (JsonException e)
            {
                Console.WriteLine($"JSON parsing error: {e.Message}");
            }
        }
    }
}
