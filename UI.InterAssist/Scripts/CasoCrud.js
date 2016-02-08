



function pageLoad(sender, args) {

    SincronizaSelector();
    SincronizarPopUps();

    $(function () {
        $("#accordion").accordion({ heightStyle: "content" });

    });

    UbicacionLoadControl();
    //InicializaControles();


}


function InicializaControles()
{
    InicializaAsignarPrestador();
}



function ToString(value)
{
    var result = "";

    if (value != null)
        result = value;

    return result;
}


function SincronizarPopUps() {

    var popup = document.getElementById("popModal").value;

    if (popup != '') {
        
        switch (popup) {
            case 'DivBusquedaPrestador':
                showPopBuscarPrestador();
                break;
            case 'divPrestadorInfo':
                showPopPrestadorInfo();
                break;
            case 'dialog-message_error':
                ShowErrorPop();
                break;
            case 'dialog-message_create':
                showSuccessPopUp(false);
                break;
            case 'dialog-message_create_salir':
                showSuccessPopUp(true);
                break;
            case 'divPrestadorDetalle':
                ShowPrestadorDetalles()
                break;
                        }

    }
}

function showSuccessPopUp(salir) {

    var txtMsg = document.getElementById("txtCasoModal").value;
    document.getElementById("pSuxccMsgTxt").innerHTML = txtMsg;
    $('#dialog-message_create').attr("title", "Administración de Casos");
    $('#dialog-message_create').attr("salir", salir ? 1 : 0);
    
    $("#dialog-message_create").dialog({
        modal: true,
        buttons: {
            Aceptar: function () {
                ClosePopUp();
                $(this).dialog("close");
                if($(this).attr("salir")==1)
                    goView('Afiliados.aspx');

            }
        }
    });
}


function ShowPrestadorDetalles()
{
    $(function () {
        $("#divPrestadorDetalle").dialog({
            modal: true,
            close: function (event, ui) { ClosePopUp(); },
            width: 800,
            height: 500

        });
    });
}

function ShowErrorPop() {

    var txtMsg = document.getElementById("txtCasoModal").value;
    document.getElementById("pSuxccMsgTxt").innerHTML = txtMsg;
    $('#dialog-message_create').attr("title", "Administración de Casos");


    $("#dialog-message_create").dialog({
        modal: true,
        buttons: {
            Aceptar: function () {
                $(this).dialog("close");
                goView('Afiliados.aspx');

            }
        }
    });
}



function showAsignarPrestador()
{

    $('.CasoPrestador_Oblicagatorio').hide();
    $("#btnAddPrestador").click(function () {
        if(Validar_AsignarPrestador())
        {
            // Guarda los datos en un hidden para enviar en el postback.

            $('#CasoPrestador_Info_ID').val($('#BuscarPrestador_idPrestador').val());
            $('#CasoPrestador_Info_TipoAsistencia').val($('#ddlCasoPrestador_TipoAsistencia').val());
            $('#CasoPrestador_Info_Descripcion').val($('#txtCasoPrestador_descripcion').val());
            $('#CasoPrestador_Info_Costo').val(DecimalControl_Costo_getValue());
            $('#CasoPrestador_Info_Kilomentros').val(DecimalControl_Kilometro_getValue());

            $("#DivAsignarPrestador").dialog("close");
            __doPostBack("UpdatePanel_postBack", "AgregarPrestador");
            Clear_AsignarPrestador();

        }

    }
    );

    $(function () {
        $("#DivAsignarPrestador").show();
        $("#DivAsignarPrestador").dialog({
            modal: true,
            close: Close_AsignarPrestador,
            width: 1000,
            height: 800

        });
    });


}

function QuitarPrestador(value, prestador)
{
    var confirm = window.confirm("¿Desea quitar el prestador " + prestador +'?');
    if (confirm) {
        $('#BuscarPrestador_internalID').val(value);
        __doPostBack("UpdatePanel_postBack", "QuitarPrestador");
    }
}

function Close_AsignarPrestador(event, ui)
{
    ClosePopUp();
    Clear_AsignarPrestador();
}

function Clear_AsignarPrestador()
{
    $('#BuscarPrestador_idPrestador').val("");
    $('#txtNombrePrestadorCaso').val("");
    $('#txtCasoPrestador_descripcion').val("");
    $('#ddlCasoPrestador_TipoAsistencia').val("-1");
    DecimalControl_Costo_resetValue();
    DecimalControl_Kilometro_resetValue();

    $('.CasoPrestador_Oblicagatorio').hide();

    
}

function Validar_AsignarPrestador()
{
    var valid = true;

    if ($('#BuscarPrestador_idPrestador').val() == "") {
        $('#CasoPrestador_Prestador').show();
        valid = false;
    } else
    {
        $('#CasoPrestador_Prestador').hide();
    }

    // Aqui se debe validar el combo
    if ($('#ddlCasoPrestador_TipoAsistencia').val() == "-1")
    {
        $('#CasoPrestador_validTipoAsistencia').show();
        valid = false;
    } else
    {
        $('#CasoPrestador_validTipoAsistencia').hide();
    }


    if(valid)
    {
        $('.CasoPrestador_Oblicagatorio').hide();
    }
    else {
        $('#CasoPrestador_Sumary').show();
    }
   

    return valid;

}


function showPopPrestadorInfo() {

    $(function () {
        $("#divPrestadorInfo").dialog({ modal: true,
            close: function (event, ui) { ClosePopUp(); },
            width: 800,
            height: 500

        });
    });

}

function ClosePopUp() {
    
    document.getElementById("ClosePopUp").value = 'true';
}

function SincronizaSelector() {

    var currentSelector = document.getElementById("CurrentSelector").value;
    document.getElementById("sincSelector").value = currentSelector;

    if (currentSelector == '') {

        $(function () {
            $("#tabs").tabs();
        }
    );
    } else {

        $(function () {
            $("#tabs").tabs();
        }
            );
        $(function () {
            $("#tabs").tabs("option", "active", currentSelector);
        }
        );

    }

    $("#tabs").tabs({
        activate: function (event, ui) { on_activate(event, ui); }
    });


}

function on_activate(event, ui) {
    document.getElementById("sincSelector").value = $("#tabs").tabs("option", "active");
}

