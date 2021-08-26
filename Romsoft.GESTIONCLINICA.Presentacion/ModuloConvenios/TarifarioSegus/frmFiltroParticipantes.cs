using Romsoft.GESTIONCLINICA.Presentacion.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloConvenios.TarifarioSegus
{
    public partial class frmFiltroParticipantes : Form
    {
        public frmFiltroParticipantes()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvListaOcupacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ComunFilter.codParticipante  = dgvListaOcupacion.CurrentRow.Cells[0].Value.ToString();
            ComunFilter.nomParticipante = dgvListaOcupacion.CurrentRow.Cells[1].Value.ToString();

            DialogResult = DialogResult.OK;

            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Color de Borde De formulario
            Rectangle rect = new Rectangle(e.ClipRectangle.X,
            e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            e.Graphics.DrawRectangle(Pens.Gray, rect);
        }

        private void frmFiltroParticipantes_Load(object sender, EventArgs e)
        {

            dgvListaOcupacion.Rows.Add("010101", "ANESTESIOLOGO");
            dgvListaOcupacion.Rows.Add("010102", "PRIMER AYUDANTE");

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
