<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="PreaprobacionPersonal.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.SolicitudAprobacion2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="server">

    
    <script>

        function mostrarAspxAsPopUp(id) {

            var url = 'DetalleAprobacionPersonal.aspx?modo=remuneracion&id=' + id;
            var strReturn = window.showModalDialog(url, null, 'status:no;dialogWidth:600px;dialogHeight:300px;dialogHide:true;help:no;scroll:yes');


        }

    </script>
    
    <asp:LinkButton ID="PersonalAprobacionLinkButton" runat="server" Enabled=false>Personal para aprobacion</asp:LinkButton> 
    <asp:LinkButton ID="PersonalProcesadoLinkButton" runat="server"  style="padding-left: 40px">Personal procesado</asp:LinkButton>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Tipo de personal : " style="padding-left: 1px"></asp:Label>
    <asp:DropDownList ID="TipoPersonalComboBox" runat="server" 
                                AutoPostBack="True" Height="20px" Width="130px" >
                                <asp:ListItem Value="" > Seleccione el tipo de personal </asp:ListItem>
                                <asp:ListItem Value="1"  Text="Empleado"> </asp:ListItem>
                                <asp:ListItem Value="2"  Text="Obrero"> </asp:ListItem>
                                </asp:DropDownList>
                    
                   <br />
                        <asp:Label ID="Label4" runat="server" Text="Localidad : " style="padding-left: 48px"></asp:Label>
                        <asp:DropDownList ID="LocalidadComboBox" runat="server" 
                                  
                                AutoPostBack="True" Height="20px" Width="130px" ></asp:DropDownList>
                  
                           <asp:Label ID="Label5" runat="server" Text="Area : " style="padding-left: 82px"></asp:Label>
                           <asp:DropDownList ID="AreaComboBox" runat="server" 
                                     AutoPostBack="True"
                                    Height="20px" Width="130px" Enabled=false></asp:DropDownList>
                       
                   
                    
                     
                         <asp:Label ID="Label6" runat="server" Text="Seccion : " style="padding-left: 58px"></asp:Label>
                        <asp:DropDownList ID="SeccionComboBox" runat="server" 
                               
                                AutoPostBack="True" Height="20px" Width="130px" Enabled=false></asp:DropDownList> <br />
                     

     
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
                                
                                >
                                <Columns>
                   

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

                                    <asp:BoundField DataField="fecha_creacion" HeaderText="Registro" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
                                   

                                    <asp:TemplateField HeaderText="Remuneracion" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="remuneracionLinkButton" runat="server" CommandName="cmdRemuneracion" CommandArgument='<%# Eval("id_persona") %>'><%#Eval("remuneracion").ToString() %></asp:LinkButton>
                                            </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Motivo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server"  rows="2" TextMode="multiline"></asp:TextBox>
                                            </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Aprobar" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                              </ItemTemplate>
                                    </asp:TemplateField>

                                  
                                </Columns>
                               </asp:GridView>  
                               
                                      
                        </td>

                    </tr>
                    <tr>
                        <td colspan="2" align="right">
                           <asp:Button ID="AprobarButton" runat="server" Text="Aprobar" />
                           <asp:Button ID="RechazarButton" runat="server" Text="Rechazar" />
                        </td>
                        </tr> 
                 </tbody>
            </Table>

             <asp:Button ID="Button1" runat="server" Text="Guadar Presupuesto" 
        /> 
  </ContentTemplate> 
  
  </asp:UpdatePanel>


</asp:Content>
