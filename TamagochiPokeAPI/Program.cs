using TamagochiPokeAPI;
using TamagochiPokeAPI.Models;

Console.WriteLine();
var nome = Console.ReadLine();
Pokemon pokemon = new();
pokemon = PokemonService.BuscarPorEspecie(nome);
Console.WriteLine(pokemon) ;