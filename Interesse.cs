using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    abstract class Interesse
    {
        public string TipoInteresse { get; set; }
        public int PercentualeInteresse { set; get; }


        public abstract void TassoInteresse();


    }
}
