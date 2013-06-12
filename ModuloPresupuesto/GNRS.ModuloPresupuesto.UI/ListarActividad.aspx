<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="ListarActividad.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.ListarActividad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="server">

<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
 
     <script>
         function Refresh() {
             var clickButton = document.getElementById("<%= BuscarButton.ClientID %>");
             clickButton.click();
             /* __doPostBack('BuscarButton', '');
             __doPostBack('DatosUpdatePanel', '');
             __doPostBack('CriteriosUpdatePanel', '');
             __doPostBack('MensajeUpdatePanel', '');*/
         }
   </script>

    
     <script>
         $(function () {
             $("#dialog-mensajes").dialog({
                 modal: true,
                 autoOpen: false,
                 height: 200,
                 width: 500,
                 autoOpen: false,
                 buttons: {
                     "Aceptar": function () {
                         $(this).dialog("close");
                     }
                 }
             });
             $("#dialog-mensajes").css({
                 fontSize: 15
             });

         });
         
  </script>
    
    <script>
        $(document).ready(function () {

            $("#dialog-confirmacion").dialog({
                autoOpen: false,
                draggable: true,

                height: 200,
                width: 450,
                modal: true,
                buttons: {
                    "Aceptar": function () {
                        //var sIdActividad = $(this).data("sIdActividad");
                        var hdnSession1 = document.getElementById("<%= hdnSession1.ClientID %>");
                        var sIdActividad = hdnSession1.value;
                        var hdnSession2 = document.getElementById("<%= hdnSession2.ClientID %>");
                        var sco = hdnSession2.value;
                        PageMethods.eliminar(sIdActividad, sco, MostrarMensajeFinal);

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


        function AbrirVentana(sId,presupuestoaprobado) {
            if (presupuestoaprobado == "Pendiente") {
                var url = 'EditarActividad.aspx?id=' + sId;
                var strReturn = window.showModalDialog(url, null, 'status:no;dialogWidth:760px;dialogHeight:450px;dialogHide:true;help:no;scroll:yes');
                //window.open(url);

                //Refresh();
            }

            if (presupuestoaprobado == "Aprobado") {
                var mensaje = 'Esta actividad ha sido aprobada y no se puede actualizar';
                $("#dialog-mensajes").text(mensaje).dialog("open");
            }
            if (presupuestoaprobado == "No aprobado") {
                var mensaje = 'Esta actividad no ha sido aprobada y no se puede actualizar';
                $("#dialog-mensajes").text(mensaje).dialog("open");
            }

        }

        function mostrarMensajeConfirmacion(id, sco, presupuestoaprobado) {
            if (presupuestoaprobado == "Pendiente") {
                var hdnSession2 = document.getElementById("<%= hdnSession2.ClientID %>");
                hdnSession2.value = sco;
                var hdnSession1 = document.getElementById("<%= hdnSession1.ClientID %>");
                hdnSession1.value = id;
                var texto = '¿Está seguro que desea eliminar el presupuesto de actividad de RRHH ' + sco + '?';

                $("#dialog-confirmacion").text(texto).dialog("open");
            }
            if (presupuestoaprobado == "Aprobado") {
                var mensaje = 'Esta actividad ha sido aprobada y no se puede eliminar';
                $("#dialog-mensajes").text(mensaje).dialog("open");
            }
            if (presupuestoaprobado == "No aprobado") {
                var mensaje = 'Esta actividad no ha sido aprobada y no se puede eliminar';
                $("#dialog-mensajes").text(mensaje).dialog("open");
            }
        }

        function MostrarMensajeFinal(mensaje) {
            $("#dialog-mensajes").text(mensaje).dialog("open");

        }
       

  </script>

   <div id="dialog-confirmacion" title="Modulo de Presupuesto"></div>
   <div id="dialog-mensajes" title="Modulo de Presupuesto">  </div>

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
            
             <td>Mes de inicio:</td>
             <td><asp:DropDownList ID="mesInicioDropDownList" runat="server" Height="24px" 
                        Width="140px" ></asp:DropDownList></td>
 


                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Año inicio:</td>
             <td><asp:DropDownList ID="anioInicioDropDownList" runat="server" Height="24px" 
                        Width="140px"></asp:DropDownList></td> 

            </tr>

            <tr>
             <td>&nbsp;</td>
            
             <td>Mes de fin:</td>
             <td><asp:DropDownList ID="mesFinDropDownList" runat="server" Height="24px" 
                        Width="140px" ></asp:DropDownList></td>
 


                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Año fin:</td>
             <td><asp:DropDownList ID="anioFinDropDownList" runat="server" Height="24px" 
                        Width="140px"></asp:DropDownList></td> 
            </tr>
             
            
            <tr>
             <td>&nbsp;</td>
              <td>Estado:</td>
            <td><asp:DropDownList ID="estadoDropDownList" runat="server" Height="24px" 
                        Width="140px" 
                        
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
       
       <asp:HiddenField ID="hdnSession1" runat="server" />
       <asp:HiddenField ID="hdnSession2" runat="server" />
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

                    <asp:BoundField HeaderText="ID Actividad Proyectada Editar" DataField="IdEditar_Actividad" visible ="false"
                        ItemStyle-Width="200">                   
                    </asp:BoundField>

					<asp:BoundField HeaderText="Codigo" DataField="Codigo_actividad" 
                        ItemStyle-Width="150" >                    
                    </asp:BoundField>

                   <asp:BoundField HeaderText="Nombre de la actividad" DataField="Nombre_actividad" 
                        ItemStyle-Width="300" >                    
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Monto Total" DataField="Monto_total" 
                        ItemStyle-Width="150" >                    
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Fecha de inicio" DataField="FechaInicio" 
                        ItemStyle-Width="150" >                    
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Fecha de fin" DataField="FechaFin" 
                        ItemStyle-Width="150" >                    
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Estado" DataField="Presupuesto_aprobado" 
                        ItemStyle-Width="150" >                    
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="center" HeaderStyle-Width="80px">
						<ItemTemplate>
							<asp:LinkButton ID="lnkEditar" runat="server" CommandName="CMDEditar" CommandArgument='<%#Eval("idEditar_Actividad") %>'></asp:LinkButton>
                            
                            
                             <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument='<%#Eval("presupuesto_aprobado") %>' Visible="false"
                             ></asp:LinkButton>

                            <button id="editar" onclick="AbrirVentana('<%#Eval("idEditar_Actividad") %>','<%#Eval("presupuesto_aprobado") %>');" >Editar</button>
                         </ItemTemplate>
					</asp:TemplateField>

					
					<asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="center" HeaderStyle-Width="80px">
						<ItemTemplate>

                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("id_actividad_proyectada") %>' Visible="false"
                             ></asp:LinkButton>

                         <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%#Eval("codigo_actividad") %>' Visible="false"
                             ></asp:LinkButton>

                        <asp:LinkButton ID="LinkButton5" runat="server" CommandArgument='<%#Eval("presupuesto_aprobado") %>' Visible="false"
                             ></asp:LinkButton>
                            
                         <button id="opesadner" onclick="mostrarMensajeConfirmacion('<%#Eval("id_actividad_proyectada") %>', '<%#Eval("codigo_actividad") %>','<%#Eval("presupuesto_aprobado") %>');" >Eliminar</button>
                                            
                        
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
