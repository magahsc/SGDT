<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="ListarPresupuestoCapacitacion.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.ListarPresupuestoCapacitacion" %>
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
                        PageMethods.eliminar(sIdCapacitacion, MostrarMensaje);
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

        function mostrarMensajeConfirmacion(sIdCapacitacion, sco, presupuestoaprobado) {
            if (presupuestoaprobado == "Pendiente") {
                var texto = '¿Está seguro que desea eliminar el presupuesto de capacitación proyectada ' + sco + '?';

                $("#dialog-confirmacion").text(texto).data("sIdCapacitacion", sIdCapacitacion).dialog("open");
                // $("#dialog-confirmacion").text(texto).data("scodigo", sIdCapacitacion).dialog("open");
            }
            if (presupuestoaprobado == "Aprobado") {
                var mensaje = 'Este presupuesto ha sido aprobado y no se puede eliminar';
                $("#dialog-message").text(mensaje).dialog("open");
            }
            if (presupuestoaprobado == "No aprobado") {
                var mensaje = 'Este presupuesto no ha sido aprobado y no se puede eliminar';
                $("#dialog-message").text(mensaje).dialog("open");
            }

        }


        function AbrirVentana(sIdCapacitacion, presupuestoaprobado) {

            if (presupuestoaprobado == "Pendiente") {
                var url = 'EditarPresupuestoCapacitacion.aspx?id=' + sIdCapacitacion;
                var strReturn = window.showModalDialog(url, null, 'status:no;dialogWidth:780px;dialogHeight:670px;dialogHide:true;help:no;scroll:yes');
                //window.open(url);

                //Refresh();
            }
            if (presupuestoaprobado == "Aprobado") {
                var mensaje = 'Este presupuesto ha sido aprobado y no se puede actualizar';
                $("#dialog-message").text(mensaje).dialog("open");
            }
            if (presupuestoaprobado == "No aprobado") {
                var mensaje = 'Este presupuesto no ha sido aprobado y no se puede actualizar';
                $("#dialog-message").text(mensaje).dialog("open");
            }
              

        }

        function MostrarMensaje(mensaje) {
            $("#dialog-message").text(mensaje).dialog("open");

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

   <div id="Div1" title="Modulo de Presupuesto">  </div>
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
  </script>

   <div id="dialog-message" title="Modulo de Presupuesto">  </div>

   <div id="dialog-confirmacion" title="Modulo de Presupuesto"></div>


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
                        Width="140px" 
                     ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
 
              <td>Año:</td>
              <td><asp:DropDownList ID="anioDropDownList" runat="server" Height="24px" 
                        Width="130px"  
                      ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       
                      
&nbsp;</td>

                <td>Estado:</td>
              <td><asp:DropDownList ID="estadoDropDownList" runat="server" Height="24px" 
                        Width="152px" 
                      ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       
                      
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
  
 <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="300">  
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

                    <asp:BoundField HeaderText="ID Capacitacion Proyectada Editar" DataField="IdEditar_presupuesto_capacitacion" visible ="false"
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

                    <asp:BoundField HeaderText="Fecha de creación" DataField="Fecha_modificada" 
                        ItemStyle-Width="300" >                    
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Estado" DataField="Presupuesto_aprobado" 
                        ItemStyle-Width="300" >                    
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="center" HeaderStyle-Width="80px">
						<ItemTemplate>
						<asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("idEditar_presupuesto_capacitacion") %>' Visible="false"
                             ></asp:LinkButton>

                             <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument='<%#Eval("presupuesto_aprobado") %>' Visible="false"
                             ></asp:LinkButton>

                         <button id="editar" onclick="AbrirVentana('<%#Eval("idEditar_presupuesto_capacitacion") %>', '<%#Eval("presupuesto_aprobado") %>');" >Editar</button>
                                            
                                            </ItemTemplate>

					</asp:TemplateField>

					<asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="center" HeaderStyle-Width="80px">
						<ItemTemplate>
						<asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("id_presupuesto_capacitacion") %>' Visible="false"
                             ></asp:LinkButton>

                         <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%#Eval("cod_presupuesto") %>' Visible="false"
                             ></asp:LinkButton>

                         <asp:LinkButton ID="LinkButton5" runat="server" CommandArgument='<%#Eval("presupuesto_aprobado") %>' Visible="false"
                             ></asp:LinkButton>
                            
                         <button id="opesadner" onclick="mostrarMensajeConfirmacion('<%#Eval("id_presupuesto_capacitacion") %>', '<%#Eval("cod_presupuesto") %>','<%#Eval("presupuesto_aprobado") %>');" >Eliminar</button>
                                            
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
