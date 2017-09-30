using System;
using BloodBank.View;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BloodBank.Model;
using System.Collections.Generic;

namespace BloodBank.Presenter
{
    public class RiepilogoDonatorePresenter : Presenter
    {
        private RiepilogoDonatoreForm riepilogoDonatoreForm;

        public RiepilogoDonatorePresenter(RiepilogoDonatoreForm riepilogoDonatoreForm)
        {
            this.riepilogoDonatoreForm = riepilogoDonatoreForm;
            riepilogoDonatoreForm.Controls["_buttonEsci"].Click += OnButtonClick;
            riepilogoDonatoreForm.Controls["_textBoxNome"].TextChanged += OnTextChanged;
            riepilogoDonatoreForm.Controls["_textBoxCognome"].TextChanged += OnTextChanged;
            (riepilogoDonatoreForm.Controls["dataGridView1"] as DataGridView).SelectionChanged += OnSelectionChanged;
        }

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            Donatore donatore = null;
            DataGridView dataGrid1 = riepilogoDonatoreForm.Controls["dataGridView1"] as DataGridView;
            string CF;

            try
            {
                CF = dataGrid1.SelectedRows[0].Cells[3].Value.ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

            foreach (Donatore d in Modello.Donatori)
                if (d.CodiceFiscale == CF)
                    donatore = d;

            if (donatore.Donazioni.Count > 0)
            {
                DataGridView dataGrid2 = riepilogoDonatoreForm.Controls["dataGridView2"] as DataGridView;

                if (dataGrid2.RowCount > 0)
                {
                    dataGrid2.Rows.Clear();
                    dataGrid2.Refresh();
                }
                foreach (Donazione d in donatore.Donazioni)
                {
                    dataGrid2.Rows.Add(d.DataPrelievo.ToString("dd-MM-yyyy"), d.Tipologia);
                }
               
            }
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            string nome = riepilogoDonatoreForm.Controls["_textBoxNome"].Text;
            string cognome = riepilogoDonatoreForm.Controls["_textBoxCognome"].Text;
            List<Donatore> donatori = new List<Donatore>();

            if (Regex.Match(nome, @"^[a-z,A-Z]*$").Success && Regex.Match(cognome, @"^[a-z,A-Z]*$").Success)
            {
                foreach (Donatore d in Modello.Donatori)
                    if (d.Nome.StartsWith(nome) && d.Cognome.StartsWith(cognome))
                        donatori.Add(d);

                if (donatori.Count > 0)
                {
                    DataGridView dataGrid = riepilogoDonatoreForm.Controls["dataGridView1"] as DataGridView;

                    if (dataGrid.RowCount > 0)
                    {
                        dataGrid.Rows.Clear();
                        dataGrid.Refresh();
                    }
                    foreach (Donatore d in donatori)
                    {
                        dataGrid.Rows.Add(d.Nome, d.Cognome, d.DataDiNascita.ToString("dd-MM-yyyy"), d.CodiceFiscale);
                    }
                   
                }
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            riepilogoDonatoreForm.Close();
        }

        protected override void OnModelChanged(object sender, EventArgs e)
        {
           //
        }
    }
}