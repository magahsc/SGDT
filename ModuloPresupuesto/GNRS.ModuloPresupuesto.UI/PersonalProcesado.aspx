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

   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" 
    EnablePartialRendering="true">  
    
    </asp:ScriptManager> 
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" CssClass="panel" >
    

    <asp:UpdatePanel ID="GridUpdatePanel" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate> 
           <div style="border-bottom-color:Aqua;border-bottom-style:groove;border-bottom-width:thin" class="texto_menu">

                <a href="SolicitudAprobacionPersonal.aspx" id="lnkSolicitudAprobacion" >Solicitud de aprobaci&oacute;n</a>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <a href="PreAprobacionPersonal.aspx" id="linkPreAprobacion" >Pre aprobaci&oacute;n</a>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <a href="AprobacionPersonal.aspx" id="lnkAprobacion" >Aprobaci&oacute;n</a>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <label class="link_inactivo">Personal procesado</label>

            </div>
            <br />     
     
             <table class="texto">
                    
                <tr>
                    <td colspan="8" ><b style="font-size:11pt">Listado de personal pendiente para aprobaci&oacute;n</b></td>
                </tr>
                <tr>
                    <td>Categoría de Personal</td>
                    <td>:</td>
                    <td><asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="True" 
                            Enabled="true" onselectedindexchanged="ddlCategoria_SelectedIndexChanged" Width="100%"></asp:DropDownList></td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>Estado</td>
                    <td>:</td>
                    <td>
                        <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="True" 
                            Enabled="true" onselectedindexchanged="ddlEstado_SelectedIndexChanged" Width="100%">
                            <asp:ListItem Value="" > Seleccione el estado </asp:ListItem>
                            <asp:ListItem Value="P"  Text="Pendiente"> </asp:ListItem>
                            <asp:ListItem Value="A"  Text="Aprobado"> </asp:ListItem>
                            <asp:ListItem Value="EP"  Text="Enviado para aprobaci&oacute;n"> </asp:ListItem>
                            <asp:ListItem Value="PA"  Text="Pre aprobado"> </asp:ListItem>
                            <asp:ListItem Value="R"  Text="Rechazado"> </asp:ListItem>
                            <asp:ListItem Value="E"  Text="Eliminado"> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Localidad</td>
                    <td>:</td>
                    <td><asp:DropDownList ID="ddlLocalidad" runat="server" AutoPostBack="True" 
                            Enabled="true" onselectedindexchanged="ddlLocalidad_SelectedIndexChanged" Width="100%"></asp:DropDownList></td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>&Aacute;rea</td>
                    <td>:</td>
                    <td><asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="True" 
                            Enabled="true" onselectedindexchanged="ddlArea_SelectedIndexChanged" Width="100%"></asp:DropDownList></td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>Secci&oacute;n</td>
                    <td>:</td>
                    <td><asp:DropDownList ID="ddlSeccion" runat="server" AutoPostBack="True" 
                            Enabled="true" onselectedindexchanged="ddlSeccion_SelectedIndexChanged" Width="100%"></asp:DropDownList></td>
                </tr>
            </table>
            <br />        
     
       
            <div>
                             <asp:GridView ID="PersonalProyectadoGridView" runat="server" 
                                 AutoGenerateColumns="false" style="margin-top: 0px" onrowcommand="PersonalProyectadoGridView_RowCommand" 
                                DataKeyNames="Id_persona"
                                >
                                    <HeaderStyle CssClass="GridHeader" />
		                            <RowStyle CssClass="GridRow" HorizontalAlign="Center" />
                                    <AlternatingRowStyle CssClass="GridAlternateRow" HorizontalAlign="Center" />
                               

                                <Columns>
                   
                                    <asp:BoundField DataField="Id_persona" HeaderText="Id_persona" Visible=false/>
                                    
                                    <asp:BoundField DataField="identificador" HeaderText="Identificador" ItemStyle-Width="200"/>

                                    <asp:TemplateField HeaderText="Categoria" ItemStyle-Width="200">
                                        <ItemTemplate>                                           
                                           <%# FormatCategoria(Eval("id_categoria").ToString()) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
        
                                    <asp:TemplateField HeaderText="Localidad" ItemStyle-Width="200">
                                        <ItemTemplate>                                           
                                           <%# FormatLocalidad(Eval("id_localidad").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Area" ItemStyle-Width="200">
                                        <ItemTemplate>                                           
                                           <%# FormatArea(Eval("id_area").ToString()) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Seccion" ItemStyle-Width="200">
                                        <ItemTemplate>                                           
                                           <%# FormatSeccion(Eval("id_seccion").ToString()) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Remuneracion" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="remuneracionLinkButton" runat="server" CommandName="cmdRemuneracion" CommandArgument='<%# Eval("id_persona") %>'><%#Eval("remuneracion").ToString() %></asp:LinkButton>
                                            </ItemTemplate>
                                    </asp:TemplateField>

                                    
                                    <asp:TemplateField HeaderText="Estado" ItemStyle-Width="200">
                                        <ItemTemplate>                                           
                                           <%# FormatEstado(Eval("Estado").ToString()) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Motivo" ItemStyle-Width="150">
                                            <ItemTemplate>
                                                <asp:Button ID="MotivoButton" runat="server" Text="+" CommandName="cmdMotivo" CommandArgument='<%# Eval("id_persona") %>' />
                                            </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                               </asp:GridView>  
                               
                                      
            </div>

  </ContentTemplate> 
  
  </asp:UpdatePanel>
  </asp:Panel>
</asp:Content>
