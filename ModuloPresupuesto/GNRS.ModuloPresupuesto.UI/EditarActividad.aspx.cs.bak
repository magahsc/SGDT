using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNRS.ModuloPresupuesto.BL.BC;
using GNRS.ModuloPresupuesto.DL.DALC;
using System.Data.Entity;

namespace GNRS.ModuloPresupuesto.UI
{
    public partial class EditarActividad : System.Web.UI.Page
    {
        CapacitarProyectadoBC objcapacitar = new CapacitarProyectadoBC();
        PRESUPUESTO_ACTIVIDAD_PROYECTADA objActividad = new PRESUPUESTO_ACTIVIDAD_PROYECTADA();
        ACTIVIDAD obj = new ACTIVIDAD();
        protected void Page_Load(object sender, EventArgs e)
        {
            String id = Request.QueryString["id"];
            if (!IsPostBack)
            {
                objActividad = objcapacitar.ObtenerPresupuestoActividad(Convert.ToInt32(id));
                FechaLabel.Text = "Mes de inicio del período del presupuesto: " + Darmes(objActividad.mes_inicio) + " del " + objActividad.anio_inicio;
                obj = objcapacitar.ObtenerActividadXCodigo(objActividad.id_actividad);
                ActividadLabel.Text = obj.nombre_actividad;

                PERIODO_PRESUPUESTO objPeriodo = new PERIODO_PRESUPUESTO();
                objPeriodo = objcapacitar.ObtenerPeriodoPresupuesto(objActividad.id_periodo_presupuesto);

                MesInicioComboBox.DataSource = ListaMesInicio(objPeriodo.mes_periodo, objPeriodo.anio_periodo);
                MesInicioComboBox.DataBind();
                MesInicioComboBox.Items.Insert(0, new ListItem("Seleccione el mes", ""));

                String smesinicio = mes(objActividad.mes_inicio, objActividad.anio_inicio);
                MesInicioComboBox.Items.FindByText(smesinicio).Selected = true;

                int icodmes = GetCodMes(MesInicioComboBox);
                int icodanio = GetCodAnio(MesInicioComboBox);
                MesFinComboBox.DataSource = ListaMesFinal(icodmes, icodanio, objPeriodo.mes_periodo, objPeriodo.anio_periodo);
                MesFinComboBox.DataBind();
                MesFinComboBox.Items.Insert(0, new ListItem("Seleccione el mes", ""));

                String smesfin = mes(objActividad.mes_fin, objActividad.anio_fin);
                MesFinComboBox.Items.FindByText(smesfin).Selected = true;

                MontoTextBox.Text = Math.Round(objActividad.monto_actividad,2) + "";

                if (objActividad.tipo_moneda == "S")
                    TipoMonedaRadioButtonList.SelectedIndex = 0;

                if (objActividad.tipo_moneda == "D")
                    TipoMonedaRadioButtonList.SelectedIndex = 1;

                ObservacionesTextBox.Text = objActividad.detalle_actividad;
            }
        }

        public String Darmes(int mes)
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

        public int GetCodMes(DropDownList dpl)
        {
            int scod = 0;

            if (dpl.SelectedValue.Contains("Enero"))
                scod = 1;
            if (dpl.SelectedValue.Contains("Febrero"))
                scod = 2;
            if (dpl.SelectedValue.Contains("Marzo"))
                scod = 3;
            if (dpl.SelectedValue.Contains("Abril"))
                scod = 4;
            if (dpl.SelectedValue.Contains("Mayo"))
                scod = 5;
            if (dpl.SelectedValue.Contains("Junio"))
                scod = 6;
            if (dpl.SelectedValue.Contains("Julio"))
                scod = 7;
            if (dpl.SelectedValue.Contains("Agosto"))
                scod = 8;
            if (dpl.SelectedValue.Contains("Setiembre"))
                scod = 9;
            if (dpl.SelectedValue.Contains("Octubre"))
                scod = 10;
            if (dpl.SelectedValue.Contains("Noviembre"))
                scod = 11;
            if (dpl.SelectedValue.Contains("Diciembre"))
                scod = 12;

            return scod;
        }

