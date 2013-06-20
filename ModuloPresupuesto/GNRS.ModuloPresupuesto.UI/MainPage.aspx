<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ModuloPresupuesto.Master" CodeBehind="MainPage.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.MainPage" %>
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
                  buttons: {
                      Ok: function () 
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
        function MostrarMensaje(mensaje) 
        {
            $("#dialog-message").text(mensaje).dialog("open");
        }
  </script>

   <div id="dialog-message" title="Modulo de Presupuesto">  </div>
   <asp:ScriptManager ID="ScriptManager1" runat="server">  
    
    </asp:ScriptManager> 

     <asp:UpdatePanel ID="MensajeUpdatePanel" runat="server" UpdateMode="Conditional"> 
       <ContentTemplate> 

       </ContentTemplate>  
 </asp:UpdatePanel>

</asp:Content>