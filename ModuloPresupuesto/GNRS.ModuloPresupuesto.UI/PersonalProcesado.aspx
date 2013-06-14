<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="PersonalProcesado.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.PersonalProcesado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="server">
      <script>
      
       function mostrarAspxAsPopUpRemuneracion(id) {

            var url = 'DetalleAprobacionPersonal.aspx?modo=remuneracion&id=' + id;
            var strReturn = window.showModalDialog(url, null, 'status:no;dialogWidth:600px;dialogHeight:300px;dialogHide:true;help:no;scroll:yes');
        }

        function mostrarAspxAsPopUpMotivo(id) {

            var url = 'DetalleAprobacionPersonal.aspx?modo=motivo&id=' + id ;
            var strReturn = window.showModalDialog(url, null, 'status:no;dialogWidth:600px;dialogHeight:300px;dialogHide:true;help:no;scroll:yes');
        }

    </script>   
    <asp:LinkButton ID="PersonalAprobacionLinkButton" runat="server" 
          onclick="PersonalAprobacionLinkButton_Click" >Personal para aprobación</asp:LinkButton> 
    <asp:LinkButton ID="PersonalProcesadoLinkButton" runat="server"  style="padding-left: 40px" Enabled=false>Personal procesado</asp:LinkButton>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Tipo de personal : " style="padding-left: 1px"></asp:Label>
    <asp:DropDownList ID="TipoPersonalComboBox" runat="server" 
                                AutoPostBack="True" Height="20px" Width="130px" 
          onselectedindexchanged="TipoPersonalComboBox_SelectedIndexChanged" >
                                <asp:ListItem Value="0" > Seleccione el tipo de personal </asp:ListItem>
                                <asp:ListItem Value="1"  Text="Empleado"> </asp:ListItem>
                                <asp:ListItem Value="2"  Text="Obrero"> </asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label1" runat="server" Text="Estado : " style="padding-left: 65px"></asp:Label>
   
    <asp:DropDownList ID="EstadoDropDownList" runat="server" 
                                AutoPostBack="True" Height="20px" Width="130px" 
          onselectedindexchanged="EstadoDropDownList_SelectedIndexChanged" >
                                <asp:ListItem Value="" > Seleccione el estado</asp:ListItem>
                                <asp:ListItem Value="P"  Text="Pendiente"> </asp:ListItem>
                                <asp:ListItem Value="A"  Text="Aprobado"> </asp:ListItem>
                                <asp:ListItem Value="E"  Text="Eliminado"> </asp:ListItem>
                                <asp:ListItem Value="EP"  Text="Enviado para aprobación"> </asp:ListItem>
                                <asp:ListItem Value="PA"  Text="Pre aprobado"> </asp:ListItem>
                                <asp:ListItem Value="R"  Text="Rechazado"> </asp:ListItem>

                                </asp:DropDownList>     
                    
                   
                   <br />
                        <asp:Label ID="Label4" runat="server" Text="Localidad : " style="padding-left: 48px"></asp:Label>
                        <asp:DropDownList ID="LocalidadComboBox" runat="server" 
                                  
                                AutoPostBack="True" Height="20px" Width="130px" 
          onselectedindexchanged="LocalidadComboBox_SelectedIndexChanged" ></asp:DropDownList>
                  
                           <asp:Label ID="Label5" runat="server" Text="Area : " style="padding-left: 82px"></asp:Label>
                           <asp:DropDownList ID="AreaComboBox" runat="server" 
                                     AutoPostBack="True"
                                    Height="20px" Width="130px" Enabled=false 
          onselectedindexchanged="AreaComboBox_SelectedIndexChanged"></asp:DropDownList>
                       
                   
                    
                     
                         <asp:Label ID="Label6" runat="server" Text="Seccion : " style="padding-left: 58px"></asp:Label>
                        <asp:DropDownList ID="SeccionComboBox" runat="server" 
                               
                                AutoPostBack="True" Height="20px" Width="130px" 
          Enabled=false onselectedindexchanged="SeccionComboBox_SelectedIndexChanged"></asp:DropDownList> <br />
                     

     
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" 
    EnablePartialRendering="true">  
    
    </asp:ScriptManager> 
    <asp:UpdatePanel ID="GridUpdatePanel" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate>   
            <Table ID="CostoEmpresaTable" runat="server" >
                 <tbody>
                       <tr>
                        <td colspan="2" align="center">
                             <asp:GridView ID="PersonalProyectadoGridView" runat="server" 
                                 AutoGenerateColumns="false" style="margin-top: 0px" onrowcommand="PersonalProyectadoGridView_RowCommand" 
                                DataKeyNames="Id_persona"
                                >
                                <Columns>
                   
                                    <asp:BoundField DataField="Id_persona" HeaderText="Id_persona" Visible=false/>
                                    
                                    <asp:BoundField DataField="identificador" HeaderText="Identificador" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>

                                    <asp:TemplateField HeaderText="Tipo de personal" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>                                           
                                           <%# FormatCategoria(Eval("id_categoria").ToString()) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
        
                                    <asp:TemplateField HeaderText="Localidad" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>                                           
                                           <%# FormatLocalidad(Eval("id_localidad").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Area" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>                                           
                                           <%# FormatArea(Eval("id_area").ToString()) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Seccion" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>                                           
                                           <%# FormatSeccion(Eval("id_seccion").ToString()) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Remuneracion" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="remuneracionLinkButton" runat="server" CommandName="cmdRemuneracion" CommandArgument='<%# Eval("id_persona") %>'><%#Eval("remuneracion").ToString() %></asp:LinkButton>
                                            </ItemTemplate>
                                    </asp:TemplateField>

                                    
                                    <asp:TemplateField HeaderText="Estado" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>                                           
                                           <%# FormatEstado(Eval("Estado").ToString()) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Motivo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Button ID="MotivoButton" runat="server" Text="+" CommandName="cmdMotivo" CommandArgument='<%# Eval("id_persona") %>' />
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
