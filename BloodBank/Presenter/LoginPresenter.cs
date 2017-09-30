using BloodBank.Model;
using BloodBank.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank.Presenter
{
    public class LoginPresenter : Presenter
    {
       
        private readonly LoginForm _loginForm;

        public LoginPresenter(LoginForm loginForm)
        {
            if (loginForm == null)
                throw new ArgumentNullException("view");

            _loginForm = loginForm;
            _loginForm.Controls["_loginButton"].Click += OnButtonClick;
            _loginForm.Controls["_clearButton"].Click += OnButtonClick;
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name == "_loginButton")
            {
                string username = _loginForm.Controls["_usernameTextBox"].Text;
                string password = _loginForm.Controls["_passwordTextBox"].Text;
                if (Modello.ControllaCredenziali(username, password))
                {
                    _loginForm.Hide();
                    MainForm mainForm = new MainForm();
                    MainFormPresenter mainFormPresenter = new MainFormPresenter(mainForm);
                    mainFormPresenter.Modello = Modello;
                    MenuStrip _menuStrip = mainForm.Controls.Find("menuStrip", true)[0] as MenuStrip;
                    foreach (ToolStripMenuItem toolStripItem in _menuStrip.Items)
                    { 
                        if (!(Modello.OperatoreCorrente is Responsabile) && toolStripItem.Name == "operatoriToolStripMenuItem")
                            toolStripItem.Enabled = false;      
                    }
                    List<SaccaContenitrice> saccheScadute = Modello.GetSaccheScadute();
                    if (saccheScadute.Count > 0)
                    {
                        string mess = "";
                        mess += "Sono state eliminate le seguenti sacche scadute: ";
                        foreach (SaccaContenitrice s in saccheScadute)
                            mess += "\n" + s.CodiceSacca;
                        MessageBox.Show(mess, "Scadenza sacche", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Credenziali Errate!", "Errore di autenticazione",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                    _loginForm.Controls["_usernameTextBox"].Text = "";
                    _loginForm.Controls["_passwordTextBox"].Text = "";
                    _loginForm.Controls["_usernameTextBox"].Focus();
                }
            }else if(button.Name == "_clearButton")
            {
                _loginForm.Controls["_usernameTextBox"].Text = "";
                _loginForm.Controls["_passwordTextBox"].Text = "";
                _loginForm.Controls["_usernameTextBox"].Focus();
            }
        }

        protected override void OnModelChanged(object sender, EventArgs e)
        {
            //_view.Color = Model.Color;
        }
        
    }
}
