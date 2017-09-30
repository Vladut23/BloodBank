using BloodBank.Model;
using BloodBank.Persistence;
using BloodBank.Presenter;
using BloodBank.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IPersistence persistence = new Persistenza();
            Modello model = new Modello(persistence);
            StartMVP(model);
        }

        static void StartMVP(Modello model)
        {
            LoginForm loginForm = new LoginForm();
            LoginPresenter loginPresenter = new LoginPresenter(loginForm);
            loginPresenter.Modello = model;
            Application.Run(loginForm);
        }

    }
}
