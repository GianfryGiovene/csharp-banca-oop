using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    internal class Cliente
    {
        string Nome { get; set; }

        string Cognome { get; set; }

        public string CodiceFiscale { get; protected set; }

        public int Stipendio { get; set; }

        // Costruttore per la creazione dell'istanza creazione
        public Cliente(string nome, string cognome, string codiceFiscale, int stipendio)
        {
            this.Nome = nome;
            this.Cognome = cognome;
            this.CodiceFiscale = codiceFiscale;
            this.Stipendio = stipendio;
        }

        // Costruttore per la modifica dell'istanza

        public Cliente(int stipendio)
        {
            this.Stipendio = stipendio;
        }


        public string GetInformazioniCliente()
        {
            return $"\n***Cliente***\nNome: {Nome}\nCognome: {Cognome}\nCodice fiscale: {CodiceFiscale}\nStipendio: {Stipendio}";
        }

    }
}
