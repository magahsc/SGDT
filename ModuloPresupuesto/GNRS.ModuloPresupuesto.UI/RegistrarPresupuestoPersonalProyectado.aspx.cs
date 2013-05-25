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

namespace GNRS.ModuloPresupuesto.UI
{
    public partial class RegistrarPresupuestoPersonalProyectado : System.Web.UI.Page
    {
        PresupuestoPersonalProyectadoBC presupuestoPersonalBC = new PresupuestoPersonalProyectadoBC();
        PersonaDALC objPersonaDALC = new PersonaDALC();
        AreaDALC objAreaDALC = new AreaDALC();
        ConceptoPersonaDALC objConceptoPersonaDALC = new ConceptoPersonaDALC();
        ConceptoRemuneracionDALC objConceptoRemuneracionDALC = new ConceptoRemuneracionDALC();


        protected void Page_Load(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "SetupDialog", "SetupDialog();", true);

            string modo = Request.QueryString["modo"];
            if (modo.Equals("1"))
            {   
                
                if (!IsPostBack)
                {
                    cantidadDiv.Visible = true;
                    identificadorDiv.Visible = false;
                    guardarButton.Visible = false;
                    registrarButton.Visible = true;

                    modoHidden.Attributes["value"] = "1";

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


                    if (Session["mes"] == null || Session["dia"] == null || Session["anio"] == null)
                    {

                        alert("Debe configurar el mes y el año para poder realizar un registro de capacitación");
                        Server.Transfer("MainPage.aspx");
                    }
                }

            }

            if (modo.Equals("2"))
            {
                if (!IsPostBack)
                {
                    cargarCostosEmpresa();

                    modoHidden.Attributes["value"] = "2";

                    

                    int idPersonaEditar;

                    PERSONA objPersona = new PERSONA();
                    if (Session["codPersonaEditar"] != null)
                    {

                        idPersonaEditar = (Int32)Session["codPersonaEditar"];
                        codigoEditarHidden.Attributes["value"] = idPersonaEditar.ToString();

                        objPersona = objPersonaDALC.obtenerPersonasXId(idPersonaEditar);

                        cargarComboBox();
                        cargarPersonaAEditar(objPersona);
                    }
                }


            }
        }

        public void cargarPersonaAEditar(PERSONA objPersona)
        {
            cantidadDiv.Visible = false;
            identificadorDiv.Visible = true;
            guardarButton.Visible = true;
            registrarButton.Visible = false;

            LocalidadComboBox.Enabled = true;
            AreaComboBox.Enabled = true;
            SeccionComboBox.Enabled = true;
            CargoComboBox.Enabled = true;
          


            LocalidadComboBox.Items.FindByValue(objPersona.id_localidad.ToString()).Selected = true;     

            AreaComboBox.DataSource = presupuestoPersonalBC.filtrarAreasXLocalidad(objPersona.id_localidad);
            AreaComboBox.DataBind();
            int codigoSeccion = objPersona.id_seccion;
            int codigoArea = objAreaDALC.obtenerIdAreaXCodigoSeccion(codigoSeccion);
            AreaComboBox.Items.FindByValue(codigoArea.ToString()).Selected = true;
            
            SeccionComboBox.DataSource = presupuestoPersonalBC.filtrarSeccionesXAreaLocalidad(codigoArea, objPersona.id_localidad);
            SeccionComboBox.DataBind(); 
            SeccionComboBox.Items.FindByValue(objPersona.id_seccion.ToString()).Selected = true;


            CargoComboBox.DataSource = presupuestoPersonalBC.filtrarCargosXSeccion(codigoSeccion);
            CargoComboBox.DataBind(); 
            CargoComboBox.Items.FindByValue(objPersona.id_cargo.ToString()).Selected = true;           

            TipoPersonalComboBox.Items.FindByValue(objPersona.id_categoria.ToString()).Selected = true;

            identificadorTextBox.Text = objPersona.nombres_persona;


            //ConceptosPersonal

            guardarConceptosPorPersonaSession(objPersona.id_persona);

            ComboBoxUpdatePanel.Update();


            

        }

