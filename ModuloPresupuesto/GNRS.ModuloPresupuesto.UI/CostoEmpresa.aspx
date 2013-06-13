<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ModuloPresupuesto.Master" CodeBehind="CostoEmpresa.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.CostoEmpresa" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
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

                $("#dialog-form").css({
                    fontSize: 15
                });    
            });
        }        
  </script>
  <script>

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
 

  </script>

  

   <script>
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
  </script>

  <script>
      function validateDecimales(evt) {
          var charCode = (evt.which) ? evt.which : event.keyCode;


          if (charCode != 44 && charCode > 31 && (charCode < 48 || charCode > 57))
              return false;
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

    <asp:Label ID="Label1" runat="server" Text="Informacion de personal a proyectar"></asp:Label>
    
     <asp:UpdatePanel ID="PrimerUpdatePanel" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate>   
            <Table ID="Table1" runat="server" >
                 <tbody>
                    <tr >
                        <td align="right" >Categoria:</td>
                        <td><asp:DropDownList ID="CategoriaComboBox" runat="server" 
                              AutoPostBack="True" Height="20px" Width="130px" >
                                <asp:ListItem Text="Seleccione Categorìa" Value="-1"></asp:ListItem>   
                                <asp:ListItem Text="Todos" Value="0"></asp:ListItem>   
                                <asp:ListItem Text="Empleado" Value="1"></asp:ListItem>   
                                <asp:ListItem Text="Obrero" Value="2"></asp:ListItem>   
                             </asp:DropDownList></td>
                    </tr>

                    <tr>
                        <td align="right">Beneficio Social:</td>
                        <td><asp:TextBox ID="BeneficioSocialTextBox" runat="server" Height="20px" Width="130px" ></asp:TextBox></td>
                    </tr>
         

                    <tr>
                        <td align="right">Factor:</td>
                        <td><asp:TextBox ID="FactorTextBox" runat="server" Height="20px" Width="130px" onkeypress='return validateDecimales(event)' ></asp:TextBox></td>
                    </tr>

                   

                    <tr>
                
                        <td colspan="2" align="right">
                           <asp:Button ID="GuardarButton" runat="server" Text="Guardar" 
                                onclick="GuardarButton_Click" />
                        </td>
                    </tr>
      </tbody>
            </Table>
            </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="GridUpdatePanel" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate>   
            <Table ID="CostoEmpresaTable" runat="server" >
                 <tbody>
                       <tr>
                        <td colspan="2" align="center">
                             <asp:GridView ID="CostoEmpresaGridView" runat="server" 
                                 AutoGenerateColumns="false" style="margin-top: 0px" onrowcommand="CostoEmpresaGridView_RowCommand" 
                                
                                >
                                <Columns>
                   

                                    <asp:TemplateField HeaderText="Categoria" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>                                           
                                           <%# FormatCategoria(Eval("id_categoria").ToString()) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
        
                                    <asp:BoundField DataField="beneficio_social" HeaderText="Beneficio Social" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
                                    <asp:BoundField DataField="factor" HeaderText="Factor" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
                                  
                                    <asp:TemplateField HeaderText="Editar" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEditar" runat="server" AutoPostBack="false" CommandName="cmdEditar" CommandArgument='<%# Eval("id_costoempresa") %>'>
                                                   E</asp:LinkButton>
                                              </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Button1" runat="server" Text="X"  AutoPostBack="false" CommandName="cmdEliminar" CommandArgument='<%# Eval("id_costoempresa") %>'></asp:LinkButton>
                       
                                              </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                               </asp:GridView>  
                               
                                      
                        </td>

                    </tr>
                    <tr>
                        <td colspan="2" align="right">
                           <asp:Button ID="Recalcular" runat="server" Text="Recalcular"   onclick="Recalcular_Click" 
                                />
                        </td>
                        </tr> 
                 </tbody>
            </Table>

             <asp:Button ID="Button1" runat="server" Text="Guadar Presupuesto" 
        /> 
  </ContentTemplate> 
  
  </asp:UpdatePanel>


    <input type="hidden" name="nuevo" id="nuevo" runat="server" />
    

    <asp:UpdatePanel ID="UpdatePanelHidden" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate>  
   <input type="hidden" name="editarHidden" id="editarHidden" runat="server" />
     
   </ContentTemplate>
</asp:UpdatePanel>

 

 
 

</asp:Content>
