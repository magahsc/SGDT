<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="PreaprobacionPersonal.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.SolicitudAprobacion2" %>
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
            var strReturn = window.showModalDialog(url, null, 'status:no;dialogWidth:600px;dialogHeight:300px;dialogHide:true;help:no;scroll:yes');


        }

    </script>
    <div id="dialog-message" title="Módulo de Presupuesto">  </div>

    
    <asp:LinkButton ID="PersonalAprobacionLinkButton" runat="server" Enabled=false>Personal para aprobacion</asp:LinkButton> 
    <asp:LinkButton ID="PersonalProcesadoLinkButton" runat="server"  style="padding-left: 40px" onclick="PersonalProcesadoLinkButton_Click">Personal procesado</asp:LinkButton>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Tipo de personal : " style="padding-left: 1px"></asp:Label>
    <asp:DropDownList ID="TipoPersonalComboBox" runat="server" 
                                AutoPostBack="True" Height="20px" Width="130px" 
        onselectedindexchanged="TipoPersonalComboBox_SelectedIndexChanged" >
                                <asp:ListItem Value="0" > Seleccione el tipo de personal </asp:ListItem>
                                <asp:ListItem Value="1"  Text="Empleado"> </asp:ListItem>
                                <asp:ListItem Value="2"  Text="Obrero"> </asp:ListItem>
                                </asp:DropDownList>
                    
                   <br />
                        <asp:Label ID="Label4" runat="server" Text="Localidad : " style="padding-left: 48px"></asp:Label>
                        <asp:DropDownList ID="LocalidadComboBox" runat="server" 
                                  
                                AutoPostBack="True" Height="20px" Width="130px" 
        onselectedindexchanged="LocalidadComboBox_SelectedIndexChanged" ></asp:DropDownList>
                  
                           <asp:Label ID="Label5" runat="server" Text="Area : " style="padding-left: 82px"></asp:Label>
                           <asp:DropDownList ID="AreaComboBox" runat="server" 
                                     AutoPostBack="True"
                                    Height="20px" Width="130px" 
        onselectedindexchanged="AreaComboBox_SelectedIndexChanged"></asp:DropDownList>
                       
                   
                    
                     
                         <asp:Label ID="Label6" runat="server" Text="Seccion : " style="padding-left: 58px"></asp:Label>
                        <asp:DropDownList ID="SeccionComboBox" runat="server" 
                               
                                AutoPostBack="True" Height="20px" Width="130px" 
          onselectedindexchanged="SeccionComboBox_SelectedIndexChanged"></asp:DropDownList> <br />
                     

     
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" 
    EnablePartialRendering="true" >  
    
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

                                    <asp:BoundField DataField="fecha_creacion" HeaderText="Registro" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
                                   

                                    <asp:TemplateField HeaderText="Remuneracion" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="remuneracionLinkButton" runat="server" CommandName="cmdRemuneracion" CommandArgument='<%# Eval("id_persona") %>'><%#Eval("remuneracion").ToString() %></asp:LinkButton>
                                            </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Motivo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="MotivoTextBox" runat="server"  rows="2" TextMode="multiline"></asp:TextBox>
                                            </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Aprobar" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="AprobarCheckBox" runat="server" />
                                              </ItemTemplate>
                                    </asp:TemplateField>

                                  
                                </Columns>
                               </asp:GridView>  
                               
                                      
                        </td>

                    </tr>
                    <tr>
                        <td colspan="2" align="right">
                           <asp:Button ID="AprobarButton" runat="server" Text="Aprobar" 
                                onclick="AprobarButton_Click" />
                           <asp:Button ID="RechazarButton" runat="server" Text="Rechazar" 
                                onclick="RechazarButton_Click" />
                        </td>
                        </tr> 
                 </tbody>
            </Table>

             
  </ContentTemplate> 
  
  </asp:UpdatePanel>


</asp:Content>