        public void guardarConceptosPorPersonaSession(int idPersona)
        {
            
            List<CONCEPTO_POR_PERSONA> listaConceptosPersona = new List<CONCEPTO_POR_PERSONA>();
            listaConceptosPersona = objConceptoPersonaDALC.listarConceptosXPersona(idPersona);

            List<ConceptoTemporalBE> listaConceptosTemporales = new List<ConceptoTemporalBE>();
            ConceptoTemporalBE objConceptoBE;
            CONCEPTO_REMUNERACION objAuxConceptoRemun=new CONCEPTO_REMUNERACION();
            int i=0;
            foreach (CONCEPTO_POR_PERSONA it in listaConceptosPersona)
            {
                objAuxConceptoRemun=objConceptoRemuneracionDALC.obtenerConceptoPersonaXID(it.id_concepto);

                objConceptoBE = new ConceptoTemporalBE();
                objConceptoBE.Cod = i;
                objConceptoBE.Concepto_Cod = it.id_concepto;
                objConceptoBE.Concepto_Texto = objAuxConceptoRemun.nombre_concepto;

                objConceptoBE.Monto = (float)it.monto;

                int tipoConcepto_Cod = objAuxConceptoRemun.columna_boleta;      

                objConceptoBE.TipoConcepto_Cod=tipoConcepto_Cod;
                if (tipoConcepto_Cod==1)
                    objConceptoBE.TipoConcepto_Texto="Ingresos";
                if (tipoConcepto_Cod==2)
                    objConceptoBE.TipoConcepto_Texto="Descuentos";
                if (tipoConcepto_Cod==3)
                    objConceptoBE.TipoConcepto_Texto="Aportaciones";

                listaConceptosTemporales.Add(objConceptoBE);
                i++;
    
            }
            Session.Add("ConceptosTemporalesLista", listaConceptosTemporales);
            nroConceptos.Attributes["value"] = listaConceptosTemporales.Count().ToString() ;

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
                int codigoLocalidad;

                if (int.TryParse(LocalidadComboBox.SelectedValue, out codigoLocalidad))
                {
                    AreaComboBox.DataSource = presupuestoPersonalBC.filtrarAreasXLocalidad(codigoLocalidad);
                    AreaComboBox.DataBind();
                    AreaComboBox.Items.Insert(0, new ListItem("Seleccione el area", ""));

                    AreaComboBox.Enabled = true;
                    SeccionComboBox.Enabled = false;
                    CargoComboBox.Enabled = false;


                    ComboBoxUpdatePanel.Update();
                }


                else
                {
                    AreaComboBox.Enabled = false;
                    AreaComboBox.Items.Insert(0, new ListItem("Seleccione el area", ""));

                    SeccionComboBox.Enabled = false;
                    SeccionComboBox.Items.Insert(0, new ListItem("Seleccione la seccion", ""));

                    CargoComboBox.Enabled = false;
                    CargoComboBox.Items.Insert(0, new ListItem("Seleccione el cargo", ""));
                    
                }

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
        public static string confirmarRegistro(string codLocalidad, string codArea, string codSeccion, string codCargo, string cantidad, string cargo, string codTipoPersonal, string costoEmpresaEmpleadoHidden, string costoEmpresaObreroHidden)
        {

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

                   

                }
                else
                {
                    return "";
                }
            }


                HttpContext.Current.Session.Remove("ConceptosTemporalesLista");

                return "sdf";

        }



        [WebMethod]
        public static string confirmarActualizacion(string codLocalidad, string codArea, string codSeccion, string codCargo, string identificador, string cargo, string codTipoPersonal, string costoEmpresaEmpleadoHidden, string costoEmpresaObreroHidden,string id_persona)
        {
            
            if (cargo.Equals(""))
            {
                return "";
            }

            PresupuestoPersonalProyectadoBC presupuestoPersonalBC = new PresupuestoPersonalProyectadoBC();


            int codigoLocalidad, codigoArea, codigoSeccion, codigoCargo, codigoTipoPersonal,codigoPersona;

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


            float costoEmpresaRegistrar = -1;
            if (codigoTipoPersonal == 1)
            {
                costoEmpresaRegistrar = float.Parse(costoEmpresaEmpleadoHidden);
            }
            if (codigoTipoPersonal == 2)
            {
                costoEmpresaRegistrar = float.Parse(costoEmpresaObreroHidden);
            }

            if (!int.TryParse(id_persona, out codigoPersona))
            {
                codigoPersona = 0;
            }

            Boolean actualizoPersona = presupuestoPersonalBC.actualizarPersonalProyectar(codigoLocalidad, codigoSeccion, codigoCargo, identificador, codigoTipoPersonal, codigoPersona);

            if (actualizoPersona ==true)
            {
                List<ConceptoTemporalBE> ConceptosTemporalesLista = new List<ConceptoTemporalBE>();
                if (HttpContext.Current.Session["ConceptosTemporalesLista"] != null)
                {
                    ConceptosTemporalesLista = (List<ConceptoTemporalBE>)HttpContext.Current.Session["ConceptosTemporalesLista"];

                }

                foreach (ConceptoTemporalBE item in ConceptosTemporalesLista)
                {
                    presupuestoPersonalBC.registrarConceptoXPersona(codigoPersona, item.Concepto_Cod, item.Monto, costoEmpresaRegistrar);
                }
            }
            else
            {
                return "";
            }

            //Registra auditoria presupuesto

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

        protected void volverButton_Click(object sender, EventArgs e)
        {
            Session.Remove("ConceptosTemporalesLista");

            Response.Redirect("Listar.aspx");
        }

        
       
    }
}