using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloConvenios.Petitorio
{
    public partial class frmListaPetitorios : Form
    {
        public frmListaPetitorios()
        {
            InitializeComponent();
        }

        private void PctSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ModuloConvenios.Petitorio.frmNuevoPetitorio frm = new ModuloConvenios.Petitorio.frmNuevoPetitorio();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //InitialLoad(0);
            }
        }
    }
}
