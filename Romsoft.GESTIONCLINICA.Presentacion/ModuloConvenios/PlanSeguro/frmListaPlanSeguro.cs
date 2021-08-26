using Romsoft.GESTIONCLINICA.Presentacion.Core;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_PLAN_SEGURO;
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

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloConvenios.PlanSeguro
{
    public partial class frmListaPlanSeguro : Form
    {

        public int intTipoConsulta = 0;

        public frmListaPlanSeguro()
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
                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_PLAN_SEGURO_GetAllFilters, GetPlanSeguroFitro(), ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var planseguroListDTO = (List<CVN_PLAN_SEGURODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_PLAN_SEGURODTO>()).GetType());
                        this.ETPlanSeguro.DataSource = planseguroListDTO;
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

                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_PLAN_SEGURO_GetAllFilters, GetPlanSeguroFitro(), ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var planseguroListDTO = (List<CVN_PLAN_SEGURODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_PLAN_SEGURODTO>()).GetType());
                        this.ETPlanSeguro.DataSource = planseguroListDTO;
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
        private CVN_PLAN_SEGURODTO GetPlanSeguroFitro()
        {
            return new CVN_PLAN_SEGURODTO
            {
                valorRequest = ComunFilter.ValorRequest,
            };
        }

        private void frmListaPlanSeguro_Load(object sender, EventArgs e)
        {
            // 0 = Consulta todos
            InitialLoad(0);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            PlanSeguro.frmFiltroPlanSeguro frm = new PlanSeguro.frmFiltroPlanSeguro();
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ComunFilter.ps_id_plan_seguro = 0;


            PlanSeguro.frmNuevoPlanSeguro frm = new PlanSeguro.frmNuevoPlanSeguro();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                InitialLoad(0);
            }
        }

        private void dgvListaCatPago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            ComunFilter.ps_id_plan_seguro = 0;


            PlanSeguro.frmNuevoPlanSeguro frm = new PlanSeguro.frmNuevoPlanSeguro();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                InitialLoad(0);
            }
        }

        private void btnFiltrar_Click_1(object sender, EventArgs e)
        {
            PlanSeguro.frmFiltroPlanSeguro frm = new PlanSeguro.frmFiltroPlanSeguro();
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

        private void dgvListaCatPago_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListaCatPago.Rows.Count > 0)
            {

                // Editar
                if (dgvListaCatPago.CurrentCell.ColumnIndex == 9)
                {
                    ComunFilter.ps_id_plan_seguro = Convert.ToInt32(dgvListaCatPago.CurrentRow.Cells[0].Value.ToString()); //id_tarifario_segus

                    PlanSeguro.frmNuevoPlanSeguro frm = new PlanSeguro.frmNuevoPlanSeguro();
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
    }
}
