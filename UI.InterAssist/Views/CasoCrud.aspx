    <%@ Page Title="" Language="C#" MasterPageFile="~/InterAssist.Master" AutoEventWireup="true" CodeBehind="CasoCrud.aspx.cs" Inherits="UI.InterAssist.Views.CasoCrud" %>
<%@ Register src="../Usercontrols/Ubicacion.ascx" tagname="Ubicacion" tagprefix="uc1" %>
<%@ Register src="../Usercontrols/AfiliadoDetalle.ascx" tagname="AfiliadoDetalle" tagprefix="uc2" %>
<%@ Register src="../Usercontrols/Prestadorctrl.ascx" tagname="Prestadorctrl" tagprefix="uc3" %>
<%@ Register src="../Usercontrols/Operador.ascx" tagname="Operador" tagprefix="uc4" %>
<%@ Register src="../Usercontrols/CasoPrestador.ascx" tagname="CasoPrestador" tagprefix="uc5" %>
<%@ Register src="../Usercontrols/DecimalControl.ascx" tagname="DecimalControl" tagprefix="uc6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style3
        {
            width: 100%;
        }

        .auto-style1 {
            height: 23px;
        }

        .auto-style2 {
            height: 23px;
        }

        </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" language="javascript" src="../Scripts/jquery-1.10.1.min.js"></script>   
    <script type="text/javascript" language="javascript" src="../Scripts/FrontControls.js"></script>
    <script type="text/javascript" language="javascript" src="../Scripts/CasoCrud.js"></script>


    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" AsyncPostBackTimeout="99999999"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <input type="hidden" id="ClosePopUp" name="ClosePopUp" value="" />
    <asp:Literal ID="litPopUp" runat="server"></asp:Literal>
    <asp:Literal ID="litSuccMsg" runat="server"></asp:Literal>

    <table class="style1">
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            <table class="style1">
                                <tr>
                                    <td nowrap="nowrap" class="DatosTicket">
                                        <table class="style1">
                                            <tr>
                                                <div id="divDatosTicket" runat="server">
                                                    <td align="left" width="100%" colspan="2">
                                                        <table class="style3">
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblIdCaso" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left" width="100%">
                                                                    <asp:Label ID="lbltxtCaso" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblOperador" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblTextOperador" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblTextFecha" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </div>
                                            </tr>
                                            <tr>
                                                <td align="right" nowrap="nowrap">
                                                    <asp:Label ID="lblEstado" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" width="100%">
                                                    <asp:DropDownList ID="ddlEstado" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" nowrap="nowrap">
                                                    <asp:Label ID="lblTipoCaso" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" width="100%">
                                                    <asp:DropDownList ID="ddlTipoCaso" runat="server" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlTipoCaso_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:CustomValidator ID="cmvTipoCaso" runat="server" 
                                                        ClientValidationFunction="validateCombo" ControlToValidate="ddlTipoCaso" 
                                                        CssClass="errorText" onservervalidate="cmvTipoCaso_ServerValidate">*</asp:CustomValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" nowrap="nowrap">
                                                    <asp:Label ID="lblTelefono" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" width="100%">
                                                    <asp:TextBox ID="txtTelefono" runat="server" Width="250px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" 
                                                        ControlToValidate="txtTelefono" CssClass="errorText">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <input name="sincSelector" id="sincSelector" type="hidden" value=""/>
                                    <asp:Literal ID="litSelector" runat="server"></asp:Literal>
                                    <td>
                                    
                                    <div id="tabs">
                                              <ul>
                                               
                                                <li><a href="#tabs-Afiliado">Afiliado</a></li>
                                                <li><a href="#tabs-Ubicacion">Ubicacion</a></li>
                                                <li><a href="#tabs-Prestador">Prestadores</a></li>
                                                <li><a href="#tabs-Detalles">Detalles</a></li>
                                              </ul>
                                              <div id="tabs-Detalles" class="TicketTab">
                                                                     <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <table>
                                                                <tr>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblProblemaMecanico" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="100%">
                                                                        <asp:DropDownList ID="ddlProblema" runat="server" Width="450px">
                                                                        </asp:DropDownList>
                                                                        <asp:CustomValidator ID="cmvProblema" runat="server" 
                                                                            ClientValidationFunction="validateCombo" ControlToValidate="ddlProblema" 
                                                                            CssClass="errorText">*</asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblDetalles" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtDetalles" runat="server" Height="101px" 
                                                                TextMode="MultiLine" Width="600px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblHistorico" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <table class="style3">
                                                            <tr>
                                                                <td>
                                                            <div id="divObservacinoes" runat="server">
                                                             <div id="accordion">
                                                              <asp:Repeater ID="rptObservaciones" runat="server" onitemdatabound="rptObservaciones_ItemDataBound">
                                                               <ItemTemplate>
                                                                 <h3><table width="100%">
                                                                    <tr>
                                                                        <td align="left"><asp:Label ID="lblObsOperador" runat="server"></asp:Label></td>
                                                                        <td align="right"><asp:Label ID="lblObsFecha" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                    </table>
                                                                 </h3>
                                                                       <div>
                                                                           <p>
                                                                            <asp:Label ID="lblObsText" runat="server"></asp:Label>
                                                                           </p>
                                                                       </div>
                                                                </ItemTemplate>
                                                              </asp:Repeater>
                                                             </div>
                                                            </div>
                                                                
                                                            </tr>

                                                                <div id="divNonObs" runat="server">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblNonObs" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </div>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                              </div>
                                              <div id="tabs-Afiliado" class="TicketTab">
                                                  <table class="style3">
                                                      <tr>
                                                          <td align="left">
                                                              <uc2:AfiliadoDetalle ID="ctrlAfiliado" runat="server" />
                                                          </td>
                                                      </tr>
                                                  </table>
                                              </div>

                                              <div id="tabs-Ubicacion" class="TicketTab">
                                                  <table align="center" class="style3">
                                                      <tr>
                                                          <td align="left" Class="Seccion">
                                                              <asp:Label ID="lblOrigen" runat="server"></asp:Label>
                                                          </td>
                                                      </tr>
                                                      <tr>
                                                          <td align="left">
                                                              <uc1:Ubicacion ID="UbicacionOrigen" runat="server" />
                                                          </td>
                                                      </tr>
                                                      <tr>
                                                          <td align="left" Class="Seccion">
                                                              <asp:Label ID="lblDestino" runat="server"></asp:Label>
                                                          </td>
                                                      </tr>
                                                      <tr>
                                                          <td align="left">
                                                              <uc1:Ubicacion ID="UbicacionDestino" runat="server" />
                                                          </td>
                                                      </tr>
                                                  </table>
                                              </div>

                                      
                                              <div id="tabs-Prestador" align="left" class="TicketTab">
                                         
                                              
                                              <table width="100%">
                                                                <tr>
                                                                    <td align="right">
                                                                        <asp:Button ID="UpdatePanel_postBack" runat="server" CausesValidation="False" Text="Button" ClientIDMode="Static" style="display:none"/>
                                                                       <asp:Button ID="btnAsignarPrestador" runat="server" CausesValidation="False" OnClientClick="showAsignarPrestador()"/>
                                                                        <asp:CustomValidator ID="cmvPrestador" runat="server" CssClass="errorText" 
                                                                            onservervalidate="cmvPrestador_ServerValidate">*</asp:CustomValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        <table class="style3">
                                                                          
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lblSinPrestadores" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:DataGrid ID="dtgPrestadoresAsignados" runat="server" AutoGenerateColumns="False" PageSize="20" Width="100%" ClientIDMode="Static" OnItemDataBound="dtgPrestadoresAsignados_ItemDataBound" EnableTheming="False" OnItemCommand="dtgPrestadoresAsignados_ItemCommand">
                                                                                        <Columns>
                                                                                            <asp:BoundColumn Visible="False"></asp:BoundColumn>
                                                                                            <asp:ButtonColumn></asp:ButtonColumn>
                                                                                            <asp:BoundColumn></asp:BoundColumn>
                                                                                            <asp:BoundColumn></asp:BoundColumn>
                                                                                            <asp:BoundColumn></asp:BoundColumn>
                                                                                            <asp:BoundColumn></asp:BoundColumn>
                                                                                            <asp:TemplateColumn>
                                                                                                <ItemTemplate>
                                                                                                    <div class="icon-cross" style="font-size:20px; cursor:pointer; color: red" runat="server"></div>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateColumn>
                                                                                        </Columns>
                                                                                        <HeaderStyle CssClass="HeaderGrid" />
                                                                                        <ItemStyle CssClass="RowGrid" />
                                                                                        <PagerStyle HorizontalAlign="Center" Mode="NumericPages" />
                                                                                    </asp:DataGrid>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                            
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                  <div id="divDatosPrestador" runat="server">
                                                                      <td>
                                                                          <table class="style3">
                                                                              <tr>
                                                                                  <td>
                                                                                      <div style="visibility:hidden">
                                                                                        <div id="divPrestadorDetalle" title="Información del Prestador">
                                                                                             <uc3:Prestadorctrl ID="PrestadorctrlDetalle" runat="server" />
                                                                                        </div>
                                                                                      </div>
                                                                                  </td>
                                                                              </tr>
                                                                          </table>
                                                                      </td>
                                                                  </div>
                                                                </tr>
                                                            </table>
                                              </div>
                                     </div>


       
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                CssClass="errorSummaryText" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table class="style3">
                                <tr>
                                    <td width="33.3%">
                                        &nbsp;</td>
                                    <td align="center" width="33.3%">
                                        &nbsp;<asp:Button ID="btnAceptar" runat="server" onclick="btnAceptar_Click" />
                                        &nbsp;<asp:Button ID="btnCancelar" runat="server" CausesValidation="False" 
                                            onclick="btnCancelar_Click" />
                                    </td>
                                    <td align="right" width="33.3%">
                                        <asp:Button ID="btnAceptarSalir" runat="server" 
                                            onclick="btnAceptarSalir_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="auto-style2">
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

 
    
    <input type="hidden" id="UpdatePanel_postBack_Arguments" name="UpdatePanel_postBack_Arguments"/>
    <input type="hidden" name="CasoPrestador_Info_ID" id="CasoPrestador_Info_ID"/>
    <input type="hidden" name="CasoPrestador_Info_TipoAsistencia" id="CasoPrestador_Info_TipoAsistencia"/>
    <input type="hidden" name="CasoPrestador_Info_Descripcion" id="CasoPrestador_Info_Descripcion"/>
    <input type="hidden" name="CasoPrestador_Info_Kilomentros" id="CasoPrestador_Info_Kilomentros" />
    <input type="hidden" name="CasoPrestador_Info_Costo" id="CasoPrestador_Info_Costo" />
    <input type="hidden" id="BuscarPrestador_internalID" name ="BuscarPrestador_internalID" />
    

    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="UpdatePanel_postBack" EventName="Click"/>
    </Triggers>
    </asp:UpdatePanel>
     <link rel="stylesheet" href="/Estilos/jTPS.css" type="text/css" />
       <div style="visibility: hidden">
        <div id="divPrestadorInfo" title="Información del Prestador">
            <table>
                <tr>
                    <td align="center">
                     <uc3:Prestadorctrl ID="PrestadorInfo" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

  <div style="visibility:hidden">
    <div id="dialog-message_error">
          <p>
            <span class="ui-icon ui-icon-circle-check" style="float:left; margin:0 7px 50px 0;"></span>
            <p id="pErrMsgTxt"></p>
          </p>
    </div>
  </div>

  <div style="visibility:hidden"> 
    <div id="DivAsignarPrestador" title="Asignar Prestador">
         <div style="font-size:12px">
          <p><uc5:CasoPrestador ID="CasoPrestador1" runat="server" />
        </div>
          </p>
    </div>
  </div>


<div style="display:none">
    <div id="dialog-message_create">
          <p>
            <span class="ui-icon ui-icon-circle-check" style="float:left; margin:0 7px 50px 0;"></span>
            <p id="pSuxccMsgTxt"></p>
          </p>

    </div>
</div>

     <script type="text/javascript" language="javascript" src="../Scripts/jTPS.js"></script>



</asp:Content>


  