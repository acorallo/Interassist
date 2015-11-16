
function AsignarPrestador(id, nombre) {
    window.alert(nombre);
}

function HidePopBuscarPrestador() {
    $("#DivBusquedaPrestador").hide();
}

function showPopBuscarPrestador() {


    InicializaBuscarPrestador();
    

    $(function () {
        $("#DivBusquedaPrestador").show();
        $("#DivBusquedaPrestador").dialog({
            modal: true,
            close: function (event, ui) { ClosePopUp(); },
            width: 1000,
            height: 800

        });
    });



}




function CrearTabla() {

    $('#demoTable').jTPS({
        perPages: [5, 12, 15, 50, 'ALL'], scrollStep: 1, scrollDelay: 30,
        clickCallback: function () {
            // target table selector
            var table = '#demoTable';
            // store pagination + sort in cookie
            document.cookie = 'jTPS=sortasc:' + $(table + ' .sortableHeader').index($(table + ' .sortAsc')) + ',' +
                    'sortdesc:' + $(table + ' .sortableHeader').index($(table + ' .sortDesc')) + ',' +
                    'page:' + $(table + ' .pageSelector').index($(table + ' .hilightPageSelector')) + ';';
        }
    });

    // reinstate sort and pagination if cookie exists
    var cookies = document.cookie.split(';');
    for (var ci = 0, cie = cookies.length; ci < cie; ci++) {
        var cookie = cookies[ci].split('=');
        if (cookie[0] == 'jTPS') {
            var commands = cookie[1].split(',');
            for (var cm = 0, cme = commands.length; cm < cme; cm++) {
                var command = commands[cm].split(':');
                if (command[0] == 'sortasc' && parseInt(command[1]) >= 0) {
                    $('#demoTable .sortableHeader:eq(' + parseInt(command[1]) + ')').click();
                } else if (command[0] == 'sortdesc' && parseInt(command[1]) >= 0) {
                    $('#demoTable .sortableHeader:eq(' + parseInt(command[1]) + ')').click().click();
                } else if (command[0] == 'page' && parseInt(command[1]) >= 0) {
                    $('#demoTable .pageSelector:eq(' + parseInt(command[1]) + ')').click();
                }
            }
        }
    }

    // bind mouseover for each tbody row and change cell (td) hover style
    $('#demoTable tbody tr:not(.stubCell)').bind('mouseover mouseout',
            function (e) {
                // hilight the row
                e.type == 'mouseover' ? $(this).children('td').addClass('hilightRow') : $(this).children('td').removeClass('hilightRow');
            }
    );


}
    
function InicializaBuscarPrestador() {
        
    getPaises();

    $('#demoTable tbody').html("");
    $('#demoTable').css('visibility', 'hidden');

    // Asigna eventos a los botos.
    $("#btnBuscarPrestador").click(_btnBuscarPrestador_click);
    //$("#btnLimpiarBusqueda").click(_btnBuscarPrestador_click);

    // CargaComboPaises.
    getPaises();



    setComboModal('ddlPrestadorProvincia', 'ddlPrestadorPais', '/Views/services.aspx/GetProvincias');


        

    }
    

function PrestadoresDetalles(id)
{
    window.alert('Detalle: ' +id);
}


function TablaPrestadores_Bind(listado) {

    $('#demoTable tbody').html("");

    for (var i = 0; i < listado.length; i++) {
        
        var row = '<tr><td onclick="javascript:AsignaPrestador(' + ToString(listado[i].Id) + ')">{0}</td>id<td onclick="javascript:AsignaPrestador(' + ToString(listado[i].Id) + ')">{1}</td><td onclick="javascript:AsignaPrestador(' + ToString(listado[i].Id) + ')">{2}</td><td onclick="javascript:AsignaPrestador(' + ToString(listado[i].Id) + ')">>{3}</td><td onclick="javascript:AsignaPrestador(' + ToString(listado[i].Id) + ')">{4}</td><td onclick="javascript:AsignaPrestador(' + ToString(listado[i].Id) + ')">{5}</td><td onclick="javascript:AsignaPrestador(' + ToString(listado[i].Id) + ')">{6}</td><td><a href="javascript:PrestadoresDetalles({7})">Detalles</a></td></tr>';
        row = String.format(row, ToString(listado[i].Id), ToString(listado[i].Nombre), ToString(listado[i].Pais), ToString(listado[i].Provincia), ToString(listado[i].Localidad), ToString(listado[i].Domicilio), ToString(listado[i].Telefono), ToString(listado[i].Id));

        $('#demoTable tbody').append(row);
    }

    if (listado.length > 0) {
        $('#demoTable').css('visibility', 'visible');
        $('#trLabelPrestador').css('visibility', 'hidden');
    } else {
        $('#demoTable').css('visibility', 'hidden');
        $('#trLabelPrestador').css('visibility', 'visible');
    }

    CrearTabla();
}

function getPaises() {


    $.ajax({
        type: "POST",
        url: "/Views/services.aspx/GetPaises",
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) { SetComboOptions('ddlPrestadorPais', response.d) },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function getPrestador(id, callBack, failCallBack)
{
    $.ajax({
        type: "POST",
        url: "/Views/services.aspx/getPrestadorWM",
        data: "{idPrestador: '" + id + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: callBack,
        failure: failCallBack
    });
}

function AsignaPrestador(value)
{
   
    AsiganarPrestador_TextBox(value);
    $("#DivBusquedaPrestador").dialog("close");
}


function AsiganarPrestador_TextBox(idPrestador)
{
    // Obtener los datos del prestador desde el server.
    getPrestador(idPrestador,
    function (response)
    {
        // Respuesta del servidor
        if(response.d != null)
        {
            var nombrePrestador = response.d.Nombre;
            $("#txtNombrePrestadorCaso").val(nombrePrestador);
            $("#BuscarPrestador_idPrestador").val(response.d.Id);
        }

    }, 
    function (response) 
    {
        // Falla del servidor
        window.alert("No se puede asignar el prestador");

    }
                  )
}


function AgregarPrestador_ServerSide(value)
{
    $("#UpdatePanel_postBack_Arguments").val(value);
    __doPostBack("UpdatePanel_postBack", "AgregarPrestador");
}


function _btnBuscarPrestador_click() {

    var pais = $("#ddlPrestadorPais").val();
    var provincia = $("#ddlPrestadorPais").val();
    var ciudad = $("#txtPrestadorCiudad").val();
    var nombre = $("#txtPrestadorNombre").val();

    $.ajax({
        type: "POST",
        url: "/Views/services.aspx/ListPrestadores",
        data: "{idPais: '" + pais + "', idProvincia: '" + provincia + "', ciudad: '" + ciudad + "', nombre: '" + nombre + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            TablaPrestadores_Bind(response.d)
        },

        failure: function (response) {
            alert(response.d);
        }
    });



}