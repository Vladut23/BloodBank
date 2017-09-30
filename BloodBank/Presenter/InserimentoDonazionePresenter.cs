using System;
using BloodBank.View;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;
using BloodBank.Model;

namespace BloodBank.Presenter
{
    public class InserimentoDonazionePresenter : Presenter
    {
        private InserimentoDonazioneForm inserimentoDonazioneForm;
        SaccaContenitrice sacca = null;

        public InserimentoDonazionePresenter(InserimentoDonazioneForm inserimentoDonazioneForm)
        {
            this.inserimentoDonazioneForm = inserimentoDonazioneForm;
            inserimentoDonazioneForm.Controls["_textBoxNome"].TextChanged += OnTextChanged;
            inserimentoDonazioneForm.Controls["_textBoxCognome"].TextChanged += OnTextChanged;
            inserimentoDonazioneForm.Controls["_buttonSalva"].Click += OnButtonClick;
            inserimentoDonazioneForm.Controls["_buttonAnnulla"].Click += OnButtonClick;
            (inserimentoDonazioneForm.Controls["_comboBoxtipologia"] as ComboBox).SelectedIndexChanged += OnSelectedIndexChangedCombobox1;
            ComboBox comboTipologia = (inserimentoDonazioneForm.Controls["_comboBoxtipologia"] as ComboBox);
            foreach (Tipologia t in Enum.GetValues(typeof(Tipologia)))
                comboTipologia.Items.Add(t);
        }

        private void OnSelectedIndexChangedCombobox1(object sender, EventArgs e)
        {
            Donatore donatore = null;
            string CF;
            DataGridView dataGrid = inserimentoDonazioneForm.Controls["dataGridView1"] as DataGridView; 
            try
            {
                CF = dataGrid.SelectedRows[0].Cells[3].Value.ToString();
            }
            catch (ArgumentOutOfRangeException )
            {
                MessageBox.Show("Scegliere il donatore!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGrid.Focus();
                return;
            }

            foreach (Donatore d in Modello.Donatori)
                if (d.CodiceFiscale == CF)
                    donatore = d;
            DateTime dataPrelievo = (inserimentoDonazioneForm.Controls["_dateTimePickerDataPrelievo"] as DateTimePicker).Value.Date;
            Tipologia tipologia = (Tipologia)(inserimentoDonazioneForm.Controls["_comboBoxtipologia"] as ComboBox).SelectedItem;
            
            sacca = SaccaContenitriceFactory.getSaccaContenitrice(tipologia, CF, donatore.GruppoSanguigno, dataPrelievo);
            inserimentoDonazioneForm.Controls["_textBoxCodiceSacca"].Text = sacca.CodiceSacca;
            inserimentoDonazioneForm.Controls["_textBoxGruppoSanguigno"].Text = sacca.GruppoSanguigno.ToString();

        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            string nome = inserimentoDonazioneForm.Controls["_textBoxNome"].Text;
            string cognome = inserimentoDonazioneForm.Controls["_textBoxCognome"].Text;
            List<Donatore> donatori = new List<Donatore>();
           
            if (Regex.Match(nome, @"^[a-z,A-Z]*$").Success && Regex.Match(cognome, @"^[a-z,A-Z]*$").Success)
            {
                foreach (Donatore d in Modello.Donatori)
                    if ( d.Nome.StartsWith(nome) && d.Cognome.StartsWith(cognome) )
                        donatori.Add(d);
               
                if (donatori.Count > 0)
                {
                    DataGridView dataGrid = inserimentoDonazioneForm.Controls["dataGridView1"] as DataGridView;
                   
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
            Button button = (Button)sender;
            if (button.Name == "_buttonSalva")
            {
                Donatore donatore = null;
                DataGridView dataGrid = inserimentoDonazioneForm.Controls["dataGridView1"] as DataGridView;
                string CF;

                try {
                       CF = dataGrid.SelectedRows[0].Cells[3].Value.ToString();
                }catch(ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Scegliere il donatore!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    dataGrid.Focus();
                    return;
                }
               
                foreach (Donatore d in Modello.Donatori)
                    if (d.CodiceFiscale == CF)
                        donatore = d;

                DateTime dataPrelievo = (inserimentoDonazioneForm.Controls["_dateTimePickerDataPrelievo"] as DateTimePicker).Value.Date;

                if ((inserimentoDonazioneForm.Controls["_comboBoxtipologia"] as ComboBox).SelectedIndex <0)
                {
                    MessageBox.Show("Scegliere la tipologia!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    inserimentoDonazioneForm.Controls["_comboBoxtipologia"].Focus();
                    return;
                }

                Tipologia tipologia = (Tipologia)(inserimentoDonazioneForm.Controls["_comboBoxtipologia"] as ComboBox).SelectedItem;

                if (sacca != null)
                {
                    Donazione donazione = new Donazione(dataPrelievo, tipologia, Modello.OperatoreCorrente.Username);
                    Modello.InserisciDonazione(donazione, donatore);
                    inserimentoDonazioneForm.Close();
                }
                else
                { 
                    MessageBox.Show("Sacca non creata!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    inserimentoDonazioneForm.Controls["_textBoxNome"].Focus();
                    return;
                }
            }
            else if (button.Name == "_buttonAnnulla")
            {
                inserimentoDonazioneForm.Close();
            }
        }

        protected override void OnModelChanged(object sender, EventArgs e)
        {
            //
        }
    }
}