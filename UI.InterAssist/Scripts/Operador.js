

function txtUsuario_onBlur(txtusuario) {
    var usuario = txtusuario.value;
    
    if (usuario != '') {
        // Hace la llamada asyncronica para obtener el resultado;
        PageMethods.ValidarUsuario(usuario, onSuccess_ValidarUsuario, onError_ValidarUsuario);
    }
}

function onSuccess_ValidarUsuario(response) {

    var elemento = document.getElementById("errUsuario");
    var resultText = "";
        
    if (!response.Result) {

        var txtUsuario = response.Error;
        resultText = txtUsuario;

    }

    elemento.innerHTML = resultText;
}

function onError_ValidarUsuario() {
    alert('Error');
}


function ShowPopSuccess_Create(){
    // Aqui hay que hacer la ventana modal.
    $("#dialog-message_create").dialog({
        modal: true,
        buttons: {
            Si: function () {
                $(this).dialog("close");
                document.location.href('OperadorCrud.aspx');

            },
            No: function () {
                $(this).dialog("close");
                document.location.href('Operadores.aspx');
            }
        }
    });
}

function ShowPopSuccess_Modif() {
    // Aqui hay que hacer la ventana modal.
    $("#dialog-message_modif").dialog({
        modal: true,
        buttons: {
            Aceptar: function () { 
                $(this).dialog("close");
                document.location.href('Operadores.aspx');
               
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
                document.location.href('Operadores.aspx');

            }
        }
    });

}

function ShowPopResetPassword() {
    
    // Aqui hay que hacer la ventana modal.
    $("#dialog-message_reset").dialog({
        modal: true,
        buttons: {  
            Aceptar: function () {
                $(this).dialog("close");
                document.location.href('Operadores.aspx');

            }
        }
    });
}

function on_loadPage() {

    var showPopUp = document.getElementById(document.getElementById("idShowPop").value).value;

    if (showPopUp == 'SHOW_POP_MODIF') {
        ShowPopSuccess_Modif();
    }
    else if (showPopUp == 'SHOW_POP_ALTA') {
        ShowPopSuccess_Create();
    } else if (showPopUp == 'SHOW_CONCURR_ERROR') {
        ShowPopSuccess_Error();
    } else if (showPopUp == 'SHOW_RESET_PASSWORD') { 
           ShowPopResetPassword();
           }
    
    
}

$(document).ready(on_loadPage);
    