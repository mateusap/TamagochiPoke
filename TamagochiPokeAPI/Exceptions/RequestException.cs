using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiPokeAPI.Models;
using TamagochiPokeAPI.View;

namespace TamagochiPokeAPI.Exceptions
{
    

    [Serializable]
    public class RequestException : Exception
    {
        public RequestException()
        {

        }
        public RequestException(string message) : base(message)
        {

        }
        public RequestException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
