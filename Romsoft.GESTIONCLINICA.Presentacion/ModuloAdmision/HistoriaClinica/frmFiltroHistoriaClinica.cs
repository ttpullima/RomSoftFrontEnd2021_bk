using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Romsoft.GESTIONCLINICA.Presentacion.Core;
using System;
using System.Windows.Forms;

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloAdmision.HistoriaClinica
{
    public partial class frmFiltroHistoriaClinica : Form
    {
        public frmFiltroHistoriaClinica()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ComunFilter.ValorRequest = "";
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnfiltro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtPaciente.Text) && string.IsNullOrEmpty(this.txtHC.Text))
            {
                this.errValidator.SetError(this.txtPaciente, "Ingresar dato para búsqueda.");

            }
            else
            {
                this.errValidator.SetError(this.txtPaciente, string.Empty);
                this.errValidator.SetError(this.txtHC, string.Empty);


                if (txtHC.Text.Length > 0)
                {
                    ComunFilter.ValorRequest = txtHC.Text;
                }

                if (txtPaciente.Text.Length > 0)
                {
                    ComunFilter.ValorRequest = txtPaciente.Text;
                }

                DialogResult = DialogResult.OK;

                this.Close();
            }
        }
    }
}
