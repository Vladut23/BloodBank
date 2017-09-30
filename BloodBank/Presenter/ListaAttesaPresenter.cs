using System;
using BloodBank.View;
using System.Windows.Forms;
using BloodBank.Model;

namespace BloodBank.Presenter
{
    public class ListaAttesaPresenter : Presenter
    {
        private ListaAttesaForm listaAttesaForm;

        public ListaAttesaPresenter(ListaAttesaForm listaAttesaForm)
        {
            this.listaAttesaForm = listaAttesaForm;
            listaAttesaForm.Load += OnLoad;
            listaAttesaForm.Controls["_buttonEsci"].Click += OnButtonClick;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            DataGridView dataGrid = listaAttesaForm.Controls["dataGridView1"] as DataGridView;

            if (dataGrid.RowCount > 0)
            {
                dataGrid.Rows.Clear();
                dataGrid.Refresh();
            }

            foreach (var value in Enum.GetValues(typeof(Tipologia)))
            {
                foreach (Ordine o in Modello.ListaDiAttesa.Ordini[Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("0-"))])
                        dataGrid.Rows.Add(o.Data.ToString("dd-MM-yyyy"), o.IndicePriorita, o.Tipologia, o.GruppoSanguigno, o.NumeroSacche, o.NomeOspedale);
                foreach (Ordine o in Modello.ListaDiAttesa.Ordini[Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("0+"))])        
                        dataGrid.Rows.Add(o.Data.ToString("dd-MM-yyyy"), o.IndicePriorita, o.Tipologia, o.GruppoSanguigno, o.NumeroSacche, o.NomeOspedale);
                foreach (Ordine o in Modello.ListaDiAttesa.Ordini[Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("A-"))])                  
                        dataGrid.Rows.Add(o.Data.ToString("dd-MM-yyyy"), o.IndicePriorita, o.Tipologia, o.GruppoSanguigno, o.NumeroSacche, o.NomeOspedale);
                foreach (Ordine o in Modello.ListaDiAttesa.Ordini[Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("A+"))])
                        dataGrid.Rows.Add(o.Data.ToString("dd-MM-yyyy"), o.IndicePriorita, o.Tipologia, o.GruppoSanguigno, o.NumeroSacche, o.NomeOspedale);
                foreach (Ordine o in Modello.ListaDiAttesa.Ordini[Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("B-"))])                
                        dataGrid.Rows.Add(o.Data.ToString("dd-MM-yyyy"), o.IndicePriorita, o.Tipologia, o.GruppoSanguigno, o.NumeroSacche, o.NomeOspedale);
                foreach (Ordine o in Modello.ListaDiAttesa.Ordini[Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("B+"))])                
                        dataGrid.Rows.Add(o.Data.ToString("dd-MM-yyyy"), o.IndicePriorita, o.Tipologia, o.GruppoSanguigno, o.NumeroSacche, o.NomeOspedale);
                foreach (Ordine o in Modello.ListaDiAttesa.Ordini[Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("AB-"))])               
                        dataGrid.Rows.Add(o.Data.ToString("dd-MM-yyyy"), o.IndicePriorita, o.Tipologia, o.GruppoSanguigno, o.NumeroSacche, o.NomeOspedale);
                foreach (Ordine o in Modello.ListaDiAttesa.Ordini[Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("AB+"))])
                        dataGrid.Rows.Add(o.Data.ToString("dd-MM-yyyy"), o.IndicePriorita, o.Tipologia, o.GruppoSanguigno, o.NumeroSacche, o.NomeOspedale);
            }

        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            listaAttesaForm.Close();
        }

        protected override void OnModelChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}