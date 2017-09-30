using System;
using BloodBank.View;
using System.Windows.Forms;
using BloodBank.Model;

namespace BloodBank.Presenter
{
    public class MainFormPresenter : Presenter
    {
        private MainForm _mainForm;
        private MenuStrip _menuStrip;
    
        InserimentoDonatoreForm inserimentoDonatoreForm;
        InserimentoEventoSospensivoForm inserimentoEventoSospensivoForm;
        InserimentoOspedaleForm inserimentoOspedaleForm;
        InserimentoDonazioneForm inserimentoDonazioneForm;
        InserimentoOperatoreForm inserimentoOperatoreForm;
        InserimentoOrdineForm inserimentoOrdineForm;
        RiepilogoDonatoreForm riepilogoDonatoreForm;
        RiepilogoOspedaleForm riepilogoOspedaleForm;
        RiepilogoDisponibilitaSaccheForm riepilogoDisponibilitaSaccheForm;
        ListaAttesaForm listaAttesaForm;
        ModificaDonatoreForm1 modificaDonatoreForm1;
        ModificaDonazioneForm modificaDonazioneForm;
        ModificaOspedaleForm modificaOspedaleForm;
        ModificaOperatoreForm modificaOperatoreForm;
        ModificaOrdineForm modificaOrdineForm;
        EliminaDonatoreForm eliminaDonatoreForm;
        EliminaDonazioneForm eliminaDonazioneForm;
        EliminaOrdineForm eliminaOrdineForm;
        EliminaOspedaleForm eliminaOspedaleForm;
        EliminaOperatoreForm eliminaOperatoreForm;

        InserimentoDonatorePresenter inserimentoDonatorePresenter;
        InserimentoEventoSospensivoPresenter inserimentoEventoSospensivoPresenter;
        InserimentoOspedalePresenter inserimentoOspedalePresenter;
        InserimentoDonazionePresenter inserimentoDonazionePresenter;
        InserimentoOperatorePresenter inserimentoOperatorePresenter;
        InserimentoOrdinePresenter inserimentoOrdinePresenter;
        RiepilogoDonatorePresenter riepilogoDonatorePresenter;
        RiepilogoOspedalePresenter riepilogoOspedalePresenter;
        RiepilogoDisponibilitaSacchePresenter riepilogoDisponibilitaSacchePresenter;
        ListaAttesaPresenter listaAttesaPresenter;
        ModificaDonatore1Presenter modificaDonatore1Presenter;
        ModificaDonazionePresenter modificaDonazionePresenter;
        ModificaOspedalePresenter modificaOspedalePresenter;
        ModificaOperatorePresenter modificaOperatorePresenter;
        ModificaOrdinePresenter modificaOrdinePresenter;
        EliminaDonatorePresenter eliminaDonatorePresenter;
        EliminaDonazionePresenter eliminaDonazionePresenter;
        EliminaOrdinePresenter eliminaOrdinePresenter;
        EliminaOspedalePresenter eliminaOspedalePresenter;
        EliminaOperatorePresenter eliminaOperatorePresenter;


        public MainFormPresenter(MainForm mainForm)
        {
            _mainForm = mainForm;
            _menuStrip =  _mainForm.Controls.Find("menuStrip", true)[0] as MenuStrip ;

            foreach(ToolStripMenuItem toolStripItem in _menuStrip.Items)
            {
                foreach (ToolStripMenuItem toolStripMenuItem in toolStripItem.DropDownItems)
                {
                        toolStripMenuItem.Click += OnToolStripMenuItemClick;
                }
            }

            _mainForm.Show();
           
            
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form_Loaded(object sender, EventArgs e)
        {
            foreach (Form frm in _mainForm.MdiChildren)
            {
                if (frm != sender)
                    frm.Close();

            }
        }

        private void OnToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem) sender;

