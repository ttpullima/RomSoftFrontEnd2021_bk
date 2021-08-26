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
using Romsoft.GESTIONCLINICA.Presentacion.Core;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_PACIENTE;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_ATENCION;
using Romsoft.GESTIONCLINICA.DTO.TABLAS;
using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Presentacion.Helpers;


namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloAdmision.HistoriaClinica
{
    public partial class frmAtencion : Form
    {
        public int intTipoConsulta = 0;
        public EstadoActual estadoActual;

        public int idTipoDiagnostico = 0;
        public int idDiagostico = 0;
        public int idTipoHospitalizacion = 0;

        //Loading loading;
        Loading waitForm = new Loading();

        public frmAtencion()
        {
            InitializeComponent();
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnCama_Click(object sender, EventArgs e)
        {
            HistoriaClinica.frmFiltroCama frm = new HistoriaClinica.frmFiltroCama();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //    InitialLoad(0);
            }
        }

        private void btnSiteds_Click(object sender, EventArgs e)
        {

            ComunFilter.sit_origenConsulta = "Atencion"; //para origen de consulta

            HistoriaClinica.frmFiltroSiteds frm = new HistoriaClinica.frmFiltroSiteds();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Mustra Filtro Siteds
                InitialLoad(0);
            }
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            HistoriaClinica.frmAutorizacion frm = new HistoriaClinica.frmAutorizacion();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 1 = Mustra Filtro autorizacion
                //    InitialLoad(1);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Para consulta en Prefacturación
            ComunFilter.f_tipo_pendiente = "C";
            ComunFilter.f_tipo_facturacion = "P";
            ComunFilter.f_idioma = "E";

        frmPrefacturacion frm = new frmPrefacturacion();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 2 = Mustra Filtro facturacion
                //    InitialLoad(2);
            }
        }


        private void BtnObtenerDiagnostico_Click(object sender, EventArgs e)
        {
            ModuloConsulta.Diagnostico.frmObtenerDiagnostico frm = new ModuloConsulta.Diagnostico.frmObtenerDiagnostico();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //carga combo
                //CargarComboCIE10();
                //
                txtIdDiagnostico.Text = Convert.ToString(ComunFilter.cie10_id_cie10.ToString());
                txtDiagnostico.Text = ComunFilter.ci10_t_descripcion;
                // 3 = Mustra Filtro Diagnostico
                //    InitialLoad(3);
            }
        }

        private async void frmAtencion_Load(object sender, EventArgs e)
        {
            LblHistoriaClinica.Text = ComunFilter.f_NumHistoriaClinica.ToString();

            if (ComunFilter.f_idAtencion == 0 && intTipoConsulta == 0)
            {
                this.estadoActual = EstadoActual.Nuevo;

                // Carga Combos async
                CheckForIllegalCrossThreadCalls = false;
                Task oTask = new Task(CargaCombos);
                oTask.Start();
                await oTask;
                gbMensjaje.Visible = false;
                //

                //cmbEstado.Text = "";
                CboBeneficio.Text = "";
                CboCategoriaPago.Text = "";
                CboConsultorio.Text = "";
                //CboDiagnostico.Text = "";
                CboEspecialidad.Text = "";
                CboHabitacionAlta.Text = "";
                CboHabitacionIngreso.Text = "";
                CboMedico.Text = "";
                CboMoneda.Text = "";
                CboMotivoAlta.Text = "";
                CboPlanSeguro.Text = "";
                CboProductoPlan.Text = "";
                CboTipoAfiliacion.Text = "";
                CboTipoFiliacion.Text = "";
                CboTipoAtencion.Text = "";
                CboTipoDiagnostico.Text = "";
                CboTipoDocAutorizador1.Text = "";
                CboTipoDocAutorizador2.Text = "";
                CboTipoFiliacion.Text = "";
                CboTipoHospitalizacion.Text = "";
                CboTipoPaciente.Text = "";
                CboMoneda.Text = "";
                DtAtencion.Value = DateTime.Now;
                DtFechaAlta.Value = DateTime.Now;
                DtFechaAutorizacion1.Value = DateTime.Now;
                //DtFechaAutorizacion2.Value = DateTime.Now;
                DtFechaIngreso.Value = DateTime.Now;
                DtFechaVigencia.Value = DateTime.Now;
                DtFechaRegistro.Value = DateTime.Now;
                TxtHoraRegistro.Text = DateTime.Now.ToString("HH:mm:ss"); //Convert.ToString(DateTime.Now.Hour) +":"+ Convert.ToString(DateTime.Now.Minute);

            }
            else
            {
                

                this.estadoActual = EstadoActual.Editar;
                //btnNuevo.Visible = true;

                // Carga Combos async
                CheckForIllegalCrossThreadCalls = false;
                Task oTask = new Task(CargaCombos);
                oTask.Start();
                await oTask;
                gbMensjaje.Visible = false;
                //

                //Consulta por ID atención
                LblCuentaCorriente.Text = Convert.ToString(ComunFilter.f_idAtencion.ToString());

                GetDatosAtencion(ComunFilter.f_idAtencion);

                if (Convert.ToDecimal(TxtCopago.Text) >= 1)
                {
                    BtnFacturar.Enabled = true;
                }

            }

        }

        public async void CargaCombos()
        {

            gbMensjaje.Visible = true;

            //Consulta Datos Paciente por ID
            GetDatosPaciente(1);

            //LLena combos
            CargarComboTipoPaciente();
            CargarComboTipoAtencion();
            CargarComboConsultorio();
            CargarComboPlanSeguro();
            CargarComboCategoriaPago();
            CargarComboBeneficio();
            CargarComboTipoAutorizador1();
            CargarComboTipoAutorizador2();
            CargarComboTipofiliacion();
            CargarComboTipoAfiliacion();
            CargarComboProductoPlan();
            CargarComboTipoCIE10();
            //CargarComboCIE10();  //carga en el filtro
            CargarComboMedicoTratante();
            //CargarComboEspecialidad();
            CargarComboTipoHospitalizacion();
            CargarComboHabitacionIngresoAlta();
            CargarComboMotivoAlta();
            CargarComboMoneda();



        }

        ////muestra formulario loading
        //public void Show()
        //{

        //    waitForm.Show(this);
        //    //loading = new Loading();
        //    //loading.Show();

        //}

        ////cierre formulario loading
        //public void Hide()
        //{
        //    //if (loading != null)
        //    //    loading.Close();
        //    waitForm.Close();

        //}

        //Obtiene datos por el ID Paciente
        private void GetDatosPaciente(int intTipoConsulta)
        {

            if (LblHistoriaClinica.Text != "" || LblHistoriaClinica.Text != "0")
            {

                var jsonResponse = new JsonResponse { Success = false };

                //Consulta Cabecera//
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_PACIENTE_GetById, GetPaciente(), ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var pacienteListDTO = (List<ADM_PACIENTEDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_PACIENTEDTO>()).GetType());
                    //this.ETUsuariobindingSource.DataSource = usuarioListDTO;
                    //--------------------------

                    for (int i = 0; i < pacienteListDTO.Count; i++)
                    {

                        LblPaciente.Text = (string.IsNullOrEmpty(pacienteListDTO[i].t_apellido_paterno) ? string.Empty : pacienteListDTO[i].t_apellido_paterno.ToString()) + " " + (string.IsNullOrEmpty(pacienteListDTO[i].t_apellido_materno) ? string.Empty : pacienteListDTO[i].t_apellido_materno.ToString()) + " " + (string.IsNullOrEmpty(pacienteListDTO[i].t_nombres) ? string.Empty : pacienteListDTO[i].t_nombres.ToString());
                        LblUbigeoNacimiento.Text = string.IsNullOrEmpty(pacienteListDTO[i].des_ubigeo_nacimiento) ? string.Empty : pacienteListDTO[i].des_ubigeo_nacimiento.ToString();
                        LblUbigeoDireccion.Text = string.IsNullOrEmpty(pacienteListDTO[i].des_ubigeo_domicilio) ? string.Empty : pacienteListDTO[i].des_ubigeo_domicilio.ToString();
                        LblFechaNacimiento.Text = pacienteListDTO[i].d_fecha_nacimiento.ToString("dd/MM/yyyy");
                        int edad = ValidationManager.CalcularEdad(Convert.ToDateTime(LblFechaNacimiento.Text), DateTime.Now);
                        LblEdad.Text = edad.ToString();
                        LblSexo.Text = pacienteListDTO[i].sexo.ToString();
                        LblDocumentoIdentidad.Text = string.IsNullOrEmpty(pacienteListDTO[i].c_documento_identidad) ? string.Empty : pacienteListDTO[i].c_documento_identidad.ToString();
                        LblEstadoCivil.Text = pacienteListDTO[i].des_estadocivil.ToString();
                        LblTelefonoCasa.Text = string.IsNullOrEmpty(pacienteListDTO[i].c_p_fono_casa) ? string.Empty : pacienteListDTO[i].c_p_fono_casa.ToString();
                        LblTelefonoMovil.Text = string.IsNullOrEmpty(pacienteListDTO[i].c_p_fono_personal) ? string.Empty : pacienteListDTO[i].c_p_fono_personal.ToString();


                    }
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }

            }



        }

        //Asigna datos para registro/ctualizar
        private ADM_PACIENTEDTO GetPaciente()
        {

            return new ADM_PACIENTEDTO
            {
                id_paciente = Convert.ToInt32(ComunFilter.f_id_paciente),
                n_historia_clinica = Convert.ToInt32(LblHistoriaClinica.Text),
            };
        }

        //Carga combos
        private void CargarComboTipoPaciente()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_TIPO_PACIENTE_GetAllActives, new DTO.TABLAS.ADM_TIPO_PACIENTE.ADM_TIPO_PACIENTEDTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var tipopaListDTO = (List<DTO.TABLAS.ADM_TIPO_PACIENTE.ADM_TIPO_PACIENTEDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.ADM_TIPO_PACIENTE.ADM_TIPO_PACIENTEDTO>()).GetType());
                    CboTipoPaciente.ValueMember = "id_tipo_paciente";
                    CboTipoPaciente.DisplayMember = "t_descripcion";
                    CboTipoPaciente.DataSource = tipopaListDTO;
                    CboTipoPaciente.SelectedIndex = -1;
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        private void CargarComboTipoAtencion()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_TIPO_ATENCION_GetAllActives, new DTO.TABLAS.ADM_TIPO_ATENCION.ADM_TIPO_ATENCIONDTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var tipopatListDTO = (List<DTO.TABLAS.ADM_TIPO_ATENCION.ADM_TIPO_ATENCIONDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.ADM_TIPO_ATENCION.ADM_TIPO_ATENCIONDTO>()).GetType());
                    CboTipoAtencion.ValueMember = "id_tipo_atencion";
                    CboTipoAtencion.DisplayMember = "t_descripcion";
                    CboTipoAtencion.DataSource = tipopatListDTO;
                    CboTipoAtencion.SelectedIndex = -1;
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        private void CargarComboConsultorio()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_CONSULTORIO_GetAllActives, new DTO.TABLAS.ADM_CONSULTORIO.ADM_CONSULTORIODTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var consultorioListDTO = (List<DTO.TABLAS.ADM_CONSULTORIO.ADM_CONSULTORIODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.ADM_CONSULTORIO.ADM_CONSULTORIODTO>()).GetType());
                    CboConsultorio.ValueMember = "id_consultorio";
                    CboConsultorio.DisplayMember = "t_descripcion";
                    CboConsultorio.DataSource = consultorioListDTO;
                    CboConsultorio.SelectedIndex = -1;
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        private void CargarComboPlanSeguro()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_PLAN_SEGURO_GetAllActives, new DTO.TABLAS.CVN_PLAN_SEGURO.CVN_PLAN_SEGURODTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var planseguroListDTO = (List<DTO.TABLAS.CVN_PLAN_SEGURO.CVN_PLAN_SEGURODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.CVN_PLAN_SEGURO.CVN_PLAN_SEGURODTO>()).GetType());
                    CboPlanSeguro.ValueMember = "id_plan_seguro";
                    CboPlanSeguro.DisplayMember = "t_descripcion";
                    CboPlanSeguro.DataSource = planseguroListDTO;
                    CboPlanSeguro.SelectedIndex = -1;
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        private void CargarComboCategoriaPago()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_CATEGORIA_PAGO_GetAllActives, new DTO.TABLAS.CVN_CATEGORIA_PAGO.CVN_CATEGORIA_PAGODTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var catpagoListDTO = (List<DTO.TABLAS.CVN_CATEGORIA_PAGO.CVN_CATEGORIA_PAGODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.CVN_CATEGORIA_PAGO.CVN_CATEGORIA_PAGODTO>()).GetType());
                    CboCategoriaPago.ValueMember = "id_categoria_pago";
                    CboCategoriaPago.DisplayMember = "t_descripcion";
                    CboCategoriaPago.DataSource = catpagoListDTO;
                    CboCategoriaPago.SelectedIndex = -1;
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        private void CargarComboBeneficio()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_BENEFICIO_GetAllActives, new DTO.TABLAS.CVN_BENEFICIO.CVN_BENEFICIODTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var beneficioListDTO = (List<DTO.TABLAS.CVN_BENEFICIO.CVN_BENEFICIODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.CVN_BENEFICIO.CVN_BENEFICIODTO>()).GetType());
                    CboBeneficio.ValueMember = "id_beneficio";
                    CboBeneficio.DisplayMember = "t_descripcion";
                    CboBeneficio.DataSource = beneficioListDTO;
                    CboBeneficio.SelectedIndex = -1;
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        private void CargarComboTipoAutorizador1()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_DOCUMENTO_PRESTACION_GetAllActives, new DTO.TABLAS.ADM_DOCUMENTO_PRESTACION.ADM_DOCUMENTO_PRESTACIONDTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var tipodoc1ListDTO = (List<DTO.TABLAS.ADM_DOCUMENTO_PRESTACION.ADM_DOCUMENTO_PRESTACIONDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.ADM_DOCUMENTO_PRESTACION.ADM_DOCUMENTO_PRESTACIONDTO>()).GetType());
                    CboTipoDocAutorizador1.ValueMember = "id_documento_prestacion";
                    CboTipoDocAutorizador1.DisplayMember = "t_descripcion";
                    CboTipoDocAutorizador1.DataSource = tipodoc1ListDTO;
                    CboTipoDocAutorizador1.SelectedIndex = -1;
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        private void CargarComboTipoAutorizador2()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_DOCUMENTO_PRESTACION_GetAllActives, new DTO.TABLAS.ADM_DOCUMENTO_PRESTACION.ADM_DOCUMENTO_PRESTACIONDTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var tipodoc2ListDTO = (List<DTO.TABLAS.ADM_DOCUMENTO_PRESTACION.ADM_DOCUMENTO_PRESTACIONDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.ADM_DOCUMENTO_PRESTACION.ADM_DOCUMENTO_PRESTACIONDTO>()).GetType());
                    CboTipoDocAutorizador2.ValueMember = "id_documento_prestacion";
                    CboTipoDocAutorizador2.DisplayMember = "t_descripcion";
                    CboTipoDocAutorizador2.DataSource = tipodoc2ListDTO;
                    CboTipoDocAutorizador2.SelectedIndex = -1;
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        private void CargarComboTipofiliacion()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_TIPO_AFILIACION_GetAllActives, new DTO.TABLAS.ADM_TIPO_AFILIACION.ADM_TIPO_AFILIACIONDTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var tipoAfiListDTO = (List<DTO.TABLAS.ADM_TIPO_AFILIACION.ADM_TIPO_AFILIACIONDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.ADM_TIPO_AFILIACION.ADM_TIPO_AFILIACIONDTO>()).GetType());
                    CboTipoFiliacion.ValueMember = "id_tipo_filiacion";
                    CboTipoFiliacion.DisplayMember = "t_descripcion";
                    CboTipoFiliacion.DataSource = tipoAfiListDTO;
                    CboTipoFiliacion.SelectedIndex = -1;
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        //
        private void CargarComboTipoAfiliacion()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_TIPO_AAFILIACION_GetAllActives, new DTO.TABLAS.ADM_TIPO_AAFILIACION.ADM_TIPO_AAFILIACIONDTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var tipoAfiListDTO = (List<DTO.TABLAS.ADM_TIPO_AAFILIACION.ADM_TIPO_AAFILIACIONDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.ADM_TIPO_AAFILIACION.ADM_TIPO_AAFILIACIONDTO>()).GetType());
                    CboTipoAfiliacion.ValueMember = "id_tipo_afiliacion";
                    CboTipoAfiliacion.DisplayMember = "t_descripcion";
                    CboTipoAfiliacion.DataSource = tipoAfiListDTO;
                    CboTipoAfiliacion.SelectedIndex = -1;

                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }


        private void CargarComboProductoPlan()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_PRODUCTO_PLAN_GetAllActives, new DTO.TABLAS.CVN_PRODUCTO_PLAN.CVN_PRODUCTO_PLANDTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var productoplanListDTO = (List<DTO.TABLAS.CVN_PRODUCTO_PLAN.CVN_PRODUCTO_PLANDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.CVN_PRODUCTO_PLAN.CVN_PRODUCTO_PLANDTO>()).GetType());
                    CboProductoPlan.ValueMember = "id_producto_plan";
                    CboProductoPlan.DisplayMember = "t_descripcion";
                    CboProductoPlan.DataSource = productoplanListDTO;
                    CboProductoPlan.SelectedIndex = -1;
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        private void CargarComboTipoCIE10()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_TIPO_CIE10_GetAllActives, new DTO.TABLAS.ADM_TIPO_CIE10.ADM_TIPO_CIE10DTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var tipoCIEListDTO = (List<DTO.TABLAS.ADM_TIPO_CIE10.ADM_TIPO_CIE10DTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.ADM_TIPO_CIE10.ADM_TIPO_CIE10DTO>()).GetType());
                    CboTipoDiagnostico.ValueMember = "id_tipo_cie10";
                    CboTipoDiagnostico.DisplayMember = "t_descripcion";
                    CboTipoDiagnostico.DataSource = tipoCIEListDTO;
                    CboTipoDiagnostico.SelectedIndex = -1;
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        //private void CargarComboCIE10()
        //{
        //    try
        //    {
        //        var jsonResponse = new JsonResponse { Success = false };
        //        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_CIE10_GetAllActives, new DTO.TABLAS.ADM_CIE10.ADM_CIE10DTO { }, ConstantesWindows.METHODPOST);

        //        if (jsonResponse.Success && !jsonResponse.Warning)
        //        {
        //            var CIEListDTO = (List<DTO.TABLAS.ADM_CIE10.ADM_CIE10DTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.ADM_CIE10.ADM_CIE10DTO>()).GetType());
        //            CboDiagnostico.ValueMember = "id_cie10";
        //            CboDiagnostico.DisplayMember = "t_descripcion";
        //            CboDiagnostico.DataSource = CIEListDTO;
        //            CboDiagnostico.SelectedIndex = -1;
        //        }
        //        else if (jsonResponse.Warning)
        //        {
        //            Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
        //    }
        //}

        private void CargarComboMedicoTratante()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_PROFESIONAL_GetAllActives, new DTO.TABLAS.ADM_PROFESIONAL.ADM_PROFESIONALDTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var profesionalListDTO = (List<DTO.TABLAS.ADM_PROFESIONAL.ADM_PROFESIONALDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.ADM_PROFESIONAL.ADM_PROFESIONALDTO>()).GetType());
                    CboMedico.ValueMember = "id_profesional";
                    CboMedico.DisplayMember = "t_medico";
                    CboMedico.DataSource = profesionalListDTO;
                    CboMedico.SelectedIndex = -1;
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        private void CargarComboEspecialidad(int Id_Profesional)
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_ESPECIALIDAD_GetAllActives, new DTO.TABLAS.ADM_ESPECIALIDAD.ADM_ESPECIALIDADPROFESIONALDTO { id_profesional= Convert.ToInt32(CboMedico.SelectedValue) }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var especialidadlListDTO = (List<DTO.TABLAS.ADM_ESPECIALIDAD.ADM_ESPECIALIDADDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.ADM_ESPECIALIDAD.ADM_ESPECIALIDADDTO>()).GetType());
                    CboEspecialidad.ValueMember = "id_especialidad";
                    CboEspecialidad.DisplayMember = "t_descripcion";
                    CboEspecialidad.DataSource = especialidadlListDTO;
                    //CboEspecialidad.SelectedIndex = -1;
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        private void CargarComboEspecialidadProfesionalId(int Id_Profesional)
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_ESPECIALIDA_PROFESIONAL_GetById, new DTO.TABLAS.ADM_ESPECIALIDAD.ADM_ESPECIALIDADDTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var especialidadlListDTO = (List<DTO.TABLAS.ADM_ESPECIALIDAD.ADM_ESPECIALIDADDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.ADM_ESPECIALIDAD.ADM_ESPECIALIDADDTO>()).GetType());
                    CboEspecialidad.ValueMember = "id_especialidad";
                    CboEspecialidad.DisplayMember = "t_descripcion";
                    CboEspecialidad.DataSource = especialidadlListDTO;
                    //CboEspecialidad.SelectedIndex = -1;
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        private void CargarComboTipoHospitalizacion()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_TIPO_HOSPITALIZACION_GetAllActives, new DTO.TABLAS.ADM_TIPO_HOSPITALIZACION.ADM_TIPO_HOSPITALIZACIONDTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var especialidadlListDTO = (List<DTO.TABLAS.ADM_TIPO_HOSPITALIZACION.ADM_TIPO_HOSPITALIZACIONDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.ADM_TIPO_HOSPITALIZACION.ADM_TIPO_HOSPITALIZACIONDTO>()).GetType());
                    CboTipoHospitalizacion.ValueMember = "id_tipo_hospitalizacion";
                    CboTipoHospitalizacion.DisplayMember = "t_descripcion";
                    CboTipoHospitalizacion.DataSource = especialidadlListDTO;
                    CboTipoHospitalizacion.SelectedIndex = -1;
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        private void CargarComboHabitacionIngresoAlta()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_HABITACION_GetAllActives, new DTO.TABLAS.ADM_HABITACION.ADM_HABITACIONDTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var especialidadlListDTO = (List<DTO.TABLAS.ADM_HABITACION.ADM_HABITACIONDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.ADM_HABITACION.ADM_HABITACIONDTO>()).GetType());
                    CboHabitacionIngreso.ValueMember = "id_habitacion";
                    CboHabitacionIngreso.DisplayMember = "t_descripcion";
                    CboHabitacionIngreso.DataSource = especialidadlListDTO;
                    CboHabitacionIngreso.SelectedIndex = -1;

                    //
                    //CboHabitacionAlta.ValueMember = "id_tipo_hospitalizacion";
                    //CboHabitacionAlta.DisplayMember = "t_descripcion";
                    //CboHabitacionAlta.DataSource = especialidadlListDTO;
                    //CboHabitacionAlta.SelectedIndex = -1;

                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        private void CargarComboMotivoAlta()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_TIPO_EGRESO_GetAllActives, new DTO.TABLAS.ADM_TIPO_EGRESO.ADM_TIPO_EGRESODTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var motivoaltalListDTO = (List<DTO.TABLAS.ADM_TIPO_EGRESO.ADM_TIPO_EGRESODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.ADM_TIPO_EGRESO.ADM_TIPO_EGRESODTO>()).GetType());
                    CboMotivoAlta.ValueMember = "id_tipo_egreso";
                    CboMotivoAlta.DisplayMember = "t_descripcion";
                    CboMotivoAlta.DataSource = motivoaltalListDTO;
                    CboMotivoAlta.SelectedIndex = -1;

                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        private void CargarComboMoneda()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_MONEDA_GetAllActives, new DTO.TABLAS.CVN_MONEDA.CVN_MONEDADTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var motivoaltalListDTO = (List<DTO.TABLAS.CVN_MONEDA.CVN_MONEDADTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.CVN_MONEDA.CVN_MONEDADTO>()).GetType());
                    CboMoneda.ValueMember = "id_moneda";
                    CboMoneda.DisplayMember = "t_descripcion";
                    CboMoneda.DataSource = motivoaltalListDTO;
                    CboMoneda.SelectedIndex = -1;


                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        //Proce cuando se filtre algun dato
        private void InitialLoad(int intTipoConsulta)
        {

            try
            {


                //Muestra Filtrado en siteds
                if (intTipoConsulta == 0)
                {
                    //Vuelve a carga Plan Seguro
                    CargarComboPlanSeguro();
                    //Asigna Valores
                    CboPlanSeguro.SelectedValue = ComunFilter.sit_res_id_plan_seguro;
                    //CboCategoriaPago.SelectedValue = ComunFilter.sit_res_id_categoria_pago;
                    TxtCodigoAsegurado.Text = ComunFilter.sit_res_codigo_asegurado;
                    TxtContrato.Text = ComunFilter.sit_res_numero_contrato;
                    CboBeneficio.SelectedValue = ComunFilter.sit_res_id_beneficio;
                    CboTipoDocAutorizador1.SelectedValue = Convert.ToInt32(ComunFilter.sit_res_id_atecion_autoriza.ToString());
                    TxtDocumentoAutorizador1.Text = ComunFilter.sit_res_c_cod_autorizacion;
                    DtFechaAutorizacion1.Text = ComunFilter.sit_res_d_fecha_autorizacion.ToString();
                    //CargarComboTipofiliacion();
                    CboTipoFiliacion.SelectedValue = Convert.ToInt32(ComunFilter.sit_res_id_tipo_filiacion.ToString());
                    TxtNombreTitular.Text = ComunFilter.sit_res_t_nombre_titular;
                    CboTipoAfiliacion.SelectedValue = Convert.ToInt32(ComunFilter.sit_res_id_tipo_afiliacion.ToString());
                    //CargarComboMoneda();
                    CboMoneda.SelectedValue = Convert.ToInt32(ComunFilter.sit_res_id_moneda.ToString());
                    TxtCopago.Text = ComunFilter.sit_res_c_num_copago_fijo.ToString();
                    TxtCoaseguro.Text = ComunFilter.sit_res_c_num_copago_variable.ToString();
                    CboProductoPlan.SelectedValue = ComunFilter.sit_res_id_producto_plan;
                    //


                }

                //Muestra Todo por filtro autoriza
                if (intTipoConsulta == 1)
                {

                }

            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        private void TxtCopago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TxtCoaseguro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                if (SaveData())
                {
                    this.estadoActual = EstadoActual.Normal;
                }
            }
        }


        private bool ValidateData()
        {
            bool result = true;

            if (string.IsNullOrEmpty(this.CboTipoPaciente.Text))
            {
                this.errValidator.SetError(this.CboTipoPaciente, "Seleccione tipo paciente.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.CboTipoPaciente, string.Empty);
            }

            if (string.IsNullOrEmpty(this.CboTipoAtencion.Text))
            {
                this.errValidator.SetError(this.CboTipoAtencion, "Seleccione tipo atención.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.CboTipoAtencion, string.Empty);
            }

            if (string.IsNullOrEmpty(this.CboPlanSeguro.Text))
            {
                this.errValidator.SetError(this.CboPlanSeguro, "Seleccione plan.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.CboPlanSeguro, string.Empty);
            }

            if (string.IsNullOrEmpty(this.CboCategoriaPago.Text))
            {
                this.errValidator.SetError(this.CboCategoriaPago, "Seleccione categoria pago.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.CboCategoriaPago, string.Empty);
            }

                       if (string.IsNullOrEmpty(this.CboBeneficio.Text))
            {
                this.errValidator.SetError(this.CboBeneficio, "Seleccione beneficio");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.CboBeneficio, string.Empty);
            }

           

            if (string.IsNullOrEmpty(this.CboMedico.Text))
            {
                this.errValidator.SetError(this.CboMedico, "Seleccione médico.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.CboMedico, string.Empty);
            }

            if(string.IsNullOrEmpty(TxtCoaseguroFarmacia.Text))
            {
                TxtCoaseguroFarmacia.Text = "0";
            }
            if (string.IsNullOrEmpty(TxtLimiteCobertura.Text))
            {
                TxtLimiteCobertura.Text = "0";
            }



            if (string.IsNullOrEmpty(this.CboTipoDiagnostico.Text))
            {
                //this.errValidator.SetError(this.CboTipoDiagnostico, "Seleccione tipo diagnostico");
                //result = false;
                idTipoDiagnostico = 0;
            }
            else
            {
                //this.errValidator.SetError(this.CboTipoDiagnostico, string.Empty);
                idTipoDiagnostico = Convert.ToInt32(CboTipoDiagnostico.SelectedValue);
            }

            if (string.IsNullOrEmpty(this.txtIdDiagnostico.Text))
            {
                //this.errValidator.SetError(this.txtIdDiagnostico, "Seleccione diagnostico");
                //result = false;
                idDiagostico = 0;
            }
            else
            {
                //this.errValidator.SetError(this.txtIdDiagnostico, string.Empty);
                idDiagostico = Convert.ToInt32(txtIdDiagnostico.Text);
            }

            if (string.IsNullOrEmpty(this.CboTipoHospitalizacion.Text))
            {
                //this.errValidator.SetError(this.txtIdDiagnostico, "Seleccione diagnostico");
                //result = false;
                idTipoHospitalizacion = 0;
            }
            else
            {
                //this.errValidator.SetError(this.txtIdDiagnostico, string.Empty);
                idTipoHospitalizacion = Convert.ToInt32(CboTipoHospitalizacion.SelectedValue);
            }


            return result;
        }

        private bool SaveData()
        {
            bool result = false;
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                switch (this.estadoActual)
                {
                    // Guardar
                    case EstadoActual.Nuevo:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_ATENCION_Add, GetAtencion(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Editar:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_ATENCION_Update, GetAtencion(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Eliminar:
                        //jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_ATENCION_Delete, new ADM_PACIENTEDTO { id_plan_seguro = Convert.ToInt32(this.txtplanSegus.Text), UsuarioCreacion = WindowsSession.UsuarioActual }, ConstantesWindows.METHODPOST);
                        break;
                }

                if (jsonResponse.Success)
                {
                    if (jsonResponse.Warning)
                    {
                        result = false;
                        Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                    }
                    else
                    {
                        result = true;
                    }
                }
                else
                {
                    result = false;
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }

                if (result)
                {
                    //this.Close();
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                    
                    //Cierra formulario si el copago = 0
                    if(Convert.ToDecimal(TxtCopago.Text) <=0)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
            return result;
        }

        //Asigna datos para registro/ctualizar
        private ADM_ATENCIONDTO GetAtencion()
        {
                return new ADM_ATENCIONDTO
                {
                    //Solo para actualizar
                    id_atencion = ComunFilter.f_idAtencion,
                    id_paciente = ComunFilter.f_id_paciente,
                    id_tipo_paciente = Convert.ToInt32(CboTipoPaciente.SelectedValue),
                    id_tipo_atencion = Convert.ToInt32(CboTipoAtencion.SelectedValue),
                    d_fecha_registro = DateTime.Now,
                    c_hora_registro = DateTime.Now.ToString("HH:mm:ss"),
                    n_paciente_derivado = validaCHK("Derivado"),
                    id_plan_seguro = Convert.ToInt32(CboPlanSeguro.SelectedValue),
                    id_categoria_pago = Convert.ToInt32(CboCategoriaPago.SelectedValue),
                    c_codigo_asegurado = TxtCodigoAsegurado.Text.Trim(),
                    c_contrato = TxtContrato.Text.Trim(),
                    id_beneficio = Convert.ToInt32(CboBeneficio.SelectedValue),
                    id_documento_prestacion1 = Convert.ToInt32(CboTipoDocAutorizador1.SelectedValue),
                    c_documento_prestacion1 = TxtDocumentoAutorizador1.Text.Trim(),
                    d_fecha_autorizacion1 = DtFechaAutorizacion1.Value,
                    id_documento_prestacion2 = Convert.ToInt32(CboTipoDocAutorizador2.SelectedValue),
                    c_documento_prestacion2 = TxtDocumentoAutorizador2.Text.Trim(),
                    d_fecha_autorizacion2 = DtFechaAutorizacion2.Value,
                    id_tipo_filiacion = Convert.ToInt32(CboTipoFiliacion.SelectedValue),
                    t_nombre_titular = TxtNombreTitular.Text.ToString().Trim().ToUpper(),
                    id_tipo_afiliacion = Convert.ToInt32(CboTipoAfiliacion.SelectedValue),
                    id_moneda = Convert.ToInt32(CboMoneda.SelectedValue),
                    n_copago_fijo = Convert.ToDecimal(TxtCopago.Text),
                    n_copago_variable = Convert.ToDecimal(TxtCoaseguro.Text),
                    n_copago_variable_far = Convert.ToDecimal(TxtCoaseguroFarmacia.Text),
                    id_producto_plan = Convert.ToInt32(CboProductoPlan.SelectedValue),
                    n_limite_cobertura = Convert.ToDecimal(TxtLimiteCobertura.Text),
                    id_tipo_diagnostico = Convert.ToInt32(idTipoDiagnostico),
                    id_diagnostico = Convert.ToInt32(idDiagostico),
                    c_numero_placa = TxtNumeroPlaca.Text,
                    n_deja_denuncia = validaCHK("Denuncia"),
                    n_deja_carta = validaCHK("DejaCarta"),
                    t_observacion_accidente = TxtObservacionAccidente.Text.Trim(),
                    id_profesional = Convert.ToInt32(CboMedico.SelectedValue),
                    id_hospitalizacion = Convert.ToInt32(idTipoHospitalizacion),
                    t_observacion_general = TxtObservacionGeneral.Text.Trim(),
                    d_fecha_cierre = DateTime.Now,
                    c_hora_cierre = DateTime.Now.ToString("HH:mm:ss"),
                    id_tipo_facturacion = 0,
                    n_a_no_gravado = 0,
                    n_a_gravado = 0,
                    n_a_impuesto = 0,
                    n_a_total = 0,
                    n_p_no_gravado = 0,
                    n_p_gravado = 0,
                    n_p_impuesto = 0,
                    n_p_total = 0,
                    n_g_no_gravado = 0,
                    n_g_gravado = 0,
                    n_g_impuesto = 0,
                    n_g_total = 0,
                    f_estado = 1,
                    UsuarioCreacion = Convert.ToString(WindowsSession.UserIdActual), //WindowsSession.UsuarioActual,
                    UsuarioModificacion = Convert.ToString(WindowsSession.UserIdActual), //WindowsSession.UsuarioActual,
                    id_usuarioCreacion = WindowsSession.UserIdActual,
                    id_usuarioModifica = WindowsSession.UserIdActual,
                    FechaCreacion = DateTime.Now,
                    FechaModificacion = DateTime.Now,
                    d_fecha_hospitalizacion = DtFechaIngreso.Value,
                    c_hora_hospitalizacion = TxtHoraIngreso.Text,
                    id_habitacion = Convert.ToInt32(CboHabitacionIngreso.SelectedValue)
                };
        }

        private int  validaCHK(string valor)
        {
            int SiNo = 0;

            if(valor == "Derivado")
            {
                if (ChkDerivado.Checked)
                {
                    SiNo = 1;
                }
                else
                {
                    SiNo = 0;
                }
            }
            if (valor == "Denuncia")
            {
                if (ChkDejaDenuncia.Checked)
                {
                    SiNo = 1;
                }
                else
                {
                    SiNo = 0;
                }
            }
            if (valor == "DejaCarta")
            {
                if (ChkDejaCarta.Checked)
                {
                    SiNo = 1;
                }
                else
                {
                    SiNo = 0;
                }
            }
            
            return SiNo;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CboMedico_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void CboMedico_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarComboEspecialidad(Convert.ToInt32(CboMedico.SelectedValue));
        }

        //Obtiene datos por el ID Paciente
        private void GetDatosAtencion(int idAtencion)
        {

           
                var jsonResponse = new JsonResponse { Success = false };

                //Consulta Cabecera//
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_ATENCION_GetById, new DTO.TABLAS.ADM_ATENCION.ADM_ATENCION_RequestDTO {IdAtencion = idAtencion }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var atencionListDTO = (List<ADM_ATENCIONDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_ATENCIONDTO>()).GetType());
                    //this.ETUsuariobindingSource.DataSource = usuarioListDTO;
                    //--------------------------

                    for (int i = 0; i < atencionListDTO.Count; i++)
                    {

                        CboTipoPaciente.SelectedValue = Convert.ToInt32(atencionListDTO[i].id_tipo_paciente.ToString());
                        CboTipoAtencion.SelectedValue = Convert.ToInt32(atencionListDTO[i].id_tipo_atencion.ToString());
                        DtFechaRegistro.Text = atencionListDTO[i].d_fecha_registro.ToString("dd/MM/yyyy");
                        TxtHoraRegistro.Text = string.IsNullOrEmpty(atencionListDTO[i].c_hora_registro) ? string.Empty : atencionListDTO[i].c_hora_registro.ToString();
                        //CboConsultorio.SelectedValue = Convert.ToInt32(atencionListDTO[i].id.ToString());
                        //DtAtencion.Text = atencionListDTO[i].d.ToString("dd/MM/yyyy");
                        //TxtHoraAtencion.Text=""
                        //DtFechaVigencia.Text=""
                        CboPlanSeguro.SelectedValue = Convert.ToInt32(atencionListDTO[i].id_plan_seguro.ToString());
                        CboCategoriaPago.SelectedValue = Convert.ToInt32(atencionListDTO[i].id_categoria_pago.ToString());
                        TxtCodigoAsegurado.Text = string.IsNullOrEmpty(atencionListDTO[i].c_codigo_asegurado) ? string.Empty : atencionListDTO[i].c_codigo_asegurado.ToString();
                        TxtContrato.Text = string.IsNullOrEmpty(atencionListDTO[i].c_contrato) ? string.Empty : atencionListDTO[i].c_contrato.ToString();
                        CboBeneficio.SelectedValue = Convert.ToInt32(atencionListDTO[i].id_beneficio.ToString());
                        CboTipoDocAutorizador1.SelectedValue = Convert.ToInt32(atencionListDTO[i].id_documento_prestacion1.ToString());
                        TxtDocumentoAutorizador1.Text = string.IsNullOrEmpty(atencionListDTO[i].c_documento_prestacion1) ? string.Empty : atencionListDTO[i].c_documento_prestacion1.ToString();
                        DtFechaAutorizacion1.Text = atencionListDTO[i].d_fecha_autorizacion1.ToString("dd/MM/yyyy");
                        CboTipoDocAutorizador2.SelectedValue = Convert.ToInt32(atencionListDTO[i].id_documento_prestacion2.ToString());
                        TxtDocumentoAutorizador2.Text = string.IsNullOrEmpty(atencionListDTO[i].c_documento_prestacion2) ? string.Empty : atencionListDTO[i].c_documento_prestacion2.ToString();
                        DtFechaAutorizacion2.Text = atencionListDTO[i].d_fecha_autorizacion2.ToString("dd/MM/yyyy");
                        CboTipoFiliacion.SelectedValue = Convert.ToInt32(atencionListDTO[i].id_tipo_filiacion.ToString());
                        TxtNombreTitular.Text = string.IsNullOrEmpty(atencionListDTO[i].t_nombre_titular) ? string.Empty : atencionListDTO[i].t_nombre_titular.ToString();
                        CboTipoAfiliacion.SelectedValue = Convert.ToInt32(atencionListDTO[i].id_tipo_afiliacion.ToString());
                        CboMoneda.SelectedValue = Convert.ToInt32(atencionListDTO[i].id_moneda.ToString());
                        TxtCopago.Text = (atencionListDTO[i].n_copago_fijo.ToString());
                        TxtCoaseguro.Text = (atencionListDTO[i].n_copago_variable.ToString());
                        TxtCoaseguroFarmacia.Text = (atencionListDTO[i].n_copago_variable_far.ToString());
                        CboProductoPlan.SelectedValue = Convert.ToInt32(atencionListDTO[i].id_producto_plan.ToString());
                        TxtLimiteCobertura.Text = atencionListDTO[i].n_limite_cobertura.ToString();
                        CboTipoDiagnostico.SelectedValue = Convert.ToInt32(atencionListDTO[i].id_tipo_diagnostico.ToString());
                        txtIdDiagnostico.Text = atencionListDTO[i].id_tipo_diagnostico.ToString();
                        txtDiagnostico.Text = CboTipoDiagnostico.Text;
                        //TxtNumeroPlaca.Text = "";
                        //TxtObservacionAccidente.Text = "";
                        CboMedico.SelectedValue = Convert.ToInt32(atencionListDTO[i].id_profesional.ToString());
                        CboTipoHospitalizacion.SelectedValue = Convert.ToInt32(atencionListDTO[i].id_hospitalizacion.ToString());
                       //DtFechaIngreso.Text = string.IsNullOrEmpty(atencionListDTO[i].d_fecha_ingreso) ? string.Empty : atencionListDTO[i].d_fecha_ingreso.ToString();
                       TxtHoraIngreso.Text = string.IsNullOrEmpty(atencionListDTO[i].c_hora_ingreso) ? string.Empty : atencionListDTO[i].c_hora_ingreso.ToString();
                        CboHabitacionIngreso.SelectedValue = Convert.ToInt32(atencionListDTO[i].id_habitacion.ToString());

                    }
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }

        }

        private void CboTipoPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void grpMensaje_Enter(object sender, EventArgs e)
        {

        }
    }
}
