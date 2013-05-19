using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNRS.ModuloPresupuesto.UI
{
    public partial class ConfiguracionPresupuesto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            //DateTime.Compare()
            // Context.Items.Add("CodUniversidad", date);
            if (!IsPostBack)
            {
            String mesnombre = mes(date.Month);
            int anio = date.Year;

            mesDropDownList.DataSource = ListaMes(date.Month);
            mesDropDownList.DataBind();

            anioDropDownList.DataSource = ListaAnio(date.Year);
            anioDropDownList.DataBind();

            PanelUpdatePanel1.Update();
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


        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Session.Add("dia", "01");
            Session.Add("mes", mesa(mesDropDownList.SelectedValue.ToString()));
            Session.Add("anio", anioDropDownList.SelectedValue.ToString());
            Session.Add("Mensaje", "0");
            alert("La configuración del presupuesto se grabo satisfactoriamente");
            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensaje('La configuración del presupuesto se grabo satisfactoriamente')", true);
            /*Context.Items.Add("dia", diaDropDownList.SelectedValue.ToString());
            Context.Items.Add("mes", mesa(mesDropDownList.SelectedValue.ToString()));
            Context.Items.Add("anio", anioDropDownList.SelectedValue.ToString());*/

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