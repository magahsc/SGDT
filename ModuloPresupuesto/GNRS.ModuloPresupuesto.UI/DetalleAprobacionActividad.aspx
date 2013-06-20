<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleAprobacionActividad.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.DetalleAprobacionActividadspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="styles/gnrs.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" 
    EnablePartialRendering="true">  
    
    </asp:ScriptManager> 
       
     <asp:UpdatePanel ID="ComboBoxUpdatePanel" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate>   
           

           <div id="MotivoDiv" runat="server" style="width:100%;">
                <table style="width:100%;">
                    <tr>
                        <td><asp:label id="lbl" runat="server" >Observacion :</asp:label></td>
                    </tr>
                    <tr>
                        <td>
                             <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="100%" Rows="5" ReadOnly="true"></asp:TextBox>                        
                        </td>
                    </tr>
                </table>
                

           </div>
         


  </ContentTemplate> 
  </asp:UpdatePanel>

 
    

    </form>
</body>
</html>
