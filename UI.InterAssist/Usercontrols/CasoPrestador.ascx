<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CasoPrestador.ascx.cs" Inherits="UI.InterAssist.Usercontrols.CasoPrestador" %>
<%@ Register src="BuscarPrestador.ascx" tagname="BuscarPrestador" tagprefix="uc1" %>
<%@ Register src="DecimalControl.ascx" tagname="DecimalControl" tagprefix="uc2" %>

<style type="text/css">
    .auto-style1 {
        width: 100%;
    }

    .search-icon
    {  
        font-size: 20px;
        margin-left: 10px;
        cursor: pointer;
    }

    

    .auto-style2 {
        height: 36px;
    }
    .auto-style3 {
        width: 100%;
        height: 36px;
    }

    

    </style>


<script type="text/javascript">



</script>


<table class="auto-style1">
    <tr>
        <td style="text-align: right; white-space: nowrap" class="auto-style2">
            <asp:Label ID="lblCasoPrestador_prestador" runat="server"></asp:Label>
            <div class="CasoPrestador_Oblicagatorio" id="CasoPrestador_Prestador">*</div></td>
        <td class="auto-style3">
            <uc1:BuscarPrestador ID="BuscarPrestador1" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right; white-space: nowrap">
            <asp:Label ID="lblCasoPrestador_TipoAsisitencia" runat="server"></asp:Label>
            <div class="CasoPrestador_Oblicagatorio" id="CasoPrestador_validTipoAsistencia">*</div>
        </td>
        <td>
            <asp:DropDownList ID="ddlCasoPrestador_TipoAsistencia" runat="server" ClientIDMode="Static" Width="300px">
            </asp:DropDownList>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; white-space: nowrap">
            <asp:Label ID="lblCasoPrestador_Kilometros" runat="server"></asp:Label>
        </td>
        <td>
            <uc2:DecimalControl ID="DecimalControl_Kilometro" runat="server" ClientIDMode="Static" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right; white-space: nowrap">
            <asp:Label ID="lblCasoPrestador_Costo" runat="server"></asp:Label>
        </td>
        <td>
            <uc2:DecimalControl ID="DecimalControl_Costo" runat="server" ClientIDMode="Static" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top; white-space: nowrap">
            <asp:Label ID="lblCasoPrestador_descripcion" runat="server"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="txtCasoPrestador_descripcion" runat="server" Rows="6" TextMode="MultiLine" Width="400px" ClientIDMode="Static" MaxLength="1024"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td><div class="CasoPrestador_Oblicagatorio" id="CasoPrestador_Sumary">Debe completar los campos obligatorios (*)</div></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <input id="btnAddPrestador" aria-sort="none" type="button" value="Agregar Prestador" /></td>
    </tr>
</table>

