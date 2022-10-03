using AutoMapper;
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
        private List<Mascote> PokemonAdotados { get; set; }
        private TamagochiView Mensagens { get; set; }


        private MascoteMapping Mapeador;

        public TamagochiController()
        {
            this.PokemonAdotados = new List<Mascote>();
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
            Mascote mascote = new();
            Pokemon pokemon = new();
            Mapeador = new MascoteMapping();

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

                        Mapper.CreateMap<Pokemon, Mascote>();
                        mascote = Mapper.Map<Pokemon, Mascote>(pokemon);


                        Mensagens.MenuDetalhes(mascote);
                        Console.WriteLine("Aperte alguma tecla para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        pokemon = PokemonService.BuscarPorEspecie(especies);

                        Mapper.CreateMap<Pokemon, Mascote>();
                        mascote = Mapper.Map<Pokemon, Mascote>(pokemon);

                        this.PokemonAdotados.Add(mascote);
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
                try
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
                catch (Exception e)
                {
                    Console.WriteLine("Você deve escolher uma das opções indicadas");
                    return;
                }
            }
        }
    }
}