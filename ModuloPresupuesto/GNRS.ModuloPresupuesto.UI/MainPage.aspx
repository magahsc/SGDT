<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ModuloPresupuesto.Master" CodeBehind="MainPage.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.MainPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="server">
 <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" />
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
    
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
  </script>

    <script>

        function MostrarMensaje(mensaje) {
            $("#dialog-message").text(mensaje).dialog("open");

        }
  </script>
  
</asp:Content>