﻿using System;
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

namespace GNRS.ModuloPresupuesto.UI
{
    public partial class RegistrarPresupuestoPersonalProyectado : System.Web.UI.Page
    {
        PresupuestoPersonalProyectadoBC presupuestoPersonalBC = new PresupuestoPersonalProyectadoBC();

        protected void Page_Load(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "SetupDialog", "SetupDialog();", true);


            if (!IsPostBack)
            {


                cargarCostosEmpresa();
                cargarComboBox();

               
                cargarDatosSession();

                if (CargoComboBox.SelectedItem.Value == "")
                    AgregarConceptosButton.Enabled = false;

                List<ConceptoTemporalBE> ConceptosTemporalesLista = new List<ConceptoTemporalBE>();
                if (Session["ConceptosTemporalesLista"] != null)
                {
                    ConceptosTemporalesLista = (List<ConceptoTemporalBE>)Session["ConceptosTemporalesLista"];
                    nuevo.Attributes["value"] = "no";
                }
                else
                {
                    nuevo.Attributes["value"] = "si";

                }

               
                if (Session["mes"] == null ||    Session["dia"] == null ||        Session["anio"] == null)
                {

                    alert("Debe configurar el mes y el año para poder realizar un registro de capacitación");
                    Server.Transfer("MainPage.aspx");
                }
            }
        }

        public void cargarCostosEmpresa()
        {
            CostoEmpresaBC objCostoEmpresaBC = new CostoEmpresaBC();
            float costoEmpresaEmpleado = objCostoEmpresaBC.calcularCostoEmpresaXCategoria(1);
            float costoEmpresaObrero = objCostoEmpresaBC.calcularCostoEmpresaXCategoria(2);

            costoEmpresaEmpleadoHidden.Attributes["value"] = costoEmpresaEmpleado.ToString();
            costoEmpresaObreroHidden.Attributes["value"] = costoEmpresaObrero.ToString();
        }
        
