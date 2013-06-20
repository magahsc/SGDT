<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="SolicitudAprobacionPersonal.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.SolicitudAprobacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
 
  <script>
        function pageLoad() {
            $(function () {
                $("#dialog-form").dialog({
                    autoOpen: false,
                    height: 200,
                    width: 350,
                    modal: true,                   
                });               
            });

           $(function () {
               $("#dialog-message").dialog({
                   modal: true,
                   autoOpen: false,
                   height: 200,
                   width: 500,
                   buttons: {
                       Ok: function () {
                           $(this).dialog("close");
                       }
                   }
               });
               $("#dialog-message").css({
                   fontSize: 15
               });

            });
        }        
  </script>

  <script>
      function mostrarMensaje(mensaje) {

          $("#dialog-message").text(mensaje).dialog("open");
      }
      
       function mostrarAspxAsPopUp(id) {
            var url = 'DetalleAprobacionPersonal.aspx?modo=remuneracion&id=' + id;
            var strReturn = window.showModalDialog(url, null, 'status:no;dialogWidth:600px;dialogHeight:250px;dialogHide:true;help:no;scroll:yes');


        }

    </script>

    <div id="dialog-message" title="Módulo de Presupuesto">  </div>

 
     
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" 
    EnablePartialRendering="true">  
    
    </asp:ScriptManager> 
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" CssClass="panel" >
       

        <asp:UpdatePanel ID="GridUpdatePanel" runat="server" UpdateMode="Conditional"> 
         <ContentTemplate>  
                <div style="border-bottom-color:Aqua;border-bottom-style:groove;border-bottom-width:thin" class="texto_menu">
                <label class="link_inactivo">Solicitud de aprobaci&oacute;n</label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <a href="PreaprobacionPersonal.aspx" id="lnkPreAprobacion" >Pre aprobaci&oacute;n</a>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <a href="AprobacionPersonal.aspx" id="lnkAprobacion" >Aprobaci&oacute;n</a>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <a href="PersonalProcesado.aspx" id="lnkPersonalProcesado" >Personal procesado</a>
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

                <div >
                      <asp:GridView ID="PersonalProyectadoGridView" runat="server" AutoGenerateColumns="false"
                                 onrowcommand="PersonalProyectadoGridView_RowCommand" DataKeyNames="Id_persona"  align = "center" >
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
        
                                        <asp:TemplateField HeaderText="Localidad" ItemStyle-Width="160">
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

                                        <asp:BoundField DataField="fecha_creacion" HeaderText="Registro" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="150"/>

                                        <asp:TemplateField HeaderText="Remuneracion" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200" ControlStyle-Font-Size="Small" ControlStyle-CssClass="link_activo">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="remuneracionLinkButton" runat="server" CommandName="cmdRemuneracion" CommandArgument='<%# Eval("id_persona") %>'><%#Eval("remuneracion").ToString() %></asp:LinkButton>
                                                </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Aprobar" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="AprobarCheckBox" runat="server" />
                                                  </ItemTemplate>
                                        </asp:TemplateField>

                                  
                                    </Columns>
                                   </asp:GridView>  
                                   <div align="right" >
                                        <asp:Button ID="SolicitarAprobacionButton" runat="server" CssClass="button_example" Text="Solicitar aprobacion" onclick="SolicitarAprobacionButton_Click" />
                                   </div>

                              </div>

             
      </ContentTemplate> 
  
      </asp:UpdatePanel>

  </asp:Panel>
</asp:Content>
