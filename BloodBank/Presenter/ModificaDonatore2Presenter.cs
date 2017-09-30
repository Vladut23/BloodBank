using BloodBank.Model;
using BloodBank.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank.Presenter
{
    public class ModificaDonatore2Presenter : Presenter
    {
        private ModificaDonatoreForm2 modificaDonatoreForm2;
        private Donatore _donatore;

        public ModificaDonatore2Presenter(ModificaDonatoreForm2 modificaDonatoreForm2, Donatore donatore)
        {
            this.modificaDonatoreForm2 = modificaDonatoreForm2;
            _donatore = donatore;
            modificaDonatoreForm2.Controls["_buttonSalva"].Click += OnButtonClick;
            modificaDonatoreForm2.Controls["_buttonAnnulla"].Click += OnButtonClick;
            modificaDonatoreForm2.Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            modificaDonatoreForm2.Controls["_textBoxNome"].Text = _donatore.Nome;
            modificaDonatoreForm2.Controls["_textBoxCognome"].Text = _donatore.Cognome;
            modificaDonatoreForm2.Controls["_textBoxCF"].Text = _donatore.CodiceFiscale;
            modificaDonatoreForm2.Controls["_textBoxTelefono"].Text = _donatore.Telefono;
            modificaDonatoreForm2.Controls["_textBoxEmail"].Text = _donatore.Email;
            modificaDonatoreForm2.Controls["_textBoxVia"].Text = _donatore.Indirizzo.Via;
            modificaDonatoreForm2.Controls["_textBoxNumero"].Text = _donatore.Indirizzo.NumeroCivico.ToString();
            modificaDonatoreForm2.Controls["_textBoxCAP"].Text = _donatore.Indirizzo.Cap;
            modificaDonatoreForm2.Controls["_textBoxCitta"].Text = _donatore.Indirizzo.Città;
            modificaDonatoreForm2.Controls["_textBoxProvincia"].Text = _donatore.Indirizzo.Provincia;
            modificaDonatoreForm2.Controls["_textBoxNazione"].Text = _donatore.Indirizzo.Nazione;
            (modificaDonatoreForm2.Controls["_dateTimePickerDataNascita"] as DateTimePicker).Value = _donatore.DataDiNascita;
            if(_donatore.Sesso == Sesso.M)
            {
                (modificaDonatoreForm2.Controls["_checkBoxMaschio"] as CheckBox).Checked = true;
                (modificaDonatoreForm2.Controls["_checkBoxFemmina"] as CheckBox).Checked = false;

            }
            else
            {
                (modificaDonatoreForm2.Controls["_checkBoxMaschio"] as CheckBox).Checked = false;
                (modificaDonatoreForm2.Controls["_checkBoxFemmina"] as CheckBox).Checked = true;
            }

            modificaDonatoreForm2.Controls["_textBoxPeso"].Text = _donatore.Peso.ToString();

            (modificaDonatoreForm2.Controls["_comboBoxGruppoSanguigno"] as ComboBox).Items.Add("0-");
            (modificaDonatoreForm2.Controls["_comboBoxGruppoSanguigno"] as ComboBox).Items.Add("0+");
            (modificaDonatoreForm2.Controls["_comboBoxGruppoSanguigno"] as ComboBox).Items.Add("A-");
            (modificaDonatoreForm2.Controls["_comboBoxGruppoSanguigno"] as ComboBox).Items.Add("A+");
            (modificaDonatoreForm2.Controls["_comboBoxGruppoSanguigno"] as ComboBox).Items.Add("B-");
            (modificaDonatoreForm2.Controls["_comboBoxGruppoSanguigno"] as ComboBox).Items.Add("B+");
            (modificaDonatoreForm2.Controls["_comboBoxGruppoSanguigno"] as ComboBox).Items.Add("AB-");
            (modificaDonatoreForm2.Controls["_comboBoxGruppoSanguigno"] as ComboBox).Items.Add("AB+");
            (modificaDonatoreForm2.Controls["_comboBoxGruppoSanguigno"] as ComboBox).SelectedItem = _donatore.GruppoSanguigno.ToString();
            modificaDonatoreForm2.Show();
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name == "_buttonSalva")
            {
                string nome = modificaDonatoreForm2.Controls["_textBoxNome"].Text;
                string cognome = modificaDonatoreForm2.Controls["_textBoxCognome"].Text;
                string CF = modificaDonatoreForm2.Controls["_textBoxCF"].Text;
                if (!Regex.Match(CF, @"^[0-9, A-Z, a-z]{16}$").Success)
                {
                    MessageBox.Show("CF non valido!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    modificaDonatoreForm2.Controls["_textBoxCF"].Focus();
                    return;
                }
                string telefono = modificaDonatoreForm2.Controls["_textBoxTelefono"].Text;
                if (!Regex.Match(telefono, @"^[0-9]{8,12}$").Success)
                {
                    MessageBox.Show("Telefono non valido!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    modificaDonatoreForm2.Controls["_textBoxTelefono"].Focus();
                    return;
                }
                string email = modificaDonatoreForm2.Controls["_textBoxEmail"].Text;
                if (!Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
                {
                    MessageBox.Show("Email non valido!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    modificaDonatoreForm2.Controls["_textBoxEmail"].Focus();
                    return;
                }
                string via = modificaDonatoreForm2.Controls["_textBoxVia"].Text;
                string numero = modificaDonatoreForm2.Controls["_textBoxNumero"].Text;
                string CAP = modificaDonatoreForm2.Controls["_textBoxCAP"].Text;
                if (!Regex.Match(CAP, @"^[0-9]{5}$").Success)
                {
                    MessageBox.Show("CAP non valido!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    modificaDonatoreForm2.Controls["_textBoxCAP"].Focus();
                    return;
                }
                string citta = modificaDonatoreForm2.Controls["_textBoxCitta"].Text;
                string provincia = modificaDonatoreForm2.Controls["_textBoxProvincia"].Text;
                string nazione = modificaDonatoreForm2.Controls["_textBoxNazione"].Text;
                DateTime dataDiNascita = (modificaDonatoreForm2.Controls["_dateTimePickerDataNascita"] as DateTimePicker).Value.Date;
                Sesso sesso;
                if ((modificaDonatoreForm2.Controls["_checkBoxMaschio"] as CheckBox).Checked == true)
                    sesso = Sesso.M;
                else
                    sesso = Sesso.F;
                string peso = modificaDonatoreForm2.Controls["_textBoxPeso"].Text;

                string gruppoSanguigno = (modificaDonatoreForm2.Controls["_comboBoxGruppoSanguigno"] as ComboBox).SelectedItem as string;

                _donatore.CodiceFiscale = CF;
                _donatore.Nome = nome;
                _donatore.Cognome = cognome;
                _donatore.Telefono = telefono;
                _donatore.Email = email;
                _donatore.DataDiNascita = dataDiNascita;
                _donatore.Peso = float.Parse(peso);
                _donatore.Indirizzo = new Indirizzo(citta, provincia, CAP, via, int.Parse(numero), nazione);
                _donatore.Sesso = sesso;
                _donatore.GruppoSanguigno = GruppoSanguignoFactory.GetGruppoSanguigno(gruppoSanguigno);
                modificaDonatoreForm2.Close();
            }
            else if (button.Name == "_buttonAnnulla")
            {
                modificaDonatoreForm2.Close();
            }
        }

        protected override void OnModelChanged(object sender, EventArgs e)
        {
            //
        }
    }
}
