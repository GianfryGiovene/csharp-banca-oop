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
aggiungere, 
modificare e 
ricercare un cliente.

aggiungere un prestito.
effettuare delle ricerche sui prestiti concessi ad un cliente dato il codice fiscale
sapere, dato il codice fiscale di un cliente, l’ammontare totale dei prestiti concessi. (nuovo) --> col calcolo degli interessi ( 3 interessi diversi si crea nuovo oggetto)
sapere, dato il codice fiscale di un cliente, quante rate rimangono da pagare alla data odierna.



Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo con tutti i dati 
che li caratterizzano in un formato di tipo stringa a piacere.

Bonus:
visualizzare per ogni cliente, la situazione dei suoi prestiti in formato tabellare. 


Nel programma della banca si vuole gestire anche l'apertura di un conto che può essere di due tipi:
- conto bancario classico: l'utente può prelevare e depositare denaro a piacere. ovviamente non può prelevare denaro se non ne ha
- nel conto bancario risparmio: l'utente può prelevare soltanto sopra i 1000 euro e può versare al massimo 5000 euro. Ovviamente non può prelevare somme che non ha in deposito.
in particolare nel conto risparmio può prelevare anche 50€ purchè ci siano almeno 1000 euro.

*/

using csharp_banca_oop; 
Banca banca = new Banca("Credem");

//  popoliamo liste
Interesse interessePaperino = new InteressePaperino("interesse paperino");
Interesse interessePippo = new InteressePippo("interesse pippo");
banca.clienti.Add(new Cliente("Pino", "La Lavatrice", "PNG20FSFS1990", 20000,new ContoBancarioRisparmio("PinoLaLavatrice")));
banca.clienti.Add(new Cliente("Carlo", "Santoro", "FI55LAPPO12345", 35000, new ContoStandard("CarloSAntoro")));
banca.clienti.Add(new Cliente("Vinovo", "Castagno", "GHGKJNSK12222", 10000, new ContoStandard("VinovoCastagno")));
banca.clienti.Add(new Cliente("Gargano", "In Fiamme", "FIAMME12345", 50000, new ContoBancarioRisparmio("GarganoInFiamme")));
banca.prestiti.Add(new Prestito(banca.clienti[0], 20000, 200, "12/05/2015", "12/07/2024", interessePaperino));
banca.prestiti.Add(new Prestito(banca.clienti[1], 25000, 200, "12/12/2020", "12/12/2025", interessePaperino));
banca.prestiti.Add(new Prestito(banca.clienti[2], 30000, 200, "12/12/2020", "12/12/2025", interessePippo));
banca.prestiti.Add(new Prestito(banca.clienti[0], 10000, 200, "12/12/2018", "12/12/2023", interessePaperino));



//end popoliamo liste

Menu menu = new Menu("*** Banca Credem ***", banca.clienti, banca.prestiti, banca);
menu.SelezionaMenu();


/********* vecchio codice  ************

banca.ProspettoClienti(banca.clienti);

banca.ProspettoPrestiti(banca.prestiti);

Console.Write("inserisci codice fiscale: ");
string codice = Console.ReadLine();
banca.GetPrestito(codice);


// Aggiungere un nuovo cliente

Cliente cliente = Banca.CreaCliente();

banca.AggiungiNuovoCliente(cliente);

//Scorri lista clienti

banca.ListaClienti();

//seleziona un cliente dalla lista dato l'indice 
Console.Write("Inserire indiceCliente:");
int indexCliente = Int32.Parse(Console.ReadLine());

Cliente clienteCercato = banca.GetCliente(indexCliente);

Console.WriteLine(clienteCercato.GetInformazioniCliente());

// Modificare un cliente

clienteCercato = banca.ModificaInformazioniCliente(clienteCercato);


//controllo
//Console.WriteLine("Rivedo Lista clienti per vedere l'effettiva modifica");
//banca.ListaClienti();

//inserimento prestito

Prestito prestito = banca.CreaPrestito();

banca.InserisciPrestito(prestito);


Console.WriteLine(prestito.GetInformazioniPrestito());

Console.WriteLine();
banca.ListaPrestiti();


//cerco in base a codice fiscale i prestiti in atto

Console.Write("inserisci codice fiscale: ");
string codice = Console.ReadLine();
banca.GetPrestito(codice);

********************************************/