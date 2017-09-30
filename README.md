# BloodBank Management Software
Requisiti del cliente
Si vuole realizzare un software per la gestione delle donazioni di sangue, plasma e
piastrine all’interno di una “banca del sangue”.
In particolare, si devono gestire i seguenti requisiti:
- La registrazione di un nuovo donatore; si deve memorizzare per ognuno di essi
il gruppo sanguigno (che può essere: 0-, 0+, A-, A+, B-, B+, AB-, AB+), nome,
cognome, CF, indirizzo completo, numero di telefono e la lista di eventi
riscontrati che possono portare alla sospensione dalla donazione. Per ogni
donatore si deve poter visualizzare un riepilogo dei suoi dati e delle sue
donazioni;
- Si devono gestire le donazioni registrando la data in cui vengono effettuate e la
relativa tipologia che può essere: di sangue, di piastrine o di plasma;
aggiornando di volta in volta il relativo numero di sacche disponibili nella banca
per ogni gruppo sanguigno;
- Le sacche contenitrici sono caratterizzate da un identificativo univoco, da un
gruppo sanguigno, dalla dimensione (450 ml per il sangue, 700 ml per il plasma
o 200 ml per le piastrine), dalle relative scadenze (49 giorni per il sangue, 5
giorni per le piastrine e 2 anni per il plasma) e da un riferimento al donatore
(CF). Le sacche scadute vengono giornalmente eliminate dal registro;
- Gli unici soggetti a poter richiedere il sangue raccolto sono gli ospedali, che
devono a loro volta essere registrati nel sistema (nome, indirizzo, responsabile);
- Ogni ordine effettuato da un ospedale può essere di tre tipi: plasma, sangue o
piastrine; inoltre si deve specificare il gruppo sanguigno desiderato e il numero
di sacche.
Nel caso in cui non fossero presenti le quantità necessarie, l’ordine sarà messo
in una lista di attesa, in base ad un indice di priorità definito come: basso, medio,
alto, urgente. Quando le quantità saranno disponibili, l’evento sarà notificato
all’operatore, che a quel punto potrà evadere l’ordine.
- Il software di gestione sarà utilizzato da un operatore che dovrà identificarsi
(con username e password) per poter accedere all’applicazione. Per ognuno di
essi si deve inoltre memorizzare nome, cognome, telefono; Nella struttura è
presente anche un responsabile che può effettuare le stesse operazioni di un
operatore normale ed in più è l’unico ad essere in grado di aggiungere e togliere
operatori.
Per ogni ordine inserito si deve tener traccia dell’operatore che l’ha effettuato.