        public void alert(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        public void cargarDatosSession()
        {
            if (Session["codLocalidad"] != null)
            {
                string codL = (string)Session["codLocalidad"];                
                LocalidadComboBox.Items.FindByValue(codL).Selected = true;
                LocalidadComboBox.Enabled = true;
            }

            if (Session["codArea"] != null)
            {
               
                string codL = (string)Session["codArea"];
                AreaComboBox.Items.FindByValue(codL).Selected = true;
                AreaComboBox.Enabled = true;
            } 
            

            if (Session["codSeccion"] != null)
            {
                string codL = (string)Session["codSeccion"];
                SeccionComboBox.Items.FindByValue(codL).Selected = true;
                SeccionComboBox.Enabled = true;

            } 

            if (Session["codCargo"] != null)
            {
                string codL = (string)Session["codCargo"];
                CargoComboBox.Items.FindByValue(codL).Selected = true;
                CargoComboBox.Enabled = true;
            }

            if (Session["cantidad"] != null)
            {
                CantidadTextBox.Text = (string)Session["cantidad"];
            }

            if (Session["codTipoPersonal"] != null)
            {

                string codL = (string)Session["codTipoPersonal"];
                TipoPersonalComboBox.Items.FindByValue(codL).Selected = true;
               
            } 
            
            
            ComboBoxUpdatePanel.Update();

           
        }

        public void cargarComboBox()
        {
            LocalidadComboBox.DataSource = presupuestoPersonalBC.listarLocalidades();
            LocalidadComboBox.DataTextField = "nombre_localidad";
            LocalidadComboBox.DataValueField = "id_localidad";
            LocalidadComboBox.DataBind();
            LocalidadComboBox.Items.Insert(0, new ListItem("Seleccione la localidad", ""));


            AreaComboBox.DataSource = presupuestoPersonalBC.listarAreas();
            AreaComboBox.DataTextField = "nombre_area";
            AreaComboBox.DataValueField = "id_area";
            AreaComboBox.DataBind();
            AreaComboBox.Items.Insert(0, new ListItem("Seleccione el area", ""));

            
            SeccionComboBox.DataSource = presupuestoPersonalBC.listarSecciones();
            SeccionComboBox.DataTextField = "nombre_seccion";
            SeccionComboBox.DataValueField = "id_seccion";
            SeccionComboBox.DataBind();
            SeccionComboBox.Items.Insert(0, new ListItem("Seleccione la seccion", ""));

            
            CargoComboBox.DataSource = presupuestoPersonalBC.listarCargos();
            CargoComboBox.DataTextField = "nombre_cargo";
            CargoComboBox.DataValueField = "id_cargo";
            CargoComboBox.DataBind();
            CargoComboBox.Items.Insert(0, new ListItem("Seleccione el cargo", ""));

        }
       

        protected void LocalidadComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                int codigoLocalidad = Convert.ToInt32(LocalidadComboBox.SelectedValue);


                AreaComboBox.DataSource = presupuestoPersonalBC.filtrarAreasXLocalidad(codigoLocalidad);
                AreaComboBox.DataBind();
                AreaComboBox.Items.Insert(0, new ListItem("Seleccione el area", ""));

                AreaComboBox.Enabled = true;
                SeccionComboBox.Enabled = false;
                CargoComboBox.Enabled = false;


                ComboBoxUpdatePanel.Update();

            }
            catch(Exception ex)
            { 
               }
        }

        protected void AreaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int codigoLocalidad = Convert.ToInt32(LocalidadComboBox.SelectedValue);
                int codigoArea = Convert.ToInt32(AreaComboBox.SelectedValue);

                SeccionComboBox.DataSource = presupuestoPersonalBC.filtrarSeccionesXAreaLocalidad(codigoArea, codigoLocalidad);
                SeccionComboBox.DataBind();
                SeccionComboBox.Items.Insert(0, new ListItem("Seleccione la seccion", ""));

                SeccionComboBox.Enabled = true;
                CargoComboBox.Enabled = false;

                ComboBoxUpdatePanel.Update();

            }
            catch (Exception ex)
            {
            }
        }

        protected void SeccionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int codigoLocalidad = Convert.ToInt32(LocalidadComboBox.SelectedValue);

                int codigoSeccion = Convert.ToInt32(SeccionComboBox.SelectedValue);
                CargoComboBox.DataSource = presupuestoPersonalBC.filtrarCargosXSeccion(codigoSeccion);
                CargoComboBox.DataBind();
                CargoComboBox.Items.Insert(0, new ListItem("Seleccione el cargo", ""));

                CargoComboBox.Enabled = true;

                ComboBoxUpdatePanel.Update();
            }
            catch (Exception ex)
            {
            }

        }



        [WebMethod]
        public static string confirmarRegistro(string codLocalidad, string codArea, string codSeccion, string codCargo, string cantidad, string cargo, string codTipoPersonal, string costoEmpresaEmpleadoHidden, string costoEmpresaObreroHidden, List<ConceptoTemporalBE>  elementos)
        {
            List<ConceptoTemporalBE> lala = elementos;
            if (cargo.Equals(""))
            {
                return "";
            }

            int cantidadAgregar = Convert.ToInt32(cantidad);
            PresupuestoPersonalProyectadoBC presupuestoPersonalBC = new PresupuestoPersonalProyectadoBC();


            int codigoLocalidad, codigoArea, codigoSeccion, codigoCargo,codigoTipoPersonal;

            if (!int.TryParse(codLocalidad, out codigoLocalidad))
            {
                codigoLocalidad = 0;
            }

            if (!int.TryParse(codArea, out codigoArea))
            {
                codigoArea = 0;
            }

            if (!int.TryParse(codSeccion, out codigoSeccion))
            {
                codigoSeccion = 0;
            }

            if (!int.TryParse(codCargo, out codigoCargo))
            {
                codigoCargo = 0;
            }

            if (!int.TryParse(codTipoPersonal, out codigoTipoPersonal))
            {
                codigoTipoPersonal = 0;
            }


            int numeroDeCargoActual = presupuestoPersonalBC.obtenerCodDePersonalProyectado(codigoLocalidad, codigoArea, codigoSeccion, codigoCargo, cargo);
            numeroDeCargoActual++;

            float costoEmpresaRegistrar=-1;
            if (codigoTipoPersonal == 1)
            {
                costoEmpresaRegistrar = float.Parse(costoEmpresaEmpleadoHidden);
            }
            if (codigoTipoPersonal == 2)
            {
                costoEmpresaRegistrar = float.Parse(costoEmpresaObreroHidden);
            }
           
            for(int i=1;i <=cantidadAgregar;i++)
            {               

                string nombre = cargo + " Proy-" + numeroDeCargoActual;
                numeroDeCargoActual++;



                int codAgregado = presupuestoPersonalBC.registrarPersonalProyectar(codigoLocalidad, codigoArea, codigoSeccion, codigoCargo, nombre,codigoTipoPersonal);

                if (codAgregado != -1)
                {
                    List<ConceptoTemporalBE> ConceptosTemporalesLista = new List<ConceptoTemporalBE>();
                    if (HttpContext.Current.Session["ConceptosTemporalesLista"] != null)
                    {
                        ConceptosTemporalesLista = (List<ConceptoTemporalBE>)HttpContext.Current.Session["ConceptosTemporalesLista"];

                    }

                    foreach (ConceptoTemporalBE item in ConceptosTemporalesLista)
                    {
                        presupuestoPersonalBC.registrarConceptoXPersona(codAgregado, item.Concepto_Cod, item.Monto, costoEmpresaRegistrar);
                    }

                    HttpContext.Current.Session.Remove("ConceptosTemporalesLista");

                }
                else
                {
                    return "";
                }
            }

           
                return "sdf";

        }

        //protected void AgregarConceptosButton_Click(object sender, EventArgs e)
        //{

            
        //    if (nuevo.Attributes["value"].Equals("si"))
        //        Session.Remove("ConceptosTemporalesLista");


        //    if (LocalidadComboBox.SelectedItem.Value != "")
        //        Session.Add("codLocalidad", LocalidadComboBox.SelectedItem.Value);

        //    if (AreaComboBox.SelectedItem.Value != "")
        //        Session.Add("codArea", AreaComboBox.SelectedItem.Value);

        //    if (SeccionComboBox.SelectedItem.Value != "")
        //        Session.Add("codSeccion", SeccionComboBox.SelectedItem.Value);

        //    if (CargoComboBox.SelectedItem.Value != "")
        //        Session.Add("codCargo", CargoComboBox.SelectedItem.Value);
            
        //    if (CantidadTextBox.Text != "")
        //        Session.Add("cantidad", CantidadTextBox.Text);


        //    if (LocalidadComboBox.SelectedItem.Value != "")
        //        Session.Add("codTipoPersonal", TipoPersonalComboBox.SelectedItem.Value);



        //    Response.Redirect("ConceptosPersonal.aspx");
        //}

        protected void CargoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (CargoComboBox.SelectedItem.Value == "")
                    AgregarConceptosButton.Enabled = false;
                else
                    AgregarConceptosButton.Enabled = true;

            }
            catch (Exception ex)
            {
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript( GetType(),"popup", "window.open('ConceptosPersonal.aspx');", true);
        }

        
       
    }
}