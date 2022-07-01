using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    internal class Banca        
    {
        string Nome { get; set; }

        public List<Cliente> clienti;
        public List<Prestito> prestiti;

        public Banca (string nome)
        {
            this.Nome = nome;
            this.clienti = new List<Cliente>();
            this.prestiti = new List<Prestito>();
        }

        //***** metodi che agiscono sull'istanza cliente *****

        // metodo creazione cliente
        public static Cliente CreaCliente()
        {
            Console.WriteLine("\n*** Creazione nuovo Cliente ***\n");

            // caratterizzo il cliente

            Console.Write("Inserire nome: ");
            string nome = Console.ReadLine();

            Console.Write("Inserire cognome: ");
            string cognome = Console.ReadLine();

            Console.Write("Inserire codice fiscale: ");
            string codiceFiscale = Console.ReadLine();

            Console.Write("Inserire stipendio annuo: ");
            int stipendio = Int32.Parse(Console.ReadLine());

            Cliente cliente = new Cliente(nome, cognome, codiceFiscale, stipendio);

            return cliente;
        }

        // metodo modifica informazioni cliente

        public static Cliente ModificaCliente()
        {
            Console.WriteLine("\n*** Modifica Cliente ***\n");

            // caratterizzo il cliente

            Console.Write("Inserire stipendio annuo: ");
            int stipendio = Int32.Parse(Console.ReadLine());

            Cliente cliente = new Cliente(stipendio);

            return cliente;
        }

        



        public void AggiungiNuovoCliente(Cliente cliente)
        {
            // salvo il cliente nella lista clienti
            clienti.Add(cliente);

        }

        public void ListaClienti()
        {
            Console.WriteLine();
            Console.WriteLine("\n*** Lista Clienti ***\n");
            
           foreach(Cliente cliente in clienti)
            {
                Console.WriteLine(cliente.GetInformazioniCliente() + "\n");
            } 
        }
        // cerca il cliente in base all'indice
        public Cliente GetCliente(int indiceCliente)
        {
            indiceCliente--;
            if(indiceCliente < 0 || indiceCliente >= clienti.Count())
            {
                Console.WriteLine("Error: Il cliente selezionato non esiste!");
                return null;
            }

            return clienti[indiceCliente];
        }

        public Cliente ModificaInformazioniCliente(Cliente clienteDaModificare)
        {
            Cliente modificheCliente = Banca.ModificaCliente();

            clienteDaModificare.Stipendio = modificheCliente.Stipendio;

            return clienteDaModificare;
        }
        //***** end metodi che agiscono sull'istanza cliente *****


        //***** metodi che agiscono sull'istanza prestito *****
        public Prestito CreaPrestito()
        {
            Console.WriteLine("\n*** Generazione Prestito ***\n");

            // caratterizzo il prestito

            Console.Write("\nInserire indiceCliente:");
            int indexCliente = Int32.Parse(Console.ReadLine());
            Cliente clienteRichiedente = this.GetCliente(indexCliente);

            Console.Write("Inserire ammontare del prestito: ");
            int ammontarePrestito = Int32.Parse(Console.ReadLine());

            Console.Write("Inserire rata del prestito: ");
            int rataPrestito = Int32.Parse(Console.ReadLine());


            Console.WriteLine("\n\n*** Data inizio prestito ***\n");

            string dataInizio =  DateTime.Today.ToShortDateString();
            DateTime dateTime = DateTime.Parse(dataInizio);

            //calcolo data fine prestito
            double temp = ammontarePrestito / rataPrestito;
            int ratePrestito = (int)Math.Round(temp, 0);


            DateTime dataFinale = dateTime.AddMonths(ratePrestito);
            string dataFine = Convert.ToString(dataFinale);
            

            Prestito prestito = new Prestito(clienteRichiedente, ammontarePrestito, rataPrestito, dataInizio, dataFine);

            return prestito;

        }

        public void InserisciPrestito(Prestito prestito)
        {
            this.prestiti.Add(prestito);
        }

        public void ListaPrestiti()
        {
            Console.WriteLine();
            Console.WriteLine("\n*** Lista Prestiti ***\n");

            foreach (Prestito prestito in prestiti)
            {
                Console.WriteLine(prestito.GetInformazioniPrestito() + "\n");
            }
        }
        // ottengo la lista dei prestiti dato il codice fiscale
        public void GetPrestito(string codiceFiscale)
        {
            List<Prestito> prestitoList = new List<Prestito>();
            for(int i = 0; i < prestiti.Count; i++)
            {
                if(codiceFiscale == prestiti[i].intestatario.CodiceFiscale)
                {
                    prestitoList.Add(prestiti[i]);
                    Console.WriteLine(prestiti[i].GetInformazioniPrestito());
                }
            }                      
        }

        //***** end metodi che agiscono sull'istanza prestito *****
    }
}
