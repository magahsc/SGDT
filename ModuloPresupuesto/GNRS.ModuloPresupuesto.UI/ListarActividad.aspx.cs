using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNRS.ModuloPresupuesto.BL.BC;
using GNRS.ModuloPresupuesto.BL.BE;
using GNRS.ModuloPresupuesto.DL.DALC;
using System.Data.Entity;
using System.Globalization;
using System.Web.Services;

namespace GNRS.ModuloPresupuesto.UI
{
    public partial class ListarActividad : System.Web.UI.Page
    {
        CapacitarProyectadoBC objcapacitar = new CapacitarProyectadoBC();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ClientScript.GetPostBackEventReference(this, string.Empty);

            if (this.IsPostBack)
            {
                string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];

                if (eventTarget == "BuscarButton_onClick")
                {
                    BuscarButton_Click(sender, e);
                }
            }


            if (!IsPostBack)
            {
                int imes = 1;

                mesInicioDropDownList.DataSource = ListaMes(imes);
                mesInicioDropDownList.DataBind();
                mesInicioDropDownList.Items.Insert(0, new ListItem("Seleccione el mes", ""));

                anioInicioDropDownList.DataSource = ListaAnio(DateTime.Now.Year);
                anioInicioDropDownList.DataBind();
                anioInicioDropDownList.Items.Insert(0, new ListItem("Seleccione el año", ""));

                mesFinDropDownList.DataSource = ListaMes(imes);
                mesFinDropDownList.DataBind();
                mesFinDropDownList.Items.Insert(0, new ListItem("Seleccione el mes", ""));

                anioFinDropDownList.DataSource = ListaAnio(DateTime.Now.Year);
                anioFinDropDownList.DataBind();
                anioFinDropDownList.Items.Insert(0, new ListItem("Seleccione el año", ""));

                estadoDropDownList.DataSource = listaestado();
                estadoDropDownList.DataBind();
                estadoDropDownList.Items.Insert(0, new ListItem("Seleccione el estado", ""));

            }
        }

        public String mes(int mes)
        {
            String mesd = "";
            switch (mes)
            {
                case 1:
                    {
                        mesd = "Enero";
                        break;
                    }

                case 2:
                    {
                        mesd = "Febrero";
                        break;
                    }

                case 3:
                    {
                        mesd = "Marzo";
                        break;
                    }

                case 4:
                    {
                        mesd = "Abril";
                        break;
                    }

                case 5:
                    {
                        mesd = "Mayo";
                        break;
                    }

                case 6:
                    {
                        mesd = "Junio";
                        break;
                    }

                case 7:
                    {
                        mesd = "Julio";
                        break;
                    }

                case 8:
                    {
                        mesd = "Agosto";
                        break;
                    }

                case 9:
                    {
                        mesd = "Setiembre";
                        break;
                    }

                case 10:
                    {
                        mesd = "Octubre";
                        break;
                    }

                case 11:
                    {
                        mesd = "Noviembre";
                        break;
                    }

                case 12:
                    {
                        mesd = "Diciembre";
                        break;
                    }
            }
            return mesd;
        }

        public List<String> listaestado()
        {
            List<String> lsestado = new List<string>();

            lsestado.Add("Pendiente");
            lsestado.Add("Aprobado");
            lsestado.Add("No aprobado");

            return lsestado;
        }

        public int mesa(String mes)
        {
            int mesd = 0;
            switch (mes)
            {
                case "Enero":
                    {
                        mesd = 1;
                        break;
                    }

                case "Febrero":
                    {
                        mesd = 2;
                        break;
                    }

                case "Marzo":
                    {
                        mesd = 3;
                        break;
                    }

                case "Abril":
                    {
                        mesd = 4;
                        break;
                    }

                case "Mayo":
                    {
                        mesd = 5;
                        break;
                    }

                case "Junio":
                    {
                        mesd = 6;
                        break;
                    }

                case "Julio":
                    {
                        mesd = 7;
                        break;
                    }

                case "Agosto":
                    {
                        mesd = 8;
                        break;
                    }

                case "Setiembre":
                    {
                        mesd = 9;
                        break;
                    }

                case "Octubre":
                    {
                        mesd = 10;
                        break;
                    }

                case "Noviembre":
                    {
                        mesd = 11;
                        break;
                    }

                case "Diciembre":
                    {
                        mesd = 12;
                        break;
                    }
            }
            return mesd;
        }

        public List<String> ListaMes(int numeromes)
        {
            List<String> lista = new List<String>();

            for (int i = numeromes; i <= 12; i++)
            {
                lista.Add(mes(i));
            }

            return lista;
        }

        public List<int> ListaAnio(int numeroanio)
        {
            List<int> lista = new List<int>();

            for (int i = 2010; i <= numeroanio + 1; i++)
            {
                lista.Add(i);
            }

            return lista;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            ActividadBE objactividad = new ActividadBE();
            if (mesInicioDropDownList.SelectedIndex == 0)
                objactividad.MesInicio = 0;

            if (mesFinDropDownList.SelectedIndex == 0)
                objactividad.MesFinal = 0;

            if (anioInicioDropDownList.SelectedIndex == 0)
                objactividad.AnioInicio = 0;

            if (anioFinDropDownList.SelectedIndex == 0)
                objactividad.AnioFinal = 0;

            if (estadoDropDownList.SelectedIndex == 0)
                objactividad.Presupuesto_aprobado = "V";


            if (estadoDropDownList.SelectedIndex == 1)
                objactividad.Presupuesto_aprobado = "P";

            if (estadoDropDownList.SelectedIndex == 2)
                objactividad.Presupuesto_aprobado = "N";

            if (estadoDropDownList.SelectedIndex == 3)
                objactividad.Presupuesto_aprobado = "A";


            if (mesInicioDropDownList.SelectedIndex > 0)
                objactividad.MesInicio = mesa(mesInicioDropDownList.SelectedValue);
            if (anioInicioDropDownList.SelectedIndex > 0)
                objactividad.AnioInicio = Convert.ToInt32(anioInicioDropDownList.SelectedValue);
            if (mesFinDropDownList.SelectedIndex > 0)
                objactividad.MesFinal = mesa(mesFinDropDownList.SelectedValue);
            if (anioFinDropDownList.SelectedIndex > 0)
                objactividad.AnioFinal = Convert.ToInt32(anioFinDropDownList.SelectedValue);

            List<ActividadBE> lista = objcapacitar.listarActividadxMesxEstado(objactividad);

            if (lista != null)
            {
                ListaActividadProyectadaGridView.DataSource = lista;
                ListaActividadProyectadaGridView.Visible = true;
                ListaActividadProyectadaGridView.DataBind();
                MensajeLabel.Text = "";
                DatosUpdatePanel.Update();
                MensajeUpdatePanel.Update();
            }

            if (lista == null)
            {
                MensajeLabel.Visible = true;
                ListaActividadProyectadaGridView.Visible = false;
                MensajeLabel.Text = "No existen presupuestos para mostrar.";
                MensajeUpdatePanel.Update();
                DatosUpdatePanel.Update();
            }

        }

        /*protected void ListaActividadProyectadaGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           string[] arg = new string[2];

            if (e.CommandName.ToUpper().Equals("CMDELIMINAR"))
            {
                arg = e.CommandArgument.ToString().Split(';');
                hdnSession1.Value = arg[0];
                hdnSession2.Value = arg[1];
            }

            MensajeUpdatePanel.Update();
            CriteriosUpdatePanel.Update();
            DatosUpdatePanel.Update();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarMensajeConfirmacion()", true);
        }*/

        [WebMethod]
        public static string eliminar(string sIdActividad, string sco)
        {
            int iIdActividad;
            AUDITORIA_PRESUPUESTO objauditoria = new AUDITORIA_PRESUPUESTO();
            CapacitarProyectadoBC objcapacitar = new CapacitarProyectadoBC();

            iIdActividad = Convert.ToInt32(sIdActividad);
            objcapacitar.ActualizarEstadoActividadPresupuesto(iIdActividad);

            objauditoria.id_capacitacion_proyectada = 0;
            objauditoria.id_personal_proyectado = 0;
            objauditoria.fecha_accion = DateTime.Now;
            objauditoria.tipo_accion = "E";
            objauditoria.id_actividad_proyectada = iIdActividad;
            objauditoria.tipo_presupuesto = "A";
            objauditoria.descripcion_auditoria = "";

            objcapacitar.RegistrarAuditoriaPresupuesto(objauditoria);
            String mensaje = "El presupuesto de actividad de RRHH " + sco + " ha sido eliminado satisfactoriamente";
            return mensaje;

        }

    }
}