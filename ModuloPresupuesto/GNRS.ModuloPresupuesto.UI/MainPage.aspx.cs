using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNRS.ModuloPresupuesto.UI
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Mensaje"] != null)
                {
                    if(Session["Mensaje"].ToString().Equals("1"))
                    {
                    String mensaje = "Debe configurar el mes y el año para poder realizar un registro de capacitación"; 
                    alert(mensaje);
                    }
                }
            
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