<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="RegistrarActividad.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.RegistrarActividad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="server">
 <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
<asp:ScriptManager ID="ScriptManager1" runat="server"  EnablePageMethods="true" 
    EnablePartialRendering="true">
    </asp:ScriptManager>

    <script>
        function lala(message) {
            alert(message);
        }
        function isNumberKey(event, value) {
            var charCode = (event.which) ? event.which : event.keyCode
            var intcount = 0;
            var stramount = value;
            for (var i = 0; i < stramount.length; i++) {
                if (stramount.charAt(i) == '.' && charCode == 46) {
                    return false;
                }
            }
            if ((charCode > 31 && (charCode < 48 || charCode > 57)) && charCode != 46)
                return false;
            return true;

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
                         $(this).dialog("close");
                     }
                 }
             });
             $("#dialog-message").css({
                 fontSize: 15
             });

         });
         
  </script>

   <script type="text/javascript" language="javascript">

       function MostrarMensaje() {
           var hdnSession = document.getElementById("<%= hdnSession.ClientID %>");
           var mensaje = hdnSession.value;
           $("#dialog-message").text(mensaje).dialog("open");

       }

       function MostrarMensajeFinal(mensaje) {
           $("#dialog-mensajes").text(mensaje).dialog("open");

       }
  </script>

   <script>

       $(function () {
           $("#dialog-mensajes").dialog({
               modal: true,
               autoOpen: false,
               height: 200,
               width: 500,
               autoOpen: false,
               buttons: {
                   "Aceptar": function () {
                       $(this).dialog("close");
                   }
               }
           });
           $("#dialog-mensajes").css({
               fontSize: 15
           });

       });
         
  </script>
     
       <script>
           $(document).ready(function () {

               $("#dialog-confirmacion").dialog({
                   autoOpen: false,
                   draggable: true,

                   height: 200,
                   width: 350,
                   modal: true,
                   buttons: {
                       "Si": function () {
                           var codigoactividad = document.getElementById("contenido_ActividadComboBox").value;
                           var mesinicio = document.getElementById("contenido_MesInicioComboBox").value;
                           var mesfin = document.getElementById("contenido_MesFinComboBox").value;
                           var monto = document.getElementById("contenido_MontoTextBox").value;

                           var tipomoneda = 0;
                           var RB1 = document.getElementById("<%=TipoMonedaRadioButtonList.ClientID%>");
                           var radio = RB1.getElementsByTagName("input");
                           var label = RB1.getElementsByTagName("label");
                           for (var i = 0; i < radio.length; i++) {
                               if (radio[i].checked) {
                                   tipomoneda = i;
                               }
                           }

                           var observaciones = document.getElementById("contenido_ObservacionesTextBox").value;
                           PageMethods.registrar(codigoactividad, mesinicio, mesfin, monto, tipomoneda, observaciones, MostrarMensajeFinal);

                           document.getElementById("contenido_ActividadComboBox").selectedIndex = 0;
                           document.getElementById("contenido_MesInicioComboBox").selectedIndex = 0;
                           document.getElementById("contenido_MesFinComboBox").selectedIndex = 0;
                           document.getElementById("contenido_MontoTextBox").value = "";
                           document.getElementById("contenido_MesFinComboBox").disabled = true;
                           observaciones = document.getElementById("contenido_ObservacionesTextBox").value = "";
                           $(this).dialog("close");

                       },
                       "No": function () {
                           $(this).dialog("close");
                       }
                   }
               });




           });

           function mostrarMensajeConfirmacion() {
               var texto = '¿Desea registrar el presupuesto de actividad proyectada ?';

               $("#dialog-confirmacion").text(texto).dialog("open");
           }

           function mostrarMensajeValidacion() {
               var texto = 'Datos incompletos. LLene todos los campos para poder registrar el presupuesto';
               var codigoactividad = document.getElementById("contenido_ActividadComboBox").value;
               var mesinicio = document.getElementById("contenido_MesInicioComboBox").value;
               var mesfin = document.getElementById("contenido_MesFinComboBox").value;
               var monto = document.getElementById("contenido_MontoTextBox").value;

               var RB1 = document.getElementById("<%=TipoMonedaRadioButtonList.ClientID%>");
               var radio = RB1.getElementsByTagName("input");
               var label = RB1.getElementsByTagName("label");
               for (var i = 0; i < radio.length; i++) {
                   if (radio[i].checked) {
                       var tipomoneda = i;
                   }
               }
               var observaciones = document.getElementById("contenido_ObservacionesTextBox").value;

               if (codigoactividad == "" || mesinicio == "" || mesfin == "" || monto == "" || observaciones == "") {
                   $("#dialog-mensajes").text(texto).dialog("open");
               }
               else {
                   mostrarMensajeConfirmacion();
               }

           }   
       
         
  </script>

   <div id="dialog-confirmacion" title="Confirmación de registro"></div>

  <div id="dialog-message" title="Modulo de Presupuesto">  </div>
  <div id="dialog-mensajes" title="Modulo de Presupuesto">  </div>

  <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" CssClass="panel" >  
  
   

  <asp:Label ID="Label1" runat="server"  Text="Información relacionada a la actividad de RRHH"></asp:Label>
    :<br />
    <br />

    <asp:UpdatePanel ID="ComboBoxUpdatePanel" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate>   
            <Table ID="Table1" runat="server" class="texto" >
                 <tbody>
                    <tr >
                        <td align="right" style="width: 114px" >Actividad:</td>
                        <td style="width: 177px">
                            <asp:DropDownList ID="ActividadComboBox" runat="server" 
                                 Height="22px" Width="170px" >
                            </asp:DropDownList></td>

                            <td></td>
                    </tr>

                      
                        <tr>
                            <td align="right" style="width: 114px">Mes de Inicio:</td>
                            <td style="width: 177px">
                                <asp:DropDownList ID="MesInicioComboBox" runat="server"  AutoPostBack = "true"
                                    Height="22px" Width="170px" 
                                    onselectedindexchanged="MesInicioComboBox_SelectedIndexChanged" ></asp:DropDownList></td>
                                    <td></td>
                        </tr>
                   

                     <tr>
                        <td align="right" style="width: 114px">Mes de fin:</td>
                        <td style="width: 177px">
                            <asp:DropDownList ID="MesFinComboBox" runat="server" 
                                Height="22px" Width="170px" ></asp:DropDownList></td>
                                <td></td>
                        </tr>
                  
                  
                    <tr>
                        <td align="right" style="width: 114px">Monto:</td>
                        <td style="width: 177px">
                       
                            <asp:TextBox ID="MontoTextBox" runat="server" 
                                Height="23px" Width="170px" onkeypress="return isNumberKey(event, value)"></asp:TextBox> </td>
                             <td><asp:RadioButtonList ID="TipoMonedaRadioButtonList" runat="server" 
                                RepeatDirection="Horizontal">
                                <asp:ListItem>Soles</asp:ListItem>
                                <asp:ListItem>Dólares</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                               
                       
                    </tr>
               

                    <tr>
                        <td align="right" style="width: 114px">Observaciones:</td>
                         <td colspan="2" style="width: 100%">
                             <br />
                         <asp:TextBox ID="ObservacionesTextBox" runat="server" Height="114px" Width="174px" 
                                 TextMode="MultiLine"></asp:TextBox>

                              <br />
                              </td>    
                              <td></td>  
                        
                    </tr>


                    
                 </tbody>
            </Table>


            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;&nbsp;
            <asp:Button ID="GuardarButton" runat="server" Text="Guardar" Width="111px" onclick="GuardarButton_Click" 
             />
            <asp:HiddenField ID="hdnSession" runat="server" />    
               


  </ContentTemplate> 
  </asp:UpdatePanel>
  </asp:Panel>
    <br />

</asp:Content>
