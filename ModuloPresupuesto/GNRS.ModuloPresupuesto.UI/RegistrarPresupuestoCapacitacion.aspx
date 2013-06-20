<%@ Page Title="" Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="RegistrarPresupuestoCapacitacion.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.RegistrarPresupuestoCapacitacion" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="server">
      <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
 
<br />
    <br />

    
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

      function registroExitoso() {

          var codigo = document.getElementById("contenido_codHidden").value;

          var mensaje = "El presupuesto de capacitación proyectada " + codigo + " ha sido guardado existosamente";
          $("#dialog-message").text(mensaje).dialog("open");
      }

      function confirmarRegistro(mensaje) {

          var aklsjdlds = mensaje;
          $("#dialog-confirmacion").text(mensaje).dialog("open");
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
                   "Sí": function () {
                       document.getElementById("contenido_registrarHidden").value = "si";
                       document.getElementById("contenido_GuardarButton1").click();
                       $(this).dialog("close");


                   },
                   "No": function () {
                       document.getElementById("contenido_registrarHidden").value = "no";

                       $(this).dialog("close");


                   }
               }
           });
           $("#dialog-confirmacion").css({
               fontSize: 15
           });

       });
  </script>
  
  <script type="text/javascript">
<!--
      function confirmation() {
          var answer = confirm("¿Desea guardar el presupuesto?")
          if (answer) {
              PageMethods.Guardar();
              //alert("Bye bye!")


          }
          else {
              //alert("")
          }
      }
//-->
</script>

 <div id="dialog-message" title="Módulo de Presupuesto">  </div>
 <div id="dialog-confirmacion" title="Módulo de Presupuesto">  </div>
 <div id="dialog-datos-incompletos" title="Módulo de Presupuesto">  </div>
  
  <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" 
    EnablePartialRendering="true">  
    
    </asp:ScriptManager> 
    &nbsp;&nbsp;&nbsp;&nbsp;
    Información relacionada a la capacitación:
    &nbsp;&nbsp;&nbsp;&nbsp;



     <asp:UpdatePanel ID="ComboBoxUpdatePanel1" runat="server" UpdateMode="Conditional"> 
  <ContentTemplate>  
  <Table ID="Table1" runat="server" style="height: 50px; width: 450px;">
         <tbody>

            <tr>
                <td style="width: 74px; height: 33px;">Instituto:</td>
                <td style="height: 33px"><asp:DropDownList ID="InstitutoDropDownList" 
                        runat="server" Height="24px" 
                        Width="169px" 
                        onselectedindexchanged="InstitutoDropDownList_SelectedIndexChanged"  AutoPostBack="True"></asp:DropDownList></td>
            </tr>

             <tr>
                <td style="width: 74px">Curso:</td>
                <td><asp:DropDownList ID="CursoDropDownList" runat="server" Height="24px" 
                        Width="171px" 
                        onselectedindexchanged="CursoDropDownList_SelectedIndexChanged"  AutoPostBack="True"></asp:DropDownList></td>
            </tr>
         </tbody>
    </Table>
     </ContentTemplate>  
 </asp:UpdatePanel>
  
    <br />
     <asp:UpdatePanel ID="ComboBoxUpdatePanel2" runat="server" UpdateMode="Conditional"> 
      <ContentTemplate>  
    <Table ID="Table2" runat="server">
         <tbody>

            <tr>
             <td>Localidad:</td>
             <td><asp:DropDownList ID="LocalidadDropDownList" runat="server" Height="24px" 
                        Width="130px" 
                     onselectedindexchanged="LocalidadDropDownList_SelectedIndexChanged"  AutoPostBack="True" ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
 
              <td>Area:</td>
              <td><asp:DropDownList ID="AreaDropDownList" runat="server" Height="24px" 
                        Width="130px" 
                      onselectedindexchanged="AreaDropDownList_SelectedIndexChanged"  AutoPostBack="True" ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>

              <td>Sección:</td>
              <td><asp:DropDownList ID="SeccionDropDownList" runat="server" Height="24px" 
                        Width="130px" 
                      onselectedindexchanged="SeccionDropDownList_SelectedIndexChanged"   AutoPostBack="True"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td> 
            </tr>

         </tbody>
    </Table>
     </ContentTemplate>  
</asp:UpdatePanel>

    &nbsp;


   <br />
   
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="200">  
     <asp:UpdatePanel ID="DatosGridView" runat="server" UpdateMode="Conditional"> 
      <ContentTemplate>
   
        <asp:GridView ID="ListaPersonasCapacitarGridView" runat="server" 
          AutoGenerateColumns="false" align = "center" DataKeyNames = "Id_persona"
        
        onpageindexchanging="ListaPersonasCapacitarGridView_PageIndexChanging" 
          CellPadding="3" CellSpacing="1" 
        AllowPaging="True" PageSize="100" onselectedindexchanged="ListaPersonasCapacitarGridView_SelectedIndexChanged" 
         >
     <Columns>

                  <asp:BoundField HeaderText="ID Usuario" DataField="Id_persona" visible ="false"
                        ItemStyle-Width="200"> 
                    
                    </asp:BoundField>

					<asp:BoundField HeaderText="Nombres y apellidos" DataField="Nombre_persona" 
                        ItemStyle-Width="300" >
                    
                    </asp:BoundField>

                   <asp:BoundField HeaderText="Puesto de trabajo" DataField="Cargo_persona" 
                        ItemStyle-Width="300" >
                    
                    </asp:BoundField>

                   <asp:TemplateField HeaderText="">
                    <ItemTemplate >

                      <asp:CheckBox ID="SelectCheckBox" runat="server" AutoPostBack="true" 
                         oncheckedchanged="SelectCheckBox_CheckedChanged" />        

                    </ItemTemplate>
                   </asp:TemplateField>

             </Columns>
        <PagerSettings FirstPageText="First" />
    </asp:GridView>
   
     </ContentTemplate>  
 </asp:UpdatePanel>
 </asp:Panel>
 
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:CheckBox ID="MarcarTodosCheckBox" runat="server"  AutoPostBack="True"
        Text=" Capacitar a todos" Font-Size="Small" oncheckedchanged="MarcarTodosCheckBox_CheckedChanged" 
        />
    <br />
    <br />
     <asp:UpdatePanel ID="LabelUpdatePanel" runat="server" UpdateMode="Conditional"> 
      <ContentTemplate>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
     <Table ID="Table3" runat="server">
         <tbody>
          <tr>
            <td>Monto total de presupuesto: </td>
             <td><asp:Label ID="MontoPresupuestoLabel" runat="server" Text="0.0"></asp:Label></td>
          </tr>
       </tbody>
    </Table>
   
         </ContentTemplate>  
 </asp:UpdatePanel>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
   <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate>  
     
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
     
      <asp:Button ID="GuardarButton1" runat="server" Text="Guadar Presupuesto" 
        onclick="GuardarButton1_Click"/>
    
          </ContentTemplate>
</asp:UpdatePanel>
    <br />



    <asp:UpdatePanel ID="UpdatePanelHidden" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate>  
   <input type="hidden" name="registrarHidden" id="registrarHidden" runat="server" />
     
   <input type="hidden" name="codHidden" id="codHidden" runat="server" />
   </ContentTemplate>
</asp:UpdatePanel>

  </asp:Content>
