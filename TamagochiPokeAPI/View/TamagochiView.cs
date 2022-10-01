using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiPokeAPI.Models;

namespace TamagochiPokeAPI.View
{
    public class TamagochiView
    {
        private string nomeJogador { get; set; }

        public TamagochiView()
        {
            BoasVindas();
        }


        public void Titulo()
        {
            Console.WriteLine(@"

██████╗░░█████╗░██╗░░░██╗░█████╗░░█████╗░██████╗░███████╗
██╔══██╗██╔══██╗╚██╗░██╔╝██╔══██╗██╔══██╗██╔══██╗██╔════╝
██║░░██║███████║░╚████╔╝░██║░░╚═╝███████║██████╔╝█████╗░░
██║░░██║██╔══██║░░╚██╔╝░░██║░░██╗██╔══██║██╔══██╗██╔══╝░░
██████╔╝██║░░██║░░░██║░░░╚█████╔╝██║░░██║██║░░██║███████╗
╚═════╝░╚═╝░░╚═╝░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝");
        }
        public void BoasVindas()
        {
            Titulo();
            Console.WriteLine("\nComo você quer ser chamado?");
            nomeJogador = Console.ReadLine();
            Console.Clear();
        }

        public void MenuInicial()
        {
            Titulo();
            Console.WriteLine("\n\n=========================== MENU ===========================");
            Console.WriteLine($"{nomeJogador}, seja bem vindo ao centro de adoção!");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("Digite 1 para adotar um mascote virtual");
            Console.WriteLine("Digite 2 para ver seus mascotes adotados");
            Console.WriteLine("Digite 3 para sair");
        }
        public string MenuAdocao()
        {
            Titulo();
            Console.WriteLine("\n\n=========================== ADOTE ===========================");
            Console.WriteLine($"{nomeJogador}, escolha um pokemon:");
            Console.WriteLine("Caso o seu pokemon favorito não esteja listado, digite o nome dele corretamente.");
            Console.WriteLine("SCYTHER");
            Console.WriteLine("SANDSHREW");
            Console.WriteLine("PSYDUCK");
            Console.WriteLine("STARYU");
            Console.WriteLine();
            return Console.ReadLine().ToUpper();
        }
        public string MenuPokemon(string especies)
        {
            Titulo();
            Console.WriteLine("\n\n========================= SAIBA MAIS =========================");
            Console.WriteLine($"{nomeJogador}, escolha uma das opções abaixo:");
            Console.WriteLine($"Digite 1 para: Saber mais sobre {especies.ToUpper()}");
            Console.WriteLine($"Digite 2 para: Adotar {especies.ToUpper()}");
            Console.WriteLine($"Digite 3 para: Voltar");
            Console.WriteLine();
            return Console.ReadLine();
        }
        public void MenuDetalhes(Pokemon Pokemon)
        {
            Titulo();
            Console.WriteLine("\n\n========================= DETALHES =========================");
            Console.WriteLine("Nome do Pokemon: " + Pokemon.name.ToUpper());
            Console.WriteLine("Altura: " + Pokemon.height / 10 + "m");
            Console.WriteLine("Peso: " + Pokemon.weight / 10 + "kg");
            Console.WriteLine("Habilidades: ");
            foreach (Abilities habilidades in Pokemon.abilities)
            {
                Console.WriteLine(habilidades.ability.name.ToUpper() + " ");
            }
        }
        public void MenuDetalhesAdotado(Pokemon pokemon)
        {
            Titulo();
            Console.WriteLine("\n\n========================= DETALHES =========================");
            Console.WriteLine("Nome do Pokemon: " + pokemon.name.ToUpper());
            Console.WriteLine("Altura: " + pokemon.height / 10 + "m");
            Console.WriteLine("Peso: " + pokemon.weight / 10 + "kg");
            System.TimeSpan idade = DateTime.Now.Subtract(pokemon.Nascimento);
            Console.WriteLine("Idade " +idade.Minutes + " anos virtuais de Pokemon.");
            if (pokemon.ChecarFome())
                Console.WriteLine($"{pokemon.name.ToUpper()} está com fome, de algo para ele comer.");
            else
                Console.WriteLine($"{pokemon.name.ToUpper()} está de barriga cheia, muito bem alimentado!");

            if (pokemon.Humor>5)
                Console.WriteLine($"{pokemon.name.ToUpper()} está irradiando felicidade!");
            else
                Console.WriteLine($"{pokemon.name.ToUpper()} está se sentindo triste, talvez devesse brincar com ele um pouco.");

            Console.WriteLine("Habilidades: ");
            foreach (Abilities habilidades in pokemon.abilities)
            {
                Console.WriteLine(habilidades.ability.name.ToUpper() + " ");
            }
        }
        public void MensagemAdocao()
        {
            Titulo();
            Console.WriteLine("\n\n========================= PARABÉNS =========================");
            Console.WriteLine($"{nomeJogador}, o Pokemon foi adotado com sucesso. Sons podem ser ouvidos vindo do ovo");
            Console.WriteLine("O ovo está chocando!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
              ██████╗
             ████████╗
            ██████████╗
            ██████████║
            ██████████║
            ╚████████╔╝
             ╚═══════╝");
            Console.ResetColor();
        }

        public int ConsultarPokemons(List<Pokemon> Pokemons)
        {
            Titulo();
            Console.WriteLine("\n\n======================= SEUS FILHOTINHOS =======================");
            Console.WriteLine($"Você possui {Pokemons.Count} Pokemons adotados com você.");
            for (int indicePoke = 0; indicePoke < Pokemons.Count; indicePoke++)
            {
                Console.WriteLine($"{indicePoke} - {Pokemons[indicePoke].name.ToUpper()}");
            }
            Console.WriteLine("Com qual Pokemon você quer interagir?");
            return Convert.ToInt32(Console.ReadLine());
        }

        public string Interagir(Pokemon Pokemon)
        {
            Titulo();
            Console.WriteLine("\n\n======================= INTERAGIR =======================");
            Console.WriteLine($"{nomeJogador}, você quer:");
            Console.WriteLine($"1 - Saber como {Pokemon.name.ToUpper()} está");
            Console.WriteLine($"2 - Alimentar {Pokemon.name.ToUpper()}");
            Console.WriteLine($"3 - Brincar com {Pokemon.name.ToUpper()}");
            Console.WriteLine("4 - Voltar");
            return Console.ReadLine().ToUpper();
        }

        public void Alimentar()
        {
            Titulo();
            Console.WriteLine("\n\n======================= ALIMENTANDO =======================");
            Console.WriteLine("\n\n                         (＾ｕ＾)");
            Console.WriteLine("Você alimentou seu Pokemon, consegue ver a satisfação no rostinho dele!");
            Console.WriteLine();
        }
        public void Brincar()
        {
            Titulo();
            Console.WriteLine("\n\n======================= BRINCANDO =======================");
            Console.WriteLine("\n\n                      ( ^)o(^ )");
            Console.WriteLine("Você brincou com seu Pokemon, a felicidade chega a transbordar!");
            Console.WriteLine();
        }
        public void GameOver(Pokemon Pokemon)
        {
            Console.WriteLine("\n\n======================= (ToT) =======================");
            Console.WriteLine("Seu Pokemon morreu de " + (Pokemon.Humor > 0 ? "fome..." : "tristeza..."));
            Console.WriteLine(@"

░██████╗░░█████╗░███╗░░░███╗███████╗  ░█████╗░██╗░░░██╗███████╗██████╗░
██╔════╝░██╔══██╗████╗░████║██╔════╝  ██╔══██╗██║░░░██║██╔════╝██╔══██╗
██║░░██╗░███████║██╔████╔██║█████╗░░  ██║░░██║╚██╗░██╔╝█████╗░░██████╔╝
██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░  ██║░░██║░╚████╔╝░██╔══╝░░██╔══██╗
╚██████╔╝██║░░██║██║░╚═╝░██║███████╗  ╚█████╔╝░░╚██╔╝░░███████╗██║░░██║
░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝  ░╚════╝░░░░╚═╝░░░╚══════╝╚═╝░░╚═╝");
        }
    }
}
