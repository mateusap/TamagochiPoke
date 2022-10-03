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
            Console.WriteLine("Digite o nome corretamente, caso contrário um pokemon aleatório será escolhido!");
            Console.WriteLine("SCYTHER");
            Console.WriteLine("SANDSHREW");
            Console.WriteLine("PSYDUCK");
            Console.WriteLine("STARYU");
            Console.WriteLine("PIKACHU");
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
        public void MenuDetalhes(Mascote mascote)
        {
            Titulo();
            Console.WriteLine("\n\n========================= DETALHES =========================");
            Console.WriteLine("Nome do Pokemon: " + mascote.name.ToUpper());
            Console.WriteLine((string)("Altura: " + mascote.height / 10 + "m"));
            Console.WriteLine((string)("Peso: " + mascote.weight / 10 + "kg"));
            Console.WriteLine("Habilidades: ");
            foreach (Abilities habilidades in mascote.abilities)
            {
                Console.WriteLine(habilidades.ability.name.ToUpper() + " ");
            }
        }
        public void MenuDetalhesAdotado(Mascote mascote)
        {
            Titulo();
            Console.WriteLine("\n\n========================= DETALHES =========================");
            Console.WriteLine("Nome do Pokemon: " + mascote.name.ToUpper());
            Console.WriteLine("Altura: " + mascote.height / 10 + "m");
            Console.WriteLine("Peso: " + mascote.weight / 10 + "kg");
            System.TimeSpan idade = DateTime.Now.Subtract(mascote.Nascimento);
            Console.WriteLine("Idade " +idade.Minutes + " anos virtuais de Pokemon.");
            if (mascote.ChecarFome())
                Console.WriteLine($"{mascote.name.ToUpper()} está com fome, de algo para ele comer.");
            else
                Console.WriteLine($"{mascote.name.ToUpper()} está de barriga cheia, muito bem alimentado!");

            if (mascote.Humor>5)
                Console.WriteLine($"{mascote.name.ToUpper()} está irradiando felicidade!");
            else
                Console.WriteLine($"{mascote.name.ToUpper()} está se sentindo triste, talvez devesse brincar com ele um pouco.");

            Console.WriteLine("Habilidades: ");
            foreach (Abilities habilidades in mascote.abilities)
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

        public int ConsultarPokemons(List<Mascote> mascotes)
        {
            Titulo();
            Console.WriteLine("\n\n======================= SEUS FILHOTINHOS =======================");
            Console.WriteLine($"Você possui {mascotes.Count} Pokemons adotados com você.");
            for (int indicePoke = 0; indicePoke < mascotes.Count; indicePoke++)
            {
                Console.WriteLine($"{indicePoke} - {mascotes[indicePoke].name.ToUpper()}");
            }
            Console.WriteLine("Com qual Pokemon você quer interagir?");
            Console.WriteLine($"Aperte outra tecla para voltar.");
            return Convert.ToInt32(Console.ReadLine());
            
        }

        public string Interagir(Mascote mascote)
        {
            Titulo();
            Console.WriteLine("\n\n======================= INTERAGIR =======================");
            Console.WriteLine($"{nomeJogador}, você quer:");
            Console.WriteLine($"1 - Saber como {mascote.name.ToUpper()} está");
            Console.WriteLine($"2 - Alimentar {mascote.name.ToUpper()}");
            Console.WriteLine($"3 - Brincar com {mascote.name.ToUpper()}");
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
        public void GameOver(Mascote mascote)
        {
            Console.WriteLine("\n\n======================= (ToT) =======================");
            Console.WriteLine("Seu Pokemon morreu de " + (mascote.Humor > 0 ? "fome..." : "tristeza..."));
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
