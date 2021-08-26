using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_PROFESIONAL;
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

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloAdmision.Profesional
{
    public partial class frmListaProfesional : Form
    {
        public int intTipoConsulta = 0;

        public frmListaProfesional()
        {
            InitializeComponent();
        }

        private void InitialLoad(int intTipoConsulta)
        {

            try
            {
                 

                //Muestra Todo
                if (intTipoConsulta == 0)
                {
                    ComunFilter.ValorRequest = "0";

                    var jsonResponse = new JsonResponse { Success = false };
                    //PaginationParameter paginationParameters = new PaginationParameter { AmountRows = 1000, CurrentPage = 0, OrderBy = "", Start = 0, WhereFilter = "WHERE U.estado IN ('Activo','Inactivo')" };
                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_PROFESIONAL_GetAllFilters, GetProfesional(), ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var ProfListDTO = (List<ADM_PROFESIONALDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_PROFESIONALDTO>()).GetType());
                        this.ETProfesional.DataSource = ProfListDTO;
                        //this.usuarioBindingNavigator.BindingSource = this.usuarioBindingSource;
                    }
                    else if (jsonResponse.Warning)
                    {
                        Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                    }
                }

                //Muestra Todo por filtro
                if (intTipoConsulta == 1)
                {


                    var jsonResponse = new JsonResponse { Success = false };

                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_PROFESIONAL_GetAllFilters, GetProfesional(), ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var ProfListDTO = (List<ADM_PROFESIONALDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_PROFESIONALDTO>()).GetType());
                        this.ETProfesional.DataSource = ProfListDTO;
                        //this.usuarioBindingNavigator.BindingSource = this.usuarioBindingSource;
                    }
                    else if (jsonResponse.Warning)
                    {
                        Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                    }
                }

            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }


        //Asigna Datos para el Filtro
        private ADM_PROFESIONALDTO GetProfesional()
        {
            return new ADM_PROFESIONALDTO
            {
                valor = ComunFilter.ValorRequest,
            };
        }

        //private void frmListaCategoriaPago_Load(object sender, EventArgs e)
        //{
        //    // 0 = Consulta todos
        //    InitialLoad(0);
        //}

            

       

       
        private void frmListaProfesional_Load(object sender, EventArgs e)
        {
            // 0 = Consulta todos
            InitialLoad(0);
        }

        //cambia color columna Estado
          

        private void PctSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            ComunFilter.profesional_id = 0;

            Profesional.frmNuevoProfesional frm = new Profesional.frmNuevoProfesional();
            //CategoriaPago.frmNuevoCategoriaPago frm = new CategoriaPago.frmNuevoCategoriaPago();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                InitialLoad(0);
            }
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            Profesional.frmFiltroProfesional frm = new Profesional.frmFiltroProfesional();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 1 = Consulta por filtro
                InitialLoad(1);
            }
            else
            {
                // 0 = Consulta todos
                InitialLoad(0);
            }
        }

        private void dgvListaProfesional_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListaProfesional.Rows.Count > 0)
            {

                // Editar
                if (dgvListaProfesional.CurrentCell.ColumnIndex == 9)
                {
                    //ComunFilter.cp_id_categoria_pago = Convert.ToInt32(dgvListaProfesional.CurrentRow.Cells[0].Value.ToString()); //id_categoria_pago
                    ComunFilter.profesional_id = Convert.ToInt32(dgvListaProfesional.CurrentRow.Cells[0].Value.ToString());
                    //CategoriaPago.frmNuevoCategoriaPago frm = new CategoriaPago.frmNuevoCategoriaPago();
                    Profesional.frmNuevoProfesional frm = new Profesional.frmNuevoProfesional();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // 0 = Consulta Todos
                        InitialLoad(0);
                    }
                }
            }
        }

        private void dgvListaProfesional_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex].Name == "estadoDataGridViewTextBoxColumn")  //columna Esatado a evaluar
            {
                if (e.Value.ToString().Contains("Inactivo"))
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                if (e.Value.ToString().Contains("Activo"))
                {
                    e.CellStyle.ForeColor = Color.CornflowerBlue;
                }
            }
        }
    }
}
