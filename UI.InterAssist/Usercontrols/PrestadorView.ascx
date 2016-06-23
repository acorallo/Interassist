<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestadorView.ascx.cs" Inherits="UI.InterAssist.Usercontrols.PrestadorView" %>

<style type="text/css">
    .Nombre_Prestador
    {
        margin-left: 10px;
        font-size: 30px;
    }

    .Direccion_Prestador
    {
        margin-left: 10px;
        font-size: 15px;
    }

    .Table_Direccion
    {
        width: 100%;
    }

</style>

        <table class="Table_Direccion">
            <tr>
                <td><ext:Label runat="server" ID="lblNombreProveedor" CtCls="Nombre_Prestador"></ext:Label></td>
            </tr>
            <tr>
                <td><ext:Label runat="server" ID="lblDireccion" CtCls="Direccion_Prestador"></ext:Label>
                    <ext:Label runat="server" CtCls="Direccion_Prestador" ID="Separador_Direccion"></ext:Label>
                    <ext:Label runat="server" CtCls="Direccion_Prestador" ID="lblLocalidad_Prestadores"></ext:Label>
                </td>
            </tr>
            <tr>
                <td><ext:Label runat="server" ID="lblCiudad_Prestador" CtCls="Direccion_Prestador"/></td>
            </tr>
            <tr>
                <td><ext:Label runat="server" ID="lblProvincia_Prestador" CtCls="Direccion_Prestador"/></td>
            </tr>
            <tr>
                <td><ext:Label runat="server" ID="lblPais_Prestador" CtCls="Direccion_Prestador"/></td>
            </tr>
            <tr>
                <td><hr></hr></td>
            </tr>
            <tr>
                <td>
                  <ext:FieldSet 
                    runat="server"
                    Title="Contactos"
                    Collapsible="false"
                    Layout="form">
                    <Content>
                        <table>
                            <tr>
                                <td>
                                <ext:TextField 
                                        ID="TxtEmailPrestador" 
                                        runat="server" 
                                        Width="400"
                                        ReadOnly="true"/>
                                    </td>
                            </tr>
                            <tr>
                                <td><ext:TextField 
                                        ID="TxtNextelPrestador" 
                                        runat="server" 
                                        Width="400"
                                        ReadOnly="true"/>
                                               
                                    <ext:TextField 
                                        ID="TxtTelefonoPrestador" 
                                        runat="server" 
                                        ReadOnly="true"
                                        Width="400"/>
                                </td>
                            </tr>
                            <tr>
                                <td><ext:TextField 
                                        ID="TxtTelefono2Prestador" 
                                        runat="server" 
                                        ReadOnly="true"
                                        Width="400"/>
                                                
                                    <ext:TextField 
                                        ID="TxtCelularPrestador" 
                                        runat="server" 
                                        ReadOnly="true"
                                        Width="400"/>

                                    <ext:TextField 
                                        ID="TxtCelular2Prestador" 
                                        runat="server" 
                                        ReadOnly="true"
                                        Width="400"/>
                                </td>
                            </tr>
                        </table> 
                    </Content>
                  </ext:FieldSet>
                </td>
            </tr>
            <tr>
                <td>
                  <ext:FieldSet 
                    runat="server"
                    Title="Descripción"
                    Collapsible="false"
                    Layout="form">
                    <Items>
                        <ext:TextArea runat="server" Width="600" Height="100" ID="TxtDetallePrestador" HideLabel="true"/>
                    </Items>
                  </ext:FieldSet>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td style="font-weight: bold; color: #000066;">Tarifas:</td>
                        </tr>
                        <tr>
                            <td>
                        <table style="border: 1px solid #000000; width:600px">
                            <tr>
                                <td align="center">
                                    &nbsp;
				                </td>
                                <td align="center">
                                    <ext:Label ID="lblLiv" runat="server"></ext:Label>
                                </td>
                                <td align="center">
                                    <ext:Label ID="lblSp1" runat="server"></ext:Label>
                                </td>
                                <td align="center">
                                    <ext:Label ID="lblSp2" runat="server"></ext:Label>
                                </td>
                                <td align="center">
                                    <ext:Label ID="lblps1" runat="server"></ext:Label>
                                </td>
                                <td align="center">
                                    <ext:Label ID="lblPs2" runat="server"></ext:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="border-style: 1; border-width: 1px; border-color: #000000;">
                                    <ext:Label ID="lblMovida" runat="server"></ext:Label>
                                </td>
                                <td style="border: 1px solid #000000; margin-left: 80px;" align="right" nowrap="nowrap">
                                    <ext:Label 
                                    ID="txtLivMovida" 
                                    runat="server" 
                                    Width="50"/>
                                </td>
                                <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                <ext:Label 
                                    ID="txtSp1Movida" 
                                    runat="server" 
                                    ReadOnly="true"
                                    Width="50"/>
                                </td>
                                <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                    <ext:Label 
                                    ID="txtSp2Movida" 
                                    runat="server" 
                                    ReadOnly="true"
                                    Width="50"/>
                                </td>
                                <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                    <ext:Label 
                                    ID="txtPs1Movida" 
                                    runat="server" 
                                    ReadOnly="true"
                                    Width="50"/>
                                </td>
                                <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                    <ext:Label 
                                    ID="txtPs2Movida" 
                                    runat="server" 
                                    ReadOnly="true"
                                    Width="50"/>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="border-style: 1; border-width: 1px; border-color: #000000;">
                                    <ext:Label ID="lblkm" runat="server"></ext:Label>
                                </td>
                                <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                    <ext:Label 
                                    ID="txtLivKm" 
                                    runat="server" 
                                    ReadOnly="true"
                                    Width="50"/>
                                </td>
                                <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                    <ext:Label 
                                    ID="txtSp1Km" 
                                    runat="server" 
                                    ReadOnly="true"
                                    Width="50"/>
                                </td>
                                <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                    <ext:Label 
                                    ID="txtSp2Km" 
                                    runat="server" 
                                    ReadOnly="true"
                                    Width="50"/>
                                </td>
                                <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                    <ext:Label 
                                    ID="txtPs1Km" 
                                    runat="server" 
                                    ReadOnly="true"
                                    Width="50"/>
                                </td>
                                <td style="border: 1px solid #000000;" align="right" colspan="1" nowrap="nowrap">
                                    <ext:Label 
                                    ID="txtPs2Km" 
                                    runat="server" 
                                    ReadOnly="true"
                                    Width="50"/>
                                </td>
                            </tr>
                        </table>
                         </td>
                      </tr>
                    </table>              
                </td>
            </tr>

            </table>
        
        
        
     
         

