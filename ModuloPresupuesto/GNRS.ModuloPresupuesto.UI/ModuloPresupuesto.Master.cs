using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNRS.ModuloPresupuesto.UI
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["mensajeRecalcular"] != null && Session["mensajeRecalcular"].Equals("si"))
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "alert('Se han hecho cambios en los beneficios sociales, se recomienda recalcular para evitar inconsistencias')", true);
              //      string popupScript =
              //          "<script type=\"text/javascript\">" +
              //          "function mostrarMensajeRecalcular(mensaje) {" +
                        
              // "$('#dialog-recalcular').text(mensaje).dialog('open');}"+
             

              //" $(function () {"+
              //    " $('#dialog-recalcular').dialog({"+
              //         "modal: true, autoOpen: false,"+
              //        " height: 200, width: 500,"+
              //        " buttons: {  Ok: function () {  $(this).dialog('close');  } }"+
              //    " });  $('#dialog-recalcular').css({ fontSize: 15 });  });"+

              //          "</script>";
              //      ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarMensajeRecalcular('Se han hecho cambios en los beneficios sociales, se recomienda recalcular para evitar inconsistencias')", false);

                //    ScriptManager.RegisterStartupScript(this.Page,Page.GetType(), "script", popupScript, false);



                    Session.Remove("mensajeRecalcular");
                
                }

            }
        }
    }
}
