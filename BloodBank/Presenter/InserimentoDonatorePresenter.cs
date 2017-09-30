using System;
using BloodBank.View;
using System.Windows.Forms;
using BloodBank.Model;
using System.Text.RegularExpressions;

namespace BloodBank.Presenter
{
    public class InserimentoDonatorePresenter : Presenter
    {
        private InserimentoDonatoreForm inserimentoDonatoreForm;

        public InserimentoDonatorePresenter(InserimentoDonatoreForm inserimentoDonatoreForm)
        {
            this.inserimentoDonatoreForm = inserimentoDonatoreForm;
            inserimentoDonatoreForm.Controls["_buttonSalva"].Click += OnButtonClick;
            inserimentoDonatoreForm.Controls["_buttonAnnulla"].Click += OnButtonClick;
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name == "_buttonSalva")
            {
                string nome = inserimentoDonatoreForm.Controls["_textBoxNome"].Text;
                string cognome = inserimentoDonatoreForm.Controls["_textBoxCognome"].Text;
                string CF = inserimentoDonatoreForm.Controls["_textBoxCF"].Text;
                if (!Regex.Match(CF, @"^[0-9, A-Z, a-z]{16}$").Success)
                {
                    MessageBox.Show("CF non valido!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    inserimentoDonatoreForm.Controls["_textBoxCF"].Focus();
                    return;
                }
                string telefono = inserimentoDonatoreForm.Controls["_textBoxTelefono"].Text;
                if(!Regex.Match(telefono, @"^[0-9]{8,12}$").Success)
                {
                    MessageBox.Show("Telefono non valido!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    inserimentoDonatoreForm.Controls["_textBoxTelefono"].Focus();
                    return;
                }
                string email = inserimentoDonatoreForm.Controls["_textBoxEmail"].Text;
                if (!Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
                {
                    MessageBox.Show("Email non valido!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    inserimentoDonatoreForm.Controls["_textBoxEmail"].Focus();
                    return;
                }
                string via = inserimentoDonatoreForm.Controls["_textBoxVia"].Text;
                string numero = inserimentoDonatoreForm.Controls["_textBoxNumero"].Text;
                string CAP = inserimentoDonatoreForm.Controls["_textBoxCAP"].Text;
                if (!Regex.Match(CAP, @"^[0-9]{5}$").Success)
                {
                    MessageBox.Show("CAP non valido!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    inserimentoDonatoreForm.Controls["_textBoxCAP"].Focus();
                    return;
                }
                string citta = inserimentoDonatoreForm.Controls["_textBoxCitta"].Text;
                string provincia = inserimentoDonatoreForm.Controls["_textBoxProvincia"].Text;
                string nazione = inserimentoDonatoreForm.Controls["_textBoxNazione"].Text;
                DateTime dataDiNascita = (inserimentoDonatoreForm.Controls["_dateTimePickerDataNascita"] as DateTimePicker).Value.Date;
                Sesso sesso;
                if (((inserimentoDonatoreForm.Controls["_groupBoxSesso"] as GroupBox).Controls["_radioButtonM"] as RadioButton).Checked == true)
                    sesso = Sesso.M;
                else
                    sesso = Sesso.F;
                string peso = inserimentoDonatoreForm.Controls["_textBoxPeso"].Text;

                string gruppoSanguigno = (inserimentoDonatoreForm.Controls["_comboBoxGruppoSanguigno"] as ComboBox).SelectedItem as string;

                Modello.InserisciDonatore(
                    new Donatore(CF, nome, cognome, telefono, email, dataDiNascita, float.Parse(peso), 
                    new Indirizzo(citta, provincia, CAP, via, int.Parse(numero), nazione), sesso, 
                    GruppoSanguignoFactory.GetGruppoSanguigno(gruppoSanguigno)));

                inserimentoDonatoreForm.Close();
            }
            else if(button.Name == "_buttonAnnulla")
            {
                inserimentoDonatoreForm.Close();
            }
        }

        protected override void OnModelChanged(object sender, EventArgs e)
        {
            //
        }
    }
}