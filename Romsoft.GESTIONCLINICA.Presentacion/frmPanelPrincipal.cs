using System;
using System.Windows.Forms;
using System.Drawing;


namespace Romsoft.GESTIONCLINICA.Presentacion
{
    public partial class frmPanelPrincipal : Form
    {
        public frmPanelPrincipal()
        {
            InitializeComponent();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Confirmar si desea abandonar la sesión en el sistema?", "Validación de sesión", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmPanelPrincipal_Load(object sender, EventArgs e)
        {
           
            //Posición del formulario
           // FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;

        }

        private void aDMISIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectTab("tabPage2");
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectTab("tabPage1");
        }

        private void cONFIGURACIÓNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectTab("tabPage12");
        }

        private void btnConfigUsuario_Click_1(object sender, EventArgs e)
        {
            ModuloSeguridad.Usuario.frmListaUsuario fm = new ModuloSeguridad.Usuario.frmListaUsuario();

            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }


        //METODO PARA ABRIR FORM DENTRO DE PANEL-----------------------------------------------------
        private void AbrirFormEnPanel(object formHijo)
        {
            if (this.panelContenedorForm.Controls.Count > 0)
                this.panelContenedorForm.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelContenedorForm.Controls.Add(fh);
            this.panelContenedorForm.Tag = fh;
            fh.Show();
        }

        //METODO PARA MOSTRAR FORMULARIO DE LOGO Al CERRAR OTROS FORM 
        private void MostrarFormLogoAlCerrarForms(object sender, FormClosedEventArgs e)
        {
            MostrarFormLogo();
        }

        //METODO PARA MOSTRAR FORMULARIO DE LOGO Al INICIAR 
        private void MostrarFormLogo()
        {
            AbrirFormEnPanel(new frmDashboardAdmin());
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Restaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Restaurar.Visible = false;
            Maximizar.Visible = true;
        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Maximizar.Visible = false;
            Restaurar.Visible = true;
        }

        private void PanelBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mnuTablas_Click(object sender, EventArgs e)
        {
            //tabControl1.SelectTab("tabPage4");
            materialTabControl1.SelectTab("tabPage11");

        }

        private void mnuFarmacia_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectTab("tabPage3");
        }
        //Conveios renombrado
        private void mnuLiquidaciones_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectTab("tabPage4");
        }

        private void mnuCaja_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectTab("tabPage5");
        }

        private void mnuCobranza_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectTab("tabPage6");
        }

        private void mnuHonorarios_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectTab("tabPage7");
        }

        private void mnuLaboratorio_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectTab("tabPage8");
        }

        private void mnuNormativa_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectTab("tabPage9");
        }

        private void mnuContabilidad_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectTab("tabPage10");
        }

        private void btnTablasOcupacion_Click(object sender, EventArgs e)
        {
            ModuloTablas.Ocupacion.frmListaOcupacion fm = new ModuloTablas.Ocupacion.frmListaOcupacion();

            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }

        private void btnTarifarioSegus_Click(object sender, EventArgs e)
        {
            ModuloConvenios.TarifarioSegus.frmListaTarifarioSegus fm = new ModuloConvenios.TarifarioSegus.frmListaTarifarioSegus();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }

        private void btnCategoriaPago_Click(object sender, EventArgs e)
        {
            ModuloConvenios.CategoriaPago.frmListaCategoriaPago fm = new ModuloConvenios.CategoriaPago.frmListaCategoriaPago();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }

        private void btnContactos_Click(object sender, EventArgs e)
        {
            ModuloConvenios.Contacto.frmListaContacto fm = new ModuloConvenios.Contacto.frmListaContacto();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }

        private void btnPlandeSeguro_Click(object sender, EventArgs e)
        {
            ModuloConvenios.PlanSeguro.frmListaPlanSeguro fm = new ModuloConvenios.PlanSeguro.frmListaPlanSeguro();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }


      
      
       
        
        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ModuloConvenios.Contacto.frmListaContacto fm = new ModuloConvenios.Contacto.frmListaContacto();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ModuloFarmacia.Producto.frmListaProducto fm = new ModuloFarmacia.Producto.frmListaProducto();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }

      

        private void button7_Click(object sender, EventArgs e)
        {
            ModuloFarmacia.Ingreso.frmListaIngreso fm = new ModuloFarmacia.Ingreso.frmListaIngreso();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }

       
        private void BtnAlmacen_Click(object sender, EventArgs e)
        {
            ModuloFarmacia.Almacen.frmListaAlmacen fm = new ModuloFarmacia.Almacen.frmListaAlmacen();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }

        private void BtnHistoriaClinica_Click(object sender, EventArgs e)
        {
            ModuloAdmision.HistoriaClinica.frmListaHistoriaClinica fm = new ModuloAdmision.HistoriaClinica.frmListaHistoriaClinica();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }

        private void BtnProfesional_Click(object sender, EventArgs e)
        {
            ModuloAdmision.Profesional.frmListaProfesional fm = new ModuloAdmision.Profesional.frmListaProfesional();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }

        private void BtnServiciosMedicos_Click(object sender, EventArgs e)
        {
            ModuloAdmision.OrdenServicio.frmListaOrdenServicio fm = new ModuloAdmision.OrdenServicio.frmListaOrdenServicio();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }

        private void btnPetitorio_Click(object sender, EventArgs e)
        {
            ModuloConvenios.Petitorio.frmListaPetitorios fm = new ModuloConvenios.Petitorio.frmListaPetitorios();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModuloAdmision.Presupuesto.frmListaPresupuesto fm = new ModuloAdmision.Presupuesto.frmListaPresupuesto();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModuloFacturacion.Liquidacion.frmListaLiquidacion fm = new ModuloFacturacion.Liquidacion.frmListaLiquidacion();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }

        private void BtnDispensacion_Click(object sender, EventArgs e)
        {
            ModuloFarmacia.Egreso.frmListaEgreso fm = new ModuloFarmacia.Egreso.frmListaEgreso();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }
    }
}
