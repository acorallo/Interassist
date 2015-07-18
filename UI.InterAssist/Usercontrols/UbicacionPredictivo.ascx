<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UbicacionPredictivo.ascx.cs" Inherits="UI.InterAssist.Usercontrols.UbicacionPredictivo" %>
<script language="javascript" src="../Scripts/jquery-1.10.1.min.js"></script>   
<script language="javascript" src="../Scripts/jquery-ui.js"></script>
<script language="javascript" src="../Scripts/UbicacionPredictivo.js"></script>
<script language="javascript">    
    <asp:Literal runat="server" id="variables"></asp:Literal>
</script>
<link href="../Estilos/InterAssist.css" rel="stylesheet" type="text/css" />
<link href="../jquery-ui-1.11.1/jquery-ui.css" rel="stylesheet" type="text/css" />
<style>    
.ui-autocomplete-loading {
background: white url("/images/ui-anim_basic_16x16.gif") right center no-repeat;
}
</style>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    
    
    .ui-menu .ui-menu-item {
	position: relative;
	margin: 0;
	padding: 3px 1em 3px .4em;
	cursor: pointer;
    min-height: 0; /* support: IE7 */
    font-size:small;
	list-style-image: url("data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7");
}
</style>

<table class="style1">
    <tr>
        <td><div class="ui-widget">
  <input id="nombreCompleto" type="hidden" runat="server"/>
  <input id="uniqueUbicacion" type="hidden" runat="server"/>
  <input id="ubicacion" type="text" style="width: 600px" runat="server"/>
  <asp:CustomValidator 
                ID="cmvUbicacion" runat="server" ClientValidationFunction="Cmv_Ubicaciones" 
                ControlToValidate="ubicacion" CssClass="errorText" 
                onservervalidate="cmvUbicacion_ServerValidate" ValidateEmptyText="True">*</asp:CustomValidator>
</div></td>
    </tr>
</table>

