<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="ListarPresupuestoPersonal.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.ListarPresupuestoPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="server">
  <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            $("#dialog-confirmacion").dialog({
                autoOpen: false,
                draggable: true,

                height: 200,
                width: 350,
                modal: true,
                buttons: {
                    "Aceptar": function () {
                        var sIdCapacitacion = $(this).data("sIdCapacitacion");
                        var sco = $(this).data("sco");
                        // var scodigo = $(this).data("scodigo");
                        PageMethods.eliminar(sIdCapacitacion, sco);
                        eliminar('sdf');

                        $(this).dialog("close");
                        location.reload();

                    },
                    Cancel: function () {
                        $(this).dialog("close");
                    }
                }
            });

        });


        function eliminar(message) {

            if (message != "") {
                var texto = "El personal proyectado se ha eliminado exitosamente";

                $("#dialog-message").text(texto).dialog("open");
            }

        }

        function mostrarMensajeConfirmacion(sIdCapacitacion, sco, presupuestoaprobado) {

            if (presupuestoaprobado == "P") {
                var texto = '¿Está seguro que desea eliminar el presupuesto de personal proyectado ' + sco + '?';
                
                $("#dialog-confirmacion").text(texto).data("sIdCapacitacion", sIdCapacitacion).data("sco", sco).dialog("open");
                // $("#dialog-confirmacion").text(texto).data("scodigo", sIdCapacitacion).dialog("open");
            }
            else {
                var mensaje = 'Solo puede eliminar presupuestos en estado Pendiente.';
                $("#dialog-message").text(mensaje).dialog("open");
            
            }
        }


        function MostrarMensaje(mensaje) {
            $("#dialog-message").text(mensaje).dialog("open");

        }


        $(function () {
            $("#dialog-message").dialog({
                modal: true,
                autoOpen: false,
                height: 200,
                width: 500,
                buttons: {
                    "Aceptar": function () {
                        $(this).dialog("close");
                    }
                }
            });
            $("#dialog-message").css({
                fontSize: 15
            });

        });


        function AbrirVentana(sIdCapacitacion, presupuestoaprobado) {

            if (presupuestoaprobado == "P") {
                var url = 'RegistrarPresupuestoPersonalProyectado.aspx?id=' + sIdCapacitacion + '&modo=2';
                location.href = url
                //window.open(url);

                //Refresh();
            } else {
                var mensaje = 'Solo puede editar presupuestos en estado Pendiente.';
                $("#dialog-message").text(mensaje).dialog("open");
            
            }

        }


    </script>
   <div id="dialog-message" title="Modulo de Presupuesto">  </div>

   <div id="dialog-confirmacion" title="Modulo de Presupuesto"></div>

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true" >  
    
    </asp:ScriptManager> 


    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" CssClass="panel" >  
        <asp:UpdatePanel ID="DatosUpdatePanel" runat="server" UpdateMode="Conditional" > 
            <ContentTemplate>
                <table class="texto">
                    <tr>
                        <td colspan="8" ><b style="font-size:11pt">Puede filtrar los presupuestos de personal proyectado por los siguientes criterios :</b></td>
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
                <div id="dvGrilla">
                <asp:GridView ID="ListaPersonalProyectadoGridView" runat="server" AutoGenerateColumns="false" align = "center" 
                        onrowcommand="ListaPersonalProyectadoGridView_RowCommand" >
                    	<HeaderStyle CssClass="GridHeader" />
		                <RowStyle CssClass="GridRow" HorizontalAlign="Center" />
                        <AlternatingRowStyle CssClass="GridAlternateRow" HorizontalAlign="Center" />
                    <Columns>
                        <asp:BoundField HeaderText="ID Persona" DataField="id_persona"  visible ="false"/>
                        <asp:BoundField HeaderText="Identificador" DataField="nombre_persona" ItemStyle-Width="200"/>
                        <asp:BoundField HeaderText="ID Categoría" DataField="id_categoria" visible ="false"/>
                        <asp:BoundField HeaderText="Categoría" DataField="categoria" ItemStyle-Width="200"/>
                        <asp:BoundField HeaderText="ID Localidad" DataField="id_localidad" visible ="false" />
                        <asp:BoundField HeaderText="Localidad" DataField="localidad" ItemStyle-Width="200" />
                        <asp:BoundField HeaderText="ID Area" DataField="id_area" visible ="false" />
                        <asp:BoundField HeaderText="&Aacute;rea" DataField="area" ItemStyle-Width="200"/>
                        <asp:BoundField HeaderText="ID Seccion" DataField="id_seccion" visible ="false" />
                        <asp:BoundField HeaderText="Secci&oacute;n" DataField="seccion" ItemStyle-Width="200"/>
                        <asp:BoundField HeaderText="Estado" DataField="estado_persona" Visible="false"/>
                        <asp:TemplateField HeaderText="Estado" ItemStyle-Width="200">
                            <ItemTemplate>                                           
                                <%# FormatEstado(Eval("estado_persona").ToString())%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Registro" DataField="fecha_creacion" ItemStyle-Width="200" DataFormatString="{0:dd/MM/yyyy}"/>
                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%--<asp:ImageButton ID="imgEditar" runat="server" CommandName="cmdEditar" CommandArgument='<%# Eval("id_persona") %>' ImageUrl="~/images/edit.png"/>--%>
                                 <button id="editar" class="button_editar" onclick="AbrirVentana('<%#Eval("id_persona") %>', '<%#Eval("estado_persona") %>');" >E</button>
                            </ItemTemplate>                       
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%--<asp:ImageButton ID="imgEliminar" runat="server" OnClientClick="mostrarMensajeConfirmacion('<%#Eval("id_persona") %>', '<%#Eval("nombre_persona") %>','<%#Eval("estado_persona") %>');" ImageUrl="~/images/delete.gif"/>--%>
                                <button  ID="imgEliminar"  class="button_eliminar" onclick="mostrarMensajeConfirmacion('<%#Eval("id_persona") %>', '<%#Eval("nombre_persona") %>','<%#Eval("estado_persona") %>');">X</button>
                            </ItemTemplate>                       
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

</asp:Content>
