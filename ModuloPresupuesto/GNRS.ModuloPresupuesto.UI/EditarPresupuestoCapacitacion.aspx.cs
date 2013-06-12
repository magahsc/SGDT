using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNRS.ModuloPresupuesto.BL.BC;
using GNRS.ModuloPresupuesto.DL.DALC;
using System.Data.Entity;
using System.Globalization;
using System.Web.Services;

namespace GNRS.ModuloPresupuesto.UI
{
    public partial class EditarPresupuestoCapacitacion : System.Web.UI.Page
    {
        CapacitarProyectadoBC objcapacitar = new CapacitarProyectadoBC();
        public double j;
        public int contador;
        public int iIdCapacitacion;

        protected void Page_Load(object sender, EventArgs e)
        {
            INSTITUCION objinstitucion = new INSTITUCION();
            CURSO objcurso = new CURSO();
            LOCALIDAD objlocalidad = new LOCALIDAD();
            AREA objarea = new AREA();
            SECCION objseccion = new SECCION();
            List<PRESUPUESTO_CAPACITACION_POR_PERSONAL> lista = new List<PRESUPUESTO_CAPACITACION_POR_PERSONAL>();
            PRESUPUESTO_CAPACITACION objpresupuesto = new PRESUPUESTO_CAPACITACION();
            String id = Request.QueryString["id"];
            Session.Add("IdCapacitacion", id);

            if (!IsPostBack)
            {
                cargarComboBox();
                if (Session["IdCapacitacion"] == null)
                {
                    Server.Transfer("ListarPresupuestoCapacitacion.aspx");
                }


                iIdCapacitacion = Convert.ToInt32(Session["IdCapacitacion"].ToString());
                objpresupuesto = objcapacitar.ObtenerPresupuestoCapacitacion(iIdCapacitacion);

                FechaLabel.Text = "Mes de inicio del periodo del presupuesto: " + mes(objpresupuesto.fecha_creacion.Month) + " del " +
                    objpresupuesto.fecha_creacion.Year + "&nbsp;" + "&nbsp;" + " &nbsp;" + "&nbsp; " + "Fecha de creación: " + cambiarmesydia(Convert.ToString(objpresupuesto.fecha_creacion.Day)) + "/" + cambiarmesydia(Convert.ToString(objpresupuesto.fecha_creacion.Month)) + "/" + objpresupuesto.fecha_creacion.Year;

                InstitutoDropDownList.DataSource = objcapacitar.listarInstituciones();
                InstitutoDropDownList.DataBind();
                InstitutoDropDownList.Items.Insert(0, new ListItem("Seleccione el instituto", ""));

                objinstitucion = objcapacitar.ObtenerInstitucionxCodigoCurso(Convert.ToInt32(objpresupuesto.id_curso));
                InstitutoDropDownList.Items.FindByText(objinstitucion.nombre_institucion).Selected = true;

                CursoDropDownList.DataSource = objcapacitar.listarCursoxInsituciones(objinstitucion.id_institucion);
                CursoDropDownList.DataBind();
                CursoDropDownList.Items.Insert(0, new ListItem("Seleccione el curso", ""));

                objcurso = objcapacitar.obtenerCurso(Convert.ToInt32(objpresupuesto.id_curso));
                CursoDropDownList.Items.FindByText(objcurso.nombre_curso).Selected = true;

                objlocalidad = objcapacitar.ObtenerLocalidadXCodigo(Convert.ToInt32(objpresupuesto.id_localidad));
                LocalidadDropDownList.Items.FindByText(objlocalidad.nombre_localidad).Selected = true;

                AreaDropDownList.DataSource = objcapacitar.filtrarAreasXLocalidad(objlocalidad.id_localidad);
                AreaDropDownList.DataBind();
                AreaDropDownList.Items.Insert(0, new ListItem("Seleccione el area", ""));

                objarea = objcapacitar.ObtenerAreaxCodigoSeccion(Convert.ToInt32(objpresupuesto.id_seccion));
                AreaDropDownList.Items.FindByText(objarea.nombre_area).Selected = true;

                SeccionDropDownList.DataSource = objcapacitar.filtrarSeccionesXAreaLocalidad(objarea.id_area, objlocalidad.id_localidad);
                SeccionDropDownList.DataBind();
                SeccionDropDownList.Items.Insert(0, new ListItem("Seleccione la seccion", ""));

                objseccion = objcapacitar.ObtenerSeccionXCodigo(Convert.ToInt32(objpresupuesto.id_seccion));
                SeccionDropDownList.Items.FindByText(objseccion.nombre_seccion).Selected = true;

                ListaPersonasCapacitarGridView.DataSource = objcapacitar.listarPersona(objlocalidad.id_localidad, objarea.id_area, objseccion.id_seccion);
                ListaPersonasCapacitarGridView.DataBind();

                lista = objcapacitar.ObtenerCapacitacionPersonaXCodigo(iIdCapacitacion);

                DatosGridView.Update();
                ComboBoxUpdatePanel2.Update();

                for (int i = 0; i < ListaPersonasCapacitarGridView.Rows.Count; i++)
                {
                    GridViewRow row = ListaPersonasCapacitarGridView.Rows[i];
                    bool isChecked = ((CheckBox)row.FindControl("SelectCheckBox")).Checked;

                    int codigopersona = (int)ListaPersonasCapacitarGridView.DataKeys[i].Value;

                    foreach (PRESUPUESTO_CAPACITACION_POR_PERSONAL item in lista)
                    {
                        if (item.id_persona == codigopersona)
                        {
                            ((CheckBox)row.FindControl("SelectCheckBox")).Checked = true;
                        }
                    }
                }

                Session.Add("costocurso", objpresupuesto.monto_total);
                Session.Add("contador", objpresupuesto.cantidad_personas);

                DatosGridView.Update();
                ComboBoxUpdatePanel2.Update();
                ComboBoxUpdatePanel1.Update();

                if (objcurso.tipo_moneda == "S")
                    MontoPresupuestoLabel.Text = "S/. " + objpresupuesto.monto_total;

                if (objcurso.tipo_moneda == "D")
                    MontoPresupuestoLabel.Text = "$ " + objpresupuesto.monto_total;

                LabelUpdatePanel.Update();
                ComboBoxUpdatePanel1.Update();
                DatosGridView.Update();
                ComboBoxUpdatePanel2.Update();
                CheckUpdatePanel.Update();

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

        protected void ListaPersonasCapacitarGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ListaPersonasCapacitarGridView.PageIndex = e.NewPageIndex;

            int codigolocalidad = Convert.ToInt32(LocalidadDropDownList.SelectedValue);
            int codigoarea = Convert.ToInt32(AreaDropDownList.SelectedValue);
            int codigoseccion = Convert.ToInt32(SeccionDropDownList.SelectedValue);

            ListaPersonasCapacitarGridView.DataSource = objcapacitar.listarPersona(codigolocalidad, codigoarea, codigoseccion);
            ListaPersonasCapacitarGridView.DataBind();

            DatosGridView.Update();
        }

        protected void InstitutoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CursoDropDownList.Enabled = true;
            MarcarTodosCheckBox.Checked = false;
            ListaPersonasCapacitarGridView.DataSource = null;
            ListaPersonasCapacitarGridView.DataBind();
            MontoPresupuestoLabel.Text = "0.0";
            LabelUpdatePanel.Update();
            DatosGridView.Update();

            if (InstitutoDropDownList.SelectedIndex != 0)
            {
                int codigoinstituto = Convert.ToInt32(InstitutoDropDownList.SelectedValue);
                List<CURSO> lstCurso = new List<CURSO>();
                lstCurso = objcapacitar.listarCursoxInsituciones(codigoinstituto);
                List<CURSO> nuevaLista = new List<CURSO>();

                foreach (CURSO item in lstCurso)
                {
                    int codigoCurso = item.id_curso;

                    CURSO curso = new CURSO();
                    curso = objcapacitar.obtenerCurso(codigoCurso);

                    PERIODO_PRESUPUESTO objPeriodo = new PERIODO_PRESUPUESTO();
                    objPeriodo = objcapacitar.ObtenerPeriodoPresupuesto(Convert.ToInt32(Session["IdCapacitacion"].ToString()));

                    String smes = objPeriodo.mes_periodo.ToString();
                    smes = cambiarmesydia(smes);
                    String sanio = objPeriodo.anio_periodo.ToString();
                    String sdia = "01";
                    sdia = cambiarmesydia(sdia);

                    String cadenafecha = sanio + "-" + smes + "-" + sdia;
                    DateTime myDate, myDate2;
                    myDate = DateTime.ParseExact(cadenafecha, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    int aniofinal = Convert.ToInt32(sanio) + 1;
                    String saniofinal = aniofinal + "";
                    String cadenafecha2 = aniofinal + "-" + smes + "-" + sdia;
                    myDate2 = DateTime.ParseExact(cadenafecha2, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    int aniomydate = Convert.ToInt32(myDate.Year);
                    int aniocurso = Convert.ToInt32(curso.fecha_inicio.Year);

                    if ((DateTime.Compare(myDate, curso.fecha_inicio) < 0) && (DateTime.Compare(myDate2, curso.fecha_fin) > 0) && aniocurso == aniomydate)
                    {
                        nuevaLista.Add(item);
                    }
                }

                CursoDropDownList.DataSource = nuevaLista;
                CursoDropDownList.DataBind();
                CursoDropDownList.Items.Insert(0, new ListItem("Seleccione el curso", ""));

                ComboBoxUpdatePanel1.Update();
            }

            if (InstitutoDropDownList.SelectedIndex == 0)
            {
                InstitutoDropDownList.Enabled = true;
                CursoDropDownList.Enabled = false;
                CursoDropDownList.Items.Insert(0, new ListItem("Seleccione el curso", ""));
                CursoDropDownList.SelectedIndex = 0;
                ComboBoxUpdatePanel1.Update();
                MontoPresupuestoLabel.Text = "0.0";
                LabelUpdatePanel.Update();

            }

            if (SeccionDropDownList.SelectedIndex > 0)
                 SeccionDropDownList_SelectedIndexChanged(sender, e);

            CheckUpdatePanel.Update();
        }

        protected void CursoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaPersonasCapacitarGridView.DataSource = null;
            ListaPersonasCapacitarGridView.DataBind();
            MontoPresupuestoLabel.Text = "0.0";
            LabelUpdatePanel.Update();
            DatosGridView.Update();

            if (CursoDropDownList.SelectedIndex != 0)
            {
                InstitutoDropDownList.Enabled = true;
                CursoDropDownList.Enabled = true;
                MarcarTodosCheckBox.Checked = false;
                ComboBoxUpdatePanel1.Update();
            }
            if (CursoDropDownList.SelectedIndex == 0)
            {
                InstitutoDropDownList.Enabled = true;
                CursoDropDownList.Enabled = true;
                MarcarTodosCheckBox.Checked = false;
                ComboBoxUpdatePanel1.Update();
                MontoPresupuestoLabel.Text = "0.0";
                LabelUpdatePanel.Update();
            }

            if (SeccionDropDownList.SelectedIndex > 0)
                SeccionDropDownList_SelectedIndexChanged(sender, e);

            CheckUpdatePanel.Update();
        }

        protected void LocalidadDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaDropDownList.Enabled = true;
            LocalidadDropDownList.Enabled = true;
            SeccionDropDownList.Enabled = false;
            MontoPresupuestoLabel.Text = "0.0";
            LabelUpdatePanel.Update();
            MarcarTodosCheckBox.Checked = false;

            ListaPersonasCapacitarGridView.DataSource = null;
            ListaPersonasCapacitarGridView.DataBind();
            DatosGridView.Update();

            if (LocalidadDropDownList.SelectedIndex != 0)
            {
                int codigolocalidad = Convert.ToInt32(LocalidadDropDownList.SelectedValue);
                AreaDropDownList.DataSource = objcapacitar.filtrarAreasXLocalidad(codigolocalidad);

                if (AreaDropDownList.Items.Count != 0)
                { AreaDropDownList.DataBind(); }

                AreaDropDownList.Items.Insert(0, new ListItem("Seleccione el area", ""));

                if (LocalidadDropDownList.SelectedIndex == 0)
                {
                    AreaDropDownList.Enabled = false;
                    SeccionDropDownList.Enabled = false;
                }
                ComboBoxUpdatePanel2.Update();
            }

            if (LocalidadDropDownList.SelectedIndex == 0)
            {
                AreaDropDownList.Enabled = false;
                SeccionDropDownList.Enabled = false;
                ComboBoxUpdatePanel2.Update();
                MontoPresupuestoLabel.Text = "0.0";
                LabelUpdatePanel.Update();
            }
            CheckUpdatePanel.Update();
        }

