﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="ListarPresupuestoCapacitacion.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.ListarPresupuestoCapacitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="server">
     <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
 
    
    
    
    <script>
       $(document).ready(function() {
           
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

    Puede buscar los presupuestos de capactación proyectada por los siguientes 
    criterios<br />

     <asp:UpdatePanel ID="CriteriosUpdatePanel" runat="server" UpdateMode="Conditional"> 
       <ContentTemplate> 
    <Table ID="Table2" runat="server">
         <tbody>

          <tr>
             <td>&nbsp;</td>
            
             <td>Mes:</td>
             <td><asp:DropDownList ID="mesDropDownList" runat="server" Height="24px" 
                        Width="130px" 
                      AutoPostBack="True" 
                     onselectedindexchanged="mesDropDownList_SelectedIndexChanged" ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
 
              <td>Año:</td>
              <td><asp:DropDownList ID="anioDropDownList" runat="server" Height="24px" 
                        Width="130px" 
                        AutoPostBack="True" 
                      onselectedindexchanged="anioDropDownList_SelectedIndexChanged" ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       
                      
&nbsp;</td>

                <td>Estado:</td>
              <td><asp:DropDownList ID="estadoDropDownList" runat="server" Height="24px" 
                        Width="130px" 
                        AutoPostBack="True" 
                      onselectedindexchanged="estadoDropDownList_SelectedIndexChanged" ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       
                      
&nbsp;</td>


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
  
 <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="200">  
 <asp:UpdatePanel ID="DatosUpdatePanel" runat="server" UpdateMode="Conditional" > 
  <ContentTemplate>
   
    <asp:GridView ID="ListasCapacitarProyectadaGridView" runat="server" 
          AutoGenerateColumns="false" align = "center"
        
          CellPadding="3" CellSpacing="1"   
         >
     <Columns>

                  <asp:BoundField HeaderText="ID Capacitacion Proyectada" DataField="Id_presupuesto_capacitacion" visible ="false"
                        ItemStyle-Width="200">                   
                    </asp:BoundField>

					<asp:BoundField HeaderText="Codigo" DataField="Cod_presupuesto" 
                        ItemStyle-Width="300" >                    
                    </asp:BoundField>

                   <asp:BoundField HeaderText="Curso" DataField="Nombre_curso" 
                        ItemStyle-Width="300" >                    
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Monto Total" DataField="Smonto_total" 
                        ItemStyle-Width="300" >                    
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Fecha de creación" DataField="Fecha_creacion" 
                        ItemStyle-Width="300" >                    
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Estado" DataField="Presupuesto_aprobado" 
                        ItemStyle-Width="300" >                    
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="center" HeaderStyle-Width="80px">
						<ItemTemplate>
							<asp:LinkButton ID="lnkEditar" runat="server" CommandName="CMDEditar" CommandArgument='<%#Eval("id_presupuesto_capacitacion") %>'><img src="images/edit.gif" width="16" height="16" alt="editar" border="0" /></asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>

					<asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="center" HeaderStyle-Width="80px">
						<ItemTemplate>
						<asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("id_presupuesto_capacitacion") %>' Visible=false
                             ></asp:LinkButton>

                         <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%#Eval("cod_presupuesto") %>' Visible=false
                             ></asp:LinkButton>
                            
                         <button id="opesadner" onclick="mostrarMensajeConfirmacion('<%#Eval("id_presupuesto_capacitacion") %>', '<%#Eval("cod_presupuesto") %>');" >X</button>
                                            
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