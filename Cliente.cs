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

        static int matrice = 0;

        private string id;


        public string Id { 
            get { return id;
            } 
            set {

                while(id.Length < 8)
                {
                    this.id += "0" + id;  
                }
                
            } 
        }

        // Costruttore per la creazione dell'istanza creazione
        public Cliente(string nome, string cognome, string codiceFiscale, int stipendio)
        {
            this.Nome = nome;
            this.Cognome = cognome;
            this.CodiceFiscale = codiceFiscale;
            this.Stipendio = stipendio;
            Cliente.matrice++;
            this.id = Cliente.matrice.ToString();
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

        public string GetProspsettoClienti()
        {
            return $"\n***Cliente{this.Id}***\nNome: {this.Nome}\nCognome: {this.Cognome}\nCodice fiscale: {this.CodiceFiscale}\nStipendio: {this.Stipendio}\n";
        }

    }
}
