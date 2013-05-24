<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ConceptosPersonal.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.ConceptosPersonal" %>
 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<body>
 <form id="Form1" runat="server">
 
  <script>
        function validateDecimales(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;


            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
  </script>
  <body onbeforeunload="terminate();">
  
  <script>
      

   function terminate() {

       var cantidad = document.getElementById("nroConceptoPersonal").value;
       var o = new Object();       
       if (cantidad == null) {
           cantidad = "0";
                 }
       o.valor = cantidad;
       window.returnValue = o;

       
   }


</script>



  <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" 
    EnablePartialRendering="true">  
    
    </asp:ScriptManager> 
       
     <asp:UpdatePanel ID="ComboBoxUpdatePanel" runat="server" UpdateMode="Conditional"> 
     <ContentTemplate>   
            <Table ID="Table1" runat="server" >
                 <tbody>
                    <tr >
                        <td align="right" >Tipo de concepto:</td>
                        <td><asp:DropDownList ID="TipoConceptoComboBox" runat="server"                                 
                                AutoPostBack="True" Height="20px" Width="130px" 
                                onselectedindexchanged="TipoConceptoComboBox_SelectedIndexChanged" >
                               <asp:ListItem Text="Ingresos" Value="1"></asp:ListItem>  
                              <asp:ListItem Text="Descuentos" Value="2"></asp:ListItem>  
                              <asp:ListItem Text="Aportaciones" Value="3"></asp:ListItem>  
                                </asp:DropDownList></td>
                    </tr>

                      
                        <tr>
                            <td align="right">Concepto:</td>
                            <td><asp:DropDownList ID="ConceptoComboBox" runat="server" Height="20px" 
                                    Width="130px" AutoPostBack="True"  Enabled=false 
                                    onselectedindexchanged="ConceptoComboBox_SelectedIndexChanged"></asp:DropDownList></td>
                        </tr>
                   

                    
                    <tr>
                        <td align="right">Monto:</td>
                        <td><asp:TextBox ID="MontoTextBox" onkeypress='return validateDecimales(event)'  runat="server" Height="20px" Width="130px" ></asp:TextBox></td>
                    </tr>
         
                    <tr>                
                        <td colspan="2" align="right">
                           <asp:Button ID="AgregarButton" runat="server" Text="Agregar" 
                                onclick="AgregarButton_Click" />
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2" align="center">
                             <asp:GridView ID="ConceptosGridView" runat="server" AutoGenerateColumns="false" 
                                 onrowcommand="ConceptosGridView_RowCommand" >
                                <Columns>
                                    <asp:BoundField DataField="TipoConcepto_Texto" HeaderText="Tipo Concepto" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
                                    <asp:BoundField DataField="Concepto_Texto" HeaderText="Concepto" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
                                    <asp:BoundField DataField="Monto" HeaderText="Monto" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
                                  
                                    <asp:TemplateField HeaderText="Editar" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEditar" runat="server" CommandName="cmdEditar" CommandArgument='<%# Eval("Cod") %>'>
                                                    E
                                                </asp:LinkButton>
                                              </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Button1" runat="server" Text="X"  CommandName="cmdEliminar" CommandArgument='<%# Eval("Cod") %>'></asp:LinkButton>
                       
                                              </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                               </asp:GridView>  
                               
                                      
                        </td>

                    </tr>

                  
                    
                 </tbody>
            </Table>


<asp:TextBox ID="nroConceptoPersonal" runat="server" Text="0"  BorderWidth=0 ForeColor=White ></asp:TextBox>


  </ContentTemplate> 
  </asp:UpdatePanel>

 
  </form>
</body>
</html>

