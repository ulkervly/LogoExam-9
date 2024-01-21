using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logo.Business.Exceptions
{
    public class IdBelowZeroException:Exception
    {
        public IdBelowZeroException()
        {

        }
        public IdBelowZeroException(string? message) : base(message)
        {
        }
        public IdBelowZeroException(string ex, string? message) : base(message)
        {
            Prop = ex;
        }

        public string Prop { get; set; }
    }
}
