using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logo.Business.Exceptions
{
    public class FeatureNullReference:Exception
    {
        public FeatureNullReference()
        {

        }
        public FeatureNullReference(string? message) : base(message)
        {
        }
        public FeatureNullReference(string ex, string? message) : base(message)
        {
            Prop = ex;
        }

        public string Prop { get; set; }
    }
}
