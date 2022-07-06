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
                throw new Exception("Cifra non valida!!");
            }
            else if (SoldiNelConto <= prelievo || SoldiNelConto < 1000)
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

            if (deposito <= 0)
            {
                throw new Exception("Deposita Denaro!!");
            }
            else if(deposito <= 5000)
            {
                throw new Exception("Versare almeno 5000 euro!!");
            }
            else
            {
                this.SoldiNelConto += deposito;
            }
        }
    }
}
