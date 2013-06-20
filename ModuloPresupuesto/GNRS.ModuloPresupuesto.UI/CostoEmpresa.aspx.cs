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

namespace GNRS.ModuloPresupuesto.UI
{
    public partial class CostoEmpresa : System.Web.UI.Page
    {
        CostoEmpresaBC objCostoEmpresaBC;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCostoEmpresaGridView();
                LimpiarCampos();



            }

        }
        public void LimpiarCampos()
        {
            BeneficioSocialTextBox.Text = "";
            FactorTextBox.Text = "";
            CategoriaComboBox.SelectedIndex = 0;

        }
        public void CargarCostoEmpresaGridView()
        {
            objCostoEmpresaBC = new CostoEmpresaBC(); 
            List<COSTO_EMPRESA> lista = new List<COSTO_EMPRESA>();
            lista = objCostoEmpresaBC.listarCosto_Empresa();
            CostoEmpresaGridView.DataSource = lista;
            CostoEmpresaGridView.DataBind();
            //GridUpdatePanel.Update();
        }
        protected string FormatCategoria(string categoria)
        {
            if (categoria.Equals("0"))
                return "Todos";
            if (categoria.Equals("1"))
                return "Empleado";
            if (categoria.Equals("2"))
                return "Obrero";
            return "";
        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (BeneficioSocialTextBox.Text.Equals("") || FactorTextBox.Text.Equals("") || CategoriaComboBox.SelectedItem.Value.Equals("-1"))
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mensajeCamposIncompletos()", true);
                }
                else
                {
                    COSTO_EMPRESA objCostoEmpresa = new COSTO_EMPRESA();
                    objCostoEmpresa.beneficio_social = BeneficioSocialTextBox.Text;
                    objCostoEmpresa.factor = Decimal.Parse(FactorTextBox.Text);

                    string categoriaSeleccionada = CategoriaComboBox.SelectedItem.Value;
                    objCostoEmpresa.id_categoria = Convert.ToInt32(categoriaSeleccionada);
                    objCostoEmpresaBC = new CostoEmpresaBC();
                    Boolean resultado;
                    if (Session["accion"] != null && Session["accion"].Equals("editar"))
                    {
                        string hidden = editarHidden.Value;
                        if (hidden.Equals(""))
                        {

                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "confirmarEditar('¿Desea actualizar el costo empresa?')", true);

                        }
                        else
                        {
                            if (editarHidden.Value.Equals("si"))
                            {
                                int codigoEditar = -1;
                                if (Session["id_costoEmpresa"] != null)
                                {
                                    codigoEditar = Convert.ToInt32(Session["id_costoEmpresa"].ToString());
                                }
                                resultado = objCostoEmpresaBC.editarCostoEmpresa(codigoEditar, objCostoEmpresa);


                                if (resultado == true)
                                {

                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "costoEmpresaRegistroExitoso('El costo empresa se ha actualizado exitosamente.')", true);

                                    BeneficioSocialTextBox.Text = "";
                                    FactorTextBox.Text = "";
                                    Session.Remove("id_costoEmpresa");
                                    Session.Remove("accion");
                                    Session.Add("mensajeRecalcular", "si");

                                    LimpiarCampos();
                                    editarHidden.Attributes["value"] = "";
                                    UpdatePanelHidden.Update();
                                    CargarCostoEmpresaGridView();
                                }
                            }

                        }
                    }
                    else
                    {
                        int res = -1;
                        res = objCostoEmpresaBC.insertarCostoEmpresa(objCostoEmpresa);
                        if (res != -1)
                        {
                            Session.Add("mensajeRecalcular", "si");

                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "costoEmpresaRegistroExitoso('El costo empresa se ha guardado exitosamente.')", true);

                            BeneficioSocialTextBox.Text = "";
                            FactorTextBox.Text = "";
                            CategoriaComboBox.SelectedIndex = 0;
                            LimpiarCampos();
                            CargarCostoEmpresaGridView();
                        }
                    }




                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void CostoEmpresaGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdEditar"))
            {
                int id_costoEmpresa = Convert.ToInt32(e.CommandArgument);
                COSTO_EMPRESA objCostoEmpresa_Editar;
                objCostoEmpresaBC = new CostoEmpresaBC();
                objCostoEmpresa_Editar = objCostoEmpresaBC.obtenerCostoEmpresa(id_costoEmpresa);

                CategoriaComboBox.ClearSelection();
                CategoriaComboBox.Items.FindByValue(objCostoEmpresa_Editar.id_categoria.ToString()).Selected = true;
                BeneficioSocialTextBox.Text = objCostoEmpresa_Editar.beneficio_social;
                FactorTextBox.Text = objCostoEmpresa_Editar.factor.ToString();

                Session.Add("accion", "editar");
                Session.Add("id_costoEmpresa", id_costoEmpresa);

                PrimerUpdatePanel.Update();

            }

            if (e.CommandName.Equals("cmdEliminar"))
            {
                Session.Remove("accion");
                Session.Remove("id_costoEmpresa");

                int id_costoEmpresa = Convert.ToInt32(e.CommandArgument);

                objCostoEmpresaBC = new CostoEmpresaBC();
                objCostoEmpresaBC.eliminarCostoEmpresa(id_costoEmpresa);
                Session.Add("mensajeRecalcular", "si");

                CargarCostoEmpresaGridView();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "alert('El costo empresa se ha sido eliminado exitosamente.')", true);



            }
        }

        protected void Recalcular_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "confirmarRecalcular('Esta opción recalculará el beneficio social para todos los empleados. ¿Está seguro de realizar esta operación?')", true);

        }

        [WebMethod]
        public static void recalcularCostoEmpresa()
        {
            CostoEmpresaBC objCostoEmpresaBC = new CostoEmpresaBC();
            float costoEmpresaEmpleado = objCostoEmpresaBC.calcularCostoEmpresaXCategoria(1);
            float costoEmpresaObrero = objCostoEmpresaBC.calcularCostoEmpresaXCategoria(2);

            // Session.Add("costoEmpresaEmpleado", costoEmpresaEmpleado);
            // Session.Add("costoEmpresaObrero", costoEmpresaObrero);

            objCostoEmpresaBC.recalcular(costoEmpresaEmpleado, costoEmpresaObrero);
            HttpContext.Current.Session.Remove("mensajeRecalcular");
        }


    }
}