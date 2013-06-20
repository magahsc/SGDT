<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ConceptosPersonal.aspx.cs" Inherits="GNRS.ModuloPresupuesto.UI.ConceptosPersonal" %>
 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
 <link rel="stylesheet" type="text/css" href="styles/gnrs.css" />
<body>
 <form id="Form1" runat="server">
 
  <script>
        function validateDecimales(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            if (charCode == 46) {
                var monto = document.getElementById("MontoTextBox").value;
                if (monto.indexOf(".") != -1)
                    return false;
            }
                   
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
            <table ID="Table1" runat="server" align="center" class="texto">
                 <tbody>
                    <tr >
                        <td style="width:120px">Tipo de concepto</td>
                        <td style="width:5px">:</td>
                        <td style="width:150px" ><asp:DropDownList ID="TipoConceptoComboBox" runat="server" AutoPostBack="True"
                                onselectedindexchanged="TipoConceptoComboBox_SelectedIndexChanged"  Width="100%">
                               <asp:ListItem Text="Ingresos" Value="1"></asp:ListItem>  
                              <asp:ListItem Text="Descuentos" Value="2"></asp:ListItem>  
                              <asp:ListItem Text="Aportaciones" Value="3"></asp:ListItem>  
                                </asp:DropDownList></td>
                    </tr>

                      
                        <tr>
                            <td >Concepto</td>
                            <td>:</td>
                            <td ><asp:DropDownList ID="ConceptoComboBox" runat="server" AutoPostBack="True"  Enabled="false"
                                    onselectedindexchanged="ConceptoComboBox_SelectedIndexChanged" ></asp:DropDownList></td>
                        </tr>
                   

                    
                    <tr>
                        <td >Monto</td>
                        <td>:</td>
                        <td ><asp:TextBox ID="MontoTextBox" onkeypress='return validateDecimales(event)'  runat="server" Width="25%"></asp:TextBox></td>
                    </tr>
         
                    <tr>                
                        <td colspan="3" align="right">
                           <asp:Button ID="AgregarButton" runat="server" Text="Agregar" 
                                onclick="AgregarButton_Click" CssClass="button_example" />
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" align="center">

                                      
                        </td>

                    </tr>

                  
                    
                 </tbody>
            </table>

            <div align="center">
                <asp:GridView ID="ConceptosGridView" runat="server" AutoGenerateColumns="false" 
                    onrowcommand="ConceptosGridView_RowCommand" >
                        <HeaderStyle CssClass="GridHeader" />
		                <RowStyle CssClass="GridRow" HorizontalAlign="Center" />
                        <AlternatingRowStyle CssClass="GridAlternateRow" HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField DataField="TipoConcepto_Texto" HeaderText="Tipo Concepto" />
                    <asp:BoundField DataField="Concepto_Texto" HeaderText="Concepto" />
                    <asp:BoundField DataField="Monto" HeaderText="Monto" />   
                    <asp:TemplateField HeaderText="Editar" >
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEditar" runat="server" CommandName="cmdEditar" CommandArgument='<%# Eval("Cod") %>' ImageUrl="~/images/edit.png"/>
                        </ItemTemplate>                       
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Eliminar" >
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEliminar" runat="server" CommandName="cmdEliminar" CommandArgument='<%# Eval("Cod") %>' ImageUrl="~/images/delete.gif"/>
                        </ItemTemplate>                       
                    </asp:TemplateField>
                </Columns>
                </asp:GridView>                               
            </div>
            
<asp:TextBox ID="nroConceptoPersonal" runat="server" Text="0"  BorderWidth=0 ForeColor=White ></asp:TextBox>


  </ContentTemplate> 
  </asp:UpdatePanel>

 
  </form>
</body>
</html>

