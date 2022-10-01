using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiPokeAPI.Models;
using TamagochiPokeAPI.Service;
using TamagochiPokeAPI.View;

namespace TamagochiPokeAPI.Controller
{
    public class TamagochiController
    {
        private string NomeJogador { get; set; }
        private List<Pokemon> PokemonAdotados { get; set; }
        private TamagochiView Mensagens { get; set; }


        public TamagochiController()
        {
            this.PokemonAdotados = new List<Pokemon>();
            this.Mensagens = new TamagochiView();
        }
        public void Jogar()
        {
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
                        MenuAdocao();
                        break;
                    case "2":
                        MenuInteracao();
                        break;
                    case "3":
                        jogar = 0;
                        break;
                    default:
                        Console.WriteLine("Opção inválida, utilize uma das opções informadas.");
                        break;
                }
            }
        }

        private void MenuAdocao()
        {
            string opcaoSubMenu = "1", especies;
            Pokemon pokemon = new();
            especies = Mensagens.MenuAdocao();
            Console.Clear();
            while (opcaoSubMenu != "3")
            {
                opcaoSubMenu = Mensagens.MenuPokemon(especies);
                Console.Clear();

                switch (opcaoSubMenu)
                {
                    case "1":
                        pokemon = PokemonService.BuscarPorEspecie(especies);
                        Mensagens.MenuDetalhes(pokemon);
                        Console.WriteLine("Aperte alguma tecla para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        pokemon = PokemonService.BuscarPorEspecie(especies);
                        this.PokemonAdotados.Add(pokemon);
                        Mensagens.MensagemAdocao();
                        Console.WriteLine("Aperte alguma tecla para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                        return;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Opção inválida, utilize uma das opções informadas.");
                        break;
                }
            }
        }

        private void MenuInteracao()
        {
            string opcaoInteracao = "0";
            int indicePoke;

            indicePoke = Mensagens.ConsultarPokemons(PokemonAdotados);
            
            Console.Clear();
            while (opcaoInteracao != "4")
            {
                opcaoInteracao = Mensagens.Interagir(PokemonAdotados[indicePoke]);
                Console.Clear();
                switch (opcaoInteracao)
                {
                    case "1":
                        Mensagens.MenuDetalhesAdotado(PokemonAdotados[indicePoke]);
                        Console.WriteLine("Aperte alguma tecla para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        PokemonAdotados[indicePoke].Alimentar();
                        Mensagens.Alimentar();
                        Console.WriteLine("Aperte alguma tecla para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                        if (!PokemonAdotados[indicePoke].Saude())
                            Mensagens.GameOver(PokemonAdotados[indicePoke]);
                        
                        break;
                    case "3":
                        PokemonAdotados[indicePoke].Brincar();
                        Mensagens.Brincar();
                        Console.WriteLine("Aperte alguma tecla para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                        if (!PokemonAdotados[indicePoke].Saude())
                        {
                            Mensagens.GameOver(PokemonAdotados[indicePoke]);
                            
                        }
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
    }
}