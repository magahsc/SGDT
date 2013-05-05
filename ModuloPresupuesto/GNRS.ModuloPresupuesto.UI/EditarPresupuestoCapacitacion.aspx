<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarPresupuestoCapacitacion.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.EditarPresupuestoCapacitacion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title title="Actualizar presupuesto de capacitación proyectada"></title>
</head>
<body>
    <form id="form1" runat="server">

      <asp:ScriptManager ID="ScriptManager1" runat="server">  
    
    </asp:ScriptManager> 

    <div>
      <asp:panel ID="Datos1Panel" runat="server" GroupingText="Información relacionada a la capacitación">
       <table border="0" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <asp:Label ID="FechaLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
   </asp:panel>

   </br></br>

    <asp:panel ID="Datos2Panel" runat="server" GroupingText="Información relacionada a la capacitación">
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
   </asp:panel>

   </br></br>
   
  <asp:panel ID="Panel1" runat="server" GroupingText="Información relacionada al personal">
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
     
    <br />

     <asp:Panel ID="Panel2" runat="server" ScrollBars="Vertical" Height="200">  
     <asp:UpdatePanel ID="DatosGridView" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate>
   
    <asp:GridView ID="ListaPersonasCapacitarGridView" runat="server" 
          AutoGenerateColumns="false" align = "center" DataKeyNames = "Id_persona"
        
        onpageindexchanging="ListaPersonasCapacitarGridView_PageIndexChanging" 
          CellPadding="3" CellSpacing="1" 
        AllowPaging="True" PageSize="100" 
          
         >
     <Columns>

                  <asp:BoundField HeaderText="ID Usuario" DataField="Id_persona" visible ="false"
                        ItemStyle-Width="200"> 
                    
                    </asp:BoundField>

					<asp:BoundField HeaderText="Nombres y apellidos" DataField="Nombre_persona" 
                        ItemStyle-Width="300" >
                    
                    </asp:BoundField>

                   <asp:BoundField HeaderText="Puesto de trabajo" DataField="Cargo_persona" 
                        ItemStyle-Width="300" >
                    
                    </asp:BoundField>

                   <asp:TemplateField HeaderText="">
                    <ItemTemplate >

                      <asp:CheckBox ID="SelectCheckBox" runat="server" AutoPostBack="true" 
                         oncheckedchanged="SelectCheckBox_CheckedChanged" />        

                    </ItemTemplate>
                   </asp:TemplateField>

             </Columns>
        <PagerSettings FirstPageText="First" />
    </asp:GridView>
   
     </ContentTemplate>  
 </asp:UpdatePanel>

         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <br />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:CheckBox ID="MarcarTodosCheckBox" runat="server"  AutoPostBack="True"
        Text=" Capacitar a todos" Font-Size="Small" oncheckedchanged="MarcarTodosCheckBox_CheckedChanged" 
        />
      </asp:Panel>
   </asp:panel>

   <asp:UpdatePanel ID="LabelUpdatePanel" runat="server" UpdateMode="Conditional"> 
      <ContentTemplate>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
     <Table ID="Table3" runat="server">
         <tbody>
          <tr>
            <td>Monto total de presupuesto: </td>
             <td><asp:Label ID="MontoPresupuestoLabel" runat="server" Text="0.0"></asp:Label></td>
          </tr>
       </tbody>
    </Table>
   
         </ContentTemplate>  
 </asp:UpdatePanel>
    <br />
    
    <asp:Button ID="GuardarButton1" runat="server" Text="Guadar Presupuesto" 
        onclick="GuardarButton1_Click" />
        </div>
    </form>
</body>
</html>