        public int GetCodAnio(DropDownList dpl)
        {
            int scod = 0;
            
            //String sanio1 = Session["anio"].ToString();
            String id = Request.QueryString["id"];
            PRESUPUESTO_ACTIVIDAD_PROYECTADA objActividadAnio = new PRESUPUESTO_ACTIVIDAD_PROYECTADA();
            objActividadAnio = objcapacitar.ObtenerPresupuestoActividad(Convert.ToInt32(id));

            PERIODO_PRESUPUESTO objPeriodo = new PERIODO_PRESUPUESTO();
            objPeriodo = objcapacitar.ObtenerPeriodoPresupuesto(objActividadAnio.id_periodo_presupuesto);

            int ianio1 = objPeriodo.anio_periodo;
            String sanio1 = Convert.ToString(ianio1);

            int ianio2 = ianio1 + 1;
            String sanio2 = Convert.ToString(ianio2);

            if (dpl.SelectedValue.Contains(sanio1))
                scod = ianio1;
            if (dpl.SelectedValue.Contains(sanio2))
                scod = ianio2;

            return scod;
        }

        public String mes(int mes, int anio)
        {
            String mesd = "";
            switch (mes)
            {
                case 1:
                    {
                        mesd = "Enero " + anio;
                        break;
                    }

                case 2:
                    {
                        mesd = "Febrero " + anio;
                        break;
                    }

                case 3:
                    {
                        mesd = "Marzo " + anio;
                        break;
                    }

                case 4:
                    {
                        mesd = "Abril " + anio;
                        break;
                    }

                case 5:
                    {
                        mesd = "Mayo " + anio;
                        break;
                    }

                case 6:
                    {
                        mesd = "Junio " + anio;
                        break;
                    }

                case 7:
                    {
                        mesd = "Julio " + anio;
                        break;
                    }

                case 8:
                    {
                        mesd = "Agosto " + anio;
                        break;
                    }

                case 9:
                    {
                        mesd = "Setiembre " + anio;
                        break;
                    }

                case 10:
                    {
                        mesd = "Octubre " + anio;
                        break;
                    }

                case 11:
                    {
                        mesd = "Noviembre " + anio;
                        break;
                    }

                case 12:
                    {
                        mesd = "Diciembre " + anio;
                        break;
                    }
            }
            return mesd;
        }

        public List<String> ListaMesInicio(int numeromes, int anio)
        {
            List<String> lista = new List<String>();
            int ianio = anio;
            int variable = 0;
            int valida = 0;

            for (int i = numeromes; i <= numeromes + 12; i++)
            {
                if (i <= 12)
                    variable = i;

                if (i > 12 && valida == 0)
                {
                    variable = 1;
                    ianio++;
                    valida = 1;
                }

                lista.Add(mes(variable, ianio));
                variable++;
            }

            return lista;
        }

