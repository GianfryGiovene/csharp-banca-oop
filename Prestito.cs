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

        private int id { get; set; }
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
        }

        public string GetInformazioniPrestito()
        {
            return $"***Prestito n.{this.id}***\nInformazioni Cliente:{this.intestatario.GetInformazioniCliente()}\n\nAmmontare prestito: {this.Ammontare} euro\nRata prestito: {this.Rata} euro\nData inizio:{this.dataInizio}\ndata fine: {this.dataFine}";
        }
        public void SetId(int value)
        {
            this.id = value;
        }
    }
}
