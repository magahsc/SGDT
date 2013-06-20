<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="AprobacionActividad.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.AprobacionActividad" %>
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

      function mostrarAspxAsPopUpObservacion(id) {

          var url = 'DetalleAprobacionActividad.aspx?modo=Observacion&id=' + id;
          var strReturn = window.showModalDialog(url, null, 'status:no;dialogWidth:600px;dialogHeight:200px;dialogHide:true;help:no;scroll:yes');
      }

      function mostrarAspxAsPopUpMotivo(id) {

          var url = 'DetalleAprobacionActividad.aspx?modo=Motivo&id=' + id + '&estado=PA';
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
                <div style="border-bottom: thin groove Aqua; width: 584px;" class="texto_menu">
                <a href="SolicitudAprobacionActividad.aspx" id="lnkPreAprobacion" >Actividades para aprobaci&oacute;n</a>
                &nbsp;&nbsp;&nbsp;&nbsp;
                            
                <a href="PreaprobacionActividad.aspx" id="lnkAprobacion" >Pre aprobaci&oacute;n</a>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <label class="link_inactivo">Aprobaci&oacute;n</label>
                &nbsp;&nbsp;&nbsp;&nbsp;    
                <a href="ActividadProcesada.aspx" id="lnkPersonalProcesado" >Actividades procesadas</a>
                </div>
                 <br />
               <table class="texto">
                    

                    <tr>
                        <td colspan="8" ><b style="font-size:11pt">Listado de actividades pendientes para aprobaci&oacute;n</b></td>
                    </tr>
                    <tr>
                        <td>Mes de inicio</td>
                        <td>:</td>
                        <td><asp:DropDownList ID="ddlMesInicio" runat="server" AutoPostBack="True" 
                                Enabled="true"  Width="100%" 
                                onselectedindexchanged="ddlMesInicio_SelectedIndexChanged"></asp:DropDownList></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td>Año de fin </td>
                        <td>:</td>
                        <td><asp:DropDownList ID="ddlAnioFin" runat="server" AutoPostBack="True" 
                                Enabled="true"  Width="100%" 
                                onselectedindexchanged="ddlAnioFin_SelectedIndexChanged"></asp:DropDownList></td>
                        

                    </tr>
                    <tr>
                        <td>Mes de fin</td>
                        <td>:</td>
                        <td><asp:DropDownList ID="ddlMesFin" runat="server" AutoPostBack="True" 
                                Enabled="true" Width="100%" 
                                onselectedindexchanged="ddlMesFin_SelectedIndexChanged"></asp:DropDownList></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td>Año de inicio </td>
                        <td>:</td>
                        <td><asp:DropDownList ID="ddlAnioInicio" runat="server" AutoPostBack="True" 
                                Enabled="true"  Width="100%" 
                                onselectedindexchanged="ddlAnioInicio_SelectedIndexChanged"></asp:DropDownList></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        </tr>
                </table>
                <br />

                <div >
                      <asp:GridView ID="ActividadProyectadoGridView" runat="server" AutoGenerateColumns="false"
                                 DataKeyNames="id_actividad_proyectada"  align = "center" 
                          onrowcommand="ActividadProyectadoGridView_RowCommand" >
                                    <HeaderStyle CssClass="GridHeader" />
		                            <RowStyle CssClass="GridRow" HorizontalAlign="Center" />
                                    <AlternatingRowStyle CssClass="GridAlternateRow" HorizontalAlign="Center" />
                               
                                    <Columns>
                   
                                        <asp:BoundField DataField="id_actividad_proyectada" HeaderText="id_actividad_proyectada" Visible=false/>
                            
                                        <asp:TemplateField HeaderText="Nombre de la actividad" ItemStyle-Width="200">
                                            <ItemTemplate>                                           
                                               <%# FormatNombreActividad(Eval("id_actividad").ToString()) %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Inicio" ItemStyle-Width="200">
                                            <ItemTemplate>                                           
                                               <%# FormatFecha(Eval("mes_inicio").ToString(), Eval("anio_inicio").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
        
                                        <asp:TemplateField HeaderText="Fin" ItemStyle-Width="200">
                                            <ItemTemplate>                                           
                                               <%# FormatFecha(Eval("mes_fin").ToString(), Eval("anio_fin").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Monto" ItemStyle-Width="200">
                                            <ItemTemplate>                                           
                                               <%# FormatMonto(Eval("monto_actividad").ToString(), Eval("tipo_moneda").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                   <asp:TemplateField HeaderText="Observacion" ItemStyle-Width="200">
                                        <ItemTemplate>
                                            <asp:Button ID="ObservacionButton" runat="server" Text="+" CommandName="cmdObservacion" CommandArgument='<%# Eval("id_actividad_proyectada") %>' />
                                            </ItemTemplate>
                                    </asp:TemplateField>
                               
                               <asp:TemplateField HeaderText="Pre aprobacion" ItemStyle-Width="200">
                                        <ItemTemplate>
                                            <asp:Button ID="PreAprobacionButton" runat="server" Text="+" CommandName="cmdMotivo" CommandArgument='<%# Eval("id_actividad_proyectada") %>' />
                                            </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Motivo" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:TextBox ID="MotivoTextBox" runat="server"  rows="2" TextMode="multiline"></asp:TextBox>
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
                                         <asp:Button ID="AprobarButton" runat="server" Text="Aprobar" 
                                             CssClass="button_example" onclick="AprobarButton_Click"
                                         />

                                   <asp:Button ID="RechazarButton" runat="server" Text="Rechazar" 
                                             CssClass="button_example" onclick="RechazarButton_Click"
                                         /></div>

                              </div>

             
      </ContentTemplate> 
  
      </asp:UpdatePanel>

  </asp:Panel>


</asp:Content>
