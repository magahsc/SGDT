using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNRS.ModuloPresupuesto.BL.BC;
using GNRS.ModuloPresupuesto.DL.DALC;
using GNRS.ModuloPresupuesto.BL.BE;
using System.Data.Entity;
using System.Web.Services;
namespace GNRS.ModuloPresupuesto.UI
{
    public partial class ConceptosPersonal : System.Web.UI.Page
    {
        PresupuestoPersonalProyectadoBC presupuestoPersonalBC = new PresupuestoPersonalProyectadoBC();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarComboBox();
               
                if (Session["ConceptosTemporalesLista"] != null)
                {
                    List<ConceptoTemporalBE> ConceptosTemporalesLista;
                    ConceptosTemporalesLista = (List<ConceptoTemporalBE>)Session["ConceptosTemporalesLista"];
                    ConceptosGridView.DataSource = ConceptosTemporalesLista;
                    ConceptosGridView.DataBind();
                    nroConceptoPersonal.Text = ConceptosTemporalesLista.Count().ToString();
                    ComboBoxUpdatePanel.Update();
                }
                //else
                //    GuardarConceptosButton.Visible = false;
            }
        }

        public void cargarComboBox()
        {
            TipoConceptoComboBox.Items.Insert(0, new ListItem("Seleccione un tipo", ""));
            ConceptoComboBox.Enabled = false;
            ConceptoComboBox.Items.Insert(0, new ListItem("Seleccione un concepto", ""));


        }

        protected void TipoConceptoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int tipoConcepto = Convert.ToInt32(TipoConceptoComboBox.SelectedValue);
                ConceptoComboBox.DataSource = presupuestoPersonalBC.filtrarConceptosXTipo(tipoConcepto);
                ConceptoComboBox.DataTextField = "nombre_concepto";
                ConceptoComboBox.DataValueField = "id_concepto"; 
                ConceptoComboBox.DataBind();
                ConceptoComboBox.Items.Insert(0, new ListItem("Seleccione un concepto", ""));

                ConceptoComboBox.Enabled = true;

                ComboBoxUpdatePanel.Update();

            }
            catch (Exception ex)
            {
            }
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            if (ConceptoComboBox.SelectedItem.Value != "" && TipoConceptoComboBox.SelectedItem.Value != "" && MontoTextBox.Text != "")
            {
                string montoRegistrar = MontoTextBox.Text.Replace(".", ",");
                

                List<ConceptoTemporalBE> ConceptosTemporalesLista = new List<ConceptoTemporalBE>();

                if (Session["ConceptosTemporalesLista"] != null)
                {
                    ConceptosTemporalesLista = (List<ConceptoTemporalBE>)Session["ConceptosTemporalesLista"];

                }


                ConceptoTemporalBE objConceptoTemp = new ConceptoTemporalBE();
                string tipoConcepto_Tipo = TipoConceptoComboBox.SelectedItem.Text;
                objConceptoTemp.TipoConcepto_Texto = tipoConcepto_Tipo;
                if (tipoConcepto_Tipo.Equals("Ingresos"))
                    objConceptoTemp.TipoConcepto_Cod = 1;
                if (tipoConcepto_Tipo.Equals("Descuentos"))
                    objConceptoTemp.TipoConcepto_Cod = 2;
                if (tipoConcepto_Tipo.Equals("Aportaciones"))
                    objConceptoTemp.TipoConcepto_Cod = 3;

                objConceptoTemp.Concepto_Cod = Convert.ToInt32(ConceptoComboBox.SelectedItem.Value);
                objConceptoTemp.Concepto_Texto = ConceptoComboBox.SelectedItem.Text;

                float _monto;
                float.TryParse(montoRegistrar, out _monto);
                objConceptoTemp.Monto = _monto;


                if (Session["accion"] != null && Session["accion"].Equals("editar"))
                {
                    int codigoEditar = Convert.ToInt32(Session["codConceptoAEditar"]);
                    objConceptoTemp.Cod = codigoEditar;
                    var index = ConceptosTemporalesLista.FindIndex(x => x.Cod == codigoEditar);
                    ConceptosTemporalesLista[index] = objConceptoTemp;

                    Session.Remove("accion");
                    Session.Remove("codConceptoAEditar");

                }

                else
                {
                    int cantidad;
                    if (ConceptosTemporalesLista.Count() == 0)
                        cantidad = 0;
                    else
                        cantidad = ConceptosTemporalesLista[ConceptosTemporalesLista.Count - 1].Cod;

                    objConceptoTemp.Cod = cantidad + 1;
                    ConceptosTemporalesLista.Add(objConceptoTemp);

                }
               
                ConceptosGridView.DataSource = ConceptosTemporalesLista;
                ConceptosGridView.DataBind();

                Session.Add("ConceptosTemporalesLista", ConceptosTemporalesLista);
                Session.Add("NumeroConceptos", ConceptosTemporalesLista.Count().ToString());
           
                ConceptoComboBox.Enabled = false;
                ConceptoComboBox.SelectedIndex = 0;
                TipoConceptoComboBox.SelectedIndex = 0;
                MontoTextBox.Text = "";

                AgregarButton.Enabled = false;

                ComboBoxUpdatePanel.Update();
                nroConceptoPersonal.Text = ConceptosTemporalesLista.Count().ToString();

            }


            
        }

        protected void ConceptosGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdEditar"))
            {
                List<ConceptoTemporalBE> ConceptosTemporalesLista = new List<ConceptoTemporalBE>();

                if (Session["ConceptosTemporalesLista"] != null)
                {
                    ConceptosTemporalesLista = (List<ConceptoTemporalBE>)Session["ConceptosTemporalesLista"];

                }

                int codigoEditar = Convert.ToInt32(e.CommandArgument);
                ConceptoTemporalBE objEditar = ConceptosTemporalesLista.Find(x => x.Cod == codigoEditar);

                int codTipo = objEditar.TipoConcepto_Cod;
                TipoConceptoComboBox.ClearSelection();
                TipoConceptoComboBox.Items.FindByValue(codTipo.ToString()).Selected = true;

                int codConcepto = objEditar.Concepto_Cod;

                int tipoConcepto = Convert.ToInt32(TipoConceptoComboBox.SelectedValue);
                ConceptoComboBox.DataSource = presupuestoPersonalBC.filtrarConceptosXTipo(tipoConcepto);
                ConceptoComboBox.DataTextField = "nombre_concepto";
                ConceptoComboBox.DataValueField = "id_concepto";
                ConceptoComboBox.DataBind();
                ConceptoComboBox.Items.Insert(0, new ListItem("Seleccione un concepto", ""));



                ConceptoComboBox.ClearSelection();

                ConceptoComboBox.Items.FindByValue(codConcepto.ToString()).Selected = true;
                ConceptoComboBox.Enabled = true;
                MontoTextBox.Text = objEditar.Monto.ToString();

                Session.Add("accion", "editar");
                Session.Add("codConceptoAEditar", codigoEditar);

                AgregarButton.Enabled = true;

                ComboBoxUpdatePanel.Update();


            } 
            
            if (e.CommandName.Equals("cmdEliminar"))
            {
                List<ConceptoTemporalBE> ConceptosTemporalesLista = new List<ConceptoTemporalBE>();

                if (Session["ConceptosTemporalesLista"] != null)
                {
                    ConceptosTemporalesLista = (List<ConceptoTemporalBE>)Session["ConceptosTemporalesLista"];

                }
      
                int codigoEliminar=Convert.ToInt32(e.CommandArgument);

                ConceptoTemporalBE obEliminar=ConceptosTemporalesLista.Find(x => x.Cod == codigoEliminar);

                ConceptosTemporalesLista.Remove(obEliminar);


                Session.Add("ConceptosTemporalesLista", ConceptosTemporalesLista);
                Session.Add("NumeroConceptos", ConceptosTemporalesLista.Count().ToString());
             

                ConceptosGridView.DataSource = ConceptosTemporalesLista;
                ConceptosGridView.DataBind();

                ComboBoxUpdatePanel.Update();
                nroConceptoPersonal.Text = ConceptosTemporalesLista.Count().ToString();

            }


        }

        //protected void GuardarConceptosButton_Click(object sender, EventArgs e)
        //{
        //    List<ConceptoTemporalBE> ConceptosTemporalesLista = new List<ConceptoTemporalBE>();

        //    if (Session["ConceptosTemporalesLista"] != null)
        //    {
        //        ConceptosTemporalesLista = (List<ConceptoTemporalBE>)Session["ConceptosTemporalesLista"];

        //    }
        //    Session.Add("ConceptosTemporalesLista", ConceptosTemporalesLista);
        //    Session.Add("NumeroConceptos", ConceptosTemporalesLista.Count().ToString());
        //    Response.Redirect("RegistrarPresupuestoPersonalProyectado.aspx");

        //}

        protected void ConceptoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ConceptoComboBox.SelectedItem.Value == "")
                    AgregarButton.Enabled = false;
                else
                    AgregarButton.Enabled = true;

            }
            catch (Exception ex)
            {
            }
        }


        [WebMethod]
        public static string borrarSession()
        {
             HttpContext.Current.Session.Remove("ConceptosTemporalesLista");
             return "";
        }
    }
}