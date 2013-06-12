using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNRS.ModuloPresupuesto.BL.BC;
using GNRS.ModuloPresupuesto.DL.DALC;
using System.Data.Entity;
using System.Globalization;
using System.Web.Services;
using GNRS.ModuloPresupuesto.BL.BE;


namespace GNRS.ModuloPresupuesto.UI
{
    public partial class ListarPresupuestoCapacitacion : System.Web.UI.Page
    {
        CapacitarProyectadoBC objcapacitar = new CapacitarProyectadoBC();

        protected void Page_Load(object sender, EventArgs e)
        {
            MensajeLabel.Text = "";
            MensajeUpdatePanel.Update();

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
                mesDropDownList.DataSource = ListaMes(1);
                mesDropDownList.DataBind();
                mesDropDownList.Items.Insert(0, new ListItem("Seleccione el mes", ""));

                anioDropDownList.DataSource = ListaAnio(2013);
                anioDropDownList.DataBind();
                anioDropDownList.Items.Insert(0, new ListItem("Seleccione el año", ""));

                estadoDropDownList.DataSource = listaestado();
                estadoDropDownList.DataBind();
                estadoDropDownList.Items.Insert(0, new ListItem("Seleccione el estado", ""));

                CriteriosUpdatePanel.Update();
            }
        }

