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
        List<Prestito> prestiti;

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

        //***** end metodi che agiscono sull'istanza cliente *****



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

        
    }
}
