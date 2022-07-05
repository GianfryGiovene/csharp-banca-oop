using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    internal class ContoBancarioRisparmio : Conto
    {
        

        public ContoBancarioRisparmio(string nomeIntestatario) : base(nomeIntestatario)
        {
            this.Username = nomeIntestatario;
        }
        
        public override void Prelievo()
        {
            Console.WriteLine("***** MENU RISPARMIO *****");
            Console.WriteLine("Quanto vuoi prelevare?");
            int prelievo = Int32.Parse(Console.ReadLine());

            if (prelievo <= 0)
            {
                throw new Exception("Deposita Denaro!!");
            }
            else if (SoldiNelConto <= prelievo)
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

        }
    }
}
