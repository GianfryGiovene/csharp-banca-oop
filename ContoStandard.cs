using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    internal class ContoStandard : Conto
    {

        public ContoStandard(string nomeIntestatario) : base(nomeIntestatario)
        {
            this.NomeIntestatario = nomeIntestatario;
        }

        public override void Prelievo()
        {
            Console.WriteLine("Quanto vuoi prelevare?");
            int prelievo = Int32.Parse(Console.ReadLine());

            if (prelievo <= 0)
            {
                throw new Exception("Deposita Denaro!!");
            }
            else if(SoldiNelConto <= prelievo)
            {
                throw new SaldoNonSufficienteException("Non ci sono abbastanza soldi nel conto!!", SoldiNelConto);
            }
            else
            {
                this.SoldiNelConto -= prelievo;
            }
        }

        public override void Deposito()
        {
            Console.WriteLine("Inserire soldi");
            int deposito = Int32.Parse(Console.ReadLine()); 

            if(deposito <= 0)
            {
                throw new Exception("Deposita Denaro!!");
            }
            else
            {
                this.SoldiNelConto += deposito;
            }
        }

       
    }
}
