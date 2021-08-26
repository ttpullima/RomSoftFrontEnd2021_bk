using Romsoft.GESTIONCLINICA.Presentacion.Core;
using System;
using System.Windows.Forms;


namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloAdmision.Presupuesto
{
    public partial class frmFiltroTarifarioSegus : Form
    {
        public frmFiltroTarifarioSegus()
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
                ComunFilter.ValorRequest = "";
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
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
