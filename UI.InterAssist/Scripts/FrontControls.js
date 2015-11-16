

// Option for control.

function setComboModal(targetCombo, observedCombo, serverSideFunction) {

    var objObservedCombo = $('#' + observedCombo);
    var objTargetCombo = $("#" + targetCombo);
    objObservedCombo.change(function () {

        
        var pKey = objObservedCombo.val();

        if (pKey != '-1')
        {

            $.ajax({
                type: "POST",
                url: serverSideFunction,
                data: '{key: "' + pKey + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    SetComboOptions(targetCombo, response.d)
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }else
        {
            objTargetCombo.children().remove();
        }
    });

}

function SetComboOptions(Targetcombo, options) {
    var combo = $('#' + Targetcombo);

    combo.children().remove();
    combo.append($('<option>', {
        value: '-1',
        text: ""
    })); combo.append

    for (var i = 0; i < options.length; i++) {
        combo.append($('<option>', {
            value: options[i].id,
            text: options[i].value
        }));
    }

}
