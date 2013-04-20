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
                    width: 350,
                    modal: true,
                    buttons: {
                        "Aceptar": function () {
                            var codigoLocalidad = document.getElementById("contenido_LocalidadComboBox").value;
                            var codigoArea = document.getElementById("contenido_AreaComboBox").value;
                            var codigoSeccion = document.getElementById("contenido_SeccionComboBox").value;
                            var codigoCargo = document.getElementById("contenido_CargoComboBox").value;
                            var cantidad = document.getElementById("contenido_CantidadTextBox").value;

                            PageMethods.confirmarRegistro(codigoLocalidad, codigoArea, codigoSeccion, codigoCargo, cantidad, confirmarRegistro);
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
          

                $("#opener").click(function () {
                    $("#dialog-form").dialog("open");
                });

                
            });


        }

        
  </script>
  <script>
      function confirmarRegistro(message) {
       
       if (message != "") {
           var texto = "El personal proyectado ha sido guardado exitosamente";
           $("#dialog-message").text(texto).dialog("open");
       } else {
           $("#dialog-error").text("Debe ingresar todos los campos solicitados.").dialog("open");
       }
         
      }
  </script>
  <script>
      $(function () {
          $("#dialog-message").dialog({
              modal: true,
              autoOpen: false,
              height: 200,
              width: 500,
              buttons: {
                  Ok: function () {
                      document.getElementById("contenido_CantidadTextBox").value = '';

                      document.getElementById("contenido_LocalidadComboBox").selectedIndex = 0;                    
                      document.getElementById("contenido_SeccionComboBox").selectedIndex = 0;
                      document.getElementById("contenido_SeccionComboBox").disabled = true;
                      document.getElementById("contenido_AreaComboBox").selectedIndex = 0;
                      document.getElementById("contenido_AreaComboBox").disabled = true;
                      document.getElementById("contenido_CargoComboBox").selectedIndex = 0;
                      document.getElementById("contenido_CargoComboBox").disabled = true;
                      $(this).dialog("close");

                  }
              }
          });
          $("#dialog-message").css({
              fontSize: 15
          });
          
      });
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
      function validate(evt) {
          var theEvent = evt || window.event;
          var key = theEvent.keyCode || theEvent.which;
          key = String.fromCharCode(key);
          var regex = /[0-9]|\./;
          if (!regex.test(key)) {
              theEvent.returnValue = false;
              if (theEvent.preventDefault) theEvent.preventDefault();
          }
      }
      function opener_onclick() {

      }

  </script>
  <div id="dialog-form" title="Confirmacion de registro">
  <p><span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>¿Desea guardar el personal?</p>
  </div>

  <div id="dialog-message" title="Confirmacion de registro">  </div>
  <div id="dialog-error" title="Error">  </div>
  
  
  
  
  
  
  <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" 
    EnablePartialRendering="true">  
    
    </asp:ScriptManager> 

    <asp:Label ID="Label1" runat="server" Text="Informacion de personal a proyectar"></asp:Label>
    
     <asp:UpdatePanel ID="ComboBoxUpdatePanel" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate>   
            <Table ID="Table1" runat="server" >
                 <tbody>
                    <tr >
                        <td align="right" >Localidad:</td>
                        <td><asp:DropDownList ID="LocalidadComboBox" runat="server" 
                                onselectedindexchanged="LocalidadComboBox_SelectedIndexChanged"  
                                AutoPostBack="True" Height="20px" Width="130px" ></asp:DropDownList></td>
                    </tr>

                      
                        <tr>
                            <td align="right">Area:</td>
                            <td><asp:DropDownList ID="AreaComboBox" runat="server" 
                                    onselectedindexchanged="AreaComboBox_SelectedIndexChanged" AutoPostBack="True"
                                    Height="20px" Width="130px" Enabled=false></asp:DropDownList></td>
                        </tr>
                   

                     <tr>
                        <td align="right">Seccion:</td>
                        <td><asp:DropDownList ID="SeccionComboBox" runat="server" 
                                onselectedindexchanged="SeccionComboBox_SelectedIndexChanged" 
                                AutoPostBack="True" Height="20px" Width="130px" Enabled=false></asp:DropDownList></td>
                    </tr>

                     <tr>
                        <td align="right">Cargo:</td>
                        <td><asp:DropDownList ID="CargoComboBox" runat="server" AutoPostBack="True"
                            Height="20px" Width="130px" Enabled=false></asp:DropDownList></td>
                    </tr>

                    <tr>
                        <td align="right">Cantidad:</td>
                        <td><asp:TextBox ID="CantidadTextBox" runat="server" Height="20px" Width="130px" onkeypress='validate(event)' ></asp:TextBox></td>
                    </tr>
         
                    <tr>
                        <td align="right">Conceptos:</td>
                         <td>
                             <asp:Button ID="AgregarConceptosButton" runat="server" Text="+" 
                                 onclick="AgregarConceptosButton_Click" />   </td>      
                        
                    </tr>

                    <tr>
                
                        <td colspan="2" align="right">
                           <button id="opener" onclick="return opener_onclick()">Registrar</button>          
                        </td>
                    </tr>
                 </tbody>
            </Table>


  </ContentTemplate> 
  </asp:UpdatePanel>



 

 
 

</asp:Content>
