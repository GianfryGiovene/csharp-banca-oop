using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    internal class InteressePippo : Interesse
    {
        

        public InteressePippo(string tipoInteresse)
        {
            this.TipoInteresse = tipoInteresse;
        }

        public override void TassoInteresse()
        {
            this.PercentualeInteresse = 30;
        }
    }
}


