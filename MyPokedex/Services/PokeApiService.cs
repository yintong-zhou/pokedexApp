﻿using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MyPokedex.Models;

public static class PokeApiService
{
    private static readonly HttpClient HttpClient = new HttpClient
    {
        BaseAddress = new Uri("https://pokeapi.co/api/v2/")
    };

    private static JsonSerializerOptions options = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true
    };

    // Metodo statico per ottenere i dettagli di un Pokémon
    public static async Task<Pokemon> GetAllPokemonAsync()
    {
        try
        {
            var response = await HttpClient.GetStringAsync($"pokemon/");
            return JsonSerializer.Deserialize<Pokemon>(response);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static async Task<Pokemon> GetPokemonAsync(string nameOrId)
    {
        try
        {
            var response = await HttpClient.GetStringAsync($"pokemon/{nameOrId}");
            return JsonSerializer.Deserialize<Pokemon>(response);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static async Task<Pokedex> GetAllPokedexAsync()
    {
        try
        {
            var response = await HttpClient.GetStringAsync($"pokedex");
            return JsonSerializer.Deserialize<Pokedex>(response);
        }
        catch (Exception ex) 
        {
            return null;
        }
    }

    public static async Task<Pokedex> GetPokedexAsync(string nameOrId)
    {
        try
        {
            var response = await HttpClient.GetStringAsync($"pokedex/{nameOrId}");
            Pokedex pokedexData = JsonSerializer.Deserialize<Pokedex>(response);

            //var tasks = pokedexData.pokemon_entries.Select(async pokemon =>
            //{
            //    var pokeResponse = await GetPokemonAsync(pokemon.pokemon_species.name);
            //    pokemon.imgurl = pokeResponse.sprites.front_default;
            //});
            //await Task.WhenAll(tasks);
            return pokedexData;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
