<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleAprobacionPersonal.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.ListaConceptosPersonal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" 
    EnablePartialRendering="true">  
    
    </asp:ScriptManager> 
       
     <asp:UpdatePanel ID="ComboBoxUpdatePanel" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate>   
           <div id="RemuneracionDiv" runat="server">
            <asp:GridView ID="ConceptosGridView" runat="server" AutoGenerateColumns="false" 
                                 >
                                <Columns>
                                    <asp:BoundField DataField="TipoConcepto_Texto" HeaderText="Tipo Concepto" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
                                    <asp:BoundField DataField="Concepto_Texto" HeaderText="Concepto" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
                                    <asp:BoundField DataField="Monto" HeaderText="Monto" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
                                    
                                    <asp:BoundField DataField="Costo_empresa" HeaderText="Costo Empresa" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>

                                    <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
                                  
                                    
                                </Columns>
                               </asp:GridView>  
           </div>  

           <div id="MotivoDiv" runat="server">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" ></asp:TextBox>
           </div>
         


  </ContentTemplate> 
  </asp:UpdatePanel>

 
    

    </form>
</body>
</html>
