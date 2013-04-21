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
                }

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
                float.TryParse(MontoTextBox.Text, out _monto);
                objConceptoTemp.Monto = _monto;
                int cantidad = ConceptosTemporalesLista.Count();
                objConceptoTemp.Cod = cantidad + 1;

                ConceptosTemporalesLista.Add(objConceptoTemp);
                ConceptosGridView.DataSource = ConceptosTemporalesLista;
                ConceptosGridView.DataBind();

                Session.Add("ConceptosTemporalesLista", ConceptosTemporalesLista);

                ConceptoComboBox.Enabled = false;
                ConceptoComboBox.SelectedIndex = 0;
                TipoConceptoComboBox.SelectedIndex = 0;
                MontoTextBox.Text = "";


                ComboBoxUpdatePanel.Update();
            }
          


        }

        protected void ConceptosGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
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
                ConceptosGridView.DataSource = ConceptosTemporalesLista;
                ConceptosGridView.DataBind();

                ComboBoxUpdatePanel.Update();
            }


        }

        protected void GuardarConceptosButton_Click(object sender, EventArgs e)
        {
            List<ConceptoTemporalBE> ConceptosTemporalesLista = new List<ConceptoTemporalBE>();

            if (Session["ConceptosTemporalesLista"] != null)
            {
                ConceptosTemporalesLista = (List<ConceptoTemporalBE>)Session["ConceptosTemporalesLista"];

            }
            Session.Add("ConceptosTemporalesLista", ConceptosTemporalesLista);
            Response.Redirect("RegistrarPresupuestoPersonalProyectado.aspx");

        }
       
    }
}