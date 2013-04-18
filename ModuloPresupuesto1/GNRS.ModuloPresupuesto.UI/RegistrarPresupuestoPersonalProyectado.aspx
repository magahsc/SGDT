<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="RegistrarPresupuestoPersonalProyectado.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.RegistrarPresupuestoPersonalProyectado" %>


 


 


<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">  
    
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
                        <td align="right">Identificador:</td>
                        <td><asp:TextBox ID="IdentificadorTextBox" runat="server" Height="20px" Width="130px" ></asp:TextBox></td>
                    </tr>
         
                    <tr>
                        <td align="right">Conceptos:</td>
                        <td><asp:TextBox ID="TextBox2" runat="server" Height="20px" Width="130px" ></asp:TextBox></td>
                    </tr>

                    <tr>
                
                        <td colspan="2" align="right">
                            <asp:Button ID="RegistrarButton" runat="server" Text="Registrar" onclick="RegistrarButton_Click" 
                                 />                
                        </td>
                    </tr>
                 </tbody>
            </Table>


  </ContentTemplate> 
                     </asp:UpdatePanel>

</asp:Content>
