using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Nel programma della banca si vuole gestire anche l'apertura di un conto che può essere di due tipi:
- conto bancario classico: l'utente può prelevare e depositare denaro a piacere. ovviamente non può prelevare denaro se non ne ha
- nel conto bancario risparmio: 
l'utente 
può prelevare soltanto sopra i 1000 euro
e può versare al massimo 5000 euro.
Ovviamente non può prelevare somme che non ha in deposito.


******** PARTICOLARE
in particolare nel conto risparmio può prelevare anche 50€ purchè ci siano almeno 1000 euro.
**************

 Eccezioni su prelievo e deposito
*/

namespace csharp_banca_oop
{
    internal abstract class Conto
    {
        protected string Username { get; set; }
        protected string NumeroConto { get; set; }
        protected int PrelievoMax { get; set; }
        public int SoldiNelConto { get; set; }

        public Conto(string nomeIntestatario)
        {
            Username = nomeIntestatario;


        }

        public static Conto SetAccount()
        {




            return null;
        } 

        public abstract void Prelievo();

        public abstract void Deposito();

       
    }
}