        public List<String> ListaMesFinal(int numeromes, int anio, int sessionmes, int sessionanio)
        {
            List<String> lista = new List<String>();

            int imes = sessionmes;
            int ianio = sessionanio;

            int diferencia = 0;

            if (anio == ianio)
                diferencia = imes + 12 - numeromes;

            if (anio > ianio)
                diferencia = imes - numeromes;

            int variable = 0;
            int valida = 0;
            ianio = anio;

            for (int i = numeromes; i <= numeromes + diferencia; i++)
            {
                if (i <= 12)
                    variable = i;

                if (i > 12 && valida == 0)
                {
                    variable = 1;
                    ianio++;
                    valida = 1;
                }

                lista.Add(mes(variable, ianio));
                variable++;
            }

            return lista;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            if (MesInicioComboBox.SelectedIndex > 0 && MesFinComboBox.SelectedIndex > 0 && MontoTextBox.Text != "" && ObservacionesTextBox.Text != "")
            {
                String id = Request.QueryString["id"];
                PRESUPUESTO_ACTIVIDAD_PROYECTADA objActividadProyectada = new PRESUPUESTO_ACTIVIDAD_PROYECTADA();
                int icodmesInicio = GetCodMes(MesInicioComboBox);
                int icodanioInicio = GetCodAnio(MesInicioComboBox);

                int icodmesFinal = GetCodMes(MesFinComboBox);
                int icodanioFinal = GetCodAnio(MesFinComboBox);

                objActividadProyectada.id_actividad_proyectada = Convert.ToInt32(id);
                objActividadProyectada.mes_inicio = icodmesInicio;
                objActividadProyectada.mes_fin = icodmesFinal;
                objActividadProyectada.anio_inicio = icodanioInicio;
                objActividadProyectada.anio_fin = icodanioFinal;

                Double dmonto = Convert.ToDouble(MontoTextBox.Text);
                String Observaciones = Convert.ToString(ObservacionesTextBox.Text);

                objActividadProyectada.monto_actividad = dmonto;
                objActividadProyectada.detalle_actividad = Observaciones;

                int iTipoMoneda = TipoMonedaRadioButtonList.SelectedIndex;
                if(iTipoMoneda == 0)
                    objActividadProyectada.tipo_moneda = "S";
                 if(iTipoMoneda == 1)
                    objActividadProyectada.tipo_moneda = "D";

                objcapacitar.ActualizarActividadDatos(objActividadProyectada);
                objActividadProyectada = objcapacitar.ObtenerPresupuestoActividad(Convert.ToInt32(id)); 

                AUDITORIA_PRESUPUESTO objauditoria = new AUDITORIA_PRESUPUESTO();

                objauditoria.id_capacitacion_proyectada = 0;
                objauditoria.id_personal_proyectado = 0;
                objauditoria.fecha_accion = DateTime.Now;
                objauditoria.tipo_accion = "A";
                objauditoria.id_actividad_proyectada = Convert.ToInt32(id); ;
                objauditoria.tipo_presupuesto = "A";

                objcapacitar.RegistrarAuditoriaPresupuesto(objauditoria);

                String Mensaje = objActividadProyectada.codigo_actividad_proyectada;
                hdnSession.Value = Mensaje;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarMensajeFinal()", true);

            }
            else
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensaje('Datos incompletos. Llene todos los campos para poder actualizar el presupuesto')", true);
        }

        protected void MesInicioComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id = Request.QueryString["id"];
            objActividad = objcapacitar.ObtenerPresupuestoActividad(Convert.ToInt32(id));

            PERIODO_PRESUPUESTO objPeriodo = new PERIODO_PRESUPUESTO();
            objPeriodo = objcapacitar.ObtenerPeriodoPresupuesto(objActividad.id_periodo_presupuesto);

            int imes = objPeriodo.mes_periodo;
            int ianio = objPeriodo.anio_periodo;

            if (MesInicioComboBox.SelectedIndex == 0)
            {
                MesFinComboBox.DataSource = ListaMesInicio(imes,ianio);
                MesFinComboBox.DataBind();
                MesFinComboBox.Items.Insert(0, new ListItem("Seleccione el mes", ""));
                MesFinComboBox.Enabled = false;
                ComboBoxUpdatePanel.Update();
            }

            if (MesInicioComboBox.SelectedIndex > 0)
            {
                int icodmes = GetCodMes(MesInicioComboBox);
                int icodanio = GetCodAnio(MesInicioComboBox);
                MesFinComboBox.DataSource = ListaMesFinal(icodmes, icodanio,imes,ianio);
                MesFinComboBox.DataBind();
                MesFinComboBox.Items.Insert(0, new ListItem("Seleccione el mes", ""));
                MesFinComboBox.Enabled = true;
                ComboBoxUpdatePanel.Update();
            }
        }
    }
}