            switch (toolStripMenuItem.Name)
            {
                case "inserisciDonatoreToolStripMenuItem":
                    if (inserimentoDonatoreForm == null)
                    {
                        inserimentoDonatoreForm = new InserimentoDonatoreForm();
                        inserimentoDonatoreForm.MdiParent = _mainForm;
                        inserimentoDonatorePresenter = new InserimentoDonatorePresenter(inserimentoDonatoreForm);
                        inserimentoDonatorePresenter.Modello = Modello;
                        inserimentoDonatoreForm.Load += Form_Loaded;
                        inserimentoDonatoreForm.FormClosed += InserimentoDonatoreForm_FormClosed;
                        inserimentoDonatoreForm.Show();
                    }
                    break;
                case "riepilogoDisponibilitàSaccheToolStripMenuItem":
                    if (inserimentoDonatoreForm == null)
                    {
                        riepilogoDisponibilitaSaccheForm = new RiepilogoDisponibilitaSaccheForm();
                        riepilogoDisponibilitaSaccheForm.MdiParent = _mainForm;
                        riepilogoDisponibilitaSacchePresenter = new RiepilogoDisponibilitaSacchePresenter(riepilogoDisponibilitaSaccheForm);
                        riepilogoDisponibilitaSacchePresenter.Modello = Modello;
                        riepilogoDisponibilitaSaccheForm.Load += Form_Loaded;
                        riepilogoDisponibilitaSaccheForm.FormClosed += riepilogoDisponibilitaSaccheForm_FormClosed;
                        riepilogoDisponibilitaSaccheForm.Show();
                    }
                    break;
                case "inserisciUnEventoSospensivoToolStripMenuItem":
                    if (inserimentoEventoSospensivoForm == null)
                    {
                        inserimentoEventoSospensivoForm = new InserimentoEventoSospensivoForm();
                        inserimentoEventoSospensivoForm.MdiParent = _mainForm;
                        inserimentoEventoSospensivoPresenter = new InserimentoEventoSospensivoPresenter(inserimentoEventoSospensivoForm);
                        inserimentoEventoSospensivoPresenter.Modello = Modello;
                        inserimentoEventoSospensivoForm.Load += Form_Loaded;
                        inserimentoEventoSospensivoForm.FormClosed += InserimentoEventoSospensivoForm_FormClosed;
                        inserimentoEventoSospensivoForm.Show();
                    }
                    break;
                case "inserisciOspedaleToolStripMenuItem":
                    if (inserimentoOspedaleForm == null)
                    {
                        inserimentoOspedaleForm = new InserimentoOspedaleForm();
                        inserimentoOspedaleForm.MdiParent = _mainForm;
                        inserimentoOspedalePresenter = new InserimentoOspedalePresenter(inserimentoOspedaleForm);
                        inserimentoOspedalePresenter.Modello = Modello;
                        inserimentoOspedaleForm.Load += Form_Loaded;
                        inserimentoOspedaleForm.FormClosed += InserimentoOspedaleForm_FormClosed;
                        inserimentoOspedaleForm.Show();
                    }
                    break;
                case "inserisciDonazioneToolStripMenuItem":
                    if (inserimentoDonazioneForm == null)
                    {
                        inserimentoDonazioneForm = new InserimentoDonazioneForm();
                        inserimentoDonazioneForm.MdiParent = _mainForm;
                        inserimentoDonazionePresenter = new InserimentoDonazionePresenter(inserimentoDonazioneForm);
                        inserimentoDonazionePresenter.Modello = Modello;
                        inserimentoDonazioneForm.Load += Form_Loaded;
                        inserimentoDonazioneForm.FormClosed += inserimentoDonazioneForm_FormClosed;
                        inserimentoDonazioneForm.Show();
                    }
                    break;
                case "inserisciOrdineToolStripMenuItem":
                    if (inserimentoOrdineForm == null)
                    {
                        inserimentoOrdineForm = new InserimentoOrdineForm();
                        inserimentoOrdineForm.MdiParent = _mainForm;
                        inserimentoOrdinePresenter = new InserimentoOrdinePresenter(inserimentoOrdineForm);
                        inserimentoOrdinePresenter.Modello = Modello;
                        inserimentoOrdineForm.Load += Form_Loaded;
                        inserimentoOrdineForm.FormClosed += inserimentoOrdineForm_FormClosed;
                        inserimentoOrdineForm.Show();
                    }
                    break;
                case "riepilogoDonatoreToolStripMenuItem":
                    if (riepilogoDonatoreForm == null)
                    {
                        riepilogoDonatoreForm = new RiepilogoDonatoreForm();
                        riepilogoDonatoreForm.MdiParent = _mainForm;
                        riepilogoDonatorePresenter = new RiepilogoDonatorePresenter(riepilogoDonatoreForm);
                        riepilogoDonatorePresenter.Modello = Modello;
                        riepilogoDonatoreForm.Load += Form_Loaded;
                        riepilogoDonatoreForm.FormClosed += riepilogoDonatoreForm_FormClosed;
                        riepilogoDonatoreForm.Show();
                    }
                    break;
                case "riepilogoOspedaleToolStripMenuItem":
                    if (riepilogoOspedaleForm == null)
                    {
                        riepilogoOspedaleForm = new RiepilogoOspedaleForm();
                        riepilogoOspedaleForm.MdiParent = _mainForm;
                        riepilogoOspedalePresenter = new RiepilogoOspedalePresenter(riepilogoOspedaleForm);
                        riepilogoOspedalePresenter.Modello = Modello;
                        riepilogoOspedaleForm.Load += Form_Loaded;
                        riepilogoOspedaleForm.FormClosed += riepilogoOspedaleForm_FormClosed;
                        riepilogoOspedaleForm.Show();
                    }
                    break;
                case "ordiniInAttesaToolStripMenuItem":
                    if (listaAttesaForm == null)
                    {
                        listaAttesaForm = new ListaAttesaForm();
                        listaAttesaForm.MdiParent = _mainForm;
                        listaAttesaPresenter = new ListaAttesaPresenter(listaAttesaForm);
                        listaAttesaPresenter.Modello = Modello;
                        listaAttesaForm.Load += Form_Loaded;
                        listaAttesaForm.FormClosed += listaAttesaForm_FormClosed;
                        listaAttesaForm.Show();
                    }
                    break;
                case "modificaDonatoreToolStripMenuItem":
                    if (modificaDonatoreForm1 == null)
                    {
                        modificaDonatoreForm1 = new ModificaDonatoreForm1(_mainForm);
                        modificaDonatoreForm1.MdiParent = _mainForm;
                        modificaDonatore1Presenter = new ModificaDonatore1Presenter(modificaDonatoreForm1, _mainForm);
                        modificaDonatore1Presenter.Modello = Modello;
                        modificaDonatoreForm1.Load += Form_Loaded;
                        modificaDonatoreForm1.FormClosed += modificaDonatoreForm_FormClosed;
                        modificaDonatoreForm1.Show();
                    }
                    break;
                case "modificaDonazioneToolStripMenuItem":
                    if (modificaDonazioneForm == null)
                    {
                        modificaDonazioneForm = new ModificaDonazioneForm();
                        modificaDonazioneForm.MdiParent = _mainForm;
                        modificaDonazionePresenter = new ModificaDonazionePresenter(modificaDonazioneForm);
                        modificaDonazionePresenter.Modello = Modello;
                        modificaDonazioneForm.Load += Form_Loaded;
                        modificaDonazioneForm.FormClosed += modificaDonazioneForm_FormClosed;
                        modificaDonazioneForm.Show();
                    }
                    break;
                case "modificaOspedaleToolStripMenuItem":
                    if (modificaOspedaleForm == null)
                    {
                        modificaOspedaleForm = new ModificaOspedaleForm();
                        modificaOspedaleForm.MdiParent = _mainForm;
                        modificaOspedalePresenter = new ModificaOspedalePresenter(modificaOspedaleForm);
                        modificaOspedalePresenter.Modello = Modello;
                        modificaOspedaleForm.Load += Form_Loaded;
                        modificaOspedaleForm.FormClosed += modificaOspedaleForm_FormClosed;
                        modificaOspedaleForm.Show();
                    }
                    break;
                case "cancellaDonatoreToolStripMenuItem":
                    if (eliminaDonatoreForm == null)
                    {
                        eliminaDonatoreForm = new EliminaDonatoreForm();
                        eliminaDonatoreForm.MdiParent = _mainForm;
                        eliminaDonatorePresenter = new EliminaDonatorePresenter(eliminaDonatoreForm);
                        eliminaDonatorePresenter.Modello = Modello;
                        eliminaDonatoreForm.Load += Form_Loaded;
                        eliminaDonatoreForm.FormClosed += eliminaDonatoreForm_FormClosed;
                        eliminaDonatoreForm.Show();
                    }
                    break;
                case "inserisciOperatoreToolStripMenuItem":
                    if (inserimentoOperatoreForm == null)
                    {
                        inserimentoOperatoreForm = new InserimentoOperatoreForm();
                        inserimentoOperatoreForm.MdiParent = _mainForm;
                        inserimentoOperatorePresenter = new InserimentoOperatorePresenter(inserimentoOperatoreForm);
                        inserimentoOperatorePresenter.Modello = Modello;
                        inserimentoOperatoreForm.Load += Form_Loaded;
                        inserimentoOperatoreForm.FormClosed += inserimentoOperatoreForm_FormClosed;
                        inserimentoOperatoreForm.Show();
                    }
                    break;
                case "modificaOperatoreToolStripMenuItem":
                    if (modificaOperatoreForm == null)
                    {
                        modificaOperatoreForm = new ModificaOperatoreForm();
                        modificaOperatoreForm.MdiParent = _mainForm;
                        modificaOperatorePresenter = new ModificaOperatorePresenter(modificaOperatoreForm);
                        modificaOperatorePresenter.Modello = Modello;
                        modificaOperatoreForm.Load += Form_Loaded;
                        modificaOperatoreForm.FormClosed += modificaOperatoreForm_FormClosed;
                        modificaOperatoreForm.Show();
                    }
                    break;
                case "modificaOrdineToolStripMenuItem":
                    if (modificaOrdineForm == null)
                    {
                        modificaOrdineForm = new ModificaOrdineForm();
                        modificaOrdineForm.MdiParent = _mainForm;
                        modificaOrdinePresenter = new ModificaOrdinePresenter(modificaOrdineForm);
                        modificaOrdinePresenter.Modello = Modello;
                        modificaOrdineForm.Load += Form_Loaded;
                        modificaOrdineForm.FormClosed += modificaOrdineForm_FormClosed;
                        modificaOrdineForm.Show();
                    }
                    break;
                case "eliminaDonazioneToolStripMenuItem":
                    if (eliminaDonazioneForm == null)
                    {
                        eliminaDonazioneForm = new EliminaDonazioneForm();
                        eliminaDonazioneForm.MdiParent = _mainForm;
                        eliminaDonazionePresenter = new EliminaDonazionePresenter(eliminaDonazioneForm);
                        eliminaDonazionePresenter.Modello = Modello;
                        eliminaDonazioneForm.Load += Form_Loaded;
                        eliminaDonazioneForm.FormClosed += eliminaDonazioneForm_FormClosed;
                        eliminaDonazioneForm.Show();
                    }
                    break;
                case "eliminaOrdineToolStripMenuItem":
                    if (eliminaOrdineForm == null)
                    {
                        eliminaOrdineForm = new EliminaOrdineForm();
                        eliminaOrdineForm.MdiParent = _mainForm;
                        eliminaOrdinePresenter = new EliminaOrdinePresenter(eliminaOrdineForm);
                        eliminaOrdinePresenter.Modello = Modello;
                        eliminaOrdineForm.Load += Form_Loaded;
                        eliminaOrdineForm.FormClosed += eliminaOrdineForm_FormClosed;
                        eliminaOrdineForm.Show();
                    }
                    break;
                case "eliminaOspedaleToolStripMenuItem":
                    if (eliminaOspedaleForm == null)
                    {
                        eliminaOspedaleForm = new EliminaOspedaleForm();
                        eliminaOspedaleForm.MdiParent = _mainForm;
                        eliminaOspedalePresenter = new EliminaOspedalePresenter(eliminaOspedaleForm);
                        eliminaOspedalePresenter.Modello = Modello;
                        eliminaOspedaleForm.Load += Form_Loaded;
                        eliminaOspedaleForm.FormClosed += eliminaOspedaleForm_FormClosed;
                        eliminaOspedaleForm.Show();
                    }
                    break;
                case "eliminaOperatoreToolStripMenuItem":
                    if (eliminaOperatoreForm == null)
                    {
                        eliminaOperatoreForm = new EliminaOperatoreForm();
                        eliminaOperatoreForm.MdiParent = _mainForm;
                        eliminaOperatorePresenter = new EliminaOperatorePresenter(eliminaOperatoreForm);
                        eliminaOperatorePresenter.Modello = Modello;
                        eliminaOperatoreForm.Load += Form_Loaded;
                        eliminaOperatoreForm.FormClosed += eliminaOperatoreForm_FormClosed;
                        eliminaOperatoreForm.Show();
                    }
                    break;
            }
        }

        private void riepilogoDisponibilitaSaccheForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            riepilogoDisponibilitaSaccheForm = null;
        }

        private void InserimentoDonatoreForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            inserimentoDonatoreForm = null;
        }

        private void InserimentoEventoSospensivoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            inserimentoEventoSospensivoForm = null;
        }

        private void InserimentoOspedaleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            inserimentoOspedaleForm = null;
        }

        private void inserimentoDonazioneForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            inserimentoDonazioneForm = null;
        }

        private void inserimentoOrdineForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            inserimentoOrdineForm = null;
        }

        private void riepilogoDonatoreForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            riepilogoDonatoreForm = null;
        }

        private void riepilogoOspedaleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            riepilogoOspedaleForm = null;
        }

        private void modificaDonatoreForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            modificaDonatoreForm1 = null;
        }

        private void modificaDonazioneForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            modificaDonazioneForm = null;
        }

        private void modificaOspedaleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            modificaOspedaleForm = null;
        }

        private void eliminaDonatoreForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            eliminaDonatoreForm = null;
        }

        private void inserimentoOperatoreForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            inserimentoOperatoreForm = null;
        }

        private void modificaOperatoreForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            modificaOperatoreForm = null;
        }

        private void modificaOrdineForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            modificaOrdineForm = null;
        }

        private void eliminaDonazioneForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            eliminaDonazioneForm = null;
        }

        private void eliminaOrdineForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            eliminaOrdineForm = null;
        }

        private void eliminaOspedaleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            eliminaOspedaleForm = null;
        }

        private void eliminaOperatoreForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            eliminaOperatoreForm = null;
        }

        private void listaAttesaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           listaAttesaForm = null;
        }

        protected override void OnModelChanged(object sender, EventArgs e)
        {
            //
        }
    }
}