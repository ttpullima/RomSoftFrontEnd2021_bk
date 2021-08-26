using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_PACIENTE;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_ATENCION;
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

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloAdmision.HistoriaClinica
{
    public partial class frmListaHistoriaClinica : Form
    {
        public int intTipoConsulta = 0;

        public frmListaHistoriaClinica()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            ComunFilter.f_id_paciente = 0;
            ComunFilter.f_NumHistoriaClinica = 0;

            HistoriaClinica.frmNuevoHistoriaClinica frm = new HistoriaClinica.frmNuevoHistoriaClinica();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                InitialLoad(0);
            }

        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            HistoriaClinica.frmFiltroHistoriaClinica frm = new HistoriaClinica.frmFiltroHistoriaClinica();
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
                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_PACIENTE_GetAllFilters, GetPacienteFitro(), ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var pacienteListDTO = (List<ADM_PACIENTEDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_PACIENTEDTO>()).GetType());
                        this.ETHCbindingSource.DataSource = pacienteListDTO;
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

                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_PACIENTE_GetAllFilters, GetPacienteFitro(), ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var pacienteListDTO = (List<ADM_PACIENTEDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_PACIENTEDTO>()).GetType());
                        this.ETHCbindingSource.DataSource = pacienteListDTO;
                        //this.usuarioBindingNavigator.BindingSource = this.usuarioBindingSource;
                    }
                    else if (jsonResponse.Warning)
                    {
                        Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                    }
                }

                //Consulta Atenciones
                if (intTipoConsulta == 3)
                {

                    ADM_ATENCION_RequestGetAllActiveDTO RequestAtencion = new ADM_ATENCION_RequestGetAllActiveDTO { id_paciente= ComunFilter.f_id_paciente };

                    var jsonResponse = new JsonResponse { Success = false };

                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_ATENCION_GetAtencionAllFilters, RequestAtencion, ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var atencionesListDTO = (List<ADM_ATENCION_ResponseGetAllActivesDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_ATENCION_ResponseGetAllActivesDTO>()).GetType());
                        this.ETAtencionesBindingSource.DataSource = atencionesListDTO;
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
        private ADM_PACIENTEDTO GetPacienteFitro()
        {
            return new ADM_PACIENTEDTO
            {
                valorRequest = ComunFilter.ValorRequest,
            };
        }



        private void dgvListaPaciente_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListaPaciente.Rows.Count > 0)
            {
                // Captura Id_Paciente y Num HClinica
                ComunFilter.f_id_paciente = Convert.ToInt32(dgvListaPaciente.CurrentRow.Cells[0].Value.ToString()); //id_paciente
                ComunFilter.f_NumHistoriaClinica = Convert.ToInt32(dgvListaPaciente.CurrentRow.Cells[1].Value.ToString()); //N° Historia Clinica


                // Ventana Atenciones
                if (dgvListaPaciente.CurrentCell.ColumnIndex == 11)
                {
                    //ComunFilter.f_id_paciente = Convert.ToInt32(dgvListaPaciente.CurrentRow.Cells[0].Value.ToString()); //id_paciente
                    //ComunFilter.f_NumHistoriaClinica = Convert.ToInt32(dgvListaPaciente.CurrentRow.Cells[1].Value.ToString()); //N° Historia Clinica

                    ComunFilter.f_idAtencion = 0; //Nueva atención

                    HistoriaClinica.frmAtencion frm = new HistoriaClinica.frmAtencion();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // 0 = Consulta Todos
                        //    InitialLoad(0);
                    }
                }

                // Editar Paciente
                if (dgvListaPaciente.CurrentCell.ColumnIndex == 12)
                {
                    //ComunFilter.f_id_paciente = Convert.ToInt32(dgvListaPaciente.CurrentRow.Cells[0].Value.ToString()); //id_paciente
                    //ComunFilter.f_NumHistoriaClinica = Convert.ToInt32(dgvListaPaciente.CurrentRow.Cells[1].Value.ToString()); //N° Historia Clinica

                    HistoriaClinica.frmNuevoHistoriaClinica frm = new HistoriaClinica.frmNuevoHistoriaClinica();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // 0 = Consulta Todos
                        InitialLoad(0);
                    }
                }

                //Listado Atenciones
                InitialLoad(3);


            }
        }

        private void frmListaHistoriaClinica_Load(object sender, EventArgs e)
        {
            // 0 = Consulta todos
            InitialLoad(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dgvAtenciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAtenciones.Rows.Count > 0)
            {
                // Captura Id_Paciente y Num HClinica
                ComunFilter.f_idAtencion = Convert.ToInt32(dgvAtenciones.CurrentRow.Cells[11].Value.ToString()); //id_atencion



                // Ventana Atenciones
                if (dgvAtenciones.CurrentCell.ColumnIndex == 10)
                {
    
                    HistoriaClinica.frmAtencion frm = new HistoriaClinica.frmAtencion();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // 0 = Consulta Todos
                        //    InitialLoad(0);
                    }
                }

                //Listado Atenciones
                //InitialLoad(3);


            }
        }


        //private void BtnAtencion_Click(object sender, EventArgs e)
        //{
        //    HistoriaClinica.frmAtencion frm = new HistoriaClinica.frmAtencion();
        //    if (frm.ShowDialog() == DialogResult.OK)
        //    {
        //        // 1 = Consulta por filtro
        //        //InitialLoad(1);
        //    }
        //}
    }
}
