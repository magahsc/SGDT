<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="ConceptosPersonal.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.ConceptosPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" 
    EnablePartialRendering="true">  
    
    </asp:ScriptManager> 

   
     <asp:UpdatePanel ID="ComboBoxUpdatePanel" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate>   
            <Table ID="Table1" runat="server" >
                 <tbody>
                    <tr >
                        <td align="right" >Tipo de concepto:</td>
                        <td><asp:DropDownList ID="TipoConceptoComboBox" runat="server"                                 
                                AutoPostBack="True" Height="20px" Width="130px" ></asp:DropDownList></td>
                    </tr>

                      
                        <tr>
                            <td align="right">Concepto:</td>
                            <td><asp:DropDownList ID="ConceptoComboBox" runat="server" Height="20px" Width="130px" Enabled=false></asp:DropDownList></td>
                        </tr>
                   

                    
                    <tr>
                        <td align="right">Monto:</td>
                        <td><asp:TextBox ID="MontoTextBox" runat="server" Height="20px" Width="130px" ></asp:TextBox></td>
                    </tr>
         
                    <tr>                
                        <td colspan="2" align="right">
                           <button id="AgregarButton">Agregar</button>          
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2" align="center">
                             <asp:GridView ID="ConceptosGridView" runat="server" AutoGenerateColumns="false" >
                                <Columns>
                                    <asp:BoundField DataField="usuario1" HeaderText="Tipo Concepto" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
                                    <asp:BoundField DataField="password" HeaderText="Concepto" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
                                    <asp:BoundField DataField="nombre" HeaderText="Monto" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
                                  
                                    <asp:TemplateField HeaderText="Editar" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEditar" runat="server" CommandName="cmdEditar" CommandArgument='<%# Eval("usuario1") %>'>
                                                    E
                                                </asp:LinkButton>
                                              </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Button1" runat="server" Text="X"  CommandName="cmdEliminar" CommandArgument='<%# Eval("usuario1") %>'></asp:LinkButton>
                       
                                              </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                               </asp:GridView>         
                        </td>

                    </tr>
                    
                 </tbody>
            </Table>


  </ContentTemplate> 
  </asp:UpdatePanel>
</asp:Content>
