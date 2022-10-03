using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagochiPokeAPI.Models
{
    public class MascoteMapping
    {
        public MascoteMapping()
        {
            Mapper.CreateMap<Pokemon, Mascote>();
        }
    }
}
