<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="RegistrarPresupuestoPersonalProyectado.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.RegistrarPresupuestoPersonalProyectado" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Informacion de personal a proyectar"></asp:Label>


    <Table ID="Table1" runat="server">
         <tbody>
            <tr>
                <td>Localidad:</td>
                <td><asp:DropDownList ID="LocalidadComboBox" runat="server" ></asp:DropDownList></td>
            </tr>

             <tr>
                <td>Area:</td>
                <td><asp:DropDownList ID="AreaComboBox" runat="server"></asp:DropDownList></td>
            </tr>

             <tr>
                <td>Seccion:</td>
                <td><asp:DropDownList ID="SeccionComboBox" runat="server"></asp:DropDownList></td>
            </tr>

             <tr>
                <td>Cargo:</td>
                <td><asp:DropDownList ID="CargoComboBox" runat="server"></asp:DropDownList></td>
            </tr>

            <tr>
                <td>Identificador:</td>
                <td><asp:TextBox ID="IdentificadorTextBox" runat="server" ></asp:TextBox></td>
            </tr>
         
            <tr>
                <td>Conceptos:</td>
                <td><asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox></td>
            </tr>

            <tr>
                
                <td colspan="2" align="right">
                    <asp:Button ID="RegistrarButton" runat="server" Text="Registrar" onclick="RegistrarButton_Click" 
                         />                
                </td>
            </tr>
         </tbody>
    </Table>

</asp:Content>
