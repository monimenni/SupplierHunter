# Supplier Hunter
La web app permette all'utente di visualizzare i fornitori possibili per il prodotto che si vuole acquistare,
in base alla loro disponibilità ed ai giorni di consegna, visualizzando il valore totale dell'eventuale ordine,
già sottratto del possibile sconto previsto.

Selezionando per esempio il "Product 1", verranno visualizzati i "Suppliers" B,C,D che sono i fornitori che
vendono quel prodotto. Selezionando successivamente una quantità, per esempio 200 pezzi, verrà tolto dalla lista
"Supplier D"che ha solo 100 pezzi disponibili e viene presentato il valore totale di 
- 200.000 euro per "Supplier B", che è il prezzo totale pieno (1000 euro/pezzo) perchè il tipo di sconto associato a
  questo prodotto per questo fornitore è di tipo stagionale e non è stata selezionata alcuna data; se viene
  selezionata una data di consegna che è compresa in quella stagione - in questo caso primavera - verrà 
  applicato uno sconto del 11%;
- 166.000 euro per "Supplier C", che è il prezzo totale (1000 euro/pezzo), scontato del 17%, che è lo sconto sul
  totale che è stato associato a questo prodotto per questo fornitore.
  Selezionando la data del 29-10-2022 come data di consegna, viene escluso "Supplier B" perché ha un minimo di giorni
  di consegna pari a 10.

Nel file estrazione.sql è presente un'estrazione dei dati che permette di poter ipotizzare altri esempi.

#### supplier-hunter
Il progetto supplier-hunter è la parte UI della solution ed è una web app React.
#### myProject.bak
La struttura dati è rappresentata da un database relazionale sql chiamato "myProject".
I "protagonisti" sono "Products" e "Suppliers"; la loro relazione è rappresentata dalla tabella
"ProductsSuppliers", che crea appunto il legame tra prodotti e fornitori.
Ogni "ProductSupplier" può essere associato - dato non obbligatorio - ad un "Discount"; ogni fornitore
decide infatti se applicare uno sconto o meno su quel prodotto ed eventualmente quale tipo di sconto applicare.
Se lo sconto è sul totale, la percentuale di sconto è rappresentata dal campo "Percentage" della tabella "Discount";
se lo sconto è stagionale, il record nella tabella "Discount" avrà popolata la chiave esterna che lo associa ad una "Season"
e lo sconto applicato è quello indicato nella tabella "Discount";
infine se lo sconto dipende dalla quantità di pezzi dell'ordine, essendo molteplici le quantità associabili allo sconto, è stata 
costruita una tabella "Quantities" che collega lo sconto alle possibili quantità associate, con ognuna il rispettivo sconto; per esempio,
sul prodotto 1 posso applicare lo sconto del 5% se ho almeno 10 pezzi oppure lo sconto del 10% se ho almeno 50 pezzi; questi due casi 
sono rappresentati da due record nella tabella "Quantities" e lo sconto applicato è il campo "Percentage" di quest'ultima.
La tabella "ProductsSupplier" presenta anche il campo "MinShippingDays" che rappresenta il minimo dei giorni che il fornitore 
impiegherà per consegnare al cliente il prodotto in questione.
#### SupplierHunterEntities
Il progetto SupplierHunterEntities rappresenta le classi, oggetti con cui vengono costruiti i dati.
È stato utilizzato Entity Framework Core come ORM.
#### SupplierHunterService 
Il progetto SupplierHunterService rappresenta infine il servizio che permette di esporre le API alla web app. 
Il servizio è stato strutturato infatti in modo che, tramite API, la web app possa ottenere la lista dei prodotti registrati a database,
per poterli selezionare, e la lista dei fornitori che rispettano le caratteristiche di ricerca.
Il "ProductController" è la classe dove sono state costruite le API.

## Let's start the hunt
Per utilizzare il progetto è necessario disporre di:
- un server SQL, per restorare il database;
- visual studio per buildare il servizio e rendere le API disponibili alle chiamate;
- node.js e visual studio code per buildare la web app.

Purtroppo l'unico modo che conosco per "utilizzare" la web app è lo stesso da me utilizzato in fase di sviluppo, che prevede i seguenti passi:
- Eseguire il restore del backup fornito del database myProject;
- Aprire il file SupplierHunter.sln con Visual Studio e, dopo aver modificato adeguatamente il nome del server sql nella connection string presente nel file "appsetting.json" e "appsetting.Development", si esegue lo "start" dell'applicazione, su "IIS Express";
- Aprire la cartella supplier-hunter con Visual Studio Code e avviare la web app con il comando "npm start" da terminale: viene costruito infatti un server che mi permette di eseguire la web app.