        public String sabermesxnumero(int mes)
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
                lista.Add(sabermesxnumero(i));
            }

            return lista;
        }

        public List<int> ListaAnio(int numeroanio)
        {
            List<int> lista = new List<int>();

            for (int i = numeroanio; i <= numeroanio + 20; i++)
            {
                lista.Add(i);
            }

            return lista;
        }

        public List<String> listaestado()
        {
            List<String> lsestado = new List<string>();

            lsestado.Add("Pendiente");
            lsestado.Add("Aprobado");
            lsestado.Add("No aprobado");

            return lsestado;
        }

        /* protected void mesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
         {
             CriteriosUpdatePanel.Update();
             ListasCapacitarProyectadaGridView.DataSource = null;
             ListasCapacitarProyectadaGridView.DataBind();
             DatosUpdatePanel.Update();
         }

         protected void anioDropDownList_SelectedIndexChanged(object sender, EventArgs e)
         {
             CriteriosUpdatePanel.Update();
             ListasCapacitarProyectadaGridView.DataSource = null;
             ListasCapacitarProyectadaGridView.DataBind();
             DatosUpdatePanel.Update();
         }

         protected void estadoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
         {
             CriteriosUpdatePanel.Update();
             ListasCapacitarProyectadaGridView.DataSource = null;
             ListasCapacitarProyectadaGridView.DataBind();
             DatosUpdatePanel.Update();
         }*/

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            CapacitacionProyectadaBE objcapacitacionBE = new CapacitacionProyectadaBE();

            if (mesDropDownList.SelectedIndex == 0)
                objcapacitacionBE.Mes = 0;
            if (anioDropDownList.SelectedIndex == 0)
                objcapacitacionBE.Anio = 0;
            if (estadoDropDownList.SelectedIndex == 0)
                objcapacitacionBE.Presupuesto_aprobado = "V";

            if (estadoDropDownList.SelectedIndex == 1)
                objcapacitacionBE.Presupuesto_aprobado = "P";

            if (estadoDropDownList.SelectedIndex == 2)
                objcapacitacionBE.Presupuesto_aprobado = "N";

            if (estadoDropDownList.SelectedIndex == 3)
                objcapacitacionBE.Presupuesto_aprobado = "A";

            if (mesDropDownList.SelectedIndex > 0)
                objcapacitacionBE.Mes = Convert.ToInt32(mesa(mesDropDownList.SelectedValue));
            if (anioDropDownList.SelectedIndex > 0)
                objcapacitacionBE.Anio = Convert.ToInt32(anioDropDownList.SelectedValue);


            List<CapacitacionProyectadaBE> lista = objcapacitar.listarCapacitacionProyectadaxMesxAnioxEstado(objcapacitacionBE);

            try
            {
                if (lista != null)
                {
                    ListasCapacitarProyectadaGridView.DataSource = lista;
                    ListasCapacitarProyectadaGridView.DataBind();
                    ListasCapacitarProyectadaGridView.Visible = true;
                    //MensajeLabel.Text = "";
                }

                if (lista == null)
                {
                    //MensajeLabel.Visible = true;
                    ListasCapacitarProyectadaGridView.Visible = false;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensaje('No existen presupuestos para mostrar')", true);
                    // MensajeLabel.Text = "No existen presupuestos para mostrar.";
                }
                DatosUpdatePanel.Update();
                CriteriosUpdatePanel.Update();
                MensajeUpdatePanel.Update();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensaje('Error en la operación. Inténtelo nuevamente')", true);
            }

        }

        [WebMethod]
        public static string eliminar(string sIdCapacitacion)
        {
            int iIdcapacitacion;
            PRESUPUESTO_CAPACITACION objpresupuesto = new PRESUPUESTO_CAPACITACION();
            AUDITORIA_PRESUPUESTO objauditoria = new AUDITORIA_PRESUPUESTO();

            CapacitarProyectadoBC objcapacitar = new CapacitarProyectadoBC();

            iIdcapacitacion = Convert.ToInt32(sIdCapacitacion);
            objcapacitar.ActualizarEstadoPresupuestoCapacitacion(iIdcapacitacion);

            objpresupuesto = objcapacitar.ObtenerPresupuestoCapacitacion(iIdcapacitacion);

            objauditoria.id_capacitacion_proyectada = iIdcapacitacion;
            objauditoria.id_personal_proyectado = 0;
            objauditoria.fecha_accion = DateTime.Now;
            objauditoria.tipo_accion = "E";
            objauditoria.id_actividad_proyectada = 0;
            objauditoria.tipo_presupuesto = "C";
            objauditoria.descripcion_auditoria = "";

            objcapacitar.RegistrarAuditoriaPresupuesto(objauditoria);
            String mensaje = "El presupuesto de capacitación proyectada " + objpresupuesto.codigo_presupuesto + " ha sido eliminado exitosamente";
            return mensaje;

        }

        protected void ListasCapacitarProyectadaGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            String sIdCapacitacion = "";
            int iIdcapacitacion;
            PRESUPUESTO_CAPACITACION obj = new PRESUPUESTO_CAPACITACION();

            if (e.CommandName.ToUpper().Equals("CMDEDITAR"))
            {
                sIdCapacitacion = e.CommandArgument.ToString();
                iIdcapacitacion = Convert.ToInt32(sIdCapacitacion);
                CriteriosUpdatePanel.Update();
                MensajeUpdatePanel.Update();
                DatosUpdatePanel.Update();
                obj = objcapacitar.ObtenerPresupuestoCapacitacion(iIdcapacitacion);
                if (obj.presupuesto_aprobado == "P")
                {
                    Session.Add("IdCapacitacion", iIdcapacitacion);
                    string Fullurl = "EditarPresupuestoCapacitacion.aspx";
                    OpenNewBrowserWindow(Fullurl, this);
                    //Server.Transfer("EditarPresupuestoCapacitacion.aspx");
                }

            }

        }

        public void alert(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        public static void OpenNewBrowserWindow(string Url, Control control)
        {
            ScriptManager.RegisterStartupScript(control, control.GetType(), "Open", "window.open('" + Url + "');", true);
        }

     /*   protected void PruebaButton_Click(object sender, EventArgs e)
        {
            CapacitacionProyectadaBE objcapacitacionBE = new CapacitacionProyectadaBE();

            if (mesDropDownList.SelectedIndex == 0)
                objcapacitacionBE.Mes = 0;
            if (anioDropDownList.SelectedIndex == 0)
                objcapacitacionBE.Anio = 0;
            if (estadoDropDownList.SelectedIndex == 0)
                objcapacitacionBE.Presupuesto_aprobado = "V";

            if (estadoDropDownList.SelectedIndex == 1)
                objcapacitacionBE.Presupuesto_aprobado = "P";

            if (estadoDropDownList.SelectedIndex == 2)
                objcapacitacionBE.Presupuesto_aprobado = "N";

            if (estadoDropDownList.SelectedIndex == 3)
                objcapacitacionBE.Presupuesto_aprobado = "A";

            if (mesDropDownList.SelectedIndex > 0)
                objcapacitacionBE.Mes = Convert.ToInt32(mesa(mesDropDownList.SelectedValue));
            if (anioDropDownList.SelectedIndex > 0)
                objcapacitacionBE.Anio = Convert.ToInt32(anioDropDownList.SelectedValue);


            List<CapacitacionProyectadaBE> lista = objcapacitar.listarCapacitacionProyectadaxMesxAnioxEstado(objcapacitacionBE);

            try
            {
                if (lista != null)
                {
                    ListasCapacitarProyectadaGridView.DataSource = lista;
                    ListasCapacitarProyectadaGridView.DataBind();
                    ListasCapacitarProyectadaGridView.Visible = true;
                    //MensajeLabel.Text = "";
                    DatosUpdatePanel.Update();
                    //MensajeUpdatePanel.Update();
                }

                if (lista == null)
                {
                    //MensajeLabel.Visible = true;
                    ListasCapacitarProyectadaGridView.Visible = false;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensaje('No existen presupuestos para mostrar')", true);
                    // MensajeLabel.Text = "No existen presupuestos para mostrar.";
                    //MensajeUpdatePanel.Update();
                    DatosUpdatePanel.Update();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensaje('Error en la operación. Inténtelo nuevamente')", true);
            }

        }*/

    }
}