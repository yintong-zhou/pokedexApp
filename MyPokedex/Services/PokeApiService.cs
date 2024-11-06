using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MyPokedex.Models;

public static class PokeApiService
{
    // Instanza statica di HttpClient condivisa tra tutti i metodi della classe
    private static readonly HttpClient HttpClient = new HttpClient
    {
        BaseAddress = new Uri("https://pokeapi.co/api/v2/")
    };

    // Metodo statico per ottenere i dettagli di un Pokémon
    public static async Task<Pokemon> GetAllPokemonAsync()
    {
        var response = await HttpClient.GetStringAsync($"pokemon/");
        return JsonSerializer.Deserialize<Pokemon>(response);
    }

    public static async Task<Pokemon> GetPokemonAsync(string nameOrId)
    {
        var response = await HttpClient.GetStringAsync($"pokemon/{nameOrId}");
        return JsonSerializer.Deserialize<Pokemon>(response);
    }

    public static async Task<Pokedex> GetAllPokedexAsync()
    {
        var response = await HttpClient.GetStringAsync($"pokedex");
        return JsonSerializer.Deserialize<Pokedex>(response);
    }

    public static async Task<Pokedex> GetPokedexAsync(string nameOrId)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            };

            var response = await HttpClient.GetStringAsync($"pokedex/{nameOrId}");
            var result = JsonSerializer.Deserialize<Pokedex>(response, options);
            return result;
        }
        catch (Exception ex) 
        {
            return null;
        }
    }
}