        protected void AreaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeccionDropDownList.Enabled = true;
            AreaDropDownList.Enabled = true;
            LocalidadDropDownList.Enabled = true;
            MontoPresupuestoLabel.Text = "0.0";
            LabelUpdatePanel.Update();
            MarcarTodosCheckBox.Checked = false;

            ListaPersonasCapacitarGridView.DataSource = null;
            ListaPersonasCapacitarGridView.DataBind();
            DatosGridView.Update();

            int codigoLocalidad = Convert.ToInt32(LocalidadDropDownList.SelectedValue);

            if (AreaDropDownList.SelectedIndex != 0)
            {
                int codigoArea = Convert.ToInt32(AreaDropDownList.SelectedValue);

                SeccionDropDownList.DataSource = objcapacitar.filtrarSeccionesXAreaLocalidad(codigoArea, codigoLocalidad);

                if (SeccionDropDownList.Items.Count != 0)
                { SeccionDropDownList.DataBind(); }

                SeccionDropDownList.Items.Insert(0, new ListItem("Seleccione la seccion", ""));

                if (AreaDropDownList.SelectedIndex == 0)
                {
                    SeccionDropDownList.Enabled = false;
                }

                ComboBoxUpdatePanel2.Update();
            }

            if (AreaDropDownList.SelectedIndex == 0)
            {
                LocalidadDropDownList.Enabled = true;
                SeccionDropDownList.Enabled = false;
                ComboBoxUpdatePanel2.Update();
                MontoPresupuestoLabel.Text = "0.0";
                LabelUpdatePanel.Update();
            }
            CheckUpdatePanel.Update();
        }

