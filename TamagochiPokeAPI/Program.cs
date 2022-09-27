﻿using TamagochiPokeAPI;
using TamagochiPokeAPI.Models;

List<Pokemon> PokemonAdotados;
TamagochiView Mensagens;
PokemonAdotados = new List<Pokemon>();
Mensagens = new TamagochiView();


string opcaoJogador;
int jogar = 1;
while (jogar == 1)
{
    Mensagens.MenuInicial();
    opcaoJogador = Console.ReadLine();
    Console.Clear();

    switch (opcaoJogador)
    {
        case "1":
            string opcaoSubMenu = "1", especies;
            Pokemon pokemon = new();
            Mensagens.Titulo();
            especies = Mensagens.MenuAdocao();

            while (opcaoJogador != "3")
            {
                Console.WriteLine($"Digite 1 para: Saber mais sobre {especies.ToUpper()}");
                Console.WriteLine($"Digite 2 para: Adotar {especies.ToUpper()}");
                Console.WriteLine($"Digite 3 para: Voltar");
                Console.WriteLine();
                opcaoSubMenu = Console.ReadLine();

                switch (opcaoSubMenu)
                {
                    case "1":
                        pokemon = PokemonService.BuscarPorEspecie(especies);
                        Console.WriteLine("Nome do Pokemon: " + pokemon.name.ToUpper());
                        Console.WriteLine("Altura: " + (pokemon.height)/10 +"m");
                        Console.WriteLine("Peso: " + (pokemon.weight)/10 +"kg");
                        Console.WriteLine("Habilidades: ");
                        foreach (Abilities habilidades in pokemon.abilities)
                        {
                            Console.WriteLine(habilidades.ability.name.ToUpper() + " ");
                        }
                        Console.WriteLine();
                        break;

                    case "2":
                        pokemon = PokemonService.BuscarPorEspecie(especies);
                        PokemonAdotados.Add(pokemon);
                        Console.WriteLine($"O Pokemon foi adotado com sucesso. Sons podem ser ouvidos vindo do ovo");
                        Console.WriteLine("O ovo está chocando!");
                        Console.WriteLine();

                        opcaoJogador = "3";
                        break;

                    case "3":
                        opcaoJogador = "3";
                        break;

                    default:
                        Console.WriteLine("Opção inválida, utilize uma das opções informadas.");
                        break;
                }
            }
            break;
        case "3":
            jogar = 0;
            break;
        default:
            Console.WriteLine("Opção inválida, utilize uma das opções informadas.");
            break;
    }
}