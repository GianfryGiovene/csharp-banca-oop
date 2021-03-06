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
        public List<Conto> conto;

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
            Conto newConto;
            // caratterizzo il cliente

            Console.Write("Inserire nome: ");
            string nome = Console.ReadLine();

            Console.Write("Inserire cognome: ");
            string cognome = Console.ReadLine();

            string username = nome + cognome;

            Console.Write("Inserire codice fiscale: ");
            string codiceFiscale = Console.ReadLine();

            Console.Write("Inserire stipendio annuo: ");
            int stipendio = Int32.Parse(Console.ReadLine());

            Console.Write("Selezioanre tipo di conto:\n1 - Conto Risparmio\n2 - Conto Normale\n ");
            int conto = Int32.Parse(Console.ReadLine());

            if(conto == 1)
            {
                newConto = new ContoBancarioRisparmio(username);
            }
            else
            {
                newConto = new ContoStandard(username);
            }

            Cliente cliente = new Cliente(nome, cognome, codiceFiscale, stipendio, newConto);

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

        public void ProspettoClienti(List<Cliente> clienti)
        {
            Console.WriteLine("Si desidera visualizzare i clienti in formato tabella?\n1 - si\n2 - no");
            int validatore = Int32.Parse(Console.ReadLine());
            Console.Clear();

            if (validatore == 2)
            {
                foreach (Cliente cliente in clienti)
                {
                    Console.Write(cliente.GetInformazioniCliente());
                }
            }
            else
            {
                foreach (Cliente cliente in clienti)
                {
                    cliente.GetInformazioniClienteTabellare();
                }
            }
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

            string dataInizio =  DateTime.Today.ToShortDateString();
            DateTime dateTime = DateTime.Parse(dataInizio);
            Console.WriteLine("\n\n*** Data inizio prestito: {0}***\n", dataInizio);

            //calcolo data fine prestito
            double temp = ammontarePrestito / rataPrestito;
            int ratePrestito = (int)Math.Round(temp, 0);

            DateTime dataFinale = dateTime.AddMonths(ratePrestito);
            string dataFine = Convert.ToString(dataFinale);
            Console.WriteLine("\n\n*** Data fine prestito: {0}***\n", dataFine);

            Console.Write("Scegliere il tipo di interesse");
            Interesse interesse = new InteressePaperino("Interesse paperino");
            
            Console.Write("Inserire prestito 'y' o 'n' -->");
            string validatore = Console.ReadLine();
            Console.Clear();
            if (validatore == "y")
            {
                Prestito prestito = new Prestito(clienteRichiedente, ammontarePrestito, rataPrestito, dataInizio, dataFine, interesse);

                Console.WriteLine("***** Prestito concesso *****");
                return prestito;
            }

            return null;

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


        // ottengo la lista dei prestiti con il loro totale complessivo dato il codice fiscale 
        public void GetPrestito(string codiceFiscale)
        {
            int sommaPrestiti = 0;
            List<Prestito> prestitiCliente = new List<Prestito>();

            //ciclo array contenente tutti i prestiti dei clienti

            foreach (Prestito prestito in prestiti)
            {

                if(codiceFiscale == prestito.intestatario.CodiceFiscale)
                {

                    prestitiCliente.Add(prestito);
                   
                }
            }

            // ciclo array del singolo utente
        
            foreach (Prestito prestito in prestitiCliente)
            {
                
                Console.WriteLine("{0}\nRate del prestito rimanenti: {1}\n", prestito.GetInformazioniPrestito(), this.GetRateRimanenti(prestito));
                
            }

            foreach (Prestito prestito in prestitiCliente)
            {
                sommaPrestiti += prestito.Ammontare;
                
            }
            Console.WriteLine("\n**** La somma totale dei prestiti è: {0} euro ****", sommaPrestiti);
        }

        public int GetRateRimanenti(Prestito prestito)
        {
            string tempDate = DateTime.Today.ToShortDateString();
            DateTime dataAttuale = DateTime.Parse(tempDate);
            DateTime dataFinale = DateTime.Parse(prestito.dataFine);

            int rateRestanti =- 12 * (dataAttuale.Year - dataFinale.Year) + dataAttuale.Month - dataFinale.Month;
               
            return rateRestanti;
        }

        public void ProspettoPrestiti(List<Prestito> prestiti)
        {
            foreach (Prestito prestito in prestiti)
            {
                Console.Write(prestito.GetInformazioniPrestito());
            }
        }

        //***** end metodi che agiscono sull'istanza prestito *****

        
        
    }
}
