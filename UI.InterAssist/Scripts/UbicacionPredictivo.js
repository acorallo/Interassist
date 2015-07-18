
if (typeof (UbicacionLoadScripts) == 'undefined') {
    var UbicacionLoadScripts = [];
}


function Cmv_Ubicaciones(oSrc, args) {

    var valor = document.getElementById($('#' + oSrc.controltovalidate).attr("ControlAsociado")).value;
    args.IsValid = valor != '' && valor != '-1';

}

function SuscribirCarga(expresion) {
    UbicacionLoadScripts.push(expresion);
}

function UbicacionLoadControl() {

    var tope = UbicacionLoadScripts.length;

    for (var i = 0; i < tope; i++) {
        UbicacionLoadScripts[i]();
    }


}

function onSource(request, response) {

    var valor = request.term;

    PageMethods.ObtenerUbicacion(valor, function (serverResponse) {response(serverResponse); }, onError_ObtenerUbicacion);
}


function onError_ObtenerUbicacion(response) {

}


function _bindAutoComplete(event) {
    
    if (event.keyCode === $.ui.keyCode.TAB) {
        event.preventDefault();
    }    
}

function InitUbicacion(control, uniqueControl, nombreCompletoControl) {

    function split(val) {
        return val.split(/,\s*/);
    }
    function extractLast(term) {
        return split(term).pop();
    }

    $("#" + control).attr("ControlAsociado", uniqueControl);
    $("#" + control).attr("NombreCompleto", nombreCompletoControl);

    $("#" + control).focusout(function () {

        // Si el campo esta vacio anula el valor.
        if (this.value != '') {
            this.value = document.getElementById($('#' + this.id).attr("NombreCompleto")).value;
        } else {
            document.getElementById($('#' + this.id).attr("NombreCompleto")).value = '';
            document.getElementById($('#' + this.id).attr("ControlAsociado")).value = '-1';
        }
    }
    );

    

    // Inicializa al control vacio.

    $("#" + control)
    // don't navigate away from the field on tab when selecting an item
      .bind("keydown", _bindAutoComplete)
      .autocomplete({
          source: onSource,
          search: function () {
              // custom minLength
              var term = extractLast(this.value);
              if (term.length < 2) {
                  return false;
              }
          },
          focus: function () {
              // prevent value inserted on focus
              return false;
          },
          select: function (event, ui) {
              var terms = split(this.value);
              var controlAsociadoId = $('#' + event.target.id).attr("ControlAsociado");
              var controlNombreComplet = $('#' + event.target.id).attr("NombreCompleto");
              var selectedId = ui.item.id;
              document.getElementById(controlAsociadoId).value = ui.item.id;
              document.getElementById(controlNombreComplet).value = ui.item.value;
              // remove the current input
              terms.pop();
              // add the selected item
              //terms.push(ui.item.label);
              // add placeholder to get the comma-and-space at the end
              /*
              terms.push("");
              this.value = terms.join(", ");
              
              */
          }
      });
    
}