using System;
using BloodBank.View;
using System.Windows.Forms;
using BloodBank.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BloodBank.Presenter
{
    public class ModificaDonatore1Presenter : Presenter
    {
        private ModificaDonatoreForm1 _modificaDonatoreForm1;
        private ModificaDonatoreForm2 _modificaDonatoreForm2;
        private Donatore _donatore = null;
        private MainForm _mainForm;
        public ModificaDonatore1Presenter(ModificaDonatoreForm1 modificaDonatoreForm1, MainForm mainForm)
        {
            this._modificaDonatoreForm1 = modificaDonatoreForm1;
            _mainForm = mainForm;
            modificaDonatoreForm1.Controls["_textBoxNome"].TextChanged += OnTextChanged;
            modificaDonatoreForm1.Controls["_textBoxCognome"].TextChanged += OnTextChanged;
            (modificaDonatoreForm1.Controls["dataGridView1"] as DataGridView).SelectionChanged += OnSelectionChanged;
            modificaDonatoreForm1.Controls["_buttonAnnulla"].Click += OnButtonClick;
            modificaDonatoreForm1.Controls["_buttonConferma"].Click += OnButtonClick;
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            string nome = _modificaDonatoreForm1.Controls["_textBoxNome"].Text;
            string cognome = _modificaDonatoreForm1.Controls["_textBoxCognome"].Text;
            List<Donatore> donatori = new List<Donatore>();

            if (Regex.Match(nome, @"^[a-z,A-Z]*$").Success && Regex.Match(cognome, @"^[a-z,A-Z]*$").Success)
            {
                foreach (Donatore d in Modello.Donatori)
                    if (d.Nome.StartsWith(nome) && d.Cognome.StartsWith(cognome))
                        donatori.Add(d);

                if (donatori.Count > 0)
                {
                    DataGridView dataGrid = _modificaDonatoreForm1.Controls["dataGridView1"] as DataGridView;

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
            
            DataGridView dataGrid1 = _modificaDonatoreForm1.Controls["dataGridView1"] as DataGridView;
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
                if(_donatore == null)
                {
                    MessageBox.Show("Selezionare un donatore", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _modificaDonatoreForm1.Close();
                
                //modificaDonatore2Presenter.Modello = Modello;
                if (_modificaDonatoreForm2 == null)
                {
                    _modificaDonatoreForm2 = new ModificaDonatoreForm2();
                    _modificaDonatoreForm2.MdiParent = _mainForm;
                    _modificaDonatoreForm2.Load += Form_Loaded;
                    _modificaDonatoreForm2.FormClosed += modificaDonatoreForm2_FormClosed;
                    ModificaDonatore2Presenter modificaDonatore2Presenter = new ModificaDonatore2Presenter(_modificaDonatoreForm2, _donatore);
                    modificaDonatore2Presenter.Modello = Modello;
                   
                    _modificaDonatoreForm2.Show();
                }
            }
            else if(button.Name == "_buttonAnnulla")
                _modificaDonatoreForm1.Close();
        }

        private void Form_Loaded(object sender, EventArgs e)
        {
            foreach (Form frm in _mainForm.MdiChildren)
            {
                if (frm != sender)
                    frm.Close();

            }
        }

        private void modificaDonatoreForm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            _modificaDonatoreForm2 = null;
        }

        protected override void OnModelChanged(object sender, EventArgs e)
        {
            //
        }
    }
}