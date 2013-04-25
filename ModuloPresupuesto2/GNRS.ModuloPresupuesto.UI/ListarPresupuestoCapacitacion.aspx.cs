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
    public partial class ListarPresupuestoCapacitacion : System.Web.UI.Page
    {
        CapacitarProyectadoBC objcapacitar = new CapacitarProyectadoBC();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            MensajeLabel.Text = "";
            MensajeUpdatePanel.Update();
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

        protected void mesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CriteriosUpdatePanel.Update();
        }

        protected void anioDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CriteriosUpdatePanel.Update();
        }

        protected void estadoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CriteriosUpdatePanel.Update();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (mesDropDownList.SelectedIndex == 0 && anioDropDownList.SelectedIndex == 0 && estadoDropDownList.SelectedIndex == 0)
            {
                List<CapacitacionProyectadaBE> lista = objcapacitar.listarCapacitacionProyectadaxTodo();
                if (lista != null)
                {
                    ListasCapacitarProyectadaGridView.DataSource = lista;
                    ListasCapacitarProyectadaGridView.DataBind();
                    MensajeLabel.Text = "";
                    DatosUpdatePanel.Update();
                    MensajeUpdatePanel.Update();
                }

                if (lista == null)
                {
                    MensajeLabel.Visible = true;
                    ListasCapacitarProyectadaGridView.Visible = false;
                    MensajeLabel.Text = "No existen presupuestos para mostrar.";
                    DatosUpdatePanel.Update();
                    MensajeUpdatePanel.Update();
                }
                
            }

            if (mesDropDownList.SelectedIndex > 0 && anioDropDownList.SelectedIndex > 0 && estadoDropDownList.SelectedIndex > 0)
            {
                CapacitacionProyectadaBE objcapacitacionBE = new CapacitacionProyectadaBE();
                objcapacitacionBE.Mes = Convert.ToInt32(mesa(mesDropDownList.SelectedValue));
                objcapacitacionBE.Anio = Convert.ToInt32(anioDropDownList.SelectedValue);

                if(estadoDropDownList.SelectedIndex == 1)
                   objcapacitacionBE.Presupuesto_aprobado = "P";

                if (estadoDropDownList.SelectedIndex == 2)
                    objcapacitacionBE.Presupuesto_aprobado = "N";

                if (estadoDropDownList.SelectedIndex == 3)
                    objcapacitacionBE.Presupuesto_aprobado = "A";

                List<CapacitacionProyectadaBE> lista = objcapacitar.listarCapacitacionProyectadaxMesxAnioxEstado(objcapacitacionBE);
                if (lista != null)
                {
                    ListasCapacitarProyectadaGridView.DataSource = lista;
                    ListasCapacitarProyectadaGridView.DataBind();
                    MensajeLabel.Text = "";
                    DatosUpdatePanel.Update();
                    MensajeUpdatePanel.Update();
                }

                if (lista == null)
                {
                    MensajeLabel.Visible = true;
                    ListasCapacitarProyectadaGridView.Visible = false;
                    MensajeLabel.Text = "No existen presupuestos para mostrar.";
                    MensajeUpdatePanel.Update();
                    DatosUpdatePanel.Update();
                }

            }

            if (mesDropDownList.SelectedIndex > 0 && anioDropDownList.SelectedIndex == 0 && estadoDropDownList.SelectedIndex == 0)
            {
                CapacitacionProyectadaBE objcapacitacionBE = new CapacitacionProyectadaBE();
                objcapacitacionBE.Mes = Convert.ToInt32(mesa(mesDropDownList.SelectedValue));
                //objcapacitacionBE.Anio = Convert.ToInt32(anioDropDownList.SelectedValue);
                //objcapacitacionBE.Presupuesto_aprobado = estadoDropDownList.SelectedValue;

                List<CapacitacionProyectadaBE> lista = objcapacitar.listarCapacitacionProyectadaxMes(objcapacitacionBE);
                if (lista != null)
                {
                    ListasCapacitarProyectadaGridView.DataSource = lista;
                    ListasCapacitarProyectadaGridView.DataBind();
                    MensajeLabel.Text = "";
                    DatosUpdatePanel.Update();
                    MensajeUpdatePanel.Update();
                }

                if (lista == null)
                {
                    MensajeLabel.Visible = true;
                    ListasCapacitarProyectadaGridView.Visible = false;
                    MensajeLabel.Text = "No existen presupuestos para mostrar.";
                    MensajeUpdatePanel.Update();
                    DatosUpdatePanel.Update();
                }

            }

            if (mesDropDownList.SelectedIndex == 0 && anioDropDownList.SelectedIndex > 0 && estadoDropDownList.SelectedIndex == 0)
            {
                CapacitacionProyectadaBE objcapacitacionBE = new CapacitacionProyectadaBE();
                //objcapacitacionBE.Mes = Convert.ToInt32(mesa(mesDropDownList.SelectedValue));
                objcapacitacionBE.Anio = Convert.ToInt32(anioDropDownList.SelectedValue);
                //objcapacitacionBE.Presupuesto_aprobado = estadoDropDownList.SelectedValue;

                List<CapacitacionProyectadaBE> lista = objcapacitar.listarCapacitacionProyectadaxAnio(objcapacitacionBE);
                if (lista != null)
                {
                    ListasCapacitarProyectadaGridView.DataSource = lista;
                    ListasCapacitarProyectadaGridView.DataBind();
                    MensajeLabel.Text = "";
                    DatosUpdatePanel.Update();
                    MensajeUpdatePanel.Update();
                }

                if (lista == null)
                {
                    MensajeLabel.Visible = true;
                    ListasCapacitarProyectadaGridView.Visible = false;
                    MensajeLabel.Text = "No existen presupuestos para mostrar.";
                    MensajeUpdatePanel.Update();
                    DatosUpdatePanel.Update();
                }

            }

            if (mesDropDownList.SelectedIndex == 0 && anioDropDownList.SelectedIndex == 0 && estadoDropDownList.SelectedIndex > 0)
            {
                CapacitacionProyectadaBE objcapacitacionBE = new CapacitacionProyectadaBE();
                //objcapacitacionBE.Mes = Convert.ToInt32(mesa(mesDropDownList.SelectedValue));
                //objcapacitacionBE.Anio = Convert.ToInt32(anioDropDownList.SelectedValue);
                objcapacitacionBE.Presupuesto_aprobado = estadoDropDownList.SelectedValue;

                if (estadoDropDownList.SelectedIndex == 1)
                    objcapacitacionBE.Presupuesto_aprobado = "P";

                if (estadoDropDownList.SelectedIndex == 2)
                    objcapacitacionBE.Presupuesto_aprobado = "N";

                if (estadoDropDownList.SelectedIndex == 3)
                    objcapacitacionBE.Presupuesto_aprobado = "A";

                List<CapacitacionProyectadaBE> lista = objcapacitar.listarCapacitacionProyectadaxEstado(objcapacitacionBE);
                if (lista != null)
                {
                    ListasCapacitarProyectadaGridView.DataSource = lista;
                    ListasCapacitarProyectadaGridView.DataBind();
                    MensajeLabel.Text = "";
                    DatosUpdatePanel.Update();
                    MensajeUpdatePanel.Update();
                }

                if (lista == null)
                {
                    MensajeLabel.Visible = true;
                    ListasCapacitarProyectadaGridView.Visible = false;
                    MensajeLabel.Text = "No existen presupuestos para mostrar.";
                    MensajeUpdatePanel.Update();
                    DatosUpdatePanel.Update();
                }

            }

            if (mesDropDownList.SelectedIndex > 0 && anioDropDownList.SelectedIndex == 0 && estadoDropDownList.SelectedIndex > 0)
            {
                CapacitacionProyectadaBE objcapacitacionBE = new CapacitacionProyectadaBE();
                objcapacitacionBE.Mes = Convert.ToInt32(mesa(mesDropDownList.SelectedValue));
                //objcapacitacionBE.Anio = Convert.ToInt32(anioDropDownList.SelectedValue);
                objcapacitacionBE.Presupuesto_aprobado = estadoDropDownList.SelectedValue;

                if (estadoDropDownList.SelectedIndex == 1)
                    objcapacitacionBE.Presupuesto_aprobado = "P";

                if (estadoDropDownList.SelectedIndex == 2)
                    objcapacitacionBE.Presupuesto_aprobado = "N";

                if (estadoDropDownList.SelectedIndex == 3)
                    objcapacitacionBE.Presupuesto_aprobado = "A";

                List<CapacitacionProyectadaBE> lista = objcapacitar.listarCapacitacionProyectadaxMesxEstado(objcapacitacionBE);
                if (lista != null)
                {
                    ListasCapacitarProyectadaGridView.DataSource = lista;
                    ListasCapacitarProyectadaGridView.DataBind();
                    MensajeLabel.Text = "";
                    DatosUpdatePanel.Update();
                    MensajeUpdatePanel.Update();
                }

                if (lista == null)
                {
                    MensajeLabel.Visible = true;
                    ListasCapacitarProyectadaGridView.Visible = false;
                    MensajeLabel.Text = "No existen presupuestos para mostrar.";
                    MensajeUpdatePanel.Update();
                    DatosUpdatePanel.Update();
                }

            }

            if (mesDropDownList.SelectedIndex > 0 && anioDropDownList.SelectedIndex > 0 && estadoDropDownList.SelectedIndex == 0)
            {
                CapacitacionProyectadaBE objcapacitacionBE = new CapacitacionProyectadaBE();
                objcapacitacionBE.Mes = Convert.ToInt32(mesa(mesDropDownList.SelectedValue));
                objcapacitacionBE.Anio = Convert.ToInt32(anioDropDownList.SelectedValue);
                //objcapacitacionBE.Presupuesto_aprobado = estadoDropDownList.SelectedValue;

               /* if (estadoDropDownList.SelectedIndex == 1)
                    objcapacitacionBE.Presupuesto_aprobado = "P";

                if (estadoDropDownList.SelectedIndex == 2)
                    objcapacitacionBE.Presupuesto_aprobado = "N";

                if (estadoDropDownList.SelectedIndex == 3)
                    objcapacitacionBE.Presupuesto_aprobado = "A";*/

                List<CapacitacionProyectadaBE> lista = objcapacitar.listarCapacitacionProyectadaxMesxAnio(objcapacitacionBE);
                if (lista != null)
                {
                    ListasCapacitarProyectadaGridView.DataSource = lista;
                    ListasCapacitarProyectadaGridView.DataBind();
                    MensajeLabel.Text = "";
                    DatosUpdatePanel.Update();
                    MensajeUpdatePanel.Update();
                }

                if (lista == null)
                {
                    MensajeLabel.Visible = true;
                    ListasCapacitarProyectadaGridView.Visible = false;
                    MensajeLabel.Text = "No existen presupuestos para mostrar.";
                    MensajeUpdatePanel.Update();
                    DatosUpdatePanel.Update();
                }

            }

            if (mesDropDownList.SelectedIndex == 0 && anioDropDownList.SelectedIndex > 0 && estadoDropDownList.SelectedIndex > 0)
            {
                CapacitacionProyectadaBE objcapacitacionBE = new CapacitacionProyectadaBE();
                //objcapacitacionBE.Mes = Convert.ToInt32(mesa(mesDropDownList.SelectedValue));
                objcapacitacionBE.Anio = Convert.ToInt32(anioDropDownList.SelectedValue);
                objcapacitacionBE.Presupuesto_aprobado = estadoDropDownList.SelectedValue;

                if (estadoDropDownList.SelectedIndex == 1)
                    objcapacitacionBE.Presupuesto_aprobado = "P";

                if (estadoDropDownList.SelectedIndex == 2)
                    objcapacitacionBE.Presupuesto_aprobado = "N";

                if (estadoDropDownList.SelectedIndex == 3)
                    objcapacitacionBE.Presupuesto_aprobado = "A";

                List<CapacitacionProyectadaBE> lista = objcapacitar.listarCapacitacionProyectadaxAnioxEstado(objcapacitacionBE);
                if (lista != null)
                {
                    ListasCapacitarProyectadaGridView.DataSource = lista;
                    ListasCapacitarProyectadaGridView.DataBind();
                    MensajeLabel.Text = "";
                    DatosUpdatePanel.Update();
                    MensajeUpdatePanel.Update();
                }

                if (lista == null)
                {
                    MensajeLabel.Visible = true;
                    ListasCapacitarProyectadaGridView.Visible = false;
                    MensajeLabel.Text = "No existen presupuestos para mostrar.";
                    MensajeUpdatePanel.Update();
                    DatosUpdatePanel.Update();
                }

            }
        }

    }
}