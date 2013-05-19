<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="RegistrarActividad.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.RegistrarActividad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script>
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

   <script>

       function MostrarMensaje(mensaje) {
           $("#dialog-message").text(mensaje).dialog("open");

       }
  </script>

  <asp:Label ID="Label1" runat="server" Text="Información relacionada a la actividad de RRHH"></asp:Label>
    :<br />
    <br />

    <asp:UpdatePanel ID="ComboBoxUpdatePanel" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate>   
            <Table ID="Table1" runat="server" >
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
                         <td style="width: 177px">
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
            <asp:Button ID="GuardarButton" runat="server" Text="Guardar" Width="111px" onclick="GuardarButton_Click" OnClientClick="if (confirm('¿Desea guardar el presupuesto?')) { return true; } else { return false; }"
                />


  </ContentTemplate> 
  </asp:UpdatePanel>
    <br />

</asp:Content>
