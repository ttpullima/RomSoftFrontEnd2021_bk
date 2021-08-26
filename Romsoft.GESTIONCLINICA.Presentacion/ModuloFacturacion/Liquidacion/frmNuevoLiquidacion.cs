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

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloFacturacion.Liquidacion
{ 
    public partial class frmNuevoLiquidacion : Form
    {
        public frmNuevoLiquidacion()
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

      

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnProducto_Click(object sender, EventArgs e)
        {
            frmPrefacturacion frm = new frmPrefacturacion();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //    InitialLoad(0);
            }
        }

        private void BtnOrdenGuia_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmPrefacturacion frm = new frmPrefacturacion();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //    InitialLoad(0);
            }
        }
    }
}
