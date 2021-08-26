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
using Romsoft.GESTIONCLINICA.Presentacion.Core;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.TIPO_ESTADO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_CATEGORIA_PAGO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_PRODUCTO_PLAN;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CON_CONTACTO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_PLAN_SEGURO_DETALLE;

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloConvenios.PlanSeguro
{
    public partial class frmNuevoPlanSeguro : Form
    {
        public EstadoActual estadoActual;
        public frmNuevoPlanSeguro()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            //cambia Color de borde  a los controles

            int AnchoBorde = 2;
            Pen ColorBorde = new Pen(Color.RoyalBlue); // Esto puede venir de una variable si necesitas un color cambiante
            e.Graphics.DrawRectangle(ColorBorde, panel3.Left - 1, panel3.Top - 1, panel3.Width + 1, panel3.Height + 1);

        }

        private void frmNuevoPlanSeguro_Load(object sender, EventArgs e)
        {
            txtplanSegus.Text = ComunFilter.ps_id_plan_seguro.ToString();


            //ClearControls();
            CargarComboEstado();
            CargarComboGarante();
            CargarComboContratante();
            CargarComboCategoriaPago();
            CargarComboProductoPlan();


            // Valida id para evaluar si es Nuevo o Actualización
            if (txtplanSegus.Text == "0")
            {
                //txtIdTarifa.Text = "0";
                this.estadoActual = EstadoActual.Nuevo;
                //lblTituloUuario.Text = ".:: Agregar";

                //btnNuevo.Visible = false;
                //btnNuevoTarifa.Visible = false;

                cmbEstad.Text = "";
                cmbGarante.Text = "";
                cmbContratante.Text = "";
                cmbCategoriaPago.Text = "";
                cmbProductoPlan.Text = "";
                
            }
            else
            {
                this.estadoActual = EstadoActual.Editar;
                //lblTituloUuario.Text = ".:: Editar";

                //btnNuevo.Visible = true;
                btnNuevoDetalle.Visible = true;

                //Consulta por ID
                GetDatosPlanSeguro();



            }

        }


        //Lista Estados
        private void CargarComboEstado()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Estado_GetAllFilters, new TIPO_ESTADODTO { tabla = "Todos" }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var estadoListDTO = (List<TIPO_ESTADODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<TIPO_ESTADODTO>()).GetType());
                    cmbEstad.ValueMember = "Id_estado";
                    cmbEstad.DisplayMember = "estado";
                    cmbEstad.DataSource = estadoListDTO;
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
        //Lista Garante
        private void CargarComboGarante()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CON_CONTACTO_GetAllActives, "", ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var garanteListDTO = (List<CON_CONTACTODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CON_CONTACTODTO>()).GetType());
                    cmbGarante.ValueMember = "id_contacto";
                    cmbGarante.DisplayMember = "t_razon_social";
                    cmbGarante.DataSource = garanteListDTO;
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
        //Lista Contratante
        private void CargarComboContratante()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CON_CONTACTO_GetAllActives, "", ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var catpagoListDTO = (List<CON_CONTACTODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CON_CONTACTODTO>()).GetType());
                    cmbContratante.ValueMember = "id_contacto";
                    cmbContratante.DisplayMember = "t_razon_social";
                    cmbContratante.DataSource = catpagoListDTO;
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
        //Lista Contratante
        private void CargarComboCategoriaPago()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_CATEGORIA_PAGO_GetAllActives, "", ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var catpagoListDTO = (List<CVN_CATEGORIA_PAGODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_CATEGORIA_PAGODTO>()).GetType());
                    cmbCategoriaPago.ValueMember = "id_categoria_pago";
                    cmbCategoriaPago.DisplayMember = "t_descripcion";
                    cmbCategoriaPago.DataSource = catpagoListDTO;
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
        //Lista Producto Plan
        private void CargarComboProductoPlan()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_PRODUCTO_PLAN_GetAllActivesFilters, GetProductoPlan(), ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var prodplanListDTO = (List<CVN_PRODUCTO_PLANDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_PRODUCTO_PLANDTO>()).GetType());
                    cmbProductoPlan.ValueMember = "id_producto_plan";
                    cmbProductoPlan.DisplayMember = "t_descripcion";
                    cmbProductoPlan.DataSource = prodplanListDTO;
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

        //Asigna datos para registro/ctualizar
        private CVN_PRODUCTO_PLANDTO GetProductoPlan()
        {

            return new CVN_PRODUCTO_PLANDTO
            {

                c_codigo_iafa = this.txtIafa.Text //Consultar como obtener
                
            };
        }

        //Asigna datos para registro/ctualizar
        private CVN_PLAN_SEGURODTO GetProductoPlanId()
        {

            return new CVN_PLAN_SEGURODTO
            {

                id_plan_seguro = ComunFilter.ps_id_plan_seguro //Consultar como obtener

            };
        }


        //Asigna datos para registro/ctualizar
        private CVN_PLAN_SEGURO_DETALLEDTO GetPlanSeguroId()
        {


            return new CVN_PLAN_SEGURO_DETALLEDTO
            {

                id_plan_seguro = Convert.ToInt32(txtplanSegus.Text) //Consultar como obtener

            };
        }

        private void ClearControls()
        {
            this.txtplanSegus.Text = "0";
            this.txtCodPlan.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtObservacio.Text = string.Empty;
            txtnumcontrato.Text = string.Empty;
            txtnumCertificado.Text = string.Empty;
            txtIafa.Text = string.Empty;
            this.cmbEstad.Text = "";
            cmbGarante.Text = "";
            cmbContratante.Text = "";
            cmbCategoriaPago.Text = "";
            cmbProductoPlan.Text = "";


        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGuarda_Click(object sender, EventArgs e)
        {
            
        }

        private bool ValidateData()
        {
            bool result = true;

            if (string.IsNullOrEmpty(this.cmbGarante.Text))
            {
                this.errValidator.SetError(this.cmbGarante, "Ingresar Garante.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cmbGarante, string.Empty);
            }



            if (string.IsNullOrEmpty(this.cmbContratante.Text))
            {
                this.errValidator.SetError(this.cmbContratante, "Ingresar Contratante.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cmbContratante, string.Empty);
            }

            if (string.IsNullOrEmpty(this.cmbCategoriaPago.Text))
            {
                this.errValidator.SetError(this.cmbCategoriaPago, "Ingresar Categoria Pago.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cmbCategoriaPago, string.Empty);
            }

            if (string.IsNullOrEmpty(this.cmbProductoPlan.Text))
            {
                this.errValidator.SetError(this.cmbProductoPlan, "Ingresar Producto Plan.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cmbProductoPlan, string.Empty);
            }


            if (string.IsNullOrEmpty(this.txtCodPlan.Text))
            {
                this.errValidator.SetError(this.txtCodPlan, "Ingresar Código Susalud.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtCodPlan, string.Empty);
            }

            if (string.IsNullOrEmpty(this.txtCodPlan.Text))
            {
                this.errValidator.SetError(this.txtCodPlan, "Ingresar Código Plan");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtCodPlan, string.Empty);
            }

            if (string.IsNullOrEmpty(this.cmbEstad.Text))
            {
                this.errValidator.SetError(this.cmbEstad, "Ingresar Estado del registro.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cmbEstad, string.Empty);
            }




            // Para Anular el registro
            if (cmbEstad.Text == "Inactivo")
            {
                this.estadoActual = EstadoActual.Eliminar;
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
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_PLAN_SEGURO_Add, GetPlanSeguro(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Editar:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_PLAN_SEGURO_Update, GetPlanSeguro(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Eliminar:
                        //jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_PLAN_SEGURO_Delete, new CVN_PLAN_SEGURODTO { id_plan_seguro = Convert.ToInt32(this.txtplanSegus.Text), UsuarioCreacion = WindowsSession.UsuarioActual }, ConstantesWindows.METHODPOST);
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
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
            return result;
        }

        //Asigna datos para registro/actualizar
        private CVN_PLAN_SEGURODTO GetPlanSeguro()
        {

            return new CVN_PLAN_SEGURODTO
            {
                id_contacto_garante = Convert.ToInt32(cmbGarante.SelectedValue),
                id_contacto_contratante = Convert.ToInt32(cmbContratante.SelectedValue),
                id_categoria_pago = Convert.ToInt32(cmbCategoriaPago.SelectedValue),
                c_codigo = txtCodPlan.Text.Trim(),
                t_descripcion = txtDescripcion.Text.Trim(),
                t_observacion = txtObservacio.Text.Trim(),
                c_codigo_iafa = txtIafa.Text.Trim(),
                d_fecha_i_vigencia = dtfechaDesde.Value,
                d_fecha_f_vigencia = dtFechahasta.Value,
                c_contrato = txtnumcontrato.Text.Trim(),
                c_certificado = txtnumCertificado.Text.Trim(),
                id_producto_plan = Convert.ToInt32(cmbProductoPlan.SelectedValue),
                f_estado = Convert.ToInt32(cmbEstad.SelectedValue),
                UsuarioCreacion = Convert.ToString(WindowsSession.UserIdActual), //WindowsSession.UsuarioActual,
                UsuarioModificacion = Convert.ToString(WindowsSession.UserIdActual), //WindowsSession.UsuarioActual,
                IdUsuarioActual = WindowsSession.UserIdActual,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            };
        }


        //Obtiene datos por el código Plan Seguro
        private void GetDatosPlanSeguro()
        {
            if (txtplanSegus.Text != "")
            {

                var jsonResponse = new JsonResponse { Success = false };

                //Consulta Cabecera
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_PLAN_SEGURO_GetById, GetProductoPlanId(), ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var pseguroListDTO = (List<CVN_PLAN_SEGURODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_PLAN_SEGURODTO>()).GetType());
                    //this.ETUsuariobindingSource.DataSource = usuarioListDTO;
                    //--------------------------

                    for (int i = 0; i < pseguroListDTO.Count; i++)
                    {

                        txtplanSegus.Text = pseguroListDTO[i].id_plan_seguro.ToString();
                        cmbGarante.SelectedValue = Convert.ToInt32(pseguroListDTO[i].id_contacto_garante.ToString());
			            cmbContratante.SelectedValue  = Convert.ToInt32(pseguroListDTO[i].id_contacto_contratante.ToString());
                        cmbCategoriaPago.SelectedValue  = Convert.ToInt32(pseguroListDTO[i].id_categoria_pago.ToString());
                        txtCodPlan.Text = pseguroListDTO[i].c_codigo.ToString();
                        txtDescripcion.Text = pseguroListDTO[i].t_descripcion.ToString();
                        txtObservacio.Text = pseguroListDTO[i].t_observacion.ToString();
                        txtIafa.Text = pseguroListDTO[i].c_codigo_iafa.ToString();
                        dtfechaDesde.Text = pseguroListDTO[i].d_fecha_i_vigencia.ToString();
                        dtFechahasta.Text = pseguroListDTO[i].d_fecha_f_vigencia.ToString();
                        txtnumcontrato.Text = pseguroListDTO[i].c_contrato.ToString();
                        txtnumCertificado.Text = pseguroListDTO[i].c_certificado.ToString();
                        cmbProductoPlan.SelectedValue = Convert.ToInt32(pseguroListDTO[i].id_producto_plan.ToString());
                        cmbEstad.SelectedValue = Convert.ToInt32(pseguroListDTO[i].f_estado.ToString());
                                            }
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }



                //COnsulta Detalle Plan Seguro por ID
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_PLAN_SEGURO_DETALLE_GetAllActivesFilters, GetPlanSeguroId(), ConstantesWindows.METHODPOST);
                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var detalleListDTO = (List<CVN_PLAN_SEGURO_DETALLEDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_PLAN_SEGURO_DETALLEDTO>()).GetType());
                    //this.ETUsuariobindingSource.DataSource = usuarioListDTO;
                    //--------------------------

                    for (int i = 0; i < detalleListDTO.Count; i++)
                    {
                        //txtIdTarifa.Text = tarifaListDTO[i].id_tarifario_segus.ToString();
                        //txtCodigo.Text = string.IsNullOrEmpty(tarifaListDTO[i].c_codigo) ? string.Empty : tarifaListDTO[i].c_codigo.ToString();

                        dgvListaDetalle.Rows.Add(detalleListDTO[i].id_plan_seguro_detalle.ToString(), detalleListDTO[i].codigo.ToString(), detalleListDTO[i].beneficio.ToString(), detalleListDTO[i].moneda.ToString(), detalleListDTO[i].n_copago_fijo.ToString(), detalleListDTO[i].n_copago_variable.ToString(), detalleListDTO[i].n_copago_variable_farmacia.ToString(), detalleListDTO[i].estado.ToString());

                    }
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }


            }



            if (txtplanSegus.Text != "0")
            {
                this.estadoActual = EstadoActual.Editar;
                    //lblTituloUuario.Text = ".:: Editar";
            }


        }

        private void GetPlanDetalleID()
        {
            var jsonResponse = new JsonResponse { Success = false };

            //COnsulta Detalle Plan Seguro por ID
            jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_PLAN_SEGURO_DETALLE_GetAllActivesFilters, GetPlanSeguroId(), ConstantesWindows.METHODPOST);
            if (jsonResponse.Success && !jsonResponse.Warning)
            {
                var detalleListDTO = (List<CVN_PLAN_SEGURO_DETALLEDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_PLAN_SEGURO_DETALLEDTO>()).GetType());
                //this.ETUsuariobindingSource.DataSource = usuarioListDTO;
                //--------------------------

                for (int i = 0; i < detalleListDTO.Count; i++)
                {
                    //txtIdTarifa.Text = tarifaListDTO[i].id_tarifario_segus.ToString();
                    //txtCodigo.Text = string.IsNullOrEmpty(tarifaListDTO[i].c_codigo) ? string.Empty : tarifaListDTO[i].c_codigo.ToString();

                    dgvListaDetalle.Rows.Add(detalleListDTO[i].id_plan_seguro_detalle.ToString(), detalleListDTO[i].codigo.ToString(), detalleListDTO[i].beneficio.ToString(), detalleListDTO[i].moneda.ToString(), detalleListDTO[i].n_copago_fijo.ToString(), detalleListDTO[i].n_copago_variable.ToString(), detalleListDTO[i].n_copago_variable_farmacia.ToString(), detalleListDTO[i].estado.ToString());

                }
            }
            else if (jsonResponse.Warning)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
            }
        }

        private void btnNuevoDetalle_Click_1(object sender, EventArgs e)
        {
            ComunFilter.ps_id_plan_seguro = Convert.ToInt32(txtplanSegus.Text);

            PlanSeguro.frmFiltroBeneficio frm = new PlanSeguro.frmFiltroBeneficio();
            if (frm.ShowDialog() == DialogResult.OK)
            {

                dgvListaDetalle.Rows.Add(ComunFilter.ps_id_plan_seguro_detalle, ComunFilter.ps_codigo, ComunFilter.ps_beneficio, ComunFilter.ps_moneda, ComunFilter.ps_copago_fijo, ComunFilter.ps_copago_variable, ComunFilter.ps_copago_farmacia, "Activo");

                //Consulta por ID
                //GetPlanDetalleID();

            }
        }

        private void btnGuarda_Click_1(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                if (SaveData())
                {
                    this.estadoActual = EstadoActual.Normal;
                }
            }
        }

        private void btnCancela_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            ClearControls();
        }

        private void dgvListaDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListaDetalle.Rows.Count > 0)
            {
                // Inactivo/Elimina
                if (dgvListaDetalle.CurrentCell.ColumnIndex == 8)
                {
                    this.estadoActual = EstadoActual.Eliminar;

                    DialogResult oDlgRes;

                    var row = dgvListaDetalle.CurrentRow;

                    var estadoA = row.Cells[8].Value.ToString();
                    var id_plan_seguro_detalle = row.Cells[0].Value.ToString();

                    if (estadoA != "Inactivo")
                    {
                        // Para eliminar
                        //UtilsComun.tipoRegistro = 2;

                        oDlgRes = MessageBox.Show("¿Está seguro que desea quitar el registro seleccionado ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                        if (oDlgRes == DialogResult.Yes)
                        {
                            SaveDataDetalle(Convert.ToInt32(id_plan_seguro_detalle));

                            dgvListaDetalle.Rows.Remove(dgvListaDetalle.Rows[e.RowIndex]);

                        }
                    }

                }
            }
        }

        //Elimna Detalle
        private bool SaveDataDetalle(int id_plan_seguro_detalle)
        {
            bool result = false;
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                switch (this.estadoActual)
                {
                    case EstadoActual.Eliminar:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_PLAN_SEGURO_DETALLE_Delete, new CVN_PLAN_SEGURO_DETALLEDTO { id_plan_seguro_detalle = Convert.ToInt32(id_plan_seguro_detalle), IdUsuarioActual = Convert.ToInt32(WindowsSession.UserIdActual) }, ConstantesWindows.METHODPOST);
                        break;
                }

                if (jsonResponse.Success)
                {
                    if (jsonResponse.Warning)
                    {
                        result = false;
                        //Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
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
                    //Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                    //DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
            return result;
        }

        private void cmbProductoPlan_Click(object sender, EventArgs e)
        {
           
            
        }

        private void BtnListar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtIafa.Text))
            {
                this.errValidator.SetError(this.txtIafa, "Ingresar Código Iafa");
                return;
            }
            else
            {
                // this.errValidator.SetError(this.cmbGarante, string.Empty);
                CargarComboProductoPlan();
            }
        }
    }
}
