<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="RegistrarActividadRRHH.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.RegistrarActividadRRHH" %>
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

    <asp:Label ID="Label1" runat="server" Text="Información relacionada a la actividad de RRHH"></asp:Label>
    :<br />
    <br />

    <asp:UpdatePanel ID="ComboBoxUpdatePanel" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate>   
            <Table ID="Table1" runat="server" >
                 <tbody>
                    <tr >
                        <td align="right" style="width: 114px" >Actividad:</td>
                        <td style="width: 207px"><asp:DropDownList ID="ActividadComboBox" runat="server" 
                                 Height="21px" Width="198px" >
                            </asp:DropDownList></td>
                    </tr>

                      
                        <tr>
                            <td align="right" style="width: 114px">Mes de Inicio:</td>
                            <td style="width: 207px"><asp:DropDownList ID="MesInicioComboBox" runat="server"  
                                    Height="21px" Width="199px" ></asp:DropDownList></td>
                        </tr>
                   

                     <tr>
                        <td align="right" style="width: 114px">Mes de fin:</td>
                        <td style="width: 207px"><asp:DropDownList ID="MesFinComboBox" runat="server" 
                                Height="21px" Width="198px" ></asp:DropDownList></td>
                        </tr>
                  
                    <tr>
                        <td align="right" style="width: 114px">Monto:</td>
                        <td style="width: 207px"><asp:TextBox ID="MontoTextBox" runat="server" 
                                Height="23px" Width="196px" onkeypress="return isNumberKey(event, value)"></asp:TextBox></td>
                    </tr>
         
                    <tr>
                        <td align="right" style="width: 114px">Observaciones:</td>
                         <td style="width: 207px">
                             <br />
                         <asp:TextBox ID="ObservacionesTextBox" runat="server" Height="110px" Width="200px" 
                                 TextMode="MultiLine"></asp:TextBox>
                              <br />
                              </td>      
                        
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
