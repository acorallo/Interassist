

function pageLoad(sender, args) {

    SincronizarPopUps();
    UbicacionLoadControl();
}

function SincronizarPopUps() 
{
    var popup = document.getElementById("popModal").value;

    if (popup != '') {

        switch (popup) {
            case 'dialog-message_error':
                ShowErrorPop();
                break;
            case 'dialog-message_create':
                showSuccessPopUp();
                break;
        }

    }
}

function showSuccessPopUp() {

    var txtMsg = document.getElementById("txtCasoModal").value;
    document.getElementById("pSuxccMsgTxt").innerHTML = txtMsg;
    $('#dialog-message_create').attr("title", "Administración de Prestadores");

    $("#dialog-message_create").dialog({
        modal: true,
        buttons: {
            Aceptar: function () {
                $(this).dialog("close");
                goView('Prestador.aspx');

            }
        }
    });
}

function ShowErrorPop() {

    var txtMsg = document.getElementById("txtCasoModal").value;
    document.getElementById("pSuxccMsgTxt").innerHTML = txtMsg;
    $('#dialog-message_create').attr("title", "Administración de Prestadores");


    $("#dialog-message_create").dialog({
        modal: true,
        buttons: {
            Aceptar: function () {
                $(this).dialog("close");
                goView('Prestador.aspx');

            }
        }
    });
}

/*$(document).ready(on_loadPage);*/