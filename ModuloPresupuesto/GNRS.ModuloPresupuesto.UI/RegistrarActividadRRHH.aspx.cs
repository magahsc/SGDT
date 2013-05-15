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
    public partial class RegistrarActividadRRHH : System.Web.UI.Page
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

                    ActividadComboBox.DataSource = ListaActividades();
                    ActividadComboBox.DataBind();
                    ActividadComboBox.Items.Insert(0, new ListItem("Seleccione la actividad", ""));
                    
                    MesInicioComboBox.DataSource = ListaMes(imes);
                    MesInicioComboBox.DataBind();
                    MesInicioComboBox.Items.Insert(0, new ListItem("Seleccione el mes", ""));

                    MesFinComboBox.DataSource = ListaMes(imes);
                    MesFinComboBox.DataBind();
                    MesFinComboBox.Items.Insert(0, new ListItem("Seleccione el mes", ""));
                }

            }
        }

        public List<String> ListaActividades()
        {
            List<String> lista = new List<string>();
            lista.Add("Evento Internacional 269life");
            lista.Add("Alto Al uso de animales como Entretenimiento");
            lista.Add("Cumpleaños de Magah");
            lista.Add("Duchar a Trapi");
            return lista;
        }

        public void alert(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
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

        public List<String> ListaMes(int numeromes)
        {
            List<String> lista = new List<String>();

            for (int i = numeromes; i <= 12; i++)
            {
                lista.Add(mes(i));
            }

            return lista;
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

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (MesInicioComboBox.SelectedIndex > 0 && MesFinComboBox.SelectedIndex > 0 && ActividadComboBox.SelectedIndex > 0 && MontoTextBox.Text != "" && 
                 MontoTextBox.Text != null)
            {
                String mesinicio = MesInicioComboBox.SelectedValue;
                String mesfinal = MesFinComboBox.SelectedValue;
                String actividad = ActividadComboBox.SelectedValue;

                int imesinicio = mesa(mesinicio);
                int imesfinal = mesa(mesfinal);

                double monto = Convert.ToDouble(MontoTextBox.Text);
                String observaciones = ObservacionesTextBox.Text;

                String smes = Convert.ToString(DateTime.Now.Month);
                smes = cambiarmesydia(smes);
                String sanio = Convert.ToString(DateTime.Now.Year);
                sanio = sanio.Substring(2, 2);
                String sdia = Convert.ToString(DateTime.Now.Day);
                sdia = cambiarmesydia(sdia);

                PRESUPUESTO_ACTIVIDAD_PROYECTADA objactividad = new PRESUPUESTO_ACTIVIDAD_PROYECTADA();
                objactividad.codigo_actividad_proyectada = "";
                objactividad.mes_inicio = imesinicio;
                objactividad.mes_fin = imesfinal;
                objactividad.nombre_actividad = actividad;
                objactividad.monto_actividad = monto;
                objactividad.detalle_actividad = observaciones;

                int idActividad = objcapacitar.insertarActividadRRHH(objactividad);
                String codigopresupuesto = sdia + smes + sanio + "" + idActividad;
                objactividad.codigo_actividad_proyectada = codigopresupuesto;
                objcapacitar.ActualizarActividadRRHH(objactividad);

                alert("El presupuesto de actividad de RRHH " + codigopresupuesto + " ha sido guardado satisfactoriamente");

            }
        }


    }
}