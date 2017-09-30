using BloodBank.Model;
using BloodBank.View;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System;

namespace BloodBank.Presenter
{
    internal class InserimentoEventoSospensivoPresenter : Presenter
    {
        private InserimentoEventoSospensivoForm inserimentoEventoSospensivoForm;
        private Donatore _donatore;
        string _evento;
        EventoSospensivo _eventoSospensivo;
        DateTime _dataFine;

        public InserimentoEventoSospensivoPresenter(InserimentoEventoSospensivoForm inserimentoEventoSospensivoForm)
        {
            this.inserimentoEventoSospensivoForm = inserimentoEventoSospensivoForm;
            inserimentoEventoSospensivoForm.Controls["_textBoxNome"].TextChanged += OnTextChanged;
            inserimentoEventoSospensivoForm.Controls["_textBoxCognome"].TextChanged += OnTextChanged;
            (inserimentoEventoSospensivoForm.Controls["dataGridView1"] as DataGridView).SelectionChanged += OnSelectionChanged;
            inserimentoEventoSospensivoForm.Controls["_buttonAnnulla"].Click += OnButtonClick;
            inserimentoEventoSospensivoForm.Controls["_buttonConferma"].Click += OnButtonClick;
            (inserimentoEventoSospensivoForm.Controls["comboBox1"] as ComboBox).SelectedValueChanged += OnValueChanged;
            inserimentoEventoSospensivoForm.Load += OnLoad;

        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            ComboBox comboEventi = inserimentoEventoSospensivoForm.Controls["comboBox1"] as ComboBox;
            _evento = comboEventi.SelectedItem as string;
            
        }

        private void OnLoad(object sender, EventArgs e)
        {
            ComboBox comboEventi = inserimentoEventoSospensivoForm.Controls["comboBox1"] as ComboBox;
            comboEventi.DataSource = CriterioDiSospensioneFactory.GetListaEventiSospensivi();
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            string nome = inserimentoEventoSospensivoForm.Controls["_textBoxNome"].Text;
            string cognome = inserimentoEventoSospensivoForm.Controls["_textBoxCognome"].Text;
            List<Donatore> donatori = new List<Donatore>();

            if (Regex.Match(nome, @"^[a-z,A-Z]*$").Success && Regex.Match(cognome, @"^[a-z,A-Z]*$").Success)
            {
                foreach (Donatore d in Modello.Donatori)
                    if (d.Nome.StartsWith(nome) && d.Cognome.StartsWith(cognome))
                        donatori.Add(d);

                if (donatori.Count > 0)
                {
                    DataGridView dataGrid = inserimentoEventoSospensivoForm.Controls["dataGridView1"] as DataGridView;

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

        private void OnSelectionChanged(object sender, EventArgs e)
        {

            DataGridView dataGrid1 = inserimentoEventoSospensivoForm.Controls["dataGridView1"] as DataGridView;
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
                    _donatore = d;

           }

        private void OnButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name == "_buttonConferma")
            {
                if (_donatore == null)
                {
                    MessageBox.Show("Selezionare un donatore", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(_evento == null)
                {
                    MessageBox.Show("Selezionare un evento sospensivo", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _dataFine = (inserimentoEventoSospensivoForm.Controls["dateTimePicker1"] as DateTimePicker).Value;

                if (_dataFine == null)
                {
                    MessageBox.Show("Selezionare una data di fine evento", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _eventoSospensivo = new EventoSospensivo(_evento, _dataFine);
                Modello.InserisciEventoSospensivo(_donatore, _eventoSospensivo);
                inserimentoEventoSospensivoForm.Close();
            }
            else if (button.Name == "_buttonAnnulla")
                inserimentoEventoSospensivoForm.Close();
        }

        protected override void OnModelChanged(object sender, EventArgs e)
        {
            
        }
    }
}