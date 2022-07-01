/*
Sviluppare un’applicazione orientata agli oggetti per gestire i prestiti che una banca concede ai propri clienti.

La banca è caratterizzata da
un nome
un insieme di clienti (una lista)
un insieme di prestiti concessi ai clienti (una lista)

I clienti sono caratterizzati da
nome,
cognome,
codice fiscale
stipendio

I prestiti sono caratterizzati da
ID
intestatario del prestito (il cliente),
un ammontare,
una rata,
una data inizio,
una data fine.

Per la banca deve essere possibile:
aggiungere, modificare e ricercare un cliente.
aggiungere un prestito.
effettuare delle ricerche sui prestiti concessi ad un cliente dato il codice fiscale
sapere, dato il codice fiscale di un cliente, l’ammontare totale dei prestiti concessi.
sapere, dato il codice fiscale di un cliente, quante rate rimangono da pagare alla data odierna.

Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo con tutti i dati 
che li caratterizzano in un formato di tipo stringa a piacere.

Bonus:
visualizzare per ogni cliente, la situazione dei suoi prestiti in formato tabellare. 
*/

using csharp_banca_oop;

Banca banca = new Banca("Credem");

//  popoliamo lista clienti

banca.clienti.Add(new Cliente("Pino", "La Lavatrice", "PNG20FSFS1990", 20000));
banca.clienti.Add(new Cliente("Carlo", "Santoro", "FI55LAPPO12345", 35000));
banca.clienti.Add(new Cliente("Vinovo", "Castagno", "GHGKJNSK12222", 10000));
banca.clienti.Add(new Cliente("Gargano", "In Fiamme", "FIAMME12345", 50000));

//  end popoliamo lista clienti


// Aggiungere un nuovo cliente

//Cliente cliente = Banca.CreaCliente();

//banca.AggiungiNuovoCliente(cliente);

//Scorri lista clienti

banca.ListaClienti();


//seleziona un cliente dalla lista 
Console.Write("Inserire indiceCliente:");
int indexCliente = Int32.Parse(Console.ReadLine());

Cliente clienteCercato = banca.GetCliente(indexCliente);

Console.WriteLine(clienteCercato.GetInformazioniCliente());

// Modificare un cliente


clienteCercato = banca.ModificaInformazioniCliente(clienteCercato);




Console.WriteLine("Rivedo Lista clienti per vedere l'effettiva modifica");
banca.ListaClienti();
