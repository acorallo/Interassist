


function pageLoad(sender, args) {

    SincronizaSelector();
    SincronizarPopUps();

    $(function () {
        $("#accordion").accordion({ heightStyle: "content" });

    });

    UbicacionLoadControl();

}


function SincronizarPopUps() {

    var popup = document.getElementById("popModal").value;

    if (popup != '') {
        
        switch(popup) {
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
                $(this).dialog("close");
                if($(this).attr("salir")==1)
                    goView('Afiliados.aspx');

            }
        }
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


function btnBuscarPrestador_onClick(button) {

    WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions("ctl00$ContentPlaceHolder1$Button1", "", false, "", "", false, false));
    


}