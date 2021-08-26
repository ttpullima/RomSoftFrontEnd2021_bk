using Romsoft.GESTIONCLINICA.Presentacion.Core;
using System;
using System.Windows.Forms;

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloConvenios.TarifarioSegus
{
    public partial class frmFiltroTarifario : Form
    {
        public frmFiltroTarifario()
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
