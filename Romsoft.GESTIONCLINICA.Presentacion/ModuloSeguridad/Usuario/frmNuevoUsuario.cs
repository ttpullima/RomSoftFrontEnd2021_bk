using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.SEG_ROL;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.SEG_USUARIO;
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

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloSeguridad.Usuario
{
    public partial class frmNuevoUsuario : Form
    {
        public EstadoActual estadoActual;

        public frmNuevoUsuario()
        {
            InitializeComponent();
        }

        private void frmNuevoUsuario_Paint(object sender, PaintEventArgs e)
        {
            //cambia Color de borde  a los controles

            int AnchoBorde = 2;
            Pen ColorBorde = new Pen(Color.RoyalBlue); // Esto puede venir de una variable si necesitas un color cambiante
            e.Graphics.DrawRectangle(ColorBorde, panel1.Left - 1, panel1.Top - 1, panel1.Width + 1, panel1.Height + 1);

        }

        private void frmNuevoUsuario_Load(object sender, EventArgs e)
        {
            // Valida id para evaluar si es Nuevo o Actualización
            if (txtid.Text == "0")
            {
                txtid.Text = "0";
                this.estadoActual = EstadoActual.Nuevo;
                lblTituloUuario.Text = ".:: Agregar";
            }
            else
            {
                this.estadoActual = EstadoActual.Editar;
                lblTituloUuario.Text = ".:: Editar";
            }

            //ClearControls();
            CargarComboRol();
            cmbTipo.Text = "";
            CargarComboEstado();
            cmbEstado.Text = "";
            GetDatosUsuario();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Color de Borde De formulario
                Rectangle rect = new Rectangle(e.ClipRectangle.X,
                e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
                e.Graphics.DrawRectangle(Pens.Black  , rect);
            
        }

      
        //Lista Roles
        private void CargarComboRol()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Rol_GetAllActives, null, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var rolListDTO = (List<SEG_ROLDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<SEG_ROLDTO>()).GetType());
                    cmbTipo.ValueMember = "Id_rol";
                    cmbTipo.DisplayMember = "rol";
                    cmbTipo.DataSource = rolListDTO;
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
        //Lista Estados
        private void CargarComboEstado()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Estado_GetAllFilters, new TIPO_ESTADODTO {tabla="Todos" }, ConstantesWindows.METHODPOST);

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

        private void ClearControls()
        {
            this.txtid.Text = "0";
            this.txtApellidos.Text = string.Empty;
            this.txtNombres.Text = string.Empty;
            this.txtLoginName.Text = string.Empty;
            this.txtpassword.Text = string.Empty;
            this.txtDni.Text = string.Empty;
            this.txtEmail.Text = string.Empty;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
       
        }

        private bool ValidateData()
        {
            bool result = true;

            if (string.IsNullOrEmpty(this.txtApellidos.Text))
            {
                this.errValidator.SetError(this.txtApellidos, "Ingresar Apellidos.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtApellidos, string.Empty);
            }

            if (string.IsNullOrEmpty(this.txtNombres.Text))
            {
                this.errValidator.SetError(this.txtNombres, "Ingresar Nombre.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtNombres, string.Empty);
            }

            if (string.IsNullOrEmpty(this.txtLoginName.Text))
            {
                this.errValidator.SetError(this.txtLoginName, "Ingresar UserName.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtLoginName, string.Empty);
            }

            if (string.IsNullOrEmpty(this.txtpassword.Text))
            {
                this.errValidator.SetError(this.txtpassword, "Ingresar Password.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtpassword, string.Empty);
            }


            if (!string.IsNullOrEmpty(this.txtEmail.Text))
            {
                if (!ValidationManager.IsEmail(this.txtEmail.Text))
                {
                    this.errValidator.SetError(this.txtEmail, "Ingresar Correo correcto.");
                    result = false;
                }
                else
                {
                    this.errValidator.SetError(this.txtEmail, string.Empty);
                }
            }
            else
            {
                this.errValidator.SetError(this.txtEmail, "Ingresar Correo.");
                result = false;
            }

            if (string.IsNullOrEmpty(this.txtDni.Text))
            {
                this.errValidator.SetError(this.txtDni, "Ingresar Nro de DNI.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtDni, string.Empty);
            }

            // Para Anular el registro
            if(cmbEstado.Text =="Inactivo")
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
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Usuario_Add, GetUsuario(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Editar:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Usuario_Update, GetUsuario(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Eliminar:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Usuario_Delete, new SEG_USUARIODTO { id_usuario = Convert.ToInt32(this.txtid.Text), UsuarioCreacion = WindowsSession.UsuarioActual }, ConstantesWindows.METHODPOST);
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


        //Asigna datos para registro/ctualizar
        private SEG_USUARIODTO GetUsuario()
        {
           
            return new SEG_USUARIODTO
            {
                id_usuario = Convert.ToInt32(this.txtid.Text),
                nombres = txtNombres.Text,
                apellidos = txtApellidos.Text,
                usuario = txtLoginName.Text,
                clave = txtpassword.Text,
                email = txtEmail.Text,
                celular = txtCelular.Text,
                nro_documento = txtDni.Text,
                id_rol = Convert.ToInt32(cmbTipo.SelectedValue),
                estado = cmbEstado.Text, //Convert.ToInt32(cmbEstado.SelectedValue),
                UsuarioCreacion = Convert.ToString(WindowsSession.UserIdActual), //WindowsSession.UsuarioActual,
                UsuarioModificacion = Convert.ToString(WindowsSession.UserIdActual), //WindowsSession.UsuarioActual,
                IdUsuarioActual = WindowsSession.UserIdActual,
                FechaCreacion =  DateTime.Now,
                FechaModificacion =DateTime.Now
            };
        }

        //Obtiene datos por el id_usuario
        private void GetDatosUsuario()
        {
            if (txtid.Text != "0")
            {

                var jsonResponse = new JsonResponse { Success = false };

                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Usuario_GetById, GetUsuario(), ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var usuarioListDTO = (List<SEG_USUARIODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<SEG_USUARIODTO>()).GetType());
                    //this.ETUsuariobindingSource.DataSource = usuarioListDTO;
                    //--------------------------

                    for (int i = 0; i < usuarioListDTO.Count; i++)
                    {
                        txtApellidos.Text = string.IsNullOrEmpty(usuarioListDTO[i].apellidos) ? string.Empty : usuarioListDTO[i].apellidos.ToString();
                        txtEmail.Text = string.IsNullOrEmpty(usuarioListDTO[i].email) ? string.Empty : usuarioListDTO[i].email.ToString();
                        txtLoginName.Text = string.IsNullOrEmpty(usuarioListDTO[i].usuario) ? string.Empty : usuarioListDTO[i].usuario.ToString();
                        txtpassword.Text = string.IsNullOrEmpty(usuarioListDTO[i].clave) ? string.Empty : usuarioListDTO[i].clave.ToString();
                        txtNombres.Text = string.IsNullOrEmpty(usuarioListDTO[i].nombres) ? string.Empty : usuarioListDTO[i].nombres.ToString();
                        cmbEstado.Text = string.IsNullOrEmpty(usuarioListDTO[i].estado) ? string.Empty : usuarioListDTO[i].estado.ToString();
                        txtDni.Text = string.IsNullOrEmpty(usuarioListDTO[i].nro_documento) ? string.Empty : usuarioListDTO[i].nro_documento.ToString();
                        txtCelular.Text = string.IsNullOrEmpty(usuarioListDTO[i].celular) ? string.Empty : usuarioListDTO[i].celular.ToString();
                        //cmbTipo.ValueMember = usuarioListDTO[i].id_rol.ToString();
                        cmbTipo.Text = string.IsNullOrEmpty(usuarioListDTO[i].RolNombre) ? string.Empty : usuarioListDTO[i].RolNombre.ToString();
                    }
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
                
            }

            
        }

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Choose Image";
            openFileDialog1.Filter = "Images (*.JPEG;*.BMP;*.JPG;*.GIF;*.PNG;*.)|*.JPEG;*.BMP;*.JPG;*.GIF;*.PNG";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(openFileDialog1.FileName);
                //picFoto.Image = img;// resizeImage(img);
                picFoto.BackgroundImage = img;
            }
        }

        private void lblTituloUuario_Click(object sender, EventArgs e)
        {

        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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
    }
 
    
}
