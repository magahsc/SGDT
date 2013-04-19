<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="RegistrarPresupuestoCapacitacion.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.RegistrarPresupuestoCapacitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">  
    
    </asp:ScriptManager> 

<br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;
    Información relacionada a la capacitación:
    &nbsp;&nbsp;&nbsp;&nbsp;

 <asp:UpdatePanel ID="ComboBoxUpdatePanel1" runat="server" UpdateMode="Conditional"> 
  <ContentTemplate>  
  <Table ID="Table1" runat="server" style="height: 50px; width: 450px;">
         <tbody>

            <tr>
                <td style="width: 74px; height: 33px;">Instituto:</td>
                <td style="height: 33px"><asp:DropDownList ID="InstitutoDropDownList" 
                        runat="server" Height="24px" 
                        Width="169px" 
                        onselectedindexchanged="InstitutoDropDownList_SelectedIndexChanged"  AutoPostBack="True"></asp:DropDownList></td>
            </tr>

             <tr>
                <td style="width: 74px">Curso:</td>
                <td><asp:DropDownList ID="CursoDropDownList" runat="server" Height="24px" 
                        Width="171px" 
                        onselectedindexchanged="CursoDropDownList_SelectedIndexChanged"  AutoPostBack="True"></asp:DropDownList></td>
            </tr>
         </tbody>
    </Table>
     </ContentTemplate>  
 </asp:UpdatePanel>
  
    <br />
     <asp:UpdatePanel ID="ComboBoxUpdatePanel2" runat="server" UpdateMode="Conditional"> 
      <ContentTemplate>  
    <Table ID="Table2" runat="server">
         <tbody>

            <tr>
             <td>Localidad:</td>
             <td><asp:DropDownList ID="LocalidadDropDownList" runat="server" Height="24px" 
                        Width="130px" 
                     onselectedindexchanged="LocalidadDropDownList_SelectedIndexChanged"  AutoPostBack="True" ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
 
              <td>Area:</td>
              <td><asp:DropDownList ID="AreaDropDownList" runat="server" Height="24px" 
                        Width="130px" 
                      onselectedindexchanged="AreaDropDownList_SelectedIndexChanged"  AutoPostBack="True" ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>

              <td>Sección:</td>
              <td><asp:DropDownList ID="SeccionDropDownList" runat="server" Height="24px" 
                        Width="130px" 
                      onselectedindexchanged="SeccionDropDownList_SelectedIndexChanged"   AutoPostBack="True"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td> 
            </tr>

         </tbody>
    </Table>
     </ContentTemplate>  
</asp:UpdatePanel>

    &nbsp;


    <br />
    <asp:GridView ID="ListaPersonasCapacitarGridView" runat="server" 
        
        onpageindexchanging="ListaPersonasCapacitarGridView_PageIndexChanging" 
        AllowPaging="True">
     <Columns>
                    <asp:BoundField HeaderText="ID Usuario" DataField="Id_persona" 
                        ItemStyle-Width="140" visible ="false"> 
                    <ItemStyle Width="140px"></ItemStyle>
                    </asp:BoundField>

					<asp:BoundField HeaderText="Nombres y apellidos" DataField="Nombre_persona" 
                        ItemStyle-Width="140" >
                    <ItemStyle Width="140px"></ItemStyle>
                    </asp:BoundField>

                   <asp:BoundField HeaderText="Puesto de trabajo" DataField="Cargo_persona" 
                        ItemStyle-Width="140" >
                    <ItemStyle Width="140px"></ItemStyle>
                    </asp:BoundField>

                   <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                       <asp:CheckBox ID="SelectCheckBox" runat="server" />
                    </ItemTemplate>
                    <HeaderTemplate>
                    </HeaderTemplate>
                   </asp:TemplateField>
    
    </Columns>
        <PagerSettings FirstPageText="First" />
    </asp:GridView>


    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:CheckBox ID="MarcarTodosCheckBox" runat="server"  
        Text=" Capacitar a todos" Font-Size="Small"/>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Monto total de presupuesto:
    <asp:Label ID="MontoPresupuestoLabel" runat="server" Text=""></asp:Label>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Guadar Presupuesto" />


    <br />
  </asp:Content>
