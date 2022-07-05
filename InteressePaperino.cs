using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    internal class InteressePaperino : Interesse, IPaperone
    {

        public InteressePaperino(string tipoInteresse)
        {
            this.TipoInteresse = tipoInteresse;
        }


        public override void TassoInteresse()
        {
            this.PercentualeInteresse = 70;
            

        }
        public int AiutoEsterno()
        {
            return this.PercentualeInteresse - 10;
        }
    }
}
