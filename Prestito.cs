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
        int Ammontare { get; set; }
        int Rata { get; set; }
        string dataInizio { get; set; }
        string dataFine { get; set; }

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
            return $"***Prestito***\nInformazioni Cliente:{intestatario.GetInformazioniCliente()}\n\nAmmontare prestito: {Ammontare}\nRata prestito : {Rata}\nData inizio:{dataInizio} e data fine {dataFine}\n\n";
        }
    }
}
