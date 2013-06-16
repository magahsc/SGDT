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
    public partial class CapacitacionesProcesadas : System.Web.UI.Page
    {
        CapacitarProyectadoBC objcapacitar = new CapacitarProyectadoBC();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarComboBox();
                mesDropDownList.DataSource = ListaMes(1);
                mesDropDownList.DataBind();
                mesDropDownList.Items.Insert(0, new ListItem("Seleccione el mes", ""));

                anioDropDownList.DataSource = ListaAnio(2013);
                anioDropDownList.DataBind();
                anioDropDownList.Items.Insert(0, new ListItem("Seleccione el año", ""));

                estadoDropDownList.DataSource = listaestado();
                estadoDropDownList.DataBind();
                estadoDropDownList.Items.Insert(0, new ListItem("Seleccione el estado", ""));

                CapacitacionesAprobarLinkButton.Enabled = true;
                CapacitacionesProcesadasLinkButton.Enabled = true;
            }
        }

        public List<String> listaestado()
        {
            List<String> lsestado = new List<string>();

            lsestado.Add("Actualizado");
            lsestado.Add("Aprobación de Presupuesto");
            lsestado.Add("Eliminado");
            lsestado.Add("Envío de solicitud");
            lsestado.Add("Preaprobado");
            lsestado.Add("Rechazado");

            return lsestado;
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

        protected void LocalidadDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaDropDownList.Enabled = true;
            LocalidadDropDownList.Enabled = true;
            SeccionDropDownList.Enabled = false;

            ListasCapacitacionesAprobacionGridView.DataSource = null;
            ListasCapacitacionesAprobacionGridView.DataBind();
            DatosUpdatePanel.Update();

            if (LocalidadDropDownList.SelectedIndex != 0)
            {
                int codigolocalidad = Convert.ToInt32(LocalidadDropDownList.SelectedValue);
                AreaDropDownList.DataSource = objcapacitar.filtrarAreasXLocalidad(codigolocalidad);

                if (AreaDropDownList.Items.Count != 0)
                { AreaDropDownList.DataBind(); }

                AreaDropDownList.Items.Insert(0, new ListItem("Seleccione el area", ""));

                if (LocalidadDropDownList.SelectedIndex == 0)
                {
                    AreaDropDownList.Enabled = false;
                    SeccionDropDownList.Enabled = false;
                }
                Criterios1UpdatePanel.Update();
                Criterios2UpdatePanel.Update();
            }

            if (LocalidadDropDownList.SelectedIndex == 0)
            {
                AreaDropDownList.Enabled = false;
                SeccionDropDownList.Enabled = false;
                Criterios2UpdatePanel.Update();
                Criterios1UpdatePanel.Update();
            }

            ListarPresupuestos();
        }

        protected void AreaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeccionDropDownList.Enabled = true;
            AreaDropDownList.Enabled = true;
            LocalidadDropDownList.Enabled = true;

            ListasCapacitacionesAprobacionGridView.DataSource = null;
            ListasCapacitacionesAprobacionGridView.DataBind();
            DatosUpdatePanel.Update();

            int codigoLocalidad = Convert.ToInt32(LocalidadDropDownList.SelectedValue);

            if (AreaDropDownList.SelectedIndex != 0)
            {
                int codigoArea = Convert.ToInt32(AreaDropDownList.SelectedValue);

                SeccionDropDownList.DataSource = objcapacitar.filtrarSeccionesXAreaLocalidad(codigoArea, codigoLocalidad);

                if (SeccionDropDownList.Items.Count != 0)
                { SeccionDropDownList.DataBind(); }

                SeccionDropDownList.Items.Insert(0, new ListItem("Seleccione la seccion", ""));

                if (AreaDropDownList.SelectedIndex == 0)
                {
                    SeccionDropDownList.Enabled = false;
                }

                Criterios1UpdatePanel.Update();
                Criterios2UpdatePanel.Update();
            }

            if (AreaDropDownList.SelectedIndex == 0)
            {
                LocalidadDropDownList.Enabled = true;
                SeccionDropDownList.Enabled = false;
                Criterios1UpdatePanel.Update();
                Criterios2UpdatePanel.Update();
            }

            ListarPresupuestos();

        }

        protected void SeccionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeccionDropDownList.Enabled = true;
            AreaDropDownList.Enabled = true;
            LocalidadDropDownList.Enabled = true;

            ListasCapacitacionesAprobacionGridView.DataSource = null;
            ListasCapacitacionesAprobacionGridView.DataBind();
            DatosUpdatePanel.Update();

            if (SeccionDropDownList.SelectedIndex != 0)
            {
                DatosUpdatePanel.Update();
                Criterios1UpdatePanel.Update();
                Criterios2UpdatePanel.Update();

            }

            if (SeccionDropDownList.SelectedIndex == 0)
            {
                AreaDropDownList.Enabled = true;
                LocalidadDropDownList.Enabled = true;
                SeccionDropDownList.Enabled = true;
                Criterios1UpdatePanel.Update();
                Criterios2UpdatePanel.Update();

            }

            ListarPresupuestos();
        }

        public void cargarComboBox()
        {
            LocalidadDropDownList.DataSource = objcapacitar.listarLocalidades();
            LocalidadDropDownList.DataTextField = "nombre_localidad";
            LocalidadDropDownList.DataValueField = "id_localidad";
            LocalidadDropDownList.DataBind();
            LocalidadDropDownList.Items.Insert(0, new ListItem("Seleccione la localidad", ""));

            AreaDropDownList.DataSource = objcapacitar.listarAreas();
            AreaDropDownList.DataTextField = "nombre_area";
            AreaDropDownList.DataValueField = "id_area";
            AreaDropDownList.DataBind();
            AreaDropDownList.Items.Insert(0, new ListItem("Seleccione el area", ""));

            SeccionDropDownList.DataSource = objcapacitar.listarSecciones();
            SeccionDropDownList.DataTextField = "nombre_seccion";
            SeccionDropDownList.DataValueField = "id_seccion";
            SeccionDropDownList.DataBind();
            SeccionDropDownList.Items.Insert(0, new ListItem("Seleccione la seccion", ""));

        }

        protected void mesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarPresupuestos();
        }

        protected void anioDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarPresupuestos();
        }

        public void ListarPresupuestos()
        {
            AprobarPresupuestoBE objAprobar = new AprobarPresupuestoBE();
            if (mesDropDownList.SelectedIndex == 0)
                objAprobar.Mes = 0;
            if (anioDropDownList.SelectedIndex == 0)
                objAprobar.Anio = 0;
            if (LocalidadDropDownList.SelectedIndex == 0)
                objAprobar.CodLocalidad = 0;
            if (AreaDropDownList.SelectedIndex == 0)
                objAprobar.CodArea = 0;
            if (SeccionDropDownList.SelectedIndex == 0)
                objAprobar.CodSeccion = 0;
            if (estadoDropDownList.SelectedIndex == 0)
                objAprobar.Presupuesto_aprobado = "T";

            if (mesDropDownList.SelectedIndex > 0)
                objAprobar.Mes = mesa(mesDropDownList.SelectedValue);
            if (anioDropDownList.SelectedIndex > 0)
                objAprobar.Anio = Convert.ToInt32(anioDropDownList.SelectedValue);
            if (LocalidadDropDownList.SelectedIndex > 0)
                objAprobar.CodLocalidad = Convert.ToInt32(LocalidadDropDownList.SelectedValue);
            if (AreaDropDownList.SelectedIndex > 0)
                objAprobar.CodArea = Convert.ToInt32(AreaDropDownList.SelectedValue);
            if (SeccionDropDownList.SelectedIndex > 0)
                objAprobar.CodSeccion = Convert.ToInt32(SeccionDropDownList.SelectedValue);

            if (estadoDropDownList.SelectedIndex == 1)
                objAprobar.Presupuesto_aprobado = "A";
            if (estadoDropDownList.SelectedIndex == 2)
                objAprobar.Presupuesto_aprobado = "AP";
            if (estadoDropDownList.SelectedIndex == 3)
                objAprobar.Presupuesto_aprobado = "E";
            if (estadoDropDownList.SelectedIndex == 4)
                objAprobar.Presupuesto_aprobado = "ES";
            if (estadoDropDownList.SelectedIndex == 5)
                objAprobar.Presupuesto_aprobado = "PA";
            if (estadoDropDownList.SelectedIndex == 6)
                objAprobar.Presupuesto_aprobado = "R";


            List<AprobarPresupuestoBE> lista = new List<AprobarPresupuestoBE>();
            lista = objcapacitar.ListaCapacitacionesProcesadas(objAprobar);

            try
            {
                if (lista != null)
                {
                    ListasCapacitacionesAprobacionGridView.DataSource = lista;
                    ListasCapacitacionesAprobacionGridView.DataBind();
                    ListasCapacitacionesAprobacionGridView.Visible = true;
                }

                if (lista == null)
                {
                    ListasCapacitacionesAprobacionGridView.Visible = false;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensaje('No existen presupuestos para mostrar')", true);
                }
                DatosUpdatePanel.Update();
                Criterios1UpdatePanel.Update();
                Criterios2UpdatePanel.Update();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensaje('Error en la operación. Inténtelo nuevamente')", true);
            }
        }

        public List<AprobarPresupuestoBE> DevolverLista()
        {
            AprobarPresupuestoBE objAprobar = new AprobarPresupuestoBE();
            if (mesDropDownList.SelectedIndex == 0)
                objAprobar.Mes = 0;
            if (anioDropDownList.SelectedIndex == 0)
                objAprobar.Anio = 0;
            if (LocalidadDropDownList.SelectedIndex == 0)
                objAprobar.CodLocalidad = 0;
            if (AreaDropDownList.SelectedIndex == 0)
                objAprobar.CodArea = 0;
            if (SeccionDropDownList.SelectedIndex == 0)
                objAprobar.CodSeccion = 0;
            if (estadoDropDownList.SelectedIndex == 0)
                objAprobar.Presupuesto_aprobado = "T";

            if (mesDropDownList.SelectedIndex > 0)
                objAprobar.Mes = mesa(mesDropDownList.SelectedValue);
            if (anioDropDownList.SelectedIndex > 0)
                objAprobar.Anio = Convert.ToInt32(anioDropDownList.SelectedValue);
            if (LocalidadDropDownList.SelectedIndex > 0)
                objAprobar.CodLocalidad = Convert.ToInt32(LocalidadDropDownList.SelectedValue);
            if (AreaDropDownList.SelectedIndex > 0)
                objAprobar.CodArea = Convert.ToInt32(AreaDropDownList.SelectedValue);
            if (SeccionDropDownList.SelectedIndex > 0)
                objAprobar.CodSeccion = Convert.ToInt32(SeccionDropDownList.SelectedValue);

            if (estadoDropDownList.SelectedIndex == 1)
                objAprobar.Presupuesto_aprobado = "A";
            if (estadoDropDownList.SelectedIndex == 2)
                objAprobar.Presupuesto_aprobado = "AP";
            if (estadoDropDownList.SelectedIndex == 3)
                objAprobar.Presupuesto_aprobado = "E";
            if (estadoDropDownList.SelectedIndex == 4)
                objAprobar.Presupuesto_aprobado = "ES";
            if (estadoDropDownList.SelectedIndex == 5)
                objAprobar.Presupuesto_aprobado = "PA";
            if (estadoDropDownList.SelectedIndex == 6)
                objAprobar.Presupuesto_aprobado = "R";

            List<AprobarPresupuestoBE> lista = new List<AprobarPresupuestoBE>();
            lista = objcapacitar.ListaCapacitacionesProcesadas(objAprobar);
            return lista;
        }


        protected void CapacitacionesAprobarLinkButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("SolicitudAprobacionCapacitacion.aspx");
        }

        protected void CapacitacionesProcesadasLinkButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("AprobacionCapacitacion.aspx");
        }

        protected void ListasCapacitacionesAprobacionGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdMotivo"))
            {
                List<AprobarPresupuestoBE> lista = new List<AprobarPresupuestoBE>();
                lista = DevolverLista();

                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });

                String id = commandArgs[0];
                String Estado = commandArgs[1];

                Session.Add("ListaProcesada", lista);
                Session.Add("EstadoProcesado", Estado);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarAspxAsPopUpMotivo(" + id + ")", true);
            }

            Criterios1UpdatePanel.Update();
            Criterios2UpdatePanel.Update();
            DatosUpdatePanel.Update();
        }

        protected void estadoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarPresupuestos();
        }

    }
}