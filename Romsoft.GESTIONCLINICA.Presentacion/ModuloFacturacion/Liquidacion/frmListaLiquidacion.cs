using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_PROFESIONAL;
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

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloFacturacion.Liquidacion
{ 
    public partial class frmListaLiquidacion : Form
    {
        public int intTipoConsulta = 0;

        public frmListaLiquidacion()
        {
            InitializeComponent();
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
                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_PROFESIONAL_GetAllFilters, GetProfesional(), ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var ProfListDTO = (List<ADM_PROFESIONALDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_PROFESIONALDTO>()).GetType());
                        this.ETProfesional.DataSource = ProfListDTO;
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

                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_PROFESIONAL_GetAllFilters, GetProfesional(), ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var catpagoListDTO = (List<ADM_PROFESIONALDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_PROFESIONALDTO>()).GetType());
                        this.ETProfesional.DataSource = catpagoListDTO;
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
        private ADM_PROFESIONALDTO GetProfesional()
        {
            return new ADM_PROFESIONALDTO
            {
                valor = ComunFilter.ValorRequest,
            };
        }

        

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            
        }

       

        private void btnNuevo_Click(object sender, EventArgs e)
        {
           
        }

        private void PctSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrar_Click_1(object sender, EventArgs e)
        {
            ModuloFacturacion.Liquidacion.frmFiltroLiquidacion frm = new ModuloFacturacion.Liquidacion.frmFiltroLiquidacion();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //InitialLoad(0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModuloFacturacion.Liquidacion.frmNuevoLiquidacion frm = new ModuloFacturacion.Liquidacion.frmNuevoLiquidacion();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //InitialLoad(0);
            }
        }
    }
}
