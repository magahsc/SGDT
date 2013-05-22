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

namespace GNRS.ModuloPresupuesto.UI
{
    public partial class RegistrarActividad : System.Web.UI.Page
    {
        CapacitarProyectadoBC objcapacitar = new CapacitarProyectadoBC();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["mes"] == null ||
                   Session["dia"] == null ||
                   Session["anio"] == null)
                {

                    Session.Add("Mensaje", "1");
                    Server.Transfer("MainPage.aspx");
                }

                if (Session["mes"] != null &&
                   Session["dia"] != null &&
                   Session["anio"] != null)
                {
                    String smes = Session["mes"].ToString();

                    int imes = Convert.ToInt32(smes);
                    //  ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensaje('El presupuesto de la actividadde RRHH " + imes + " ha sido guaradado satisfactoriamente')", true);
                    ActividadComboBox.DataSource = objcapacitar.ListaActividadNombres();
                    ActividadComboBox.DataTextField = "nombre_actividad";
                    ActividadComboBox.DataValueField = "id_actividad";
                    ActividadComboBox.DataBind();
                    ActividadComboBox.Items.Insert(0, new ListItem("Seleccione la actividad", ""));

                    MesInicioComboBox.DataSource = ListaMesInicio(imes);
                    MesInicioComboBox.DataBind();
                    MesInicioComboBox.Items.Insert(0, new ListItem("Seleccione el mes", ""));

                    MesFinComboBox.DataSource = ListaMesInicio(imes);
                    MesFinComboBox.DataBind();
                    MesFinComboBox.Items.Insert(0, new ListItem("Seleccione el mes", ""));
                    MesFinComboBox.Enabled = false;

                    TipoMonedaRadioButtonList.SelectedIndex = 0;
                }
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
            String sanio = Session["anio"].ToString();
            int ianio = Convert.ToInt32(sanio);
            int variable = 0;
            int valida = 0;

            for (int i = numeromes; i <= numeromes + 12; i++)
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

