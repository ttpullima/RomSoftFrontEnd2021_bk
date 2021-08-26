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

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloFarmacia.Almacen
{
    public partial class frmListaAlmacen : Form
    {
        public int intTipoConsulta = 0;

        public frmListaAlmacen()
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
                        var catpagoListDTO = (List<ADM_PROFESIONALDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_PROFESIONALDTO>()).GetType());
                        this.ETProfesional.DataSource = catpagoListDTO;
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Almacen.frmFiltroAlmacen frm = new Almacen.frmFiltroAlmacen();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                InitialLoad(0);
            }

        }

        //private void dgvListaCatPago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dgvListaProfesional.Rows.Count > 0)
        //    {

        //        // Editar
        //        if (dgvListaProfesional.CurrentCell.ColumnIndex == 6)
        //        {
        //            ComunFilter.cp_id_categoria_pago = Convert.ToInt32(dgvListaProfesional.CurrentRow.Cells[0].Value.ToString()); //id_categoria_pago

        //            CategoriaPago.frmNuevoCategoriaPago frm = new CategoriaPago.frmNuevoCategoriaPago();
        //            if (frm.ShowDialog() == DialogResult.OK)
        //            {
        //                // 0 = Consulta Todos
        //                InitialLoad(0);
        //            }
        //        }


        //    }
        //}

        private void btnNuevo_Click(object sender, EventArgs e)
        {
          
            Almacen.frmNuevoAlmacen frm = new Almacen.frmNuevoAlmacen();
            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                InitialLoad(0);
            }
        }

        private void PctSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //cambia color columna Estado
        //private void dgvListaCatPago_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    DataGridView dgv = sender as DataGridView;

        //    if (dgv.Columns[e.ColumnIndex].Name == "estadoDataGridViewTextBoxColumn")  //columna Esatado a evaluar
        //    {
        //        if (e.Value.ToString().Contains("Inactivo"))
        //        {
        //            e.CellStyle.ForeColor = Color.Red;
        //        }
        //        if (e.Value.ToString().Contains("Activo"))
        //        {
        //            e.CellStyle.ForeColor = Color.CornflowerBlue;
        //        }
        //    }
        //}


    }
}
