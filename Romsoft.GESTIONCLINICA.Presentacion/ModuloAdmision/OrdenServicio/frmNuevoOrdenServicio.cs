using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Romsoft.GESTIONCLINICA.Presentacion.ModuloFacturacion.Prefacturacion;

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloAdmision.OrdenServicio
{
    public partial class frmNuevoOrdenServicio : Form
    {
        public frmNuevoOrdenServicio()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            frmPrefacturacion frm = new frmPrefacturacion();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //    InitialLoad(0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrdenServicio.frmFiltroProfesional frm = new OrdenServicio.frmFiltroProfesional();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //    InitialLoad(0);
            }
        }

        private void BtnProducto_Click(object sender, EventArgs e)
        {
            OrdenServicio.frmFiltroPacienteCuenta frm = new OrdenServicio.frmFiltroPacienteCuenta();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //    InitialLoad(0);
            }
        }

        private void BtnOrdenGuia_Click(object sender, EventArgs e)
        {

        }
    }
}
