using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.SEG_ROL;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_OCUPACION;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.TIPO_ESTADO;
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

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloTablas.Ocupacion
{
    public partial class frmNuevoOcupacion : Form
    {
        public EstadoActual estadoActual;

        public frmNuevoOcupacion()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmNuevoOcupacion_Paint(object sender, PaintEventArgs e)
        {
            //cambia Color de borde  a los controles
            string colorBordeControl = ConstantesWindows.ColorBodeControles;

            int AnchoBorde = 2;
            Pen ColorBorde = new Pen(Color.RoyalBlue); // Esto puede venir de una variable si necesitas un color cambiante
            e.Graphics.DrawRectangle(ColorBorde, panel1.Left - 1, panel1.Top - 1, panel1.Width + 1, panel1.Height + 1);
        }

        private void frmNuevoOcupacion_Load(object sender, EventArgs e)
        {
            // Valida id para evaluar si es Nuevo o Actualización
            if (txtid.Text == "0")
            {
                txtid.Text = "0";
                this.estadoActual = EstadoActual.Nuevo;
                lblTituloUuario.Text = "Nueva Ocupación";
            }
            else
            {
                this.estadoActual = EstadoActual.Editar;
                lblTituloUuario.Text = "Actualiza Datos Ocupación";
            }

            //ClearControls();
            CargarComboEstado();
            cmbEstado.Text = "";
            GetDatosOcupacion();
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
                    cmbEstado.ValueMember = "Id_estado";
                    cmbEstado.DisplayMember = "estado";
                    cmbEstado.DataSource = estadoListDTO;
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

        //Obtiene datos por el id
        private void GetDatosOcupacion()
        {
            if (txtid.Text != "0")
            {

                var jsonResponse = new JsonResponse { Success = false };

                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Ocupacion_GetById, GetOcupacion(), ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var ocupacionListDTO = (List<ADM_OCUPACIONDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_OCUPACIONDTO>()).GetType());
                    //this.ETUsuariobindingSource.DataSource = usuarioListDTO;
                    //--------------------------

                    for (int i = 0; i < ocupacionListDTO.Count; i++)
                    {
                        txtCodigo.Text = string.IsNullOrEmpty(ocupacionListDTO[i].c_codigo) ? string.Empty : ocupacionListDTO[i].c_codigo.ToString();
                        txtDescripcion.Text = string.IsNullOrEmpty(ocupacionListDTO[i].t_descripcion) ? string.Empty : ocupacionListDTO[i].t_descripcion.ToString();
                        txtObservacion.Text = string.IsNullOrEmpty(ocupacionListDTO[i].t_observacion) ? string.Empty : ocupacionListDTO[i].t_observacion.ToString();
                        //cmbEstado.ValueMember = usuarioListDTO[i].id_rol.ToString();
                        cmbEstado.Text = string.IsNullOrEmpty(ocupacionListDTO[i].estado) ? string.Empty : ocupacionListDTO[i].estado.ToString();

                    }
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }

            }


        }

        //Asigna datos para registro/ctualizar
        private ADM_OCUPACIONDTO GetOcupacion()
        {

            return new ADM_OCUPACIONDTO
            {
                id_ocupacion = Convert.ToInt32(this.txtid.Text),
                c_codigo = txtCodigo.Text,
                t_descripcion = txtDescripcion.Text,
                t_observacion = txtObservacion.Text,
                estado = cmbEstado.Text,
                f_estado = Convert.ToInt32(cmbEstado.SelectedValue),
                UsuarioCreacion = WindowsSession.UsuarioActual,
                UsuarioModificacion = WindowsSession.UsuarioActual,
                IdUsuarioActual = WindowsSession.UserIdActual,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            };
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ////Color de Borde De formulario
            //Rectangle rect = new Rectangle(e.ClipRectangle.X,
            //e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            //e.Graphics.DrawRectangle(Pens.Gray, rect);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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

            if (string.IsNullOrEmpty(this.txtCodigo.Text))
            {
                this.errValidator.SetError(this.txtCodigo, "Ingresar Código.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtCodigo, string.Empty);
            }

            if (string.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                this.errValidator.SetError(this.txtDescripcion, "Ingresar Descripción.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtDescripcion, string.Empty);
            }

            if (string.IsNullOrEmpty(this.cmbEstado.Text))
            {
                this.errValidator.SetError(this.cmbEstado, "Ingresar Estado.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cmbEstado, string.Empty);
            }


            // Para Anular el registro
            if (cmbEstado.Text == "Inactivo")
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
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Ocupacion_Add, GetOcupacion(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Editar:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Ocupacion_Update, GetOcupacion(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Eliminar:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Ocupacion_Delete, new ADM_OCUPACIONDTO { id_ocupacion = Convert.ToInt32(this.txtid.Text), UsuarioCreacion = WindowsSession.UsuarioActual,IdUsuarioActual=WindowsSession.UserIdActual }, ConstantesWindows.METHODPOST);
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

    }
}
