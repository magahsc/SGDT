<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="ListarActividad.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.ListarActividad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="server">

<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
 
    
    
    
    <script>
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
                        // var scodigo = $(this).data("scodigo");
                        PageMethods.eliminar(sIdCapacitacion);

                        var clickButton = document.getElementById("<%= BuscarButton.ClientID %>");
                        clickButton.click();
                        $(this).dialog("close");

                    },
                    Cancel: function () {
                        $(this).dialog("close");
                    }
                }
            });




        });

        function mostrarMensajeConfirmacion(sIdCapacitacion, sco) {
            var texto = '¿Está seguro de eliminar el presupuesto ' + sco + ' ?';

            $("#dialog-confirmacion").text(texto).data("sIdCapacitacion", sIdCapacitacion).dialog("open");
            // $("#dialog-confirmacion").text(texto).data("scodigo", sIdCapacitacion).dialog("open");
        }   
       

      

        
  </script>

   <div id="dialog-confirmacion" title="Confirmacion de registro"></div>


    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true" >  
    
    </asp:ScriptManager> 

    Puede buscar los presupuestos de actividades proyectada por los siguientes 
    criterios:<br />

     <asp:UpdatePanel ID="CriteriosUpdatePanel" runat="server" UpdateMode="Conditional"> 
       <ContentTemplate> 
    <Table ID="Table2" runat="server">
         <tbody>

          <tr>
             <td>&nbsp;</td>
            
             <td>Mes de inicio de la actividad:</td>
             <td><asp:DropDownList ID="mesInicioDropDownList" runat="server" Height="24px" 
                        Width="140px" 
                     
                      ></asp:DropDownList></td>
 


                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Estado:</td>
              <td><asp:DropDownList ID="estadoDropDownList" runat="server" Height="24px" 
                        Width="152px" 
                        
                     ></asp:DropDownList></td>


            </tr>

         </tbody>
    </Table>
     </ContentTemplate>  
 </asp:UpdatePanel>

 

<asp:UpdatePanel ID="MensajeUpdatePanel" runat="server" UpdateMode="Conditional"> 
       <ContentTemplate> 
        <Table ID="Table1" runat="server">
         <tbody>

          <tr>
             <td><asp:Label ID="MensajeLabel" runat="server" Text="" Width="500"></asp:Label></td>
             
              <td><asp:Button ID="BuscarButton" runat="server" Text="Buscar" 
        Width="94px" onclick="BuscarButton_Click" /></td>

        

       </tr>
       </tbody>
       </Table>
  </ContentTemplate> 
</asp:UpdatePanel > 
  
 <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="300">  
 <asp:UpdatePanel ID="DatosUpdatePanel" runat="server" UpdateMode="Conditional" > 
  <ContentTemplate>
   
    <asp:GridView ID="ListaActividadProyectadaGridView" runat="server" 
          AutoGenerateColumns="false" align = "center"
        
          CellPadding="3" CellSpacing="1" 
         >
     <Columns>

                  <asp:BoundField HeaderText="ID Actividad Proyectada" DataField="Id_actividad_proyectada" visible ="false"
                        ItemStyle-Width="200">                   
                    </asp:BoundField>

					<asp:BoundField HeaderText="Codigo" DataField="Codigo_actividad" 
                        ItemStyle-Width="150" >                    
                    </asp:BoundField>

                   <asp:BoundField HeaderText="Nombre de la actividad" DataField="Nombre_actividad" 
                        ItemStyle-Width="300" >                    
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Monto Total" DataField="Monto_total" 
                        ItemStyle-Width="200" >                    
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Fecha de creación" DataField="Fecha_modificada" 
                        ItemStyle-Width="200" >                    
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Estado" DataField="Presupuesto_aprobado" 
                        ItemStyle-Width="200" >                    
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="center" HeaderStyle-Width="80px">
						<ItemTemplate>
							<asp:LinkButton ID="lnkEditar" runat="server" CommandName="CMDEditar" CommandArgument='<%#Eval("id_actividad_proyectada") %>'><img src="images/edit.gif" width="16" height="16" alt="editar" border="0" /></asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>

					 <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="center" HeaderStyle-Width="80px">
						<ItemTemplate>
							<asp:LinkButton ID="lnkEliminar" runat="server" CommandName="CMDEliminar" CommandArgument='<%#Eval("id_actividad_proyectada") %>'><img src="images/delete.gif" width="16" height="16" alt="eliminar" border="0" /></asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>


                   

                   
                   
    
             </Columns>
        <PagerSettings FirstPageText="First" />
    </asp:GridView>
   
     </ContentTemplate>  
 </asp:UpdatePanel>
 </asp:Panel>
    <br />
    <br />

</asp:Content>
