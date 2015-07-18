

function on_loadPage() {

    InicializaControles();



}

function InicializaControles() {

    // Inicializa los datepicker
    var idTxtFechaDesde = document.getElementById("ctrlIdFechaDesde").value;
    var idTxtFechaHasta = document.getElementById("ctrlIdFechaHasta").value;

    $(function () {
        $("#" + idTxtFechaDesde).datepicker({ dateFormat: "dd/mm/yy" });
    });


    $(function () {
        $("#" + idTxtFechaHasta).datepicker({dateFormat: "dd/mm/yy" });
    });
}

$(document).ready(on_loadPage);