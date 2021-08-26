using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_TARIFARIO_SEGUS;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_TARIFARIO_SEGUS_PARTICIPANTE;
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
    public partial class frmFiltroParticipantes : Form
    {
        public EstadoActual estadoActual;

        public frmFiltroParticipantes()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //private void dgvListaOcupacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
            
        //}

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Color de Borde De formulario
            Rectangle rect = new Rectangle(e.ClipRectangle.X,
            e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            e.Graphics.DrawRectangle(Pens.Gray, rect);
        }

        private void frmFiltroParticipantes_Load(object sender, EventArgs e)
        {

            //dgvListaOcupacion.Rows.Add("010101", "ANESTESIOLOGO");
            //dgvListaOcupacion.Rows.Add("010102", "PRIMER AYUDANTE");
            this.estadoActual = EstadoActual.Nuevo;


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(this.txtDescripcion.Text))
                {
                    this.errValidator.SetError(this.txtDescripcion, "Ingresar Valor para Búsqueda.");
                    
                }
                else
                {

                    //Muestra Todo por filtro

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
                valorRequest = txtDescripcion.Text.Trim(),
            };
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnFiltrar.PerformClick();
            }
        }

        private void dgvListaOcupacion_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dgvListaOcupacion.Rows.Count > 0)
            {
                ComunFilter.codParticipante = dgvListaOcupacion.CurrentRow.Cells[0].Value.ToString(); //Codigo
                ComunFilter.nomParticipante = dgvListaOcupacion.CurrentRow.Cells[1].Value.ToString(); //Descripción
                ComunFilter.id_tarifario_segus = Convert.ToInt32(dgvListaOcupacion.CurrentRow.Cells[2].Value.ToString()); //id_tarifario_segus


                if (SaveData())
                {
                    this.estadoActual = EstadoActual.Normal;

                    DialogResult = DialogResult.OK;

                    this.Close();
                }
            }

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
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_TARIFARIO_SEGUS_PARTICIPANTE_Add, GetParticipante(), ConstantesWindows.METHODPOST);

                        // obtiene el último id registrado
                        ComunFilter.id_tarifario_segus_participante = Convert.ToInt32(jsonResponse.Data);

                        break;
                    //case EstadoActual.Eliminar:
                    //    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_TARIFARIO_SEGUS_PARTICIPANTE_Delete, new CVN_TARIFARIO_SEGUSDTO { id_tarifario_segus = Convert.ToInt32(this.txtIdTarifa.Text), UsuarioCreacion = WindowsSession.UsuarioActual }, ConstantesWindows.METHODPOST);
                    //    break;
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
        private CVN_TARIFARIO_SEGUS_PARTICIPANTEDTO GetParticipante()
        {

            return new CVN_TARIFARIO_SEGUS_PARTICIPANTEDTO
            {
                id_tarifario_segus = ComunFilter.f_id_tarifario_segus,
                id_tarifario_segus_referencia = ComunFilter.id_tarifario_segus,
                UsuarioCreacion = Convert.ToString(WindowsSession.UserIdActual), //WindowsSession.UsuarioActual,
                UsuarioModificacion = Convert.ToString(WindowsSession.UserIdActual), //WindowsSession.UsuarioActual,
                IdUsuarioActual = WindowsSession.UserIdActual,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            };
        }

    }
}
