using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model;

namespace BloodBank.Persistence
{
    public class Persistenza : IPersistence
    {
       
        private List<Donatore> _donatori;
        private List<Ospedale> _ospedali;
        private List<Operatore> _operatori;
        private ListaAttesa _listaDiAttesa;
        private Dictionary<Tuple<Tipologia, GruppoSanguigno>, List<SaccaContenitrice>> _sacche;

        public Persistenza()
        {
            _operatori = new List<Operatore>();
            _donatori = new List<Donatore>();
            _sacche = new Dictionary<Tuple<Tipologia, GruppoSanguigno>, List<SaccaContenitrice>>();
            _ospedali = new List<Ospedale>();
            _listaDiAttesa = new ListaAttesa();

            foreach(var value in Enum.GetValues(typeof(Tipologia)))
            {
                _sacche.Add(Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("0-")), new List<SaccaContenitrice>());
                _sacche.Add(Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("0+")), new List<SaccaContenitrice>());
                _sacche.Add(Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("A-")), new List<SaccaContenitrice>());
                _sacche.Add(Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("A+")), new List<SaccaContenitrice>());
                _sacche.Add(Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("B-")), new List<SaccaContenitrice>());
                _sacche.Add(Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("B+")), new List<SaccaContenitrice>());
                _sacche.Add(Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("AB-")), new List<SaccaContenitrice>());
                _sacche.Add(Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("AB+")), new List<SaccaContenitrice>());
            }


            Operatore operatore1 = new Responsabile("admin", "admin", "Vladut", "Valeanu");
            Operatore operatore2 = new Operatore("oper1", "1234", "Lorenzo", "Castagnini");

            _operatori.Add(operatore1);
            _operatori.Add(operatore2);
            
            Donatore donatore1 = new Donatore("AAABCD19BNDKO19J", "Luca", "Babino", "012023245", "carlo.babaino@gmail.com",
                          new DateTime(1995, 4, 23),
                          75,
                          new Indirizzo("Bologna", "Bo", "40025", "via Mazzini", 80, "Italia"),
                          Sesso.M,
                          GruppoSanguignoFactory.GetGruppoSanguigno("A-"));
            donatore1.EventiSospensivi.Add(new EventoSospensivo("Influenza", new DateTime(2017, 1, 27)));
            donatore1.Donazioni.Add(new Donazione(new DateTime(2017, 3, 13), Tipologia.sangue, operatore1.Username));
            _sacche[Tuple.Create(Tipologia.sangue, donatore1.GruppoSanguigno)].Add
                        (SaccaContenitriceFactory.getSaccaContenitrice(Tipologia.sangue, donatore1.CodiceFiscale, donatore1.GruppoSanguigno, new DateTime(2017, 3, 13)));

            Donatore donatore2 = new Donatore("DVBHJNJKSDNJSDF", "Sara", "Carlaio", "782953210", "sara.carlai@gmail.com",
                         new DateTime(1994, 4, 23),
                         55,
                         new Indirizzo("Castello", "Bo", "40024", "via Orti", 30, "Italia"),
                         Sesso.F,
                         GruppoSanguignoFactory.GetGruppoSanguigno("AB+"));
           
            donatore2.Donazioni.Add(new Donazione(new DateTime(2017, 3, 20), Tipologia.piastrine, operatore2.Username));
            _sacche[Tuple.Create(Tipologia.piastrine, donatore2.GruppoSanguigno)].Add
                        ( SaccaContenitriceFactory.getSaccaContenitrice(Tipologia.sangue, donatore2.CodiceFiscale, donatore2.GruppoSanguigno, new DateTime(2017, 3, 20)));

            Donatore donatore3 = new Donatore("CVBBJNAKSGNJSQB", "Luca", "Zibi", "74853110", "luca.zibi@gmail.com",
                        new DateTime(1989, 12, 1),
                        89,
                        new Indirizzo("Imola", "Bo", "40031", "via dell'Infinito", 41, "Italia"),
                        Sesso.M,
                        GruppoSanguignoFactory.GetGruppoSanguigno("0-"));
            donatore3.EventiSospensivi.Add(new EventoSospensivo("Tatuaggio", new DateTime(2017, 5, 1)));
            donatore3.Donazioni.Add(new Donazione(new DateTime(2017, 1, 15), Tipologia.plasma, operatore2.Username));
            _sacche[Tuple.Create(Tipologia.plasma, donatore3.GruppoSanguigno)].Add
                         (SaccaContenitriceFactory.getSaccaContenitrice(Tipologia.plasma, donatore3.CodiceFiscale, donatore3.GruppoSanguigno, new DateTime(2017, 1, 15)));


            _donatori.Add(donatore1);
            _donatori.Add(donatore2);
            _donatori.Add(donatore3);

            Ospedale ospedale1 = new Ospedale("Ospedale Bellaria", "051456678", "bellaria@ospedale.it", "Gianluca Mazzoni",
                                              new Indirizzo("Bologna", "BO", "40100", "via Altura", 40, "Italia"));
            Ordine ordine1 = new Ordine("Ospedale Maggiore", new DateTime(2017, 6, 20), Tipologia.sangue, GruppoSanguignoFactory.GetGruppoSanguigno("A-"), 1, IndicePriorita.Medio, operatore1);
            ordine1.ListaSacche.Add("SAN00345");
            ospedale1.ListaOrdini.Add(ordine1);

            Ospedale ospedale2 = new Ospedale("Ospedale Maggiore", "051456348", "maggiore@ospedale.it", "Paolo Rossi",
                                             new Indirizzo("Bologna", "BO", "40100", "via Emilia", 100, "Italia"));
            Ordine ordine2 = new Ordine("Ospedale Bellaria", new DateTime(2017, 5, 20), Tipologia.piastrine, GruppoSanguignoFactory.GetGruppoSanguigno("AB+"), 1, IndicePriorita.Alto, operatore2);
            ordine2.ListaSacche.Add("PIA00045");
            ospedale2.ListaOrdini.Add(ordine2);

            Ospedale ospedale3 = new Ospedale("Ospedale Sant'Orsola", "0514563124", "orsola@ospedale.it", "Giulio Verdi",
                                             new Indirizzo("Bologna", "BO", "40100", "via Baglioni", 31, "Italia"));
            Ordine ordine3 = new Ordine("Ospedale Sant'Orsola", new DateTime(2017, 6, 22), Tipologia.plasma, GruppoSanguignoFactory.GetGruppoSanguigno("B-"), 1, IndicePriorita.Basso, operatore1);
            ordine3.ListaSacche.Add("PLA00237");
            ospedale3.ListaOrdini.Add(ordine3);

            _ospedali.Add(ospedale1);
            _ospedali.Add(ospedale2);
            _ospedali.Add(ospedale3);

            Ordine ordine = new Ordine("Ospedale Bellaria", new DateTime(2017, 6, 20), Tipologia.plasma, GruppoSanguignoFactory.GetGruppoSanguigno("AB+"), 2, IndicePriorita.Alto, operatore2);
            _listaDiAttesa.AggiungiOrdinePerPriorita(ordine);

        }

        public List<Donatore> GetDonatori()
        {
            return _donatori;
        }

        public ListaAttesa GetListaDiAttesa()
        {
            return _listaDiAttesa;
        }

        public List<Operatore> GetOperatori()
        {
            return _operatori;
        }

        public List<Ospedale> GetOspedali()
        {
            return _ospedali;
        }

        public Dictionary<Tuple<Tipologia, GruppoSanguigno>, List<SaccaContenitrice>> GetSacche()
        {
            return _sacche;
        }

        public void RendiPersistente(Modello model)
        {
            //Non fa nulla
        }
    }
}
