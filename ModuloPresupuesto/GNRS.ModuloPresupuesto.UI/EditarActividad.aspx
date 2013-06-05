<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarActividad.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.EditarActividad" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
    <div>

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
                    "Aceptar": function () {
                       // window.opener.Refresh();

                        $(this).dialog("close");
                       // window.close();
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
               $("#dialog-final").dialog({
                   modal: true,
                   autoOpen: false,
                   height: 200,
                   width: 500,
                   buttons: {
                       "Aceptar": function () {
                           window.opener.Refresh();
                           $(this).dialog("close");
                           window.close();

                       }
                   }
               });
               $("#dialog-final").css({
                   fontSize: 15
               });

           });
  </script>

    <script>

        function MostrarMensaje(mensaje) {
            $("#dialog-message").text(mensaje).dialog("open");
        }

        function mostrarMensajeFinal() {
            var hdnSession = document.getElementById("<%= hdnSession.ClientID %>");
            var codigo = hdnSession.value;
            var texto = 'El presupuesto de capacitación proyectada ' + codigo + ' ha sido actualizado exitosamente';

            $("#dialog-final").text(texto).dialog("open");
        }
  </script>

  <div id="dialog-message" title="Modulo de Presupuesto">  </div>
  <div id="dialog-final" title="Modulo de Presupuesto">  </div>

    <asp:Panel ID="Datos1Panel" runat="server" GroupingText="Información relacionada al presupuesto">
     <asp:UpdatePanel ID="FechaUpdatePanel" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate> 
     <table border="0" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <asp:Label ID="FechaLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>    
    </ContentTemplate>  
   </asp:UpdatePanel>
   </asp:Panel>
   <br />

  <asp:Panel ID="InformacionPanel" runat="server" GroupingText="Información relacionada a la actividad">
    <asp:UpdatePanel ID="ComboBoxUpdatePanel" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate>   
            <Table ID="Table1" runat="server" >
                 <tbody>
                    <tr >
                        <td align="right" style="width: 114px" >Actividad:</td>
                        <td><asp:Label ID="ActividadLabel" runat="server"></asp:Label></td>
                            <td></td>
                    </tr>

                      
                        <tr>
                            <td align="right" style="width: 114px">Mes de Inicio:</td>
                             <td style="width: 177px">
                            <asp:DropDownList ID="MesInicioComboBox" runat="server" AutoPostBack="true" 
                                Height="22px" 
                                Width="170px" onselectedindexchanged="MesInicioComboBox_SelectedIndexChanged">
                            </asp:DropDownList>
                            </td>
                                    <td></td>
                        </tr>
                   
                    <tr>
                        <td align="right" style="width: 114px">Mes de fin:</td>
                        <td style="width: 177px">
                       
                            <asp:DropDownList ID="MesFinComboBox" runat="server" Height="22px" 
                                Width="170px">
                            </asp:DropDownList>
                        </td>
                             <td>
                        </td>
                               
                    </tr>

                     <tr>
                        <td align="right" style="width: 114px">Monto:</td>
                        <td style="width: 177px">
                            <asp:TextBox ID="MontoTextBox" runat="server" Height="23px" 
                                onkeypress="return isNumberKey(event, value)" Width="170px"></asp:TextBox>
                         </td>
                                <td>
                                    <asp:RadioButtonList ID="TipoMonedaRadioButtonList" runat="server" 
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem>Soles</asp:ListItem>
                                        <asp:ListItem>Dólares</asp:ListItem>
                                    </asp:RadioButtonList>
                         </td>
                        </tr>
                  
                 </tbody>
            </Table>

            <table>
             
                    <tr>
                        <td align="right" style="width: 114px">Observaciones:</td>
                         <td style="width: 177px">
                             <br />
                         <asp:TextBox ID="ObservacionesTextBox" runat="server" Height="114px" Width="463px" 
                                 TextMode="MultiLine"></asp:TextBox>

                              <br />
                              </td>    
                              <td></td>  
                        
                    </tr>
            </table>


            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;&nbsp;
            <asp:Button ID="GuardarButton" runat="server" Text="Guardar" Width="111px" onclick="GuardarButton_Click"  OnClientClick="window.opener.__doPostBack('BuscarButton_onClick','');"
             />
            <asp:HiddenField ID="hdnSession" runat="server" />    
               


  </ContentTemplate> 
  </asp:UpdatePanel>
  </asp:Panel>
    </div>
    </form>
</body>
</html>
