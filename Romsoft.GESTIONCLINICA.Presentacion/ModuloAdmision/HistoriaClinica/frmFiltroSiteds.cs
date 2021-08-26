using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_DOCUMENTO_AUTORIZACION;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Core;
using Romsoft.GESTIONCLINICA.Presentacion.Helpers;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloAdmision.HistoriaClinica
{
    public partial class frmFiltroSiteds : Form
    {
        public frmFiltroSiteds()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmFiltroSiteds_Load(object sender, EventArgs e)
        {

        }

        //Consulta Nro de Autorizació en BD Access
        private void InitialLoad(int intTipoConsulta)
        {

            try
            {
                ComunFilter.f_descripcionUbigeo = "";

                //Muestra Todo
                if (intTipoConsulta == 1)
                {
                    ComunFilter.ValorRequest = "0";

                    var jsonResponse = new JsonResponse { Success = false };
                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_DOCUMENTO_AUTORIZACION_GetAllFilters, GetCodAutorizacion(), ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var sitedsListDTO = (List<ADM_DOCUMENTO_AUTORIZACIONDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_DOCUMENTO_AUTORIZACIONDTO>()).GetType());
                        this.ETSitedsbindingSource.DataSource = sitedsListDTO;

                        if(sitedsListDTO.Count ==0)
                        {
                            Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, "Número Autorización, No existe.");
                        }

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
        private ADM_DOCUMENTO_AUTORIZACIONDTO GetCodAutorizacion()
        {
            return new ADM_DOCUMENTO_AUTORIZACIONDTO
            {
                COD_AUTORIZACION = txtNumAutorizacion.Text,
            };
        }

        private void txtNumAutorizacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (string.IsNullOrEmpty(this.txtNumAutorizacion.Text))
                {
                    this.errValidator.SetError(this.txtNumAutorizacion, "Ingresar Número de Autorización.");
                }
                else
                {
                    this.errValidator.SetError(this.txtNumAutorizacion, string.Empty);

                    LimpiaVariables();

                    //Consulta siteds
                    InitialLoad(1);
                }



            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //if (dgvSiteds.Rows.Count > 0)
            //{
            //    if(ComunFilter.sit_COD_AUTORIZACION.Length <=0)
            //    {
            //        if (string.IsNullOrEmpty(this.txtNumAutorizacion.Text))
            //        {
            //            this.errValidator.SetError(this.txtNumAutorizacion, "Ingresar Número de Autorización.");
            //            return;
            //        }
            //        else
            //        {
            //            this.errValidator.SetError(this.txtNumAutorizacion, string.Empty);
            //        }
            //    }


            //    var jsonResponse = new JsonResponse { Success = false };

            //    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_DOCUMENTO_AUTORIZACION_GetAddAtencionAll, GetAsignaDtos(), ConstantesWindows.METHODPOST);

            //    if (jsonResponse.Success && !jsonResponse.Warning)
            //    {
            //        var sitedsListDTO = (List<ADM_DOCUMENTO_AUTORIZACION_RESDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_DOCUMENTO_AUTORIZACION_RESDTO>()).GetType());
            //        //this.ETSitedsbindingSource.DataSource = sitedsListDTO;
            //        for (int i = 0; i < sitedsListDTO.Count; i++)
            //        {
            //            ComunFilter.sit_res_id_documento_autorizacion = sitedsListDTO[i].id_documento_autorizacion;
            //            ComunFilter.sit_res_id_plan_seguro = sitedsListDTO[i].id_plan_seguro;
            //            ComunFilter.sit_res_id_categoria_pago = sitedsListDTO[i].id_plan_seguro;
            //            ComunFilter.sit_res_codigo_asegurado = string.IsNullOrEmpty(sitedsListDTO[i].codigo_asegurado) ? string.Empty : sitedsListDTO[i].codigo_asegurado.ToString();
            //            ComunFilter.sit_res_numero_contrato = string.IsNullOrEmpty(sitedsListDTO[i].numero_contrato) ? string.Empty : sitedsListDTO[i].numero_contrato.ToString();
            //            ComunFilter.sit_res_id_beneficio = sitedsListDTO[i].id_beneficio;
            //            ComunFilter.sit_res_id_atecion_autoriza = sitedsListDTO[i].id_atecion_autoriza;
            //            ComunFilter.sit_res_c_cod_autorizacion = sitedsListDTO[i].c_cod_autorizacion;
            //            ComunFilter.sit_res_d_fecha_autorizacion = sitedsListDTO[i].d_fecha_autorizacion;
            //            ComunFilter.sit_res_id_tipo_filiacion = sitedsListDTO[i].id_tipo_filiacion;
            //            ComunFilter.sit_res_t_nombre_titular = string.IsNullOrEmpty(sitedsListDTO[i].t_nombre_titular) ? string.Empty : sitedsListDTO[i].t_nombre_titular.ToString();
            //            ComunFilter.sit_res_id_tipo_afiliacion = Convert.ToInt32(sitedsListDTO[i].id_tipo_afiliacion.ToString());
            //            ComunFilter.sit_res_id_moneda = Convert.ToInt32(sitedsListDTO[i].id_moneda.ToString());
            //            ComunFilter.sit_res_c_num_copago_fijo = sitedsListDTO[i].c_num_copago_fijo;
            //            ComunFilter.sit_res_c_num_copago_variable = sitedsListDTO[i].c_num_copago_variable;
            //            ComunFilter.sit_res_id_producto_plan = sitedsListDTO[i].id_producto_plan;
            //        }

            //        DialogResult = DialogResult.OK;
            //        this.Close();

            //    }
            //    else if (jsonResponse.Warning)
            //    {
            //        Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
            //    }

            //}
            //else
            //{
            //    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ConstantesWindows.SeleccioneRegistro);
            //}
        }

        //Asigna Datos para el Filtro
        private ADM_DOCUMENTO_AUTORIZACION_REQDTO GetAsignaDtos()
        {
            //List<ADM_DOCUMENTO_AUTORIZACIONDTO> listaAutoriza = new List<ADM_DOCUMENTO_AUTORIZACIONDTO>();

            return new ADM_DOCUMENTO_AUTORIZACION_REQDTO
            {
                idUser = WindowsSession.UserIdActual,

                listaAutoriza = new ADM_DOCUMENTO_AUTORIZACIONDTO
                 {
                    COD_DOCUMENTO = ComunFilter.sit_COD_DOCUMENTO,
                    COD_AUTORIZACION = ComunFilter.sit_COD_AUTORIZACION,
                    COD_ASEGURADO = ComunFilter.sit_COD_ASEGURADO,
                    FEC_AUTORIZACION = ComunFilter.sit_FEC_AUTORIZACION,
                    FEC_NACIMIENTO = ComunFilter.sit_FEC_NACIMIENTO,
                    NOMBRES = ComunFilter.sit_NOMBRES,
                    AP_PATERNO = ComunFilter.sit_AP_PATERNO,
                    AP_MATERNO = ComunFilter.sit_AP_MATERNO,
                    PACIENTE = ComunFilter.sit_PACIENTE,
                    TITULAR = ComunFilter.sit_TITULAR,
                    RUC_IPRESS = ComunFilter.sit_RUC_IPRESS,
                    COD_IAFA = ComunFilter.sit_COD_IAFA,
                    NUM_COPAGO_FIJO = ComunFilter.sit_NUM_COPAGO_FIJO,
                    NUM_COPAGO_VARIABLE = ComunFilter.sit_NUM_COPAGO_VARIABLE,
                    COD_IPRESS = ComunFilter.sit_COD_IPRESS,
                    SEXO = ComunFilter.sit_SEXO,
                    NUM_DOCUMENTO = ComunFilter.sit_NUM_DOCUMENTO,
                    NUM_EDAD = ComunFilter.sit_NUM_EDAD,
                    COD_ASEGURADO_TITULAR = ComunFilter.sit_COD_ASEGURADO_TITULAR,
                    COD_DOCUMENTO_TITULAR = ComunFilter.sit_COD_DOCUMENTO_TITULAR,
                    NUM_DOCUMENTO_TITULAR = ComunFilter.sit_NUM_DOCUMENTO_TITULAR,
                    COD_TIPO_FILIACION = ComunFilter.sit_COD_TIPO_FILIACION,
                    DES_TIPO_FILIACION = ComunFilter.sit_DES_TIPO_FILIACION,
                    COD_COBERTURA = ComunFilter.sit_COD_COBERTURA,
                    COD_SUBCOBERTURA = ComunFilter.sit_COD_SUBCOBERTURA,
                    DES_BENEFICIO = ComunFilter.sit_DES_BENEFICIO,
                    COD_PRODUCTO = ComunFilter.sit_COD_PRODUCTO,
                    DES_PRODUCTO = ComunFilter.sit_DES_PRODUCTO,
                    COD_TIPOPLAN = ComunFilter.sit_COD_TIPOPLAN,
                    DES_TIPOPLAN = ComunFilter.sit_DES_TIPOPLAN,
                    COD_TIPO_AFILIACION = ComunFilter.sit_COD_TIPO_AFILIACION,
                    DES_TIPO_AFILIACION = ComunFilter.sit_DES_TIPO_AFILIACION,
                    NUM_POLIZA = ComunFilter.sit_NUM_POLIZA,
                    NUM_PLAN = ComunFilter.sit_NUM_PLAN,
                    COD_CONTRATANTE = ComunFilter.sit_COD_CONTRATANTE,
                    COD_CONTRATANTE_ABR = ComunFilter.sit_COD_CONTRATANTE_ABR,
                    NUM_CONTRATANTE = ComunFilter.sit_NUM_CONTRATANTE,
                    DES_CONTRATANTE = ComunFilter.sit_DES_CONTRATANTE,
                    FEC_INICIO_VIGENCIA = ComunFilter.sit_FEC_INICIO_VIGENCIA,
                    FEC_FIN_VIGENCIA = ComunFilter.sit_FEC_FIN_VIGENCIA,
                    FE_INCLDATE = ComunFilter.sit_FE_INCLDATE,
                    COD_MONEDA = ComunFilter.sit_COD_MONEDA,
                    COD_SERVICIO = ComunFilter.sit_COD_SERVICIO,
                    NUM_IP = ComunFilter.sit_NUM_IP,
                    f_estado = 1
                },
            };
        }


        private void dgvSiteds_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSiteds.Rows.Count > 0)
            {
                ComunFilter.sit_COD_IAFA = dgvSiteds.CurrentRow.Cells[0].Value.ToString();
                ComunFilter.sit_COD_ASEGURADO = dgvSiteds.CurrentRow.Cells[1].Value.ToString();
                ComunFilter.sit_COD_AUTORIZACION = dgvSiteds.CurrentRow.Cells[2].Value.ToString();
                ComunFilter.sit_FEC_AUTORIZACION = Convert.ToDateTime(dgvSiteds.CurrentRow.Cells[3].Value.ToString());
                ComunFilter.sit_PACIENTE = dgvSiteds.CurrentRow.Cells[4].Value.ToString();
                ComunFilter.sit_TITULAR = dgvSiteds.CurrentRow.Cells[5].Value.ToString();
                ComunFilter.sit_DES_BENEFICIO = dgvSiteds.CurrentRow.Cells[6].Value.ToString();
                ComunFilter.sit_NUM_COPAGO_FIJO = Convert.ToDecimal(dgvSiteds.CurrentRow.Cells[7].Value.ToString());
                ComunFilter.sit_NUM_COPAGO_VARIABLE = Convert.ToDecimal(dgvSiteds.CurrentRow.Cells[8].Value.ToString());
                ComunFilter.sit_COD_DOCUMENTO = dgvSiteds.CurrentRow.Cells[9].Value.ToString();
                ComunFilter.sit_FEC_NACIMIENTO = Convert.ToDateTime(dgvSiteds.CurrentRow.Cells[10].Value.ToString());
                ComunFilter.sit_NOMBRES = dgvSiteds.CurrentRow.Cells[11].Value.ToString();
                ComunFilter.sit_AP_PATERNO = dgvSiteds.CurrentRow.Cells[12].Value.ToString();
                ComunFilter.sit_AP_MATERNO = dgvSiteds.CurrentRow.Cells[13].Value.ToString();
                ComunFilter.sit_RUC_IPRESS = dgvSiteds.CurrentRow.Cells[14].Value.ToString();
                ComunFilter.sit_COD_IPRESS = dgvSiteds.CurrentRow.Cells[15].Value.ToString();
                ComunFilter.sit_SEXO = dgvSiteds.CurrentRow.Cells[16].Value.ToString();
                ComunFilter.sit_NUM_DOCUMENTO = dgvSiteds.CurrentRow.Cells[17].Value.ToString();
                ComunFilter.sit_NUM_EDAD = dgvSiteds.CurrentRow.Cells[18].Value.ToString();
                ComunFilter.sit_COD_ASEGURADO_TITULAR = dgvSiteds.CurrentRow.Cells[19].Value.ToString();
                ComunFilter.sit_COD_DOCUMENTO_TITULAR = dgvSiteds.CurrentRow.Cells[20].Value.ToString();
                ComunFilter.sit_NUM_DOCUMENTO_TITULAR = dgvSiteds.CurrentRow.Cells[21].Value.ToString();
                ComunFilter.sit_COD_TIPO_FILIACION = dgvSiteds.CurrentRow.Cells[22].Value.ToString();
                ComunFilter.sit_DES_TIPO_FILIACION = dgvSiteds.CurrentRow.Cells[23].Value.ToString();
                ComunFilter.sit_COD_COBERTURA = dgvSiteds.CurrentRow.Cells[24].Value.ToString();
                ComunFilter.sit_COD_SUBCOBERTURA = dgvSiteds.CurrentRow.Cells[25].Value.ToString();
                ComunFilter.sit_COD_PRODUCTO = dgvSiteds.CurrentRow.Cells[26].Value.ToString();
                ComunFilter.sit_DES_PRODUCTO = dgvSiteds.CurrentRow.Cells[27].Value.ToString();
                ComunFilter.sit_COD_TIPOPLAN = dgvSiteds.CurrentRow.Cells[28].Value.ToString();
                ComunFilter.sit_DES_TIPOPLAN = dgvSiteds.CurrentRow.Cells[29].Value.ToString();
                ComunFilter.sit_COD_TIPO_AFILIACION = dgvSiteds.CurrentRow.Cells[30].Value.ToString();
                ComunFilter.sit_DES_TIPO_AFILIACION = dgvSiteds.CurrentRow.Cells[31].Value.ToString();
                ComunFilter.sit_NUM_POLIZA = dgvSiteds.CurrentRow.Cells[32].Value.ToString();
                ComunFilter.sit_NUM_PLAN = dgvSiteds.CurrentRow.Cells[33].Value.ToString();
                ComunFilter.sit_COD_CONTRATANTE = dgvSiteds.CurrentRow.Cells[34].Value.ToString();
                ComunFilter.sit_COD_CONTRATANTE_ABR = dgvSiteds.CurrentRow.Cells[35].Value.ToString();
                ComunFilter.sit_NUM_CONTRATANTE = dgvSiteds.CurrentRow.Cells[36].Value.ToString();
                ComunFilter.sit_DES_CONTRATANTE = dgvSiteds.CurrentRow.Cells[37].Value.ToString();
                ComunFilter.sit_FEC_INICIO_VIGENCIA = Convert.ToDateTime(dgvSiteds.CurrentRow.Cells[38].Value.ToString());
                ComunFilter.sit_FEC_FIN_VIGENCIA = Convert.ToDateTime(dgvSiteds.CurrentRow.Cells[39].Value.ToString());
                ComunFilter.sit_FE_INCLDATE = Convert.ToDateTime(dgvSiteds.CurrentRow.Cells[40].Value.ToString());
                ComunFilter.sit_COD_MONEDA = dgvSiteds.CurrentRow.Cells[41].Value.ToString();
                ComunFilter.sit_COD_SERVICIO = dgvSiteds.CurrentRow.Cells[42].Value.ToString();
                ComunFilter.sit_NUM_IP = dgvSiteds.CurrentRow.Cells[43].Value.ToString();


                // Inicio Grabado, Solo si viene desde atención
                if (ComunFilter.sit_origenConsulta == "Atencion")
                {
                    var jsonResponse = new JsonResponse { Success = false };

                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_DOCUMENTO_AUTORIZACION_GetAddAtencionAll, GetAsignaDtos(), ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var sitedsListDTO = (List<ADM_DOCUMENTO_AUTORIZACION_RESDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_DOCUMENTO_AUTORIZACION_RESDTO>()).GetType());
                        //this.ETSitedsbindingSource.DataSource = sitedsListDTO;
                        for (int i = 0; i < sitedsListDTO.Count; i++)
                        {
                            ComunFilter.sit_res_id_documento_autorizacion = sitedsListDTO[i].id_documento_autorizacion;
                            ComunFilter.sit_res_id_plan_seguro = sitedsListDTO[i].id_plan_seguro;
                            ComunFilter.sit_res_id_categoria_pago = sitedsListDTO[i].id_plan_seguro;
                            ComunFilter.sit_res_codigo_asegurado = string.IsNullOrEmpty(sitedsListDTO[i].codigo_asegurado) ? string.Empty : sitedsListDTO[i].codigo_asegurado.ToString();
                            ComunFilter.sit_res_numero_contrato = string.IsNullOrEmpty(sitedsListDTO[i].numero_contrato) ? string.Empty : sitedsListDTO[i].numero_contrato.ToString();
                            ComunFilter.sit_res_id_beneficio = sitedsListDTO[i].id_beneficio;
                            ComunFilter.sit_res_id_atecion_autoriza = sitedsListDTO[i].id_atecion_autoriza;
                            ComunFilter.sit_res_c_cod_autorizacion = sitedsListDTO[i].c_cod_autorizacion;
                            ComunFilter.sit_res_d_fecha_autorizacion = sitedsListDTO[i].d_fecha_autorizacion;
                            ComunFilter.sit_res_id_tipo_filiacion = sitedsListDTO[i].id_tipo_filiacion;
                            ComunFilter.sit_res_t_nombre_titular = string.IsNullOrEmpty(sitedsListDTO[i].t_nombre_titular) ? string.Empty : sitedsListDTO[i].t_nombre_titular.ToString();
                            ComunFilter.sit_res_id_tipo_afiliacion = sitedsListDTO[i].id_tipo_afiliacion;
                            ComunFilter.sit_res_id_moneda = sitedsListDTO[i].id_moneda;
                            ComunFilter.sit_res_c_num_copago_fijo = sitedsListDTO[i].c_num_copago_fijo;
                            ComunFilter.sit_res_c_num_copago_variable = sitedsListDTO[i].c_num_copago_variable;
                            ComunFilter.sit_res_id_producto_plan = sitedsListDTO[i].id_producto_plan;
                        }

                        DialogResult = DialogResult.OK;
                        this.Close();

                    }
                    else if (jsonResponse.Warning)
                    {
                        Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                    }
                }
                
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void LimpiaVariables()
        {
            ComunFilter.sit_res_id_documento_autorizacion = 0;
            ComunFilter.sit_res_id_plan_seguro = 0;
            ComunFilter.sit_res_id_categoria_pago = 0;
            ComunFilter.sit_res_codigo_asegurado = string.Empty;
            ComunFilter.sit_res_numero_contrato = string.Empty;
            ComunFilter.sit_res_id_beneficio = 0;
            ComunFilter.sit_res_id_atecion_autoriza = 0;
            ComunFilter.sit_res_c_cod_autorizacion = string.Empty;
            ComunFilter.sit_res_d_fecha_autorizacion = Convert.ToDateTime("01/01/1900");
            ComunFilter.sit_res_id_tipo_filiacion = 0;
            ComunFilter.sit_res_t_nombre_titular = string.Empty;
            ComunFilter.sit_res_id_tipo_afiliacion = 0;
            ComunFilter.sit_res_id_moneda = 0;
            ComunFilter.sit_res_c_num_copago_fijo = 0;
            ComunFilter.sit_res_c_num_copago_variable = 0;
            ComunFilter.sit_res_id_producto_plan = 0;
        }

        private void dgvSiteds_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}





