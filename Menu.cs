using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    internal class Menu
    {
        private string Titolo { get; set; }

        protected List<Menu> listaMenu;

        protected List<Cliente> clienti;

        protected List<Prestito> prestiti;

        protected Banca banca;

        protected ContoStandard contoStandard = new ContoStandard("Pino");

        public Menu (string titolo, List<Cliente> clienti, List<Prestito> prestiti, Banca banca)
        {
            this.Titolo = titolo;
            this.listaMenu = new List<Menu> ();
            this.clienti = clienti;
            this.prestiti = prestiti;
            this.banca = banca;
        }
        
        public void SelezionaMenu()
        {
            Console.WriteLine("Selezionare il tipo di operazioni:\n1- Menù clienti\n2- Menù prestiti\n3- Deposita Denaro\n4- Preleva denaro");

            int selezione = int.Parse(Console.ReadLine());

            switch(selezione)
            {
                case 1:
                    
                    Console.Clear();
                    this.MenuClienti();
                    break;
                    
                case 2:
                    
                    Console.Clear();
                    this.MenuPrestiti();
                    break;
                case 3:
                    try
                    {
                        contoStandard.Deposito();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("inserisci importo");
                    }
                    break;
                default:
                    try
                    {
                        contoStandard.Prelievo();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\ninserisci prelievo");
                        contoStandard.Prelievo();
                    }
                    
                    break;
            }
        }

        public void MenuClienti()
        {
            Console.WriteLine("****Menu Clienti****\n\n1-Aggiungi nuovo cliente\n2- Selezionare cliente dalla lista\n3- Modificare cliente\n4- prospetto clienti ");
            int selezione = int.Parse(Console.ReadLine());
            switch (selezione)
            {
                case 1:
                    Console.Clear();
                    // Aggiungere un nuovo cliente
                    Cliente cliente = Banca.CreaCliente();
                    banca.AggiungiNuovoCliente(cliente);
                    break;

                case 2:
                    Console.Clear();
                    //Scorri lista clienti

                    banca.ListaClienti();

                    //seleziona un cliente dalla lista dato l'indice 
                    Console.Write("Inserire indiceCliente:");
                    int indexCliente = Int32.Parse(Console.ReadLine());

                    Cliente clienteCercato = banca.GetCliente(indexCliente);

                    Console.WriteLine(clienteCercato.GetInformazioniCliente());
                    break;

                case 3:
                    Console.Clear();
                    //Scorri lista clienti

                    banca.ListaClienti();
                    //seleziona un cliente dalla lista dato l'indice 
                    Console.Write("Inserire indiceCliente:");
                    int index = Int32.Parse(Console.ReadLine());

                    Cliente clienteDaModificare = banca.GetCliente(index);
                    // Modificare un cliente
                    clienteDaModificare = banca.ModificaInformazioniCliente(clienteDaModificare);

                    break;

                case 4:
                    Console.Clear();
                    banca.ProspettoClienti(clienti);                    
                    break;

            }
        }

        public void MenuPrestiti()
        {
            Console.WriteLine("****Menu Prestiti****\n\n1-Aggiungi un prestito\n2- Ricerca prestiti per codice fiscale\n3- Prospetto prestiti");
            int selezione = int.Parse(Console.ReadLine());
            switch (selezione)
            {
                case 1:
                    Console.Clear();

                    //inserimento prestito
                    Console.WriteLine("Lista clienti banca:\n");
                    banca.ListaClienti();

                    Prestito prestito = banca.CreaPrestito();
                    banca.InserisciPrestito(prestito);
                    break;

                case 2:

                    Console.Clear();
                    //Scorri lista clienti

                    banca.ListaPrestiti();

                    //cerco in base a codice fiscale i prestiti in atto sul cliente

                    Console.Write("inserisci codice fiscale: ");
                    string codice = Console.ReadLine();
                    Console.Clear();
                    banca.GetPrestito(codice);
                    break;

                case 3:
                    Console.Clear();
                    banca.ProspettoPrestiti(prestiti);
                    break;

            }
        
        }

    }
}
