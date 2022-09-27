using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagochiPokeAPI
{
    public class TamagochiView
    {
        private string nomeJogador { get; set; }

        public TamagochiView()
        {
            BoasVindas();
        }

        public void BoasVindas()
        {
            Console.WriteLine(@"

██████╗░░█████╗░██╗░░░██╗░█████╗░░█████╗░██████╗░███████╗
██╔══██╗██╔══██╗╚██╗░██╔╝██╔══██╗██╔══██╗██╔══██╗██╔════╝
██║░░██║███████║░╚████╔╝░██║░░╚═╝███████║██████╔╝█████╗░░
██║░░██║██╔══██║░░╚██╔╝░░██║░░██╗██╔══██║██╔══██╗██╔══╝░░
██████╔╝██║░░██║░░░██║░░░╚█████╔╝██║░░██║██║░░██║███████╗
╚═════╝░╚═╝░░╚═╝░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝");

            Console.WriteLine("\nComo você quer ser chamado?");
            nomeJogador = Console.ReadLine();
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

        public void MenuInicial()
        {
            Console.WriteLine("\n\n=========================== MENU ===========================");
            Console.WriteLine($"{nomeJogador}, seja bem vindo ao centro de adoção!");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("Digite 1 para adotar um mascote virtual");
            Console.WriteLine("Digite 3 para sair");
        }
        public string MenuAdocao()
        {
            Console.WriteLine("\n\n=========================== ADOTE ===========================");
            Console.WriteLine($"{nomeJogador}, escolha um pokemon:");
            Console.WriteLine("SCYTHER");
            Console.WriteLine("SANDSHREW");
            Console.WriteLine("PSYDUCK");
            Console.WriteLine("STARYU");
            Console.WriteLine();
            return Console.ReadLine().ToUpper();
        }
    }
}
