<%@ Page Title="" Language="C#" MasterPageFile="~/InterAssist.Master" AutoEventWireup="true" CodeBehind="Afiliados.aspx.cs" Inherits="UI.InterAssist.Views.Afiliados" %>

<%@ Register Src="~/Usercontrols/VerifcacionCasos.ascx" TagPrefix="uc1" TagName="VerifcacionCasos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../Scripts/jquery-2.1.4.min.js"></script>
    <style type="text/css">
        .style3
        {
            height: 34px;
        }

        .style_Count{
            cursor: pointer;
        }

        .contadorPane
        {
            background-color: rgb(247, 255, 171);
            width:200px;
            position: absolute;
            top:20px;
            left:50px;
        }

        .check_disc_caso{
            margin-left : 50px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" AsyncPostBackTimeout="99999999"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

    <ext:ResourceManager runat="server" />
    <script type="text/javascript">

        function verificarCaso(idPoliza, idAfiliado) {
            Ext.net.DirectMethods.VerificarCasos(idPoliza, idAfiliado);
        }


        function _chkAceptarInfoCasos_check()
        {
            ContentPlaceHolder1_btnContinuarCaso.setDisabled(!ContentPlaceHolder1_chkAceptarInfoCasos.checked);
        }
        </script>


    <table class="style1">
        <tr>
            <td class="style3" align="right">
                        <asp:TextBox ID="txtSearch" runat="server" MaxLength="255" 
                    Width="250px"></asp:TextBox>
                        &nbsp;<asp:Button ID="btnBuscar" runat="server" 
                    onclick="btnBuscar_Click" />
                        &nbsp;<asp:Button ID="btnFreeSeacrh" runat="server" 
                            onclick="btnFreeSeacrh_Click" />
                    </td>
        </tr>
            <div id="divListado" runat="server">
        <tr>
            <td align="left">
                <table class="style1">
                    <tr>
                        <div id="divCantregistros" runat="server">
                        <td>
                            <asp:Label ID="lblCantRegistros" runat="server" 
                                CssClass="LblRegistrosFiltradas"></asp:Label>
                        </td>
                        <td width="100%">
                            <asp:Label ID="lbltxtCantidadRegistros" runat="server" 
                                CssClass="LblCantRegistrosFiltradas"></asp:Label>
                        </td>
                        </div>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <div id="divGrid" runat="server">
            <td>
                <asp:DataGrid ID="dtgAfiliados" runat="server" AllowCustomPaging="True" 
                    AllowPaging="True" AutoGenerateColumns="False" 
                    onitemcommand="dtgAfiliados_ItemCommand" 
                    onitemdatabound="dtgAfiliados_ItemDataBound" 
                    onpageindexchanged="dtgAfiliados_PageIndexChanged" 
                    onselectedindexchanged="dtgAfiliados_SelectedIndexChanged" PageSize="20" 
                    Width="100%" CssClass="RowGrid">
                    <Columns>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:ButtonColumn></asp:ButtonColumn>
                        <asp:ButtonColumn></asp:ButtonColumn>
                    </Columns>
                    <HeaderStyle CssClass="HeaderGrid" Font-Bold="True" Font-Italic="False" 
                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                        HorizontalAlign="Center" />
                    <ItemStyle CssClass="RowGrid" />
                    <PagerStyle HorizontalAlign="Center" Mode="NumericPages" />
                </asp:DataGrid>
            </td>
            </div>
        </tr>
        <tr><div id="divNonResult" runat="server" visible="false">
            <td align="left">
                <asp:Label ID="lblNonResults" runat="server" Class="SinRegistros"></asp:Label>
            </td></div>
        </tr>
            </div>


        <tr>
            <td>&nbsp; &nbsp;</td></tr>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnCrearNUevo" runat="server" onclick="btnCrearNUevo_Click" />
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">


        $(function ()
        {
            $('#divContador').hide();
        })

        function contarCasos(e, value) {
            showContador(e, value);
        }


        function showContador(e, poliza)
        {
            $('#idspanPoliza').text(poliza)
            var left = e.clientX + "px";
            var top = e.clientY + "px";
            $('#divContador').toggle(150).css("top", top).css("left", left).css("position", "fixed");
            $('#divContador').show();

            BuscarContador(poliza);
        }

        function OcultarContador()
        {
            $('#divContador').hide();
        }

        function BuscarContador(poliza)
        {
            $.ajax({
                type: "POST",
                url: "Afiliados.aspx/getCasos",
                data: "{Poliza:'" + poliza + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: BuscarContador_Succeded,
                failure: function (response) {
                    alert('No se pudo obtener el dato desde el servidor.');
                }
            });
        }

       
        function BuscarContador_Succeded(response)
        {
            tblContadorDeleteRow();
            if(response.d!=null)
            {
                if(response.d.Cantidad==0)
                {
                    // Notifica que no hay casos mostra.
                    ShowContador(false);
                    ShowSinCasos(true);
                }
                else {
                    // Notifica que hay casos mostrar.
                    ShowContador(true);
                    ShowSinCasos(false);
                    if(response.d.Casos)
                    {
                        var tope = response.d.Casos.length;

                        for(var i=0;i<tope;i++)
                        {
                            var TipoCaso = response.d.Casos[i].TipoCaso;
                            var Cantidad = response.d.Casos[i].Cantidad;

                            $("#idTblContador").append('<tr><td>' + TipoCaso + '</td><td>' + Cantidad + '</td></tr>');

                        }

                        $("#idTblContador").append('<tr><td>Total</td><td>' + response.d.Cantidad + '</td></tr>');

                    }
                }
            }
            else
            {
                window.alert('No se pudo obtener el dato desde el servidor.');
            }

        }

        function tblContadorDeleteRow()
        {
            while($("#idTblContador tr").length>1)
                $("#divContador tr").last().remove();
   
        }

        function ShowContador(value)
        {
            if(value)
            {
                $("#idTblContador").show();
            } else {
                $("#idTblContador").hide();
            }

        }

        function ShowSinCasos(value)
        {
            if (value) {
                $("#idSpanSinCasos").show();
            } else {
                $("#idSpanSinCasos").hide();
            }

        }

    </script>

    <div id="divContador" class="contadorPane">
       <h3>Poliza: <span id="idspanPoliza"></span></h3>
       <h4>Mes Corriente</h4>
       <table id="idTblContador">
           <tr>
               <th>Tipo Servicio</th>
               <th>Cantidad</th>
           </tr>
       </table> 
       <span id="idSpanSinCasos"><p>No tiene casos registrados</p></span>
    </div>

    

       <ext:Window 
        ID="WdoInformacionCasos" 
        runat="server" 
        Icon="information" 
        Hidden="true" 
        Width="650"
        Modal="true"
        Height="600"
        BodyStyle="background-color: #fff">
        
        <Content>

            <table width="100%">
                <tr>
                    <td><uc1:VerifcacionCasos runat="server" ID="VerifcacionCasos" /></td>

                </tr>
                <tr>
                    <td style="padding:10px">

                    <ext:Checkbox ID="chkAceptarInfoCasos" runat="server" Checked="false">
                        <Listeners>
                            <Check Handler="_chkAceptarInfoCasos_check();" />
                        </Listeners>
                    </ext:Checkbox>

                    </td>

                </tr>
                <tr>
                    <td style="padding:10px">
                        <br />
                <ext:Button ID="btnContinuarCaso" runat="server" Disabled="true">
                    <DirectEvents> 
                        <Click OnEvent="ContinuarCaso" />
                    </DirectEvents>
                </ext:Button>  
                    </td>

                </tr>
            </table>


            


            
            
        </Content>


        </ext:Window>

</asp:Content>


