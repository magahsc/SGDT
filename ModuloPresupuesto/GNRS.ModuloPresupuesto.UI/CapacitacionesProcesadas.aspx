<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="CapacitacionesProcesadas.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.CapacitacionesProcesadas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="server">
<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>

  </script>
      <script>
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
  </script>

  <script>
      function MostrarMensaje(mensaje) {
          $("#dialog-message").text(mensaje).dialog("open");

      }

      function mostrarAspxAsPopUpMotivo(id) {

          var url = 'DetalleMotivoPresupuestoCapacitacion.aspx?modo=otro&id=' + id + '&estado=O';
          var strReturn = window.showModalDialog(url, null, 'status:no;dialogWidth:300px;dialogHeight:300px;dialogHide:true;help:no;scroll:yes');
      }

  </script>
   <div id="dialog-message" title="Modulo de Presupuesto">  </div>

    <asp:LinkButton ID="CapacitacionesAprobarLinkButton" runat="server" 
        onclick="CapacitacionesAprobarLinkButton_Click">Capacitaciones para aprobación</asp:LinkButton>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="CapacitacionesProcesadasLinkButton" runat="server" 
        onclick="CapacitacionesProcesadasLinkButton_Click">Capacitaciones procesadas</asp:LinkButton>
    &nbsp;

     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true" >  
    
    </asp:ScriptManager> 
    <br /><br />

    Listado de capacitaciones pendientes para aprobación<br />
    <br />

     <asp:UpdatePanel ID="Criterios1UpdatePanel" runat="server" UpdateMode="Conditional"> 
       <ContentTemplate> 
       <Table ID="Table2" runat="server">
         <tbody>

          <tr>
             <td>&nbsp;</td>
            
             <td>Mes:</td>
             <td><asp:DropDownList ID="mesDropDownList" runat="server" Height="24px" 
                        Width="140px"  AutoPostBack = "true" onselectedindexchanged="mesDropDownList_SelectedIndexChanged"
                     ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;</td>
 
              <td>Año:</td>
              <td><asp:DropDownList ID="anioDropDownList" runat="server" Height="24px" 
                        Width="130px"   AutoPostBack = "true" onselectedindexchanged="anioDropDownList_SelectedIndexChanged"
                      ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       
                      
&nbsp;</td>

              <td>Estado:</td>
              <td><asp:DropDownList ID="estadoDropDownList" runat="server" Height="24px"  AutoPostBack = "true"
                        Width="152px" onselectedindexchanged="estadoDropDownList_SelectedIndexChanged" 
                      ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      </td>

            </tr>
              </tbody>
       </Table>
     </ContentTemplate>  
 </asp:UpdatePanel>


     <asp:UpdatePanel ID="Criterios2UpdatePanel" runat="server" UpdateMode="Conditional"> 
      <ContentTemplate>  
    <Table ID="Table1" runat="server">
         <tbody>            
         <tr>
             <td>Localidad:</td>
             <td><asp:DropDownList ID="LocalidadDropDownList" runat="server" Height="24px" 
                        Width="130px"  AutoPostBack = "true" onselectedindexchanged="LocalidadDropDownList_SelectedIndexChanged"
                    ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
 
              <td>Area:</td>
              <td><asp:DropDownList ID="AreaDropDownList" runat="server" Height="24px" 
                        Width="130px" AutoPostBack = "true" onselectedindexchanged="AreaDropDownList_SelectedIndexChanged"
                       ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>

              <td>Sección:</td>
              <td><asp:DropDownList ID="SeccionDropDownList" runat="server" Height="24px" 
                        Width="130px" AutoPostBack = "true" onselectedindexchanged="SeccionDropDownList_SelectedIndexChanged"
                     ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td> 
            </tr>
         </tbody>
    </Table>
     </ContentTemplate>  
 </asp:UpdatePanel>

     <br />

      <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="300">  
      <asp:UpdatePanel ID="DatosUpdatePanel" runat="server" UpdateMode="Conditional" > 
     <ContentTemplate> 
    <asp:GridView ID="ListasCapacitacionesAprobacionGridView" runat="server" 
          AutoGenerateColumns="false" align = "center" DataKeyNames = "IdCapacitacion_Proyectada"
        
          CellPadding="3" CellSpacing="1" style="margin-left: 19px" Width="1035px" onrowcommand="ListasCapacitacionesAprobacionGridView_RowCommand" 
         >
     <Columns>

                  <asp:BoundField HeaderText="ID Capacitacion Proyectada" DataField="IdCapacitacion_Proyectada" visible ="false"
                        ItemStyle-Width="200">                   
                    </asp:BoundField>

					<asp:BoundField HeaderText="Curso" DataField="NombreCurso" 
                        ItemStyle-Width="650" >                    
                    </asp:BoundField>

                   <asp:BoundField HeaderText="Inicio" DataField="MesInicio" 
                        ItemStyle-Width="350" >                    
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Fin" DataField="MesFin" 
                        ItemStyle-Width="350" >                    
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Localidad" DataField="NombreLocalidad" 
                        ItemStyle-Width="300" >                    
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Área" DataField="NombreArea" 
                        ItemStyle-Width="300" >                    
                    </asp:BoundField>

                     <asp:BoundField HeaderText="Sección" DataField="NombreSeccion" 
                        ItemStyle-Width="400" >                    
                    </asp:BoundField>

                     <asp:BoundField HeaderText="Monto Total" DataField="SMonto" 
                        ItemStyle-Width="300" >                    
                    </asp:BoundField>

                     <asp:TemplateField HeaderText="Pre aprobado" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="250">
                                            <ItemTemplate>
                                                <asp:Button ID="PreaprobadoButton" runat="server" Text="+" CommandName="cmdMotivo" CommandArgument='<%# Eval("idCapacitacion_Proyectada") + "," + Eval("presupuesto_aprobado") %>' />
                                            </ItemTemplate>
                                    </asp:TemplateField>


                      <asp:BoundField HeaderText="Estado" DataField="Presupuesto_aprobado" 
                        ItemStyle-Width="300" >                    
                    </asp:BoundField>
                    
                   
             </Columns>
        <PagerSettings FirstPageText="First" />
    </asp:GridView>
   
     </ContentTemplate>  
 </asp:UpdatePanel>
  </asp:Panel>

      <br />
    

</asp:Content>


