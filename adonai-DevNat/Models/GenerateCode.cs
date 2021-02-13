using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adonai_DevNat.Models
{
    public class GenerateCode
    {
        public Int32 server { get; set; }

        public string tableName { get; set; }

        public string package { get; set; }

        public string language { get; set; }

        public string className { get; set; }

        public string routeName { get; set; }

        public string code { get; set; }

        public Int32 tipo { get; set; }

        public Byte model { get; set; }

        public Byte controller { get; set; }

        public Byte resource { get; set; }

        public Byte requerToken { get; set; }
    }
}
