<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleAprobacionPersonal.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.ListaConceptosPersonal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
           <div id="RemuneracionDiv" runat="server" align="center">
            <asp:GridView ID="ConceptosGridView" runat="server" AutoGenerateColumns="false"
                                 >
                                    <HeaderStyle CssClass="GridHeader" />
		                            <RowStyle CssClass="GridRow" HorizontalAlign="Center" />
                                    <AlternatingRowStyle CssClass="GridAlternateRow" HorizontalAlign="Center" />
                               
                                <Columns>
                                    <asp:BoundField DataField="TipoConcepto_Texto" HeaderText="Tipo Concepto" ItemStyle-Width="200"/>
                                    <asp:BoundField DataField="Concepto_Texto" HeaderText="Concepto" ItemStyle-Width="300"/>
                                    <asp:BoundField DataField="Monto" HeaderText="Monto" ItemStyle-Width="200"/>
                                    
                                    <asp:BoundField DataField="Costo_empresa" HeaderText="Costo Empresa" ItemStyle-Width="200"/>

                                    <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-Width="200"/>
                                  
                                    
                                </Columns>
                               </asp:GridView>  
           </div>  

           <div id="MotivoDiv" runat="server" style="width:100%;">
                <table style="width:100%;">
                    <tr>
                        <td><label>Motivo :</label></td>
                    </tr>
                    <tr>
                        <td colspan="5">
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
