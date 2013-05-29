<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="RegistrarPresupuestoPersonalProyectado.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.RegistrarPresupuestoPersonalProyectado" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
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

                            PageMethods.confirmarActualizacion(codigoLocalidad, codigoArea, codigoSeccion, codigoCargo, identificador, cargo, codigoTipoPersonal, costoEmpresaEmpleadoHidden, costoEmpresaObreroHidden, id_persona, confirmarActualizacion);
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
               fontSize: 15
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
  
  
  
  
  
  
  <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" 
    EnablePartialRendering="true">  
    
    </asp:ScriptManager> 

    <asp:Label ID="Label1" runat="server" Text="Informacion de personal a proyectar"></asp:Label>
    
     <asp:UpdatePanel ID="ComboBoxUpdatePanel" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate>   
    
        <div runat=server id="identificadorDiv" visible=false>
            <asp:Label ID="Label2" runat="server" Text="Identificador : " style="padding-left: 32px"></asp:Label>
            <asp:TextBox ID="identificadorTextBox" runat="server" Height="20px" Width="130px" ></asp:TextBox>
        </div>

            
            <asp:Label ID="Label3" runat="server" Text="Tipo de personal : " style="padding-left: 1px"></asp:Label>
            <asp:DropDownList ID="TipoPersonalComboBox" runat="server" 
                                AutoPostBack="True" Height="20px" Width="130px" >
                                <asp:ListItem Value="" > Seleccione el tipo de personal </asp:ListItem>
                                <asp:ListItem Value="1"  Text="Empleado"> </asp:ListItem>
                                <asp:ListItem Value="2"  Text="Obrero"> </asp:ListItem>
                                </asp:DropDownList>
                    
                   <br />
                        <asp:Label ID="Label4" runat="server" Text="Localidad : " style="padding-left: 48px"></asp:Label>
                        <asp:DropDownList ID="LocalidadComboBox" runat="server" 
                                onselectedindexchanged="LocalidadComboBox_SelectedIndexChanged"  
                                AutoPostBack="True" Height="20px" Width="130px" ></asp:DropDownList>
                    <br />
                           <asp:Label ID="Label5" runat="server" Text="Area : " style="padding-left: 82px"></asp:Label>
                           <asp:DropDownList ID="AreaComboBox" runat="server" 
                                    onselectedindexchanged="AreaComboBox_SelectedIndexChanged" AutoPostBack="True"
                                    Height="20px" Width="130px" Enabled=false></asp:DropDownList>
                       
                   
                    <br />
                     
                         <asp:Label ID="Label6" runat="server" Text="Seccion : " style="padding-left: 58px"></asp:Label>
                        <asp:DropDownList ID="SeccionComboBox" runat="server" 
                                onselectedindexchanged="SeccionComboBox_SelectedIndexChanged" 
                                AutoPostBack="True" Height="20px" Width="130px" Enabled=false></asp:DropDownList> <br />
                     
                    
                     <asp:Label ID="Label7" runat="server" Text="Cargo : " style="padding-left: 71px"></asp:Label>
                        <asp:DropDownList ID="CargoComboBox" runat="server" AutoPostBack="True"
                            Height="20px" Width="130px" Enabled=false 
                                onselectedindexchanged="CargoComboBox_SelectedIndexChanged"></asp:DropDownList>
                   

            <div runat="server" id="cantidadDiv" >  
                 <asp:Label ID="Label8" runat="server" Text="Cantidad : " style="padding-left: 51px"></asp:Label>
                <asp:TextBox ID="CantidadTextBox" runat="server" Height="20px" Width="130px" onkeypress='return validateNumerosEnteros(event)' ></asp:TextBox>           
             </div>
             <br />
                <asp:Label ID="Label9" runat="server" Text="Conceptos : " style="padding-left: 38px"></asp:Label>
               <asp:Button ID="AgregarConceptosButton" runat="server" Text="+" 
                                 OnClientClick=" mostrarAspxAsPopUp()"
                                  />  
                    
                <div runat=server id="registrarButton">
               

                           <button id="opener" onclick="return opener_onclick()" >Registrar</button>          
                       

                </div>

                <div runat=server id="guardarButton" visible="false" >
                
                           <button id="openerGuardar" onclick="return openerGuardar_onclick()">Guardar</button>          
                       
                       <br />
                       <br />
                            <asp:Button ID="volverButton" runat="server" Text="Volver" 
                                onclick="volverButton_Click" />
                        
                </div>
  </ContentTemplate> 
  </asp:UpdatePanel>

  

  <input type="hidden" name="nuevo" id="nuevo" runat="server" />
 <input type="hidden" name="nroConceptos" id="nroConceptos" runat="server" />
 <input type="hidden"   id="conceptosHidden" runat="server" />

 <input type="hidden" name="costoEmpresaEmpleadoHidden" id="costoEmpresaEmpleadoHidden" runat="server" />
 <input type="hidden" name="costoEmpresaObreroHidden" id="costoEmpresaObreroHidden" runat="server" />
 <input type="hidden" name="modoHidden" id="modoHidden" runat="server" />
 <input type="hidden" name="codigoEditarHidden" id="codigoEditarHidden" runat="server" />

 

 
 

</asp:Content>