        public List<String> ListaMesFinal(int numeromes, int anio)
        {
            List<String> lista = new List<String>();

            String smes = Session["mes"].ToString();
            int imes = Convert.ToInt32(smes);

            String sanio = Session["anio"].ToString();
            int ianio = Convert.ToInt32(sanio);
            int diferencia = 0;

            if (anio == ianio)
                diferencia = imes + 12 - numeromes;

            if (anio > ianio)
                diferencia = imes - numeromes;

            int variable = 0;
            int valida = 0;
            ianio = anio;

            for (int i = numeromes; i <= numeromes + diferencia; i++)
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

        public String cambiarmesydia(String dato)
        {
            String sdato = dato;
            switch (dato)
            {
                case "1":
                    {
                        sdato = "01";
                        break;
                    }

                case "2":
                    {
                        sdato = "02";
                        break;
                    }

                case "3":
                    {
                        sdato = "03";
                        break;
                    }

                case "4":
                    {
                        sdato = "04";
                        break;
                    }

                case "5":
                    {
                        sdato = "05";
                        break;
                    }

                case "6":
                    {
                        sdato = "06";
                        break;
                    }

                case "7":
                    {
                        sdato = "07";
                        break;
                    }

                case "8":
                    {
                        sdato = "08";
                        break;
                    }

                case "9":
                    {
                        sdato = "09";
                        break;
                    }

            }

            return sdato;
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
            String sanio1 = Session["anio"].ToString();
            int ianio1 = Convert.ToInt32(sanio1);
            int ianio2 = ianio1 + 1;
            String sanio2 = Convert.ToString(ianio2);

            if (dpl.SelectedValue.Contains(sanio1))
                scod = ianio1;
            if (dpl.SelectedValue.Contains(sanio2))
                scod = ianio2;

            return scod;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (MesInicioComboBox.SelectedIndex > 0 && MesFinComboBox.SelectedIndex > 0 && ActividadComboBox.SelectedIndex > 0 && MontoTextBox.Text != "" &&
                 MontoTextBox.Text != null)
            {
                String actividad = ActividadComboBox.SelectedValue;
                int iactividad = Convert.ToInt32(actividad);

                int icodmesInicio = GetCodMes(MesInicioComboBox);
                int icodanioInicio = GetCodAnio(MesInicioComboBox);

                int icodmesFinal = GetCodMes(MesFinComboBox);
                int icodanioFinal = GetCodAnio(MesFinComboBox);

                double monto = Convert.ToDouble(MontoTextBox.Text);
                String observaciones = ObservacionesTextBox.Text;

                String smes = Convert.ToString(DateTime.Now.Month);
                smes = cambiarmesydia(smes);
                String sanio = Convert.ToString(DateTime.Now.Year);
                sanio = sanio.Substring(2, 2);
                String sdia = Convert.ToString(DateTime.Now.Day);
                sdia = cambiarmesydia(sdia);

                ACTIVIDAD valoractividad = new ACTIVIDAD();
                valoractividad = objcapacitar.ObtenerActividadXCodigo(iactividad);

                PRESUPUESTO_ACTIVIDAD_PROYECTADA objactividad = new PRESUPUESTO_ACTIVIDAD_PROYECTADA();
                objactividad.codigo_actividad_proyectada = "";
                objactividad.mes_inicio = icodmesInicio;
                objactividad.mes_fin = icodmesFinal;
                objactividad.anio_inicio = icodanioInicio;
                objactividad.anio_fin = icodanioFinal;
               // objactividad.nombre_actividad = valoractividad.nombre_actividad;
                objactividad.monto_actividad = monto;
                objactividad.detalle_actividad = observaciones;
                objactividad.fecha_creacion = DateTime.Now;
               // objactividad.presupesto_aprobado = "P";

                if (TipoMonedaRadioButtonList.SelectedIndex == 0)
                    objactividad.tipo_moneda = "S";
                if (TipoMonedaRadioButtonList.SelectedIndex == 1)
                    objactividad.tipo_moneda = "D";

                int idActividad = objcapacitar.insertarActividadRRHH(objactividad);
                String codigopresupuesto = sdia + smes + sanio + "" + idActividad;
                objactividad.codigo_actividad_proyectada = codigopresupuesto;
                objcapacitar.ActualizarActividadRRHH(objactividad);

                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensaje('El presupuesto de la actividadde RRHH " + codigopresupuesto + " ha sido guaradado satisfactoriamente')", true);
                alert("El presupuesto de actividad de RRHH " + codigopresupuesto + " ha sido guardado satisfactoriamente");
                ActividadComboBox.SelectedIndex = 0;
                MesInicioComboBox.SelectedIndex = 0;
                MesFinComboBox.SelectedIndex = 0;
                MontoTextBox.Text = "";
                ObservacionesTextBox.Text = "";
                MesFinComboBox.Enabled = false;
                ComboBoxUpdatePanel.Update();

            }

        }

        protected void MesInicioComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String smes = Session["mes"].ToString();
            int imes = Convert.ToInt32(smes);

            if (MesInicioComboBox.SelectedIndex == 0)
            {
                MesFinComboBox.DataSource = ListaMesInicio(imes);
                MesFinComboBox.DataBind();
                MesFinComboBox.Items.Insert(0, new ListItem("Seleccione el mes", ""));
                MesFinComboBox.Enabled = false;
                ComboBoxUpdatePanel.Update();
            }

            if (MesInicioComboBox.SelectedIndex > 0)
            {
                int icodmes = GetCodMes(MesInicioComboBox);
                int icodanio = GetCodAnio(MesInicioComboBox);
                MesFinComboBox.DataSource = ListaMesFinal(icodmes, icodanio);
                MesFinComboBox.DataBind();
                MesFinComboBox.Items.Insert(0, new ListItem("Seleccione el mes", ""));
                MesFinComboBox.Enabled = true;
                ComboBoxUpdatePanel.Update();
            }
        }

        public void alert(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
    }
}