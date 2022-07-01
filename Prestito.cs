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
        static int id = 0;
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
            return $"***Prestito***\nInformazioni Cliente:{intestatario.GetInformazioniCliente()}\n\nAmmontare prestito: {Ammontare} euro\nRata prestito : {Rata} euro\nData inizio:{dataInizio} e data fine {dataFine}\n\n";
        }
    }
}
