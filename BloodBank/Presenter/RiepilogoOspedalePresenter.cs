using System;
using BloodBank.View;
using System.Windows.Forms;
using BloodBank.Model;

namespace BloodBank.Presenter
{
    public class RiepilogoOspedalePresenter : Presenter
    {
        private RiepilogoOspedaleForm riepilogoOspedaleForm;

        public RiepilogoOspedalePresenter(RiepilogoOspedaleForm riepilogoOspedaleForm)
        {
            this.riepilogoOspedaleForm = riepilogoOspedaleForm;
            riepilogoOspedaleForm.Load += OnLoad;
            (riepilogoOspedaleForm.Controls["_comboBoxOspedali"] as ComboBox).SelectedValueChanged += OnSelectedValueChanged;
            riepilogoOspedaleForm.Controls["_buttonEsci"].Click += OnButtonClick;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            ComboBox comboOspedali = (riepilogoOspedaleForm.Controls["_comboBoxOspedali"] as ComboBox);
            foreach (Ospedale o in Modello.Ospedali)
                comboOspedali.Items.Add(o.Nome);
        }

        private void OnSelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox comboOspedali = (riepilogoOspedaleForm.Controls["_comboBoxOspedali"] as ComboBox);
            DataGridView dataGrid = riepilogoOspedaleForm.Controls["dataGridView1"] as DataGridView;
           
            Ospedale ospedale = null;
            string nomeOspedale;
            try
            {
                nomeOspedale = (string)comboOspedali.SelectedItem;

                foreach (Ospedale o in Modello.Ospedali)
                    if (o.Nome == nomeOspedale)
                        ospedale = o;
                if (dataGrid.RowCount > 0)
                {
                    dataGrid.Rows.Clear();
                    dataGrid.Refresh();
                }
                    foreach (Ordine o in ospedale.ListaOrdini)
                    {
                        dataGrid.Rows.Add(o.Data.ToString("dd-MM-yyyy"),o.IndicePriorita, o.Tipologia, o.GruppoSanguigno, o.NumeroSacche, "Evaso");
                    }
                    foreach (var value in Enum.GetValues(typeof(Tipologia)))
                    {
                        foreach(Ordine o in Modello.ListaDiAttesa.Ordini[Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("0-"))])
                            if(o.NomeOspedale == nomeOspedale)
                                dataGrid.Rows.Add(o.Data.ToString("dd-MM-yyyy"), o.IndicePriorita, o.Tipologia, o.GruppoSanguigno, o.NumeroSacche, "In attesa");
                        foreach (Ordine o in Modello.ListaDiAttesa.Ordini[Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("0+"))])
                            if (o.NomeOspedale == nomeOspedale)
                                dataGrid.Rows.Add(o.Data.ToString("dd-MM-yyyy"), o.IndicePriorita, o.Tipologia, o.GruppoSanguigno, o.NumeroSacche, "In attesa");
                        foreach (Ordine o in Modello.ListaDiAttesa.Ordini[Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("A-"))])
                            if (o.NomeOspedale == nomeOspedale)
                                dataGrid.Rows.Add(o.Data.ToString("dd-MM-yyyy"), o.IndicePriorita, o.Tipologia, o.GruppoSanguigno, o.NumeroSacche, "In attesa");
                        foreach (Ordine o in Modello.ListaDiAttesa.Ordini[Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("A+"))])
                            if (o.NomeOspedale == nomeOspedale)
                                dataGrid.Rows.Add(o.Data.ToString("dd-MM-yyyy"), o.IndicePriorita, o.Tipologia, o.GruppoSanguigno, o.NumeroSacche, "In attesa");
                        foreach (Ordine o in Modello.ListaDiAttesa.Ordini[Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("B-"))])
                            if (o.NomeOspedale == nomeOspedale)
                                dataGrid.Rows.Add(o.Data.ToString("dd-MM-yyyy"), o.IndicePriorita, o.Tipologia, o.GruppoSanguigno, o.NumeroSacche, "In attesa");
                        foreach (Ordine o in Modello.ListaDiAttesa.Ordini[Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("B+"))])
                            if (o.NomeOspedale == nomeOspedale)
                                dataGrid.Rows.Add(o.Data.ToString("dd-MM-yyyy"), o.IndicePriorita, o.Tipologia, o.GruppoSanguigno, o.NumeroSacche, "In attesa");
                        foreach (Ordine o in Modello.ListaDiAttesa.Ordini[Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("AB-"))])
                            if (o.NomeOspedale == nomeOspedale)
                                dataGrid.Rows.Add(o.Data.ToString("dd-MM-yyyy"), o.IndicePriorita, o.Tipologia, o.GruppoSanguigno, o.NumeroSacche, "In attesa");
                        foreach (Ordine o in Modello.ListaDiAttesa.Ordini[Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("AB+"))])
                            if (o.NomeOspedale == nomeOspedale)
                                dataGrid.Rows.Add(o.Data.ToString("dd-MM-yyyy"), o.IndicePriorita, o.Tipologia, o.GruppoSanguigno, o.NumeroSacche, "In attesa");
                    }
                    
                
            }
            catch(Exception exception)
            {
                return;
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            riepilogoOspedaleForm.Close();
        }

        protected override void OnModelChanged(object sender, EventArgs e)
        {
            //
        }
    }
}