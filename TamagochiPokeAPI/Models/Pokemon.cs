using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagochiPokeAPI.Models
{
    public class Mascote
    {
        public List<Abilities> abilities { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
        public string name { get; set; }

        //atributo de interação
        public int Fome { get; set; }
        public int Humor { get; set; }
        public DateTime Nascimento { get; set; }


        public Mascote()
        {
            Random random = new();
            Fome = random.Next(2, 10);
            Humor = random.Next(2, 10);
            Nascimento = DateTime.Now;
        }
        public bool ChecarFome()
        {
            return this.Fome < 5;
        }
        public void Alimentar()
        {
            this.Fome++;
        }
        public void Brincar()
        {
            this.Humor++;
            this.Fome--;
        }
        public bool Saude()
        {
            return (this.Fome > 0 && this.Humor > 0);
        }
    }
}
