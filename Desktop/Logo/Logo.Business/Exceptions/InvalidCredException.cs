using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logo.Business.Exceptions
{
    public class InvalidCredException:Exception
    {
        public InvalidCredException()
        {
            
        }
        public InvalidCredException(string? message) : base(message)
        {
        }
        public InvalidCredException(string ex,string? message) : base(message)
        {
            Prop = ex;
        }

        public string Prop {  get; set; }
        
    }
}
