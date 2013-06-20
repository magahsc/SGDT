using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNRS.ModuloPresupuesto.BL.BC;
using GNRS.ModuloPresupuesto.DL.DALC;
using System.Data.Entity;

namespace GNRS.ModuloPresupuesto.UI
{
    public partial class ConfiguracionPresupuesto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;

            if (!IsPostBack)
            {
                String mesnombre = mes(date.Month);
                int anio = date.Year;

                mesDropDownList.DataSource = ListaMes(1);
                mesDropDownList.DataBind();

                anioDropDownList.DataSource = ListaAnio(date.Year);
                anioDropDownList.DataBind();

                PanelUpdatePanel1.Update();

                if (Session["mes"] != null && Session["dia"] != null && Session["anio"] != null && Session["idPeriodo"] != null)
                {
                    CerrarButton.Visible = true;
                    GuardarButton.Visible = false;

                    CapacitarProyectadoBC objcapacitar = new CapacitarProyectadoBC();
                    PERIODO_PRESUPUESTO verificar = new PERIODO_PRESUPUESTO();
                    verificar = objcapacitar.ObtenerPeriodoPresupuestoEstado();

                    mesDropDownList.SelectedIndex = verificar.mes_periodo - 1;
                    anioDropDownList.SelectedIndex = ObtenerIndiceDelTextoEnDropDownList(verificar.anio_periodo.ToString(), anioDropDownList);
                    descripcionPeriodoTextBox.Text = verificar.descripcion_periodo;
                    descripcionPeriodoTextBox.Enabled = false;
                    mesDropDownList.Enabled = false;
                    anioDropDownList.Enabled = false;
                }
                else
                {
                    CerrarButton.Visible = false;
                    GuardarButton.Visible = true;
                }
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

                case  "Junio":
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

        public int ObtenerIndiceDelTextoEnDropDownList(string pTexto, DropDownList pDropDownList)
        {            
            ListItem listItemSeleccionado = pDropDownList.Items.FindByText(pTexto);
         
            return pDropDownList.Items.IndexOf(listItemSeleccionado);
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

            for (int i = numeroanio; i <= numeroanio + 12; i++)
            {
                lista.Add(i);
            }

            return lista;
        }

        protected void CerrarButton_Click(object sender, EventArgs e)
        {
            CapacitarProyectadoBC objcapacitar = new CapacitarProyectadoBC();
            objcapacitar.CerrarPeriodoPresupuestoConID(Convert.ToInt16(Session["idPeriodo"].ToString()));

            descripcionPeriodoTextBox.Text = "";
            descripcionPeriodoTextBox.Enabled = true;
            mesDropDownList.SelectedIndex = 0;
            mesDropDownList.Enabled = true;
            anioDropDownList.SelectedIndex = 0;
            anioDropDownList.Enabled = true;
            GuardarButton.Visible = true;
            CerrarButton.Visible = false;

            BotonUpdatePanel.Update();
            PanelUpdatePanel1.Update();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            int mes , anio1;
            mes = Convert.ToInt32(mesa(mesDropDownList.SelectedValue.ToString()));
            anio1 =  Convert.ToInt32(anioDropDownList.SelectedValue);

            if (anio1 == DateTime.Now.Year && mes < DateTime.Now.Month)
            {                
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensajeError('El período de presupuesto ingresado es incorrecto.')", true);
            }
            else if (anio1 < DateTime.Now.Year)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensajeError('El período de presupuesto ingresado es incorrecto.')", true);
            }
            else
            {
                CapacitarProyectadoBC objcapacitar = new CapacitarProyectadoBC();
                PERIODO_PRESUPUESTO verificar = new PERIODO_PRESUPUESTO();
                verificar = objcapacitar.ObtenerPeriodoPresupuestoEstado();

                if (verificar == null)
                {
                    if (descripcionPeriodoTextBox.Text.Length > 0)
                    {
                        Session.Add("dia", "01");
                        Session.Add("mes", mesa(mesDropDownList.SelectedValue.ToString()));
                        Session.Add("anio", anioDropDownList.SelectedValue.ToString());

                        PERIODO_PRESUPUESTO objPeriodo = new PERIODO_PRESUPUESTO();
                        objPeriodo.mes_periodo = Convert.ToInt32(mesa(mesDropDownList.SelectedValue.ToString()));
                        objPeriodo.anio_periodo = Convert.ToInt32(anioDropDownList.SelectedValue);
                        objPeriodo.estado_periodo = 1;
                        objPeriodo.descripcion_periodo = descripcionPeriodoTextBox.Text;

                        int codigoPeriodo = objcapacitar.RegistrarPeriodoPresupuesto(objPeriodo);

                        if (codigoPeriodo > 0)
                        {
                            Session.Add("idPeriodo", codigoPeriodo);
                            int anio = Convert.ToInt32(anioDropDownList.SelectedValue);
                            anio = anio + 1;
                            Session.Add("Mensaje", "0");
                            hdnSession.Value = "A partir de este momento, los presupuestos anuales empezarán desde " + mesDropDownList.SelectedValue.ToString() + " " +
                            anioDropDownList.SelectedValue.ToString() + " hasta el " + mesDropDownList.SelectedValue.ToString() + " " + anio + ".";
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensaje()", true);

                            descripcionPeriodoTextBox.Enabled = false;
                            mesDropDownList.Enabled = false;
                            anioDropDownList.Enabled = false;
                            GuardarButton.Visible = false;
                            CerrarButton.Visible = true;

                            BotonUpdatePanel.Update();
                            PanelUpdatePanel1.Update();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensajeError('Hubo un error en el registro. Inténtelo nuevamente.')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensajeError('Debe de ingresar la descripción del nuevo período.')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensajeError('Ya existe un período de presupuesto activo.')", true);
                }
            }
        }

        public void alert(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        protected void mesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelUpdatePanel1.Update();
        }

        protected void anioDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelUpdatePanel1.Update();
        }
    }

}