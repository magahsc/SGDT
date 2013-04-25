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
    public partial class RegistrarPresupuestoCapacitacion : System.Web.UI.Page
    {
        CapacitarProyectadoBC objcapacitar = new CapacitarProyectadoBC();
        public double j ;
        public int contador;

        protected void Page_Load(object sender, EventArgs e)
        {
            CursoDropDownList.Enabled = false;
            AreaDropDownList.Enabled = false;
            SeccionDropDownList.Enabled = false;

            DateTime date = DateTime.Now;
           // String hola = Session.

            if (!IsPostBack)
            {
                cargarComboBox();
                if (Session["mes"] == null || 
                    Session["dia"]== null || 
                    Session["anio"] == null)
                {
                   /* Session.Add("dia", "01");
                    Session.Add("mes", date.Month);
                    Session.Add("anio", date.Year);
                    * */
                    Session.Add("Mensaje", "1");
                    Server.Transfer("MainPage.aspx");
                    //alert("Debe configurar el mes y el año para poder realizar un registro de capacitación");
                }



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

            int codigoinstituto = Convert.ToInt32(InstitutoDropDownList.SelectedValue);

            CursoDropDownList.DataSource = objcapacitar.listarCursoxInsituciones(codigoinstituto);
            CursoDropDownList.DataBind();
            CursoDropDownList.Items.Insert(0, new ListItem("Seleccione el curso", ""));

            if (InstitutoDropDownList.SelectedIndex == 0)
            {
                CursoDropDownList.Enabled = false;
            }

            ComboBoxUpdatePanel1.Update();
        }

        protected void CursoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            InstitutoDropDownList.Enabled = true;
            CursoDropDownList.Enabled = true;
            MarcarTodosCheckBox.Checked = false;
            ComboBoxUpdatePanel1.Update();
        }

        protected void LocalidadDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaDropDownList.Enabled = true;
            LocalidadDropDownList.Enabled = true;
            SeccionDropDownList.Enabled = false;
            MontoPresupuestoLabel.Text = "0.0";
            MarcarTodosCheckBox.Checked = false;

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

        protected void AreaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeccionDropDownList.Enabled = true;
            AreaDropDownList.Enabled = true;
            LocalidadDropDownList.Enabled = true;
            MontoPresupuestoLabel.Text = "0.0";
            MarcarTodosCheckBox.Checked = false;

            int codigoLocalidad = Convert.ToInt32(LocalidadDropDownList.SelectedValue);
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

            if (CursoDropDownList.SelectedIndex > 0)
            {
                int codigoCurso = Convert.ToInt32(CursoDropDownList.SelectedValue);
                CURSO curso = new CURSO();
                curso = objcapacitar.obtenerCurso(codigoCurso);

                String smes = Session["mes"].ToString();
                smes = cambiarmesydia(smes);
                String sanio = Session["anio"].ToString();
                String sdia = Session["dia"].ToString();
                sdia = cambiarmesydia(sdia);

                String cadenafecha = sanio + "-" + smes + "-" + sdia;
                DateTime myDate,myDate2;
                myDate = DateTime.ParseExact(cadenafecha, "yyyy-MM-dd", CultureInfo.InvariantCulture);


                int aniofinal = Convert.ToInt32(sanio) + 1;
                String saniofinal = aniofinal + "";
                String cadenafecha2 = aniofinal + "-" + smes + "-" + sdia;
                myDate2 = DateTime.ParseExact(cadenafecha2, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                int aniomydate = Convert.ToInt32(myDate.Year);
                int aniocurso = Convert.ToInt32(curso.fecha_inicio.Year);

                if ((DateTime.Compare(myDate, curso.fecha_inicio) < 0) && (DateTime.Compare(myDate2, curso.fecha_fin) > 0) && aniocurso == aniomydate)
                {
                    int codigolocalidad = Convert.ToInt32(LocalidadDropDownList.SelectedValue);
                    int codigoarea = Convert.ToInt32(AreaDropDownList.SelectedValue);
                    int codigoseccion = Convert.ToInt32(SeccionDropDownList.SelectedValue);

                    ListaPersonasCapacitarGridView.DataSource = objcapacitar.listarPersona(codigolocalidad, codigoarea, codigoseccion);
                    ListaPersonasCapacitarGridView.DataBind();

                    DatosGridView.Update();
                    ComboBoxUpdatePanel2.Update();
                }
            }

        }

        protected void SelectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            contador = 0;
            j = 0.0;
            Control chkSelect = null;
            CURSO curso = new CURSO();
            String tipomoneda ="";

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

            if (CursoDropDownList.SelectedIndex == 0)
            {
                MontoPresupuestoLabel.Text = "0.0";
                alert("Debe seleccionar un curso si desea ver el monto presupuestado");
                Session.Add("costocurso", j);
                Session.Add("contador", contador);
                LabelUpdatePanel.Update();
            }
            


            if (CursoDropDownList.SelectedIndex > 0)
            {
                if(tipomoneda == "S")
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

        }

        protected void MarcarTodosCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Select the checkboxes from the GridView control

            bool valor = MarcarTodosCheckBox.Checked;

            for (int i = 0; i < ListaPersonasCapacitarGridView.Rows.Count; i++)
            {
                GridViewRow row = ListaPersonasCapacitarGridView.Rows[i];
               // bool isChecked = ((CheckBox)row.FindControl("SelectCheckBox")).Checked;

                ((CheckBox)row.FindControl("SelectCheckBox")).Checked = valor;
            }
            DatosGridView.Update();
            
        }

        protected void GuardarButton1_Click(object sender, EventArgs e)
        {
            Control chkSelect = null;
            CURSO curso = new CURSO();
            String scodigoalert = "";

            if (CursoDropDownList.SelectedIndex > 0 && SeccionDropDownList.SelectedIndex > 0)
            {
                PRESUPUESTO_CAPACITACION objpresupuesto = new PRESUPUESTO_CAPACITACION();
                PRESUPUESTO_CAPACITACION_POR_PERSONAL objpresupuestopersona = new PRESUPUESTO_CAPACITACION_POR_PERSONAL();
                String smes = Session["mes"].ToString();
                smes = cambiarmesydia(smes);
                String sanio = Session["anio"].ToString();
                String sdia = Session["dia"].ToString();
                sdia = cambiarmesydia(sdia);

                String scosto = Session["costocurso"].ToString();
                String scontador = Session["contador"].ToString();

                String cadenafecha = sanio + "-" + smes + "-" + sdia;
                DateTime myDate;
                myDate = DateTime.ParseExact(cadenafecha, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                objpresupuesto.id_curso = Convert.ToInt32(CursoDropDownList.SelectedValue);
                objpresupuesto.monto_total = Convert.ToDouble(scosto);
                objpresupuesto.codigo_presupuesto = "";
                objpresupuesto.cantidad_personas = Convert.ToInt32(scontador);
                objpresupuesto.presupuesto_aprobado = "P";
                objpresupuesto.fecha_creacion = myDate;
                objpresupuesto.id_seccion = Convert.ToInt32(SeccionDropDownList.SelectedValue);
                objpresupuesto.id_localidad = Convert.ToInt32(LocalidadDropDownList.SelectedValue);
                objpresupuesto.id_periodo_presupuesto = 0;
                int codigoCapacitacion = objcapacitar.insertarcapacitacionProyectada(objpresupuesto);

                objpresupuesto.id_presupuesto_capacitacion = codigoCapacitacion;
                sanio = sanio.Substring(2,2);
                scodigoalert = sdia + "" + smes + "" + sanio + "" + codigoCapacitacion;
                objpresupuesto.codigo_presupuesto = sdia + "" + smes + "" + sanio + ""  + codigoCapacitacion;
                objcapacitar.ActualizarcapacitacionProyectada(objpresupuesto);
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
                                    objpresupuestopersona.id_presupuesto_capacitacion = codigoCapacitacion;
                                    objpresupuestopersona.monto_presupuesto_proyectado = curso.costo_curso;
                                    objpresupuestopersona.id_persona = codigopersona;
                                    objcapacitar.insertarcapacitacionProyectadaxPersona(objpresupuestopersona);
                                }
                            }
                        }
                    }
                }

                alert("El presupuesto de capacitacíon proyectada " + scodigoalert + " ha sido guardado existosamente");

            }

            SeccionDropDownList.Enabled = true;
            AreaDropDownList.Enabled = true;
            LocalidadDropDownList.Enabled = true;
            CursoDropDownList.Enabled = true;
            InstitutoDropDownList.Enabled = true;

            InstitutoDropDownList.SelectedIndex = 0;
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
            ListaPersonasCapacitarGridView.DataBind();

            ComboBoxUpdatePanel1.Update();
            DatosGridView.Update();
            LabelUpdatePanel.Update();
            ComboBoxUpdatePanel2.Update();

            

        }

        public void alert(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

    }
}