using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    internal class Prestito
    {
        public Cliente intestatario;
        static int matrice = 0;
        private int id;
        public int Ammontare { get; private set; }
        int Rata { get; set; }
        public string dataInizio { get; set; }
        public string dataFine { get; set; }
        

        public Prestito(Cliente intestatario, int ammontare, int rata, string dataInizio, string dataFine)
        {
            this.intestatario = intestatario;
            this.Ammontare = ammontare;
            this.Rata = rata;
            this.dataInizio = dataInizio;
            this.dataFine = dataFine;
            Prestito.matrice++;
            this.id = Prestito.matrice;


        }

        public string GetInformazioniPrestito()
        {
            return $"\n***Prestito n.{this.id}***\nInformazioni Cliente:{this.intestatario.GetInformazioniCliente()}\nAmmontare prestito: {this.Ammontare} euro\nRata prestito: {this.Rata} euro\nData inizio:{this.dataInizio}\ndata fine: {this.dataFine}\n";
        }
        
    }
}
