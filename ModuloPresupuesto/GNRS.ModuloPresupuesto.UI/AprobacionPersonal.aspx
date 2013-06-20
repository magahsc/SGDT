<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="Aprobacion.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.SolicitudAprobacion3" %>
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

        function mostrarAspxAsPopUpRemuneracion(id) {

            var url = 'DetalleAprobacionPersonal.aspx?modo=remuneracion&id=' + id;
            var strReturn = window.showModalDialog(url, null, 'status:no;dialogWidth:600px;dialogHeight:200px;dialogHide:true;help:no;scroll:yes');
        }

        function mostrarAspxAsPopUpMotivo(id) {

            var url = 'DetalleAprobacionPersonal.aspx?modo=motivo&id=' + id+'&estado=PA';
            var strReturn = window.showModalDialog(url, null, 'status:no;dialogWidth:600px;dialogHeight:200px;dialogHide:true;help:no;scroll:yes');
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

                <a href="SolicitudAprobacionPersonal.aspx" id="lnkSolicitudAprobacion" >Solicitud de aprobaci&oacute;n</a>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <a href="PreAprobacionPersonal.aspx" id="linkPreAprobacion" >Pre aprobaci&oacute;n</a>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <label class="link_inactivo">Aprobaci&oacute;n</label>
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

                                    <asp:BoundField DataField="fecha_creacion" HeaderText="Registro" ItemStyle-Width="200" DataFormatString="{0:dd/MM/yyyy}"/>
                                   

                                    <asp:TemplateField HeaderText="Remuneracion" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="remuneracionLinkButton" runat="server" CommandName="cmdRemuneracion" CommandArgument='<%# Eval("id_persona") %>'><%#Eval("remuneracion").ToString() %></asp:LinkButton>
                                            </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Pre aprobacion" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:Button ID="PreaprobadoButton" runat="server" Text="+" CommandName="cmdMotivo" CommandArgument='<%# Eval("id_persona") %>' />
                                            </ItemTemplate>
                                    </asp:TemplateField>



                                    <asp:TemplateField HeaderText="Motivo" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:TextBox ID="MotivoTextBox" runat="server"  rows="2" TextMode="multiline"></asp:TextBox>
                                            </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Aprobar" ItemStyle-Width="150">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="AprobarCheckBox" runat="server" />
                                              </ItemTemplate>
                                    </asp:TemplateField>

                                  
                                </Columns>
                               </asp:GridView>  
                               
                                      
                            <div align="right">
                               <asp:Button ID="AprobarButton" runat="server" Text="Aprobar"  CssClass="button_example"
                                    onclick="AprobarButton_Click" />
                               
                               <asp:Button ID="RechazarButton" runat="server" Text="Rechazar" CssClass="button_example"
                               onclick="RechazarButton_Click" />
                           </div>
                    </div>

  </ContentTemplate> 
  
  </asp:UpdatePanel>
  </asp:Panel>

</asp:Content>
