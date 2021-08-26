using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_PROFESIONAL;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.TIPO_ESTADO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_GENERO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_DOCUMENTO_IDENTIDAD;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_ESPECIALIDAD;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_TIPO_PROFESIONAL;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_CONDICION_PROFESIONAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Presentacion.Helpers;
using Romsoft.GESTIONCLINICA.Presentacion.Core;

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloFarmacia.Egreso
{
    public partial class frmNuevoOtros : Form
    {
        public frmNuevoOtros()
        {
            InitializeComponent();
        }

   
       

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
       

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnProducto_Click(object sender, EventArgs e)
        {
            ModuloConsulta.Producto.frmObtenerProductoDispensacion frm = new ModuloConsulta.Producto.frmObtenerProductoDispensacion();

            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void BtnOrdenGuia_Click(object sender, EventArgs e)
        {
          
        }

        private void BtnProveedor_Click(object sender, EventArgs e)
        {
          
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModuloConsulta.Paciente.frmObtenerPacienteCuenta frm = new ModuloConsulta.Paciente.frmObtenerPacienteCuenta();

            if (frm.ShowDialog() == DialogResult.OK)
            {
             
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ModuloFacturacion.Prefacturacion.frmPrefacturacion frm = new ModuloFacturacion.Prefacturacion.frmPrefacturacion();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //    InitialLoad(0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModuloFarmacia.Egreso.frmDevolverDispensacion frm = new ModuloFarmacia.Egreso.frmDevolverDispensacion();

            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Esta Seguro de devolver/anular Orden", "Confirmación", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
        }
    }
}
