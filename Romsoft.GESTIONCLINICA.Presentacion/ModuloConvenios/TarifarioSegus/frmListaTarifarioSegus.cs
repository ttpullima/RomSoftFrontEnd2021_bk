using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_TARIFARIO_SEGUS;
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

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloConvenios.TarifarioSegus
{
    public partial class frmListaTarifarioSegus : Form
    {
        public int intTipoConsulta = 0;

        public frmListaTarifarioSegus()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_TARIFARIO_SEGUS_GetAllFilters, GetTarifaFitro(), ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var tarifaListDTO = (List<CVN_TARIFARIO_LISTADTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_TARIFARIO_LISTADTO>()).GetType());
                        this.ETListaTarifabindingSource.DataSource = tarifaListDTO;
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

                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_TARIFARIO_SEGUS_GetAllFilters, GetTarifaFitro(), ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var tarifaListDTO = (List<CVN_TARIFARIO_LISTADTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_TARIFARIO_LISTADTO>()).GetType());
                        this.ETListaTarifabindingSource.DataSource = tarifaListDTO;
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
        private CVN_TARIFARIO_SEGUSDTO GetTarifaFitro()
        {
            return new CVN_TARIFARIO_SEGUSDTO
            {
                valorRequest = ComunFilter.ValorRequest,
            };
        }


        private void frmListaTarifarioSegus_Load(object sender, EventArgs e)
        {
            // 0 = Consulta todos
            InitialLoad(0);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
     
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

      
        }

        private void dgvListaUsuarios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListaUsuarios.Rows.Count > 0)
            {
                ComunFilter.f_id_tarifario_segus = Convert.ToInt32(dgvListaUsuarios.CurrentRow.Cells[0].Value.ToString()); //id_tarifario_segus

                TarifarioSegus.frmNuevoTarifarioSegus frm = new TarifarioSegus.frmNuevoTarifarioSegus();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // 0 = Consulta Todos
                    InitialLoad(0);
                }
            }
        }

        private void dgvListaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListaUsuarios.Rows.Count > 0)
            {

                // Editar
                if (dgvListaUsuarios.CurrentCell.ColumnIndex == 8)
                {
                    ComunFilter.f_id_tarifario_segus = Convert.ToInt32(dgvListaUsuarios.CurrentRow.Cells[0].Value.ToString()); //id_tarifario_segus

                    TarifarioSegus.frmNuevoTarifarioSegus frm = new TarifarioSegus.frmNuevoTarifarioSegus();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // 0 = Consulta Todos
                        InitialLoad(0);
                    }
                }

                
            }
        }

        //cambia color columna Estado
        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            ComunFilter.f_id_tarifario_segus = 0;


            TarifarioSegus.frmNuevoTarifarioSegus frm = new TarifarioSegus.frmNuevoTarifarioSegus();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                InitialLoad(0);
            }
        }

        private void btnFiltrar_Click_1(object sender, EventArgs e)
        {
            TarifarioSegus.frmFiltroTarifario frm = new TarifarioSegus.frmFiltroTarifario();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 1 = Consulta por filtro
                InitialLoad(1);
            }
            else
            {
                // 0 = Consulta todo
                InitialLoad(0);
            }
        }

        private void dgvListaUsuarios_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListaUsuarios.Rows.Count > 0)
            {

                // Editar
                if (dgvListaUsuarios.CurrentCell.ColumnIndex == 8)
                {
                    ComunFilter.f_id_tarifario_segus = Convert.ToInt32(dgvListaUsuarios.CurrentRow.Cells[0].Value.ToString()); //id_tarifario_segus

                    TarifarioSegus.frmNuevoTarifarioSegus frm = new TarifarioSegus.frmNuevoTarifarioSegus();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // 0 = Consulta Todos
                        InitialLoad(0);
                    }
                }


            }
        }

        private void PctSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListaUsuarios_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
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
