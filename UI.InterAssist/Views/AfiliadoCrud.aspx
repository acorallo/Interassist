<%@ Page Title="" Language="C#" MasterPageFile="~/InterAssist.Master" AutoEventWireup="true" CodeBehind="AfiliadoCrud.aspx.cs" Inherits="UI.InterAssist.Views.AfiliadoCrud" %>
<%@ Register src="../Usercontrols/AfiliadoCtrl.ascx" tagname="AfiliadoCtrl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AfiliadoCtrl ID="AfiliadoCtrl1" runat="server" />

<script src="../Scripts/AfiladoCrud.js" type="text/javascript"></script>


<asp:HiddenField id="showpop" runat="server"/>
<input type="hidden" id="idShowPop" value="<%Response.Write(this.showpop.ClientID.ToString());%>" />

<div style="visibility:hidden">
    <div id="dialog-message_modif" title="<%Response.Write(this.SeccionName);%>">
          <p>
            <span class="ui-icon ui-icon-circle-check" style="float:left; margin:0 7px 50px 0;"></span>
            <%Response.Write(SuccessModif);%>
          </p>

    </div>
</div>

<div style="visibility:hidden">
    <div id="dialog-message_create" title="<%Response.Write(this.SeccionName);%>">
          <p>
            <span class="ui-icon ui-icon-circle-check" style="float:left; margin:0 7px 50px 0;"></span>
            <%Response.Write(SuccessCreate);%>
          </p>

    </div>
</div>

<div style="visibility:hidden">
    <div id="dialog-message_error" title="<%Response.Write(this.SeccionName);%>">
          <p>
            <span class="ui-icon ui-icon-circle-check" style="float:left; margin:0 7px 50px 0;"></span>
            <%Response.Write(ErrorText);%>
          </p>

    </div>
</div>
</asp:Content>