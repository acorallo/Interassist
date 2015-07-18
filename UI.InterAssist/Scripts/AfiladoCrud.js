
function on_loadPage() {

    var showPopUp = document.getElementById(document.getElementById("idShowPop").value).value;

    if (showPopUp == 'SHOW_POP_MODIF') {
        ShowPopSuccess_Modif();
    }
    else if (showPopUp == 'SHOW_POP_ALTA') {
        ShowPopSuccess_Create();
    } else if (showPopUp == 'SHOW_CONCURR_ERROR') {
        ShowPopSuccess_Error();
    }


}

function ShowPopSuccess_Modif() {
    // Aqui hay que hacer la ventana modal.
    $("#dialog-message_modif").dialog({
        modal: true,
        buttons: {
            Aceptar: function () {
                $(this).dialog("close");
                goView('Afiliados.aspx');

            }
        }
    });

}

function ShowPopSuccess_Error() {
    // Aqui hay que hacer la ventana modal.
    $("#dialog-message_error").dialog({
        modal: true,
        buttons: {
            Aceptar: function () {
                $(this).dialog("close");
                document.location.href('Afiliados.aspx');

            }
        }
    });

}

function ShowPopSuccess_Create() {
    // Aqui hay que hacer la ventana modal.
    $("#dialog-message_create").dialog({
        modal: true,
        buttons: {
            Si: function () {
                $(this).dialog("close");
                document.location.href('AfiliadoCrud.aspx');

            },
            No: function () {
                $(this).dialog("close");
                document.location.href('Afiliados.aspx');
            }
        }
    });
}

$(document).ready(on_loadPage);