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
            if (!IsPostBack)
            {
                    int imes = 1;

                    mesInicioDropDownList.DataSource = ListaMesInicio(imes);
                    mesInicioDropDownList.DataBind();
                    mesInicioDropDownList.Items.Insert(0, new ListItem("Seleccione el mes", ""));

                    estadoDropDownList.DataSource = listaestado();
                    estadoDropDownList.DataBind();
                    estadoDropDownList.Items.Insert(0, new ListItem("Seleccione el estado", ""));

            }
        }

        public String mes(int mes, int anio)
        {
            String mesd = "";
            switch (mes)
            {
                case 1:
                    {
                        mesd = "Enero - " + anio;
                        break;
                    }

                case 2:
                    {
                        mesd = "Febrero - " + anio;
                        break;
                    }

                case 3:
                    {
                        mesd = "Marzo - " + anio;
                        break;
                    }

                case 4:
                    {
                        mesd = "Abril - " + anio;
                        break;
                    }

                case 5:
                    {
                        mesd = "Mayo - " + anio;
                        break;
                    }

                case 6:
                    {
                        mesd = "Junio - " + anio;
                        break;
                    }

                case 7:
                    {
                        mesd = "Julio - " + anio;
                        break;
                    }

                case 8:
                    {
                        mesd = "Agosto - " + anio;
                        break;
                    }

                case 9:
                    {
                        mesd = "Setiembre - " + anio;
                        break;
                    }

                case 10:
                    {
                        mesd = "Octubre - " + anio;
                        break;
                    }

                case 11:
                    {
                        mesd = "Noviembre - " + anio;
                        break;
                    }

                case 12:
                    {
                        mesd = "Diciembre - " + anio;
                        break;
                    }
            }
            return mesd;
        }

        public List<String> ListaMesInicio(int numeromes)
        {
            List<String> lista = new List<String>();
            int ianio = DateTime.Now.Year;
            int variable = 0;
            int valida = 0;

            for (int i = numeromes; i <= numeromes + 11; i++)
            {
                if (i <= 12)
                    variable = i;

                if (i > 12 && valida == 0)
                {
                    variable = 1;
                    ianio++;
                    valida = 1;
                }

                lista.Add(mes(variable, ianio));
                variable++;
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

        public int GetCodMes(DropDownList dpl)
        {
            int scod = 0;

            if (dpl.SelectedValue.Contains("Enero"))
                scod = 1;
            if (dpl.SelectedValue.Contains("Febrero"))
                scod = 2;
            if (dpl.SelectedValue.Contains("Marzo"))
                scod = 3;
            if (dpl.SelectedValue.Contains("Abril"))
                scod = 4;
            if (dpl.SelectedValue.Contains("Mayo"))
                scod = 5;
            if (dpl.SelectedValue.Contains("Junio"))
                scod = 6;
            if (dpl.SelectedValue.Contains("Julio"))
                scod = 7;
            if (dpl.SelectedValue.Contains("Agosto"))
                scod = 8;
            if (dpl.SelectedValue.Contains("Setiembre"))
                scod = 9;
            if (dpl.SelectedValue.Contains("Octubre"))
                scod = 10;
            if (dpl.SelectedValue.Contains("Noviembre"))
                scod = 11;
            if (dpl.SelectedValue.Contains("Diciembre"))
                scod = 12;

            return scod;
        }

        public int GetCodAnio(DropDownList dpl)
        {
            int scod = 0;
            int ianio1 = DateTime.Now.Year;
            String sanio1 = Convert.ToString(ianio1);
            int ianio2 = ianio1 + 1;
            String sanio2 = Convert.ToString(ianio2);

            if (dpl.SelectedValue.Contains(sanio1))
                scod = ianio1;
            if (dpl.SelectedValue.Contains(sanio2))
                scod = ianio2;

            return scod;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (mesInicioDropDownList.SelectedIndex > 0 && estadoDropDownList.SelectedIndex > 0)
            {
                ActividadBE objactividad = new ActividadBE();

                int icodmesInicio = GetCodMes(mesInicioDropDownList);
                int icodanioInicio = GetCodAnio(mesInicioDropDownList);

                if (estadoDropDownList.SelectedIndex == 1)
                    objactividad.Presupuesto_aprobado = "P";

                if (estadoDropDownList.SelectedIndex == 2)
                    objactividad.Presupuesto_aprobado = "N";

                if (estadoDropDownList.SelectedIndex == 3)
                    objactividad.Presupuesto_aprobado = "A";

                  objactividad.Mes = icodmesInicio;
                  objactividad.Anio = icodanioInicio;

                  List<ActividadBE> lista =  objcapacitar.listarActividadxMesxEstado(objactividad);

                  if (lista != null)
                  {
                      ListaActividadProyectadaGridView.DataSource = lista;
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


            if (mesInicioDropDownList.SelectedIndex > 0 && estadoDropDownList.SelectedIndex == 0)
            {
                ActividadBE objactividad = new ActividadBE();

                int icodmesInicio = GetCodMes(mesInicioDropDownList);
                int icodanioInicio = GetCodAnio(mesInicioDropDownList);

                objactividad.Mes = icodmesInicio;
                objactividad.Anio = icodanioInicio;

                List<ActividadBE> lista = objcapacitar.listarActividadxMes(objactividad);

                if (lista != null)
                {
                    ListaActividadProyectadaGridView.DataSource = lista;
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

            if (mesInicioDropDownList.SelectedIndex == 0 && estadoDropDownList.SelectedIndex > 0)
            {
                ActividadBE objactividad = new ActividadBE();

                if (estadoDropDownList.SelectedIndex == 1)
                    objactividad.Presupuesto_aprobado = "P";

                if (estadoDropDownList.SelectedIndex == 2)
                    objactividad.Presupuesto_aprobado = "N";

                if (estadoDropDownList.SelectedIndex == 3)
                    objactividad.Presupuesto_aprobado = "A";


                List<ActividadBE> lista = objcapacitar.listarActividadxEstado(objactividad);

                if (lista != null)
                {
                    ListaActividadProyectadaGridView.DataSource = lista;
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

            if (mesInicioDropDownList.SelectedIndex == 0 && estadoDropDownList.SelectedIndex == 0)
            {
                List<ActividadBE> lista = objcapacitar.listarActividadxTodo();

                if (lista != null)
                {
                    ListaActividadProyectadaGridView.DataSource = lista;
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

        }
    }
}