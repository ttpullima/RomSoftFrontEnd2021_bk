using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Core;
using Romsoft.GESTIONCLINICA.Presentacion.Helpers;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Romsoft.GESTIONCLINICA.Presentacion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool result = true;

            if (string.IsNullOrEmpty(this.txtUser.Text))
            {
                this.errValidator.SetError(this.txtUser, "Ingresar Nombre Usuario.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtUser, string.Empty);
            }
            if (string.IsNullOrEmpty(this.txtPass.Text))
            {
                this.errValidator.SetError(this.txtPass, "Ingresar Contraseña.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtPass, string.Empty);
            }

            if (result)
            {

           
                AccountModel accountModel = new AccountModel { Username = this.txtUser.Text, Password = this.txtPass.Text };
                var jsonResponse = new JsonResponse { Success = false };

                try
                {
            
                    
                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Account_Login, accountModel, ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var usuarioModel = (UsuarioModel)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new UsuarioModel()).GetType());
                        WindowsSession.UsuarioActual = usuarioModel.usuario;
                        WindowsSession.UserIdActual = usuarioModel.id_usuario;
                        WindowsSession.RolIdActual = usuarioModel.id_rol;
                        WindowsSession.nombreUsuario = usuarioModel.apellidos + " " + usuarioModel.nombres;
                        //this.DialogResult = DialogResult.OK;
                        this.Hide();

                        frmPanelPrincipal frm = new frmPanelPrincipal();
                        frm.Show();

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

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnLogin.PerformClick();
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            txtUser.Text = "tony.tapullima@gmail.com";
        }
    }
}
