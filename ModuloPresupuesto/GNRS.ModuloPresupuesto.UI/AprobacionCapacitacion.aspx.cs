﻿using System;
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
    public partial class AprobacionCapacitacion : System.Web.UI.Page
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

                CapacitacionesAprobarLinkButton.Enabled = true;
                CapacitacionesProcesadasLinkButton.Enabled = false;
            }
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


            List<AprobarPresupuestoBE> lista = new List<AprobarPresupuestoBE>();
            lista = objcapacitar.ListaCapacitacionesParaAprobar(objAprobar, "PA");

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


            List<AprobarPresupuestoBE> lista = new List<AprobarPresupuestoBE>();
            lista = objcapacitar.ListaCapacitacionesParaAprobar(objAprobar, "PA");
            return lista;
        }

        protected void AprobarButton_Click(object sender, EventArgs e)
        {
            Boolean entrar = false;
            int cod;
            String mot;

            foreach (GridViewRow row in ListasCapacitacionesAprobacionGridView.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("AprobarSelectCheckBox");
                TextBox textbox = (TextBox)row.FindControl("MotivoTextBox");
                if (check.Checked)
                {

                    cod = (int)ListasCapacitacionesAprobacionGridView.DataKeys[row.RowIndex].Value;
                    mot = textbox.Text;

                    PRESUPUESTO_CAPACITACION objPresupuesto = new PRESUPUESTO_CAPACITACION();
                    objPresupuesto.id_presupuesto_capacitacion = cod;
                    objPresupuesto.presupuesto_aprobado = "A";
                    objcapacitar.ActualizarCapacitacionParaAprobarEstado(objPresupuesto);


                    AUDITORIA_PRESUPUESTO objauditoria = new AUDITORIA_PRESUPUESTO();

                    objauditoria.id_capacitacion_proyectada = cod;
                    objauditoria.id_personal_proyectado = 0;
                    objauditoria.fecha_accion = DateTime.Now;
                    objauditoria.tipo_accion = "AP";
                    objauditoria.id_actividad_proyectada = 0;
                    objauditoria.tipo_presupuesto = "C";
                    objauditoria.descripcion_auditoria = mot;

                    objcapacitar.RegistrarAuditoriaPresupuesto(objauditoria);

                    entrar = true;

                }

            }

            if (entrar == false)
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensaje('Debe marcar algun presupuesto de capacitación para la solicitud de aprobación')", true);

            if (entrar == true)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensaje('Se envió la solicitud de aprobación')", true);
                
                string body = "<p>Estimado(a)," +
                 "<br />Se le informa que se ha realizado una solicitud de aprobación de presupuesto de capacitación." +
                 "<br />Recomendamos realizar las acciones pertinentes" +
                 "<br />Gracias," +
                 "<br />Administrador del Sistema</p>";

                string asunto = "Aprobación de Presupuesto";
                ListarPresupuestos();
            }

        }

        protected void RechazarButton_Click(object sender, EventArgs e)
        {
            Boolean entrar = false;
            Boolean haytexto = false;
            Boolean mismacantidad = false;

            int cod;
            String mot;
            int cont = 0;


            foreach (GridViewRow row in ListasCapacitacionesAprobacionGridView.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("AprobarSelectCheckBox");
                TextBox textbox = (TextBox)row.FindControl("MotivoTextBox");
                cont++;
                if (check.Checked)
                {
                    cod = (int)ListasCapacitacionesAprobacionGridView.DataKeys[row.RowIndex].Value;
                    mot = textbox.Text;
                    cont--;

                    if (mot.Length == 0 || mot == "" || mot == null)
                    {
                        haytexto = true;
                    }
                }

                if (cont == DevolverLista().Count)
                {
                    haytexto = true;
                    mismacantidad = true;
                }

            }


            if (haytexto == false)
            {
                foreach (GridViewRow row in ListasCapacitacionesAprobacionGridView.Rows)
                {
                    CheckBox check = (CheckBox)row.FindControl("AprobarSelectCheckBox");
                    TextBox textbox = (TextBox)row.FindControl("MotivoTextBox");
                    if (check.Checked)
                    {
                        cod = (int)ListasCapacitacionesAprobacionGridView.DataKeys[row.RowIndex].Value;
                        mot = textbox.Text;

                        PRESUPUESTO_CAPACITACION objPresupuesto = new PRESUPUESTO_CAPACITACION();
                        objPresupuesto.id_presupuesto_capacitacion = cod;
                        objPresupuesto.presupuesto_aprobado = "R";
                        objcapacitar.ActualizarCapacitacionParaAprobarEstado(objPresupuesto);


                        AUDITORIA_PRESUPUESTO objauditoria = new AUDITORIA_PRESUPUESTO();

                        objauditoria.id_capacitacion_proyectada = cod;
                        objauditoria.id_personal_proyectado = 0;
                        objauditoria.fecha_accion = DateTime.Now;
                        objauditoria.tipo_accion = "R";
                        objauditoria.id_actividad_proyectada = 0;
                        objauditoria.tipo_presupuesto = "C";
                        objauditoria.descripcion_auditoria = mot;

                        objcapacitar.RegistrarAuditoriaPresupuesto(objauditoria);

                        entrar = true;
                    }

                }

            }


            if (mismacantidad == true)
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensaje('Debe marcar algun presupuesto de capacitación para la solicitud de aprobación')", true);

            if (haytexto == false)
            {
                if (entrar == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensaje('Se procesó satisfactoriamente')", true);
                    //correo

                    string body = "<p>Estimado(a)," +
              "<br />Se le informa que se ha rechazado la solicitud de aprobación de presupuesto de capacitación. Ingresar al sistema para mayor detalle." +
              "<br /> <br />Gracias," +
              "<br />Administrador del Sistema</p>";

                    string asunto = "Rechazo de Preaprobación";
                    ListarPresupuestos();
                    
                    ListarPresupuestos();
                }
            }

            if (haytexto == true)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensaje('Debe llenar todos los motivos en los casilleros marcados')", true);
            }
        }

        protected void CapacitacionesAprobarLinkButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("SolicitudAprobacionCapacitacion.aspx");
        }


        protected void ListasCapacitacionesAprobacionGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdMotivo"))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarAspxAsPopUpMotivo(" + e.CommandArgument + ")", true);
                 
            }

            Criterios1UpdatePanel.Update();
            Criterios2UpdatePanel.Update();
            DatosUpdatePanel.Update();
            SolicitarAprobacionUpdatePanel.Update();
        }

    }
}