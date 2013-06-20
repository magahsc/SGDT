<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ModuloPresupuesto.Master" CodeBehind="CostoEmpresa.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.CostoEmpresa" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
  <script type="text/javascript"> 
        function pageLoad() {
            $(function () {
                $("#dialog-form").dialog({
                    autoOpen: false,
                    height: 200,
                    width: 350,
                    modal: true,
                   
                });

                $("#dialog-form").css({
                    fontSize: 15
                });


          


            });


        }

        
      function mensajeCamposIncompletos() {
          $("#dialog-message").text("Datos incompletos. Llene todos los campos para poder registrar el costo de empresa.").dialog("open");

      }

      function costoEmpresaRegistroExitoso(mensaje) {

          $("#dialog-message").text(mensaje).dialog("open");
      }

      function confirmarRecalcular(mensaje) {

          $("#dialog-confirmacion").text(mensaje).dialog("open");
      }

      function confirmarEditar(mensaje) {

          $("#dialog-confirmacion-editar").text(mensaje).dialog("open");
      }
 

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



       $(function () {
           $("#dialog-confirmacion").dialog({
               modal: true,
               autoOpen: false,
               height: 200,
               width: 500,
               buttons: {
                   "Aceptar": function () {
                       PageMethods.recalcularCostoEmpresa();
                       $(this).dialog("close");

                       $("#dialog-message").text('Se ha recalculado correctamente el beneficio social para todos los empleados').dialog("open");

                   },
                   Cancel: function () {
                       $(this).dialog("close");


                   }
               }
           });
           $("#dialog-confirmacion").css({
               fontSize: 15
           });

       });



       $(function () {
           $("#dialog-confirmacion-editar").dialog({
               modal: true,
               autoOpen: false,
               height: 200,
               width: 500,
               buttons: {
                   "Sí": function () {
                       document.getElementById("contenido_editarHidden").value = "si";
                       document.getElementById("contenido_GuardarButton").click();
                       $(this).dialog("close");

                   },
                   "No": function () {
                       $(this).dialog("close");


                   }
               }
           });
           $("#dialog-confirmacion-editar").css({
               fontSize: 15
           });

       });

      function validateDecimales(evt) {
          var charCode = (evt.which) ? evt.which : event.keyCode;
          
          if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
              return false;

              alert($("<%= FactorTextBox.ClientID %>").value);

          if (charCode == 46) {
              var factor = $("#FactorTextBox").value;
              if (factor.indexOf(".") != -1)
                  return false;
          }

          return true;
      }

  </script>
  <div id="dialog-form" title="Módulo de Presupuesto">
  <p><span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>¿Desea guardar el personal?</p>
  </div>

  <div id="dialog-message" title="Módulo de Presupuesto">  </div>
  <div id="dialog-error" title="Módulo de Presupuesto">  </div>
  <div id="dialog-confirmacion" title="Módulo de Presupuesto">  </div>
  <div id="dialog-confirmacion-editar" title="Módulo de Presupuesto">  </div>
  
    
  <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" 
    EnablePartialRendering="true">  
    
    </asp:ScriptManager> 
        
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" CssClass="panel" > 
         <asp:Label ID="Label1" runat="server" CssClass="texto" Font-Size="11pt" Text="Costo Empresa"></asp:Label>
         <br /><br />
         <asp:UpdatePanel ID="PrimerUpdatePanel" runat="server" UpdateMode="Conditional"> 
            <ContentTemplate>   
                <table ID="Table1" runat="server" class="texto" align="center">
                     <tbody>
                        <tr >
                            <td style="width:120px">Categoria</td>
                            <td style="width:5px">:</td>
                            <td style="width:120px"><asp:DropDownList ID="CategoriaComboBox" runat="server" AutoPostBack="True" Width="100%">
                                    <asp:ListItem Text="Seleccione Categorìa" Value="-1"></asp:ListItem>   
                                    <asp:ListItem Text="Todos" Value="0"></asp:ListItem>   
                                    <asp:ListItem Text="Empleado" Value="1"></asp:ListItem>   
                                    <asp:ListItem Text="Obrero" Value="2"></asp:ListItem>   
                                 </asp:DropDownList></td>
                        </tr>

                        <tr>
                            <td >Beneficio Social</td>
                            <td>:</td>
                            <td><asp:TextBox ID="BeneficioSocialTextBox" runat="server"  ></asp:TextBox></td>
                        </tr>
         

                        <tr>
                            <td>Factor</td>
                            <td>:</td>
                            <td><asp:TextBox ID="FactorTextBox" runat="server" onkeypress='return validateDecimales(event)' Width="25%"></asp:TextBox></td>
                        </tr>
                        <tr>
                
                            <td colspan="3" align="right">
                               <asp:Button ID="GuardarButton" runat="server" Text="Guardar" onclick="GuardarButton_Click" CssClass="button_example" />
                            </td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <div align="center" style="width:100%" >
                    <table>
                        <tr>
                            <td>
                                   <asp:GridView ID="CostoEmpresaGridView" runat="server" AutoGenerateColumns="false" style="margin-top: 0px" 
                                                onrowcommand="CostoEmpresaGridView_RowCommand" Width="100%">
                    	                <HeaderStyle CssClass="GridHeader" Font-Size="5pt" />
		                                <RowStyle CssClass="GridRow" HorizontalAlign="Center" />
                                        <AlternatingRowStyle CssClass="GridAlternateRow" HorizontalAlign="Center" />

                                        <Columns>
                                            <asp:TemplateField HeaderText="Categoria" ControlStyle-Width="60px">
                                                <ItemTemplate>                                           
                                                    <%# FormatCategoria(Eval("id_categoria").ToString()) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
        
                                            <asp:BoundField DataField="beneficio_social" HeaderText="Beneficio Social" ControlStyle-Width="10px"/>
                                            <asp:BoundField DataField="factor" HeaderText="Factor" />
                                  
                                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                            <asp:ImageButton ID="imgEditar" runat="server" CommandName="cmdEditar" CommandArgument='<%# Eval("id_costoempresa") %>' ImageUrl="~/images/edit.png"/>
                                                    </ItemTemplate>  
                                            </asp:TemplateField>

                                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgEliminar" runat="server" CommandName="cmdEliminar" CommandArgument='<%# Eval("id_costoempresa") %>' ImageUrl="~/images/delete.gif"/>
                                                    </ItemTemplate> 
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>    
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                 <asp:Button ID="Recalcular" runat="server" Text="Recalcular" onclick="Recalcular_Click" CssClass="button_example" />
                            </td>
                        </tr>
                    </table>

                       
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="UpdatePanelHidden" runat="server" UpdateMode="Conditional"> 
            <ContentTemplate>  
                <input type="hidden" name="editarHidden" id="editarHidden" runat="server" />
                <input type="hidden" name="nuevo" id="nuevo" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Panel>
  

</asp:Content>
