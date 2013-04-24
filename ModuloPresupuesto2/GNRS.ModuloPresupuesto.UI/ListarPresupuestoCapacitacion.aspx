<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="ListarPresupuestoCapacitacion.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.ListarPresupuestoCapacitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">  
    
    </asp:ScriptManager> 

    Puede buscar los presupuestos de capactación proyectada por los siguientes 
    criterios<br />

     <asp:UpdatePanel ID="CriteriosUpdatePanel" runat="server" UpdateMode="Conditional"> 
       <ContentTemplate> 
    <Table ID="Table2" runat="server">
         <tbody>

          <tr>
             <td>&nbsp;</td>
            
             <td>Mes:</td>
             <td><asp:DropDownList ID="mesDropDownList" runat="server" Height="24px" 
                        Width="130px" 
                      AutoPostBack="True" 
                     onselectedindexchanged="mesDropDownList_SelectedIndexChanged" ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
 
              <td>Año:</td>
              <td><asp:DropDownList ID="anioDropDownList" runat="server" Height="24px" 
                        Width="130px" 
                        AutoPostBack="True" 
                      onselectedindexchanged="anioDropDownList_SelectedIndexChanged" ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       
                      
&nbsp;</td>

                <td>Estado:</td>
              <td><asp:DropDownList ID="estadoDropDownList" runat="server" Height="24px" 
                        Width="130px" 
                        AutoPostBack="True" 
                      onselectedindexchanged="estadoDropDownList_SelectedIndexChanged" ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       
                      
&nbsp;</td>


            </tr>

         </tbody>
    </Table>
     </ContentTemplate>  
 </asp:UpdatePanel>

 

<asp:UpdatePanel ID="MensajeUpdatePanel" runat="server" UpdateMode="Conditional"> 
       <ContentTemplate> 
        <Table ID="Table1" runat="server">
         <tbody>

          <tr>
             <td><asp:Label ID="MensajeLabel" runat="server" Text="" Width="500"></asp:Label></td>
             
              <td><asp:Button ID="BuscarButton" runat="server" Text="Buscar" 
        Width="94px" onclick="BuscarButton_Click" /></td>

       </tr>
       </tbody>
       </Table>
  </ContentTemplate> 
</asp:UpdatePanel > 
  
 <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="200">  
 <asp:UpdatePanel ID="DatosUpdatePanel" runat="server" UpdateMode="Conditional"> 
  <ContentTemplate>
   
    <asp:GridView ID="ListasCapacitarProyectadaGridView" runat="server" 
          AutoGenerateColumns="false" align = "center"
        
          CellPadding="3" CellSpacing="1" 
         >
     <Columns>

                  <asp:BoundField HeaderText="ID Capacitacion Proyectada" DataField="Id_presupuesto_capacitacion" visible ="false"
                        ItemStyle-Width="200"> 
                    
                    </asp:BoundField>

					<asp:BoundField HeaderText="Codigo" DataField="Cod_presupuesto" 
                        ItemStyle-Width="300" >
                    
                    </asp:BoundField>

                   <asp:BoundField HeaderText="Curso" DataField="Nombre_curso" 
                        ItemStyle-Width="300" >
                    
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Monto Total" DataField="Smonto_total" 
                        ItemStyle-Width="300" >
                    
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Fecha de creación" DataField="Fecha_creacion" 
                        ItemStyle-Width="300" >
                    
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Estado" DataField="Presupuesto_aprobado" 
                        ItemStyle-Width="300" >
                    
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="center" HeaderStyle-Width="80px">
						<ItemTemplate>
							<asp:LinkButton ID="lnkEditar" runat="server" CommandName="CMDEditar" CommandArgument='<%#Eval("id_presupuesto_capacitacion") %>'><img src="images/edit.gif" width="16" height="16" alt="editar" border="0" /></asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="center" HeaderStyle-Width="80px">
						<ItemTemplate>
						<asp:LinkButton ID="lnkEliminar" runat="server" CommandName="CMDEliminar" CommandArgument='<%#Eval("id_presupuesto_capacitacion") %>'><img src="images/delete.gif" width="16" height="16" alt="eliminar" border="0" onclick="if (confirm('¿Está Ud. seguro que desea eliminar dicho registro?')) { return true; } else { return false; }" /></asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>
    
             </Columns>
        <PagerSettings FirstPageText="First" />
    </asp:GridView>
   
     </ContentTemplate>  
 </asp:UpdatePanel>
 </asp:Panel>

     <br />
    <br />
</asp:Content>
