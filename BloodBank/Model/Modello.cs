using BloodBank.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank.Model
{
    public class Modello
    {
        public event EventHandler Changed;

        private IPersistence _persistenza;
        private Operatore _operatoreCorrente;
        private List<Donatore> _donatori;
        private List<Ospedale> _ospedali;
        private List<Operatore> _operatori;
        private ListaAttesa _listaDiAttesa;
        private Dictionary<Tuple<Tipologia, GruppoSanguigno>, List<SaccaContenitrice>> _sacche;

        public IPersistence Persistenza
        {
            get
            {
                return _persistenza;
            }

            set
            {
                _persistenza = value;
            }
        }

        public Operatore OperatoreCorrente
        {
            get
            {
                return _operatoreCorrente;
            }

            set
            {
                _operatoreCorrente = value;
            }
        }

        public List<Donatore> Donatori
        {
            get
            {
                return _donatori;
            }

            set
            {
                _donatori = value;
            }
        }

        public List<Ospedale> Ospedali
        {
            get
            {
                return _ospedali;
            }

            set
            {
                _ospedali = value;
            }
        }

        public List<Operatore> Operatori
        {
            get
            {
                return _operatori;
            }

            set
            {
                _operatori = value;
            }
        }

        public ListaAttesa ListaDiAttesa
        {
            get
            {
                return _listaDiAttesa;
            }

            set
            {
                _listaDiAttesa = value;
            }
        }

        public Dictionary<Tuple<Tipologia, GruppoSanguigno>, List<SaccaContenitrice>> Sacche
        {
            get
            {
                return _sacche;
            }

            set
            {
                _sacche = value;
            }
        }

        public Modello(IPersistence persistenza)
        {
            Persistenza = persistenza;
            Popolati();
        }

        

        public bool ControllaCredenziali(string username, string password)
        {
            foreach(Operatore o in Operatori)
            {
                if(o.Username == username && o.Password == password)
                {
                    OperatoreCorrente = o;
                    return true;
                }
            }
            return false;
        }

        //---------------------------------------------------------------------------

        public bool InserisciDonatore(Donatore donatore)
        {
            foreach (Donatore d in Donatori)
                if (d.CodiceFiscale == donatore.CodiceFiscale)
                    return false;

            Donatori.Add(donatore);
            return true;
        }

        public bool InserisciOspedale(Ospedale ospedale)
        {
            foreach (Ospedale o in Ospedali)
                if (o.Nome == ospedale.Nome)
                    return false;

            Ospedali.Add(ospedale);
            return true;
        }

        public bool InserisciOperatore(Operatore operatore)
        {
            foreach (Operatore o in Operatori)
                if (o.Username == operatore.Username)
                    return false;

            Operatori.Add(operatore);
            return true;
        }

        // vero se evade subito
        // falso se viene inserito nella lista di attesa
        public bool InserisciOrdine(Ordine ordine)
        {
            bool result = false;
            int saccheDisponibili = 0;

            foreach (GruppoSanguigno gruppo in ordine.GruppoSanguigno.GetGruppiCompatibili())
            {
                saccheDisponibili += Sacche[Tuple.Create(ordine.Tipologia, gruppo)].Count;
            }

            if (saccheDisponibili >= ordine.NumeroSacche)
            {
                Ospedale o = (from osp in Ospedali
                              where osp.Nome == ordine.NomeOspedale
                              select osp).Single();

                foreach (GruppoSanguigno gruppo in ordine.GruppoSanguigno.GetGruppiCompatibili())
                {
                    List<SaccaContenitrice> saccheUtilizzate = new List<SaccaContenitrice>();
                    if (saccheDisponibili > 0)
                    {
                        foreach (SaccaContenitrice sacca in Sacche[Tuple.Create(ordine.Tipologia, gruppo)])
                        {
                            if (saccheDisponibili > 0)
                            {
                                saccheUtilizzate.Add(sacca);
                                saccheDisponibili--;
                            }
                            else
                                break;
                        }
                        foreach (SaccaContenitrice s in saccheUtilizzate)
                        {
                            ordine.ListaSacche.Add(s.CodiceSacca);
                            Sacche[Tuple.Create(ordine.Tipologia, gruppo)].Remove(s);
                        }
                    }
                    else
                        break;
                }
                o.ListaOrdini.Add(ordine);
                result = true;
            }
            else
            {
                ListaDiAttesa.AggiungiOrdinePerPriorita(ordine);
                result = false;
            }
            return result;
        }

        internal void InserisciEventoSospensivo(Donatore donatore, EventoSospensivo evento)
        {
            donatore.EventiSospensivi.Add(evento);
        }

        public void InserisciDonazione(Donazione donazione, Donatore donatore)
        {
            
            Donatore d = (from don in Donatori
                          where don.CodiceFiscale == donatore.CodiceFiscale
                          select don).Single();
            if(donazione.Tipologia == Tipologia.sangue)
            {
                if (d.IsAbilitatoADonareSangue() == false)
                {
                    MessageBox.Show("Il donatore non è momentaneamente abilitato a donare sangue", "Errore",
                                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }else
            {
                if (d.IsAbilitatoADonarePlasmaPiastrine() == false)
                {
                    MessageBox.Show("Il donatore non è momentaneamente abilitato a donare plasma e piastrine", "Errore",
                                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
           

            d.Donazioni.Add(donazione);
            Sacche[Tuple.Create(donazione.Tipologia, donatore.GruppoSanguigno)].Add(SaccaContenitriceFactory.getSaccaContenitrice(donazione.Tipologia, donatore.CodiceFiscale, donatore.GruppoSanguigno, donazione.DataPrelievo));

            Ordine ordineDaEvadere = PossibilitaEvasione(donazione.Tipologia, donatore.GruppoSanguigno);
            if (ordineDaEvadere != null)
            {
              
                String mess =   "Possibilità evasione" + 
                                "\nOrdine del ospedale: " + ordineDaEvadere.NomeOspedale +
                                "\nTipologia: " + ordineDaEvadere.Tipologia +
                                "\nGruppo Sanguigno: " + ordineDaEvadere.GruppoSanguigno +
                                "\nNumero Sacche: " + ordineDaEvadere.NumeroSacche +
                                "\n\nVuoi evaderlo?";
                DialogResult response;
                response = MessageBox.Show(mess, "Evasione ordine",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(response == DialogResult.Yes)
                {
                    InserisciOrdine(ordineDaEvadere);
                    ListaDiAttesa.RimuoviOrdine(ordineDaEvadere);
                }
                
            }
        }

        // ---------------------------------------------------------------------------

        public void ModificaOspedale(Ospedale ospedale) { }

        public void ModificaOperatore(Operatore operatore) { }

        public void ModificaOrdine(Ordine ordine) { }

        public void ModificaDonazione(Donazione donazione, Donatore donatore) { }

        //----------------------------------------------------------------------------

        public void EliminaDonatore(Donatore donatore)
        {
            foreach (Donazione d in donatore.Donazioni)
                EliminaDonazione(d, donatore);
            Donatori.Remove(donatore);
        }

        public void EliminaOspedale(Ospedale ospedale)
        {
            // non implementato
        }

        public void EliminaOperatore(Operatore operatore)
        {
            Operatori.Remove(operatore);
        }

        public void EliminaOrdine(Ordine ordine)
        {
            ListaDiAttesa.RimuoviOrdine(ordine);
        }

        public void EliminaDonazione(Donazione donazione, Donatore donatore)
        {
            foreach(SaccaContenitrice sacca in Sacche[Tuple.Create(donazione.Tipologia, donatore.GruppoSanguigno)]){
                if (sacca.CFDonatore == donatore.CodiceFiscale && sacca.DataCreazione == donazione.DataPrelievo)
                    Sacche[Tuple.Create(donazione.Tipologia, donatore.GruppoSanguigno)].Remove(sacca);
            }
            donatore.Donazioni.Remove(donazione);
        }

        //----------------------------------------------------------------------------

        // null se non c'è
        private Ordine PossibilitaEvasione(Tipologia tipologia, GruppoSanguigno gruppoSanguigno)
        {

            List<Ordine> possibiliOrdiniDaEvadere = new List<Ordine>();
            foreach (GruppoSanguigno gruppo in gruppoSanguigno.GetGruppiCompatibili())
            {
                if(ListaDiAttesa.Ordini[Tuple.Create(tipologia, gruppo)].Count > 0)
                    possibiliOrdiniDaEvadere.Add(ListaDiAttesa.Ordini[Tuple.Create(tipologia, gruppo)].First());
            }
            possibiliOrdiniDaEvadere.Sort((x, y) => x.Data.CompareTo(y.Data));
            if (possibiliOrdiniDaEvadere.Count == 0)
                return null;
            
            Ordine ordineDaEvadere = possibiliOrdiniDaEvadere.First();
                
            int saccheDisponibili = 0;
            foreach (GruppoSanguigno gruppo in ordineDaEvadere.GruppoSanguigno.GetGruppiCompatibili())
            {
                saccheDisponibili += Sacche[Tuple.Create(ordineDaEvadere.Tipologia, gruppo)].Count;
            }

            if (saccheDisponibili >= ordineDaEvadere.NumeroSacche)
            {
                return ordineDaEvadere;
            }
            else
                return null;

        }

        public List<SaccaContenitrice> GetSaccheScadute()
        {
            List<SaccaContenitrice> saccheScadute = new List<SaccaContenitrice>();

            foreach (var value in Enum.GetValues(typeof(Tipologia)))
            {
                foreach(GruppoSanguigno g in GruppoSanguignoFactory.GetListaGruppi())
                {
                    foreach (SaccaContenitrice s in Sacche[Tuple.Create((Tipologia)value, g)].ToList<SaccaContenitrice>())
                        if (s.GetDataScadenza() <= DateTime.Now)
                        {
                            saccheScadute.Add(s);
                            Sacche[Tuple.Create((Tipologia)value, g)].Remove(s);
                        }
                }
            }
            return saccheScadute;
        }
    
        private void Popolati()
        {
            Donatori = Persistenza.GetDonatori();
            Ospedali = Persistenza.GetOspedali();
            Operatori = Persistenza.GetOperatori();
            ListaDiAttesa = Persistenza.GetListaDiAttesa();
            Sacche = Persistenza.GetSacche();
        }

        private void RenditiPersistente()
        {
            Persistenza.RendiPersistente(this);
        }

        protected virtual void OnChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
            RenditiPersistente();
        }
       
    }
}
