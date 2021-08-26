using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Romsoft.GESTIONCLINICA.Presentacion.Core;
using System;

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloConvenios.PlanSeguro
{
    public partial class frmFiltroPlanSeguro : Form
    {
        public frmFiltroPlanSeguro()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            ComunFilter.ValorRequest = "";
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                this.errValidator.SetError(this.txtDescripcion, "Ingresar Valor para Búsqueda.");

            }
            else
            {
                ComunFilter.ValorRequest = txtDescripcion.Text;
                this.errValidator.SetError(this.txtDescripcion, string.Empty);

                DialogResult = DialogResult.OK;

                this.Close();
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnFiltrar.PerformClick();
            }
        }
    }
}
