using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNRS.ModuloPresupuesto.BL.BC;
using GNRS.ModuloPresupuesto.DL.DALC;
using System.Data.Entity;
using System.Web.Services;
using GNRS.ModuloPresupuesto.BL.BE;


//+
using System.Threading;
using System.Net.Mail;
using System.Reflection;
using System.Configuration;
using System.IO;
using System.Net.Mime;
using System.Text;
using System.Net;
namespace GNRS.ModuloPresupuesto.UI
{
    public partial class Prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Session.Add("codPersonaEditar", 129);
            //Response.Redirect("RegistrarPresupuestoPersonalProyectado.aspx?modo=2");
             
            string body = "<p>Estimado(a)," +
                    "<br />" +
                    "Se le informa que se ha realizado una solicitud de presupuesto de personal, ingresa al sistema para mayor detalle. " +
                    "Recomendamos realizar las acciones pertinentes." +
                    "<br /><br />Gracias," +
                    "<br />Administrador del Sistema</p>";
            EnviarCorreo("mghscmghsc@gmail.com", "mghscmghsc@gmail.com", body, "asuntoo!");
            
        }



        public void EnviarCorreo(string strTo, string strFrom, string strBody, string strSubject)
        {
            MailMessage message = new MailMessage();
            // Very basic html. HTML should always be valid, otherwise you go to spam
            message.Body = "<html><body>" + strBody + "</body></html>";
            // QuotedPrintable encoding is the default, but will often lead to trouble, 
            // so you should set something meaningful here. Could also be ASCII or some ISO
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            // No Subject usually goes to spam, too
            message.Subject = strSubject;
            // Note that you can add multiple recipients, bcc, cc rec., etc. Using the 
            // address-only syntax, i.e. w/o a readable name saves you from some issues
            message.To.Add(strTo);
            message.From = new MailAddress(strFrom, "Usuario", System.Text.Encoding.UTF8);
            // SmtpHost, -Port, -User, -Password must be a valid account you can use to 
            // send messages. Note that it is very often required that the account you
            // use also has the specified sender address associated! 
            // If you configure the Smtp yourself, you can change that of course
           
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(strFrom, "yssecpneaFE312"),
                EnableSsl = true
            };

            try
            {
                // It might be necessary to enforce a specific sender address, see above
                //if (!string.IsNullOrEmpty(ForceSenderAddress)) {
                //    message.From = new MailAddress(ForceSenderAddress);
                //}
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        

    }
}