        public void cargarComboBox()
        {
            InstitutoDropDownList.DataSource = objcapacitar.listarInstituciones();
            InstitutoDropDownList.DataTextField = "nombre_institucion";
            InstitutoDropDownList.DataValueField = "id_institucion";
            InstitutoDropDownList.DataBind();
            InstitutoDropDownList.Items.Insert(0, new ListItem("Seleccione la Institucion", ""));

            CursoDropDownList.DataSource = objcapacitar.listarCurso();
            CursoDropDownList.DataTextField = "nombre_curso";
            CursoDropDownList.DataValueField = "id_curso";
            CursoDropDownList.DataBind();
            CursoDropDownList.Items.Insert(0, new ListItem("Seleccione el curso", ""));

            LocalidadDropDownList.DataSource = objcapacitar.listarLocalidades();
            LocalidadDropDownList.DataTextField = "nombre_localidad";
            LocalidadDropDownList.DataValueField = "id_localidad";
            LocalidadDropDownList.DataBind();
            LocalidadDropDownList.Items.Insert(0, new ListItem("Seleccione la localidad", ""));

            AreaDropDownList.DataSource = objcapacitar.listarAreas();
            AreaDropDownList.DataTextField = "nombre_area";
            AreaDropDownList.DataValueField = "id_area";
            AreaDropDownList.DataBind();
            AreaDropDownList.Items.Insert(0, new ListItem("Seleccione el area", ""));

            SeccionDropDownList.DataSource = objcapacitar.listarSecciones();
            SeccionDropDownList.DataTextField = "nombre_seccion";
            SeccionDropDownList.DataValueField = "id_seccion";
            SeccionDropDownList.DataBind();
            SeccionDropDownList.Items.Insert(0, new ListItem("Seleccione la seccion", ""));

        }

        public String cambiarmesydia(String dato)
        {
            String sdato = dato;
            switch (dato)
            {
                case "1":
                    {
                        sdato = "01";
                        break;
                    }

                case "2":
                    {
                        sdato = "02";
                        break;
                    }

                case "3":
                    {
                        sdato = "03";
                        break;
                    }

                case "4":
                    {
                        sdato = "04";
                        break;
                    }

                case "5":
                    {
                        sdato = "05";
                        break;
                    }

                case "6":
                    {
                        sdato = "06";
                        break;
                    }

                case "7":
                    {
                        sdato = "07";
                        break;
                    }

                case "8":
                    {
                        sdato = "08";
                        break;
                    }

                case "9":
                    {
                        sdato = "09";
                        break;
                    }

            }

            return sdato;
        }

        protected void SeccionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeccionDropDownList.Enabled = true;
            AreaDropDownList.Enabled = true;
            MarcarTodosCheckBox.Checked = false;
            LocalidadDropDownList.Enabled = true;
            MontoPresupuestoLabel.Text = "0.0";
            LabelUpdatePanel.Update();

            ListaPersonasCapacitarGridView.DataSource = null;
            ListaPersonasCapacitarGridView.DataBind();
            DatosGridView.Update();

            if (SeccionDropDownList.SelectedIndex != 0)
            {
                        int codigolocalidad = Convert.ToInt32(LocalidadDropDownList.SelectedValue);
                        int codigoarea = Convert.ToInt32(AreaDropDownList.SelectedValue);
                        int codigoseccion = Convert.ToInt32(SeccionDropDownList.SelectedValue);

                        ListaPersonasCapacitarGridView.DataSource = objcapacitar.listarPersona(codigolocalidad, codigoarea, codigoseccion);
                        ListaPersonasCapacitarGridView.DataBind();

                        DatosGridView.Update();
                        CheckUpdatePanel.Update();
                        ComboBoxUpdatePanel2.Update();
                  
            }

            if (SeccionDropDownList.SelectedIndex == 0)
            {
                AreaDropDownList.Enabled = true;
                LocalidadDropDownList.Enabled = true;
                SeccionDropDownList.Enabled = true;
                ComboBoxUpdatePanel2.Update();
                MontoPresupuestoLabel.Text = "0.0";
                LabelUpdatePanel.Update();
            }
        }

        protected void SelectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            contador = 0;
            j = 0.0;
            Control chkSelect = null;
            CURSO curso = new CURSO();
            String tipomoneda = "";

            if (CursoDropDownList.SelectedIndex > 0)
            {
                int codigoCurso = Convert.ToInt32(CursoDropDownList.SelectedValue);
                curso = objcapacitar.obtenerCurso(codigoCurso);
                tipomoneda = curso.tipo_moneda;
            }

            if (CursoDropDownList.SelectedIndex > 0)
            {
                // Select the checkboxes from the GridView control
                for (int i = 0; i < ListaPersonasCapacitarGridView.Rows.Count; i++)
                {
                    GridViewRow row = ListaPersonasCapacitarGridView.Rows[i];
                    bool isChecked = ((CheckBox)row.FindControl("SelectCheckBox")).Checked;

                    chkSelect = ListaPersonasCapacitarGridView.Rows[i].Cells[0].FindControl("SelectCheckBox");

                    if (isChecked)
                    {
                        if (chkSelect != null)
                        {
                            //If CheckBox is checked then get AddressId by using DataKeys
                            // properties of GridView and add AddressId of selected row in List.
                            if (((CheckBox)chkSelect).Checked)
                            {
                                int iAddressId = (int)ListaPersonasCapacitarGridView.DataKeys[i].Value;
                                // Column 2 is the name column
                                //String id = ListaPersonasCapacitarGridView.Rows[i].Cells[0].Text;
                                // ListaPersonasCapacitarGridView.Rows[i].Cells[0].Visible = false;
                                if (CursoDropDownList.SelectedIndex > 0)
                                {
                                    int codigoCurso = Convert.ToInt32(CursoDropDownList.SelectedValue);
                                    curso = objcapacitar.obtenerCurso(codigoCurso);
                                    tipomoneda = curso.tipo_moneda;
                                    j = j + curso.costo_curso;
                                    contador++;
                                }
                            }
                        }
                    }
                }
            }

            if (CursoDropDownList.SelectedIndex == 0)
            {
                MontoPresupuestoLabel.Text = "0.0";
                CursoDropDownList.Enabled = false;
                Session.Add("costocurso", j);
                Session.Add("contador", contador);
                LabelUpdatePanel.Update();
            }

            if (contador < ListaPersonasCapacitarGridView.Rows.Count)
                MarcarTodosCheckBox.Checked = false;

            if (contador == ListaPersonasCapacitarGridView.Rows.Count)
                MarcarTodosCheckBox.Checked = true;

            if (CursoDropDownList.SelectedIndex > 0)
            {
                if (tipomoneda == "S")
                    MontoPresupuestoLabel.Text = "S/. " + j + "";

                if (tipomoneda == "D")
                    MontoPresupuestoLabel.Text = "$ " + j + "";

                Session.Add("costocurso", j);
                Session.Add("contador", contador);
                LabelUpdatePanel.Update();
            }

            SeccionDropDownList.Enabled = true;
            AreaDropDownList.Enabled = true;
            LocalidadDropDownList.Enabled = true;
            CursoDropDownList.Enabled = true;
            InstitutoDropDownList.Enabled = true;
            ComboBoxUpdatePanel1.Update();
            ComboBoxUpdatePanel2.Update();
            DatosGridView.Update();
            CheckUpdatePanel.Update();
            //SelectCheckBox.

        }

        protected void MarcarTodosCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Select the checkboxes from the GridView control
            CURSO curso = new CURSO();
            String tipomoneda = "";
            j = 0.0;
            contador = 0;

            bool valor = MarcarTodosCheckBox.Checked;

            for (int i = 0; i < ListaPersonasCapacitarGridView.Rows.Count; i++)
            {
                GridViewRow row = ListaPersonasCapacitarGridView.Rows[i];
                // bool isChecked = ((CheckBox)row.FindControl("SelectCheckBox")).Checked;

                ((CheckBox)row.FindControl("SelectCheckBox")).Checked = valor;

                if (CursoDropDownList.SelectedIndex > 0)
                {
                    int codigoCurso = Convert.ToInt32(CursoDropDownList.SelectedValue);
                    curso = objcapacitar.obtenerCurso(codigoCurso);
                    tipomoneda = curso.tipo_moneda;
                    j = j + curso.costo_curso;
                    contador++;
                }
            }


            if (CursoDropDownList.SelectedIndex == 0)
            {
                MontoPresupuestoLabel.Text = "0.0";
                Session.Add("costocurso", j);
                Session.Add("contador", contador);
                LabelUpdatePanel.Update();
            }


            if (CursoDropDownList.SelectedIndex > 0)
            {
                if (tipomoneda == "S")
                    MontoPresupuestoLabel.Text = "S/. " + j + "";

                if (tipomoneda == "D")
                    MontoPresupuestoLabel.Text = "$ " + j + "";

                Session.Add("costocurso", j);
                Session.Add("contador", contador);
                LabelUpdatePanel.Update();
            }

            if (MarcarTodosCheckBox.Checked == false)
            {
                if (tipomoneda == "S")
                    MontoPresupuestoLabel.Text = "S/. 0.0";

                if (tipomoneda == "D")
                    MontoPresupuestoLabel.Text = "$ 0.0";
            }

            SeccionDropDownList.Enabled = true;
            AreaDropDownList.Enabled = true;
            LocalidadDropDownList.Enabled = true;
            CursoDropDownList.Enabled = true;
            InstitutoDropDownList.Enabled = true;
            LabelUpdatePanel.Update();
            ComboBoxUpdatePanel1.Update();
            ComboBoxUpdatePanel2.Update();
            CheckUpdatePanel.Update();
            DatosGridView.Update();

        }

        protected void GuardarButton1_Click(object sender, EventArgs e)
        {
            Control chkSelect = null;
            Boolean marcado = false;
            for (int i = 0; i < ListaPersonasCapacitarGridView.Rows.Count; i++)
            {
                GridViewRow row = ListaPersonasCapacitarGridView.Rows[i];
                bool isChecked = ((CheckBox)row.FindControl("SelectCheckBox")).Checked;

                chkSelect = ListaPersonasCapacitarGridView.Rows[i].Cells[0].FindControl("SelectCheckBox");

                if (isChecked)
                {
                    if (chkSelect != null)
                    {
                        if (((CheckBox)chkSelect).Checked)
                        {
                            if (CursoDropDownList.SelectedIndex > 0)
                            {
                                marcado = true;
                            }
                        }
                    }
                }
            }

            if (InstitutoDropDownList.SelectedIndex == 0 || CursoDropDownList.SelectedIndex == 0 || LocalidadDropDownList.SelectedIndex == 0 ||
                  AreaDropDownList.SelectedIndex == 0 || SeccionDropDownList.SelectedIndex == 0 || marcado == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "MostrarMensaje('Datos incompletos. Llene todos los campos para poder actualizar el presupuesto')", true);
            }
            if (InstitutoDropDownList.SelectedIndex > 0 && CursoDropDownList.SelectedIndex > 0 && LocalidadDropDownList.SelectedIndex > 0 &&
              AreaDropDownList.SelectedIndex > 0 && SeccionDropDownList.SelectedIndex > 0 && marcado == true)
            {
                ActualizarDatos();
                PRESUPUESTO_CAPACITACION objpresupuesto = new PRESUPUESTO_CAPACITACION();
                int iIdcapacitacion = Convert.ToInt32(Session["IdCapacitacion"].ToString());
                objpresupuesto = objcapacitar.ObtenerPresupuestoCapacitacion(iIdcapacitacion);
                String mensaje = objpresupuesto.codigo_presupuesto;
                hdnSession.Value = mensaje;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarMensajeFinal()", true);
                // this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
            }

            ComboBoxUpdatePanel1.Update();
            DatosGridView.Update();
            LabelUpdatePanel.Update();
            ComboBoxUpdatePanel2.Update();
            CheckUpdatePanel.Update();
            FechaUpdatePanel.Update();
            BuscarUpdatePanel.Update();

        }

        public void ActualizarDatos()
        {
            Control chkSelect = null;
            CURSO curso = new CURSO();
            iIdCapacitacion = Convert.ToInt32(Session["IdCapacitacion"].ToString());

            if (CursoDropDownList.SelectedIndex > 0 && SeccionDropDownList.SelectedIndex > 0)
            {
                PRESUPUESTO_CAPACITACION objpresupuesto = new PRESUPUESTO_CAPACITACION();
                PRESUPUESTO_CAPACITACION_POR_PERSONAL objpresupuestopersona = null;

                String scosto = Session["costocurso"].ToString();
                String scontador = Session["contador"].ToString();

                objpresupuesto.id_curso = Convert.ToInt32(CursoDropDownList.SelectedValue);
                objpresupuesto.monto_total = Convert.ToDouble(scosto);
                objpresupuesto.id_presupuesto_capacitacion = iIdCapacitacion;
                objpresupuesto.cantidad_personas = Convert.ToInt32(scontador);
                objpresupuesto.id_seccion = Convert.ToInt32(SeccionDropDownList.SelectedValue);
                objpresupuesto.id_localidad = Convert.ToInt32(LocalidadDropDownList.SelectedValue);

                objcapacitar.ActualizarCapacitacionProyectadaDatos(objpresupuesto);

                objpresupuestopersona = new PRESUPUESTO_CAPACITACION_POR_PERSONAL();
                objpresupuestopersona.id_presupuesto_capacitacion = iIdCapacitacion;

                objcapacitar.EliminarCapacitacionProyectadaxPersona(objpresupuestopersona);

                AUDITORIA_PRESUPUESTO objauditoria = new AUDITORIA_PRESUPUESTO();

                objauditoria.id_capacitacion_proyectada = iIdCapacitacion;
                objauditoria.id_personal_proyectado = 0;
                objauditoria.fecha_accion = DateTime.Now;
                objauditoria.tipo_accion = "A";
                objauditoria.id_actividad_proyectada = 0;
                objauditoria.tipo_presupuesto = "C";
                objauditoria.descripcion_auditoria = "";

                objcapacitar.RegistrarAuditoriaPresupuesto(objauditoria);


                int codigoCurso = Convert.ToInt32(CursoDropDownList.SelectedValue);
                curso = objcapacitar.obtenerCurso(codigoCurso);

                for (int i = 0; i < ListaPersonasCapacitarGridView.Rows.Count; i++)
                {
                    GridViewRow row = ListaPersonasCapacitarGridView.Rows[i];
                    bool isChecked = ((CheckBox)row.FindControl("SelectCheckBox")).Checked;

                    chkSelect = ListaPersonasCapacitarGridView.Rows[i].Cells[0].FindControl("SelectCheckBox");

                    if (isChecked)
                    {
                        if (chkSelect != null)
                        {
                            if (((CheckBox)chkSelect).Checked)
                            {
                                if (CursoDropDownList.SelectedIndex > 0)
                                {
                                    int codigopersona = (int)ListaPersonasCapacitarGridView.DataKeys[i].Value;
                                    objpresupuestopersona = new PRESUPUESTO_CAPACITACION_POR_PERSONAL();
                                    objpresupuestopersona.id_presupuesto_capacitacion = iIdCapacitacion;
                                    objpresupuestopersona.monto_presupuesto_proyectado = curso.costo_curso;
                                    objpresupuestopersona.id_persona = codigopersona;
                                    objcapacitar.insertarcapacitacionProyectadaxPersona(objpresupuestopersona);
                                }
                            }
                        }
                    }
                }

            }

            SeccionDropDownList.Enabled = true;
            AreaDropDownList.Enabled = true;
            LocalidadDropDownList.Enabled = true;
            CursoDropDownList.Enabled = true;
            InstitutoDropDownList.Enabled = true;

            /*InstitutoDropDownList.SelectedIndex = 0;
            SeccionDropDownList.SelectedIndex = 0;
            AreaDropDownList.SelectedIndex = 0;
            LocalidadDropDownList.SelectedIndex = 0;
            CursoDropDownList.SelectedIndex = 0;

            CursoDropDownList.Enabled = false;
            SeccionDropDownList.Enabled = false;
            AreaDropDownList.Enabled = false;

            MarcarTodosCheckBox.Checked = false;
            MontoPresupuestoLabel.Text = "0.0";

            ListaPersonasCapacitarGridView.DataSource = null;
            ListaPersonasCapacitarGridView.DataBind();*/

            ComboBoxUpdatePanel1.Update();
            DatosGridView.Update();
            LabelUpdatePanel.Update();
            ComboBoxUpdatePanel2.Update();
            CheckUpdatePanel.Update();
        }
    }
}