<%@ Page Language="C#" MasterPageFile="~/ModuloPresupuesto.Master" AutoEventWireup="true" CodeBehind="ConfiguracionPresupuesto.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.ConfiguracionPresupuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="server">
  <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
    
      <script>

          $(function () 
          {
              $("#dialog-message").dialog(
              {
                  modal: true,
                  autoOpen: false,
                  height: 200,
                  width: 500,
                  buttons: 
                  {
                      "Aceptar": function () 
                      {
                          $(this).dialog("close");
                      }
                  }
              });
              $("#dialog-message").css(
              {
                  fontSize: 15
              });
          });

  </script>

  <script type="text/javascript">

    function MostrarMensaje() 
    {
        var hdnSession = document.getElementById("<%= hdnSession.ClientID %>");
        var mensaje = hdnSession.value;
        $("#dialog-message").text(mensaje).dialog("open");
    }

    function MostrarMensajeError(mensaje) 
    {
        $("#dialog-message").text(mensaje).dialog("open");
    }

  </script>

   <div id="dialog-message" title="Modulo de Presupuesto">  </div>

     <asp:ScriptManager ID="ScriptManager1" runat="server">  
    
    </asp:ScriptManager> 

    <asp:Label ID="Label1" runat="server" Text="Seleccione el mes y el año donde empezarán a registrarse los presupuestos"></asp:Label>
    
    <asp:UpdatePanel ID="PanelUpdatePanel1" runat="server" UpdateMode="Conditional"> 
        <ContentTemplate> 
            <Table ID="Table2" runat="server" class="texto">
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
                            onselectedindexchanged="anioDropDownList_SelectedIndexChanged" ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">Descripción:</td>
                        <td colspan="3">
                            <asp:TextBox ID="descripcionPeriodoTextBox" runat="server" TextMode="MultiLine" 
                                Width="367px" Height="100px"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </Table>
        </ContentTemplate>  
    </asp:UpdatePanel>
     
     <br />

    <asp:UpdatePanel ID="BotonUpdatePanel" runat="server" UpdateMode="Conditional"> 
       <ContentTemplate> 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="CerrarButton" runat="server" Text="Cerrar presupuesto"  
               CssClass="button_example" onclick="CerrarButton_Click"/>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="GuardarButton" runat="server" Text="Guardar" onclick="GuardarButton_Click" CssClass="button_example"/>
            <asp:HiddenField ID="hdnSession" runat="server" />  
       </ContentTemplate>  
    </asp:UpdatePanel>

</asp:Content>
