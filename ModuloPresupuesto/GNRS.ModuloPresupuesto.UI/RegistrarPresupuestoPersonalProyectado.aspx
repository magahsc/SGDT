<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="RegistrarPresupuestoPersonalProyectado.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.RegistrarPresupuestoPersonalProyectado" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server" >
  <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
 
    
    <script>
        function pageLoad() {
            $(function () {
                $("#dialog-form").dialog({
                    autoOpen: false,
                    height: 200,
                    width: 450,
                    modal: true,
                    buttons: {
                        "Aceptar": function () {
                            var codigoLocalidad = document.getElementById("contenido_LocalidadComboBox").value;
                            var codigoArea = document.getElementById("contenido_AreaComboBox").value;
                            var codigoSeccion = document.getElementById("contenido_SeccionComboBox").value;
                            var codigoCargo = document.getElementById("contenido_CargoComboBox").value;

                            var cantidad = document.getElementById("contenido_CantidadTextBox").value;
                            var CargoDDL = document.getElementById("contenido_CargoComboBox");
                            var cargo = CargoDDL.options[CargoDDL.selectedIndex].text;

                            var codigoTipoPersonal = document.getElementById("contenido_TipoPersonalComboBox").value;
                            var costoEmpresaEmpleadoHidden = document.getElementById("contenido_costoEmpresaEmpleadoHidden").value;
                            var costoEmpresaObreroHidden = document.getElementById("contenido_costoEmpresaObreroHidden").value;


                            PageMethods.confirmarRegistro(codigoLocalidad, codigoArea, codigoSeccion, codigoCargo, cantidad, cargo, codigoTipoPersonal, costoEmpresaEmpleadoHidden, costoEmpresaObreroHidden, confirmarRegistro);
                            $(this).dialog("close");
                        },
                        Cancel: function () {
                            $(this).dialog("close");
                        }
                    }
                });

                $("#dialog-form").css({
                    fontSize: 15
                });


                $("#dialog-form2").dialog({
                    autoOpen: false,
                    height: 200,
                    width: 450,
                    modal: true,
                    buttons: {
                        "Aceptar": function () {
                            var codigoLocalidad = document.getElementById("contenido_LocalidadComboBox").value;
                            var codigoArea = document.getElementById("contenido_AreaComboBox").value;
                            var codigoSeccion = document.getElementById("contenido_SeccionComboBox").value;
                            var codigoCargo = document.getElementById("contenido_CargoComboBox").value;


                            var CargoDDL = document.getElementById("contenido_CargoComboBox");
                            var cargo = CargoDDL.options[CargoDDL.selectedIndex].text;

                            var codigoTipoPersonal = document.getElementById("contenido_TipoPersonalComboBox").value;
                            var costoEmpresaEmpleadoHidden = document.getElementById("contenido_costoEmpresaEmpleadoHidden").value;
                            var costoEmpresaObreroHidden = document.getElementById("contenido_costoEmpresaObreroHidden").value;

                            var identificador = document.getElementById("contenido_identificadorTextBox").value;
                            var id_persona = document.getElementById("contenido_codigoEditarHidden").value;
                            PageMethods.confirmarActualizacion(codigoLocalidad, codigoArea, codigoSeccion, codigoCargo, identificador, cargo, codigoTipoPersonal, costoEmpresaEmpleadoHidden, costoEmpresaObreroHidden, id_persona);
                            confirmarActualizacion("aa");
                            $(this).dialog("close");
                        },
                        Cancel: function () {
                            $(this).dialog("close");
                        }
                    }
                });

                $("#dialog-form2").css({
                    fontSize: 15
                });



                $("#opener").click(function () {
                    var cantidadPersonales = document.getElementById("contenido_CantidadTextBox").value;
                    var cantidadConceptos = document.getElementById("contenido_nroConceptos").value;


                    var tipoPersonal = document.getElementById("contenido_TipoPersonalComboBox").value;
                    var codigoLocalidad = document.getElementById("contenido_LocalidadComboBox").value;
                    var codigoArea = document.getElementById("contenido_AreaComboBox").value;
                    var codigoSeccion = document.getElementById("contenido_SeccionComboBox").value;
                    var codigoCargo = document.getElementById("contenido_CargoComboBox").value;

                    if (cantidadConceptos == "0" || codigoCargo == "" || cantidadPersonales == "" || tipoPersonal == ""
                    || codigoLocalidad == "" || codigoArea == "" || codigoSeccion == "" || codigoCargo == "") {
                        $("#dialog-error").text("Datos incompletos. Llene todos los campos para poder registrar el presupuesto de personal proyectado").dialog("open");
                    }
                    else {
                        $("#dialog-form").dialog("open");
                    }
                });




                $("#openerGuardar").click(function () {

                    var identificador = document.getElementById("contenido_identificadorTextBox").value;
                    var cantidadConceptos = document.getElementById("contenido_nroConceptos").value;

                    var tipoPersonal = document.getElementById("contenido_TipoPersonalComboBox").value;
                    var codigoLocalidad = document.getElementById("contenido_LocalidadComboBox").value;
                    var codigoArea = document.getElementById("contenido_AreaComboBox").value;
                    var codigoSeccion = document.getElementById("contenido_SeccionComboBox").value;
                    var codigoCargo = document.getElementById("contenido_CargoComboBox").value;
                    if (cantidadConceptos == "0" || codigoCargo == "" || identificador == "" || tipoPersonal == ""
                    || codigoLocalidad == "" || codigoArea == "" || codigoSeccion == "" || codigoCargo == "") {
                        $("#dialog-error").text("Datos incompletos. Llene todos los campos para poder registrar el presupuesto de personal proyectado").dialog("open");
                    }
                    else {
                        $("#dialog-form2").dialog("open");
                    }
                });



                $("#dialog-message").dialog({
                    modal: true,
                    autoOpen: false,
                    height: 200,
                    width: 500,
                    buttons: {
                        Ok: function () {
                            document.getElementById("contenido_CantidadTextBox").value = '';

                            document.getElementById("contenido_TipoPersonalComboBox").selectedIndex = 0;


                            document.getElementById("contenido_LocalidadComboBox").selectedIndex = 0;
                            document.getElementById("contenido_SeccionComboBox").selectedIndex = 0;
                            document.getElementById("contenido_SeccionComboBox").disabled = true;
                            document.getElementById("contenido_AreaComboBox").selectedIndex = 0;
                            document.getElementById("contenido_AreaComboBox").disabled = true;
                            document.getElementById("contenido_CargoComboBox").selectedIndex = 0;
                            document.getElementById("contenido_CargoComboBox").disabled = true;
                            document.getElementById("contenido_AgregarConceptosButton").disabled = true;
                            document.getElementById("contenido_nuevo").value = "si";


                            $(this).dialog("close");

                        }
                    }
                });
                $("#dialog-message").css({
                    fontSize: 15
                });


                $("#dialog-message2").dialog({
                    modal: true,
                    autoOpen: false,
                    height: 200,
                    width: 500,
                    buttons: {
                        Ok: function () {

                            $(this).dialog("close");

                        }
                    }
                });
                $("#dialog-message2").css({
                    fontSize: 15
                });



            });



        }

        
  </script>
  <script>
      function confirmarRegistro(message) {

          if (message != "") {
              var texto = "El personal proyectado se ha guardado exitosamente";

              $("#dialog-message").text(texto).dialog("open");
          }

      }

      function confirmarActualizacion(message) {

          if (message != "") {
              var texto = "El personal proyectado se ha actualizado exitosamente";

              $("#dialog-message2").text(texto).dialog("open");
          }

      }
  </script>

   <script>
       $(function () {
           $("#dialog-error").dialog({
               modal: true,
               autoOpen: false,
               height: 200,
               width: 500,
               buttons: {
                   Ok: function () {
                       $(this).dialog("close");
                   }
               }
           });
           $("#dialog-error").css({
               fontSize: 12
           });

       });
  </script>

  <script>
      function validateNumerosEnteros(evt) {
          var charCode = (evt.which) ? evt.which : event.keyCode;


          if (charCode > 31 && (charCode < 48 || charCode > 57))
              return false;
          return true;
      }

      function mostrarAspxAsPopUp() {

          var strReturn = window.showModalDialog('ConceptosPersonal.aspx', null, 'status:no;dialogWidth:600px;dialogHeight:300px;dialogHide:true;help:no;scroll:yes');

          document.getElementById("contenido_nroConceptos").value = strReturn.valor;
          document.getElementById("contenido_conceptosHidden").value = strReturn.elementos;


      }
  </script>

 
  <div id="dialog-form" title="Módulo de Presupuesto">
  <p><span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>¿Desea guardar el personal proyectado?</p>
  </div>

  <div id="dialog-form2" title="Módulo de Presupuesto">
  <p><span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>¿Desea actualizar el personaje proyectado?</p>
  </div>


  <div id="dialog-message" title="Módulo de Presupuesto">  </div>
  <div id="dialog-message2" title="Módulo de Presupuesto">  </div>

  <div id="dialog-error" title="Módulo de Presupuesto">  </div>
    
  <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true">     
  </asp:ScriptManager> 
  <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" CssClass="panel" >  
    
        <asp:Label ID="Label1" runat="server" CssClass="texto" Font-Size="11pt" Text="Ingresar la informaci&oacute;n del personal a registrar"></asp:Label>
        <br /><br />
        <asp:UpdatePanel ID="ComboBoxUpdatePanel" runat="server" UpdateMode="Conditional" > 
                 <ContentTemplate>   
  
                    <table style="padding-left:20px;"  class="texto" align="center" >
                        <tr id="rowidentificador" runat="server" visible="false">
                            <td>Identificador</td>
                            <td>:</td>
                            <td style="width:130px"><asp:TextBox ID="identificadorTextBox"  runat="server" Width="100%"></asp:TextBox></td>
                        </tr>
                        
                        <tr>
                            <td>Categor&iacute;a de personal</td>
                            <td>:</td>
                            <td style="width:130px">            
                                <asp:DropDownList ID="TipoPersonalComboBox" runat="server" AutoPostBack="True" >
                                            <asp:ListItem Value="" > Seleccione la categor&iacute;a </asp:ListItem>
                                            <asp:ListItem Value="1"  Text="Empleado"> </asp:ListItem>
                                            <asp:ListItem Value="2"  Text="Obrero"> </asp:ListItem>
                                 </asp:DropDownList>
                             </td>
                        </tr>
                        <tr>
                            <td>Localidad</td>
                            <td>:</td>
                            <td >                        
                                 <asp:DropDownList ID="LocalidadComboBox" runat="server" onselectedindexchanged="LocalidadComboBox_SelectedIndexChanged" AutoPostBack="True" Width="100%">
                                 </asp:DropDownList>
                             </td>
                        </tr>
                        <tr>
                            <td>&Aacute;rea</td>
                            <td>:</td>
                            <td >
                                <asp:DropDownList ID="AreaComboBox" runat="server" onselectedindexchanged="AreaComboBox_SelectedIndexChanged" AutoPostBack="True" Enabled="false" Width="100%"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Secci&oacute;n</td>
                            <td>:</td>
                            <td >
                                <asp:DropDownList ID="SeccionComboBox" runat="server" onselectedindexchanged="SeccionComboBox_SelectedIndexChanged" AutoPostBack="True" Enabled="false" Width="100%"></asp:DropDownList>
                            </td>
                        </tr>    
                        <tr>
                            <td>Cargo</td>
                            <td>:</td>
                            <td >
                                <asp:DropDownList ID="CargoComboBox" runat="server" AutoPostBack="True" Enabled="false" onselectedindexchanged="CargoComboBox_SelectedIndexChanged" Width="100%"></asp:DropDownList>
                            </td>
                        </tr> 
                        <tr id="rowCantidad" runat="server">
                            <td>Cantidad</td>
                            <td>:</td>
                            <td >
                                <asp:TextBox ID="CantidadTextBox" runat="server" onkeypress='return validateNumerosEnteros(event)' Width="25%"></asp:TextBox>
                            </td>
                        </tr>              
                        <tr>
                            <td>Conceptos</td>
                            <td>:</td>
                            <td >
                                <asp:Button ID="AgregarConceptosButton" runat="server" Text="+" OnClientClick=" mostrarAspxAsPopUp()" />  
                            </td>
                        </tr>




                    </table>           
                    <div runat="server" id="registrarButton" align="center" style="widht:100px">
                                <button id="opener" class="button_example" onclick="return opener_onclick()" >Guardar</button>          
                    </div>

                    <div runat="server" id="guardarButton" visible="false" align="center" style="widht:100px">
                
                                <button id="openerGuardar" class="button_example" onclick="return openerGuardar_onclick()">Guardar</button>          
                       
                            <br />
                            <br />
                            <div align="right">
                                <asp:Button ID="volverButton" runat="server" Text="Volver" CssClass="button_example"  onclick="volverButton_Click" />
                            </div>
                    </div>
                    </ContentTemplate> 

        </asp:UpdatePanel>
    </asp:Panel>


  

  <input type="hidden" name="nuevo" id="nuevo" runat="server" />
 <input type="hidden" name="nroConceptos" id="nroConceptos" runat="server" />
 <input type="hidden"   id="conceptosHidden" runat="server" />

 <input type="hidden" name="costoEmpresaEmpleadoHidden" id="costoEmpresaEmpleadoHidden" runat="server" />
 <input type="hidden" name="costoEmpresaObreroHidden" id="costoEmpresaObreroHidden" runat="server" />
 <input type="hidden" name="modoHidden" id="modoHidden" runat="server" />
 <input type="hidden" name="codigoEditarHidden" id="codigoEditarHidden" runat="server" />

 

 
 

</asp:Content>
