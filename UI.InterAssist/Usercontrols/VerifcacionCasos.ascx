<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VerifcacionCasos.ascx.cs" Inherits="UI.InterAssist.Usercontrols.VerifcacionCasos" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>

<style type="text/css">
    .Header_Afiliado {
        margin-left: 10px;
        font-size: 30px;
    }

    .Header_auto{
        font-size: 25px;
    }

    .Header_Tipo{
        font-size: 20px;
    }

   .Sin_Casos{
        font-size: 30px;
        color: green;
    }

    .Cantidad{
        font-size: 90px;
        color: red;
    }

</style>

<table class="auto-style1">
    <tr>
        <td>
            <table class="auto-style1">
                <tr>
                    <td class="Header_Afiliado"><ext:Label runat="server" id="lblCompania"/> - <ext:Label runat="server" id="lblPoliza"/></td>
                </tr>
                <tr>
                    <td class="Header_auto"><ext:Label runat="server" id="lblMarca"/> - <ext:Label runat="server" id="lblPatente"/></td>
                </tr>
                <tr>
                    <td class="Header_Tipo"><ext:Label runat="server" id="lblTipo"/></td>
                </tr>
                <tr>
                    <td><hr /></td>
                </tr>
                <tr>
                    <td runat="server" id="tdCantidadCasos">


                    </td>
                </tr>
                <tr>
                    <td class="Header_Afiliado">
                        <ext:Label runat="server" id="lblMesCorriente"/>
                    </td>
                </tr>
                <tr>
                    <td style="height:300px;vertical-align:middle">
                        <ext:Label ID="lblCantidadCasos" runat="server" CtCls="Cantidad"></ext:Label>
                        <ext:Label id="lblSinCasos" runat="server" CtCls="Sin_Casos"/>
                        <ext:GridPanel 
                        ID="GdPCasosAsignados"
                        runat="server" 
                        Width="200"
                        AutoHeight="true"> 
                        <Store>
                            <ext:Store ID="Store1" runat="server">
                                <Reader>
                                    <ext:JsonReader>
                                        <Fields>
                                            <ext:RecordField Name="TipoCaso"></ext:RecordField>
                                            <ext:RecordField Name="Cantidad"></ext:RecordField>
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                         </Store>
                        <ColumnModel runat="server" ID="ctl86">
                        <Columns>
                            <ext:Column Header="Tipo Caso" DataIndex="TipoCaso" Sortable="false" Fixed="true"/>
                            <ext:Column Header="Cantidad" DataIndex="Cantidad" Align="Right" Sortable="false" Fixed="true"/>   
                        </Columns>
                        </ColumnModel>
                        </ext:GridPanel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

