using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TamagochiPokeAPI.Exceptions;
using TamagochiPokeAPI.Models;

namespace TamagochiPokeAPI.Service
{
    public static class PokemonService
    {
        public static Pokemon BuscarPorEspecie(string especie)
        {
            Random random = new Random();
            try
            {
                var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{especie.ToLower()}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonSerializer.Deserialize<Pokemon>(response.Content);
            }
            catch
            {
                var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{random.Next(1, 905)}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonSerializer.Deserialize<Pokemon>(response.Content);
            }


        }
    }
}
