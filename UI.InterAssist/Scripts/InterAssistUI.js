

function validateCombo(oSrc, args) {
    args.IsValid = (args.Value != '-1');
}

function goView(view) {
    window.location.assign(view);
}

function GenerateZeroesValues(value, lenght) {

    if (value.length < lenght) {
        return GenerateZeroesValues(value + '0', lenght)
    }
    else {
        return value
    }

    
}

function _leaveDecControl(ParenControl, ChildControl, lenght)
{
    if (ParenControl.value == '') {
        ChildControl.value = '';
    } else {

    ChildControl.value = GenerateZeroesValues(ChildControl.value, lenght);
    }
}

function _leaveIntControl(integerCtl, decimalCtl) {

    if (integerCtl.value != '') {

        if (decimalCtl.value != '') {
            //decimalCtl.value = '';
        }

        else {
            decimalCtl.value = '00';
        }   
    }
    else {
        decimalCtl.value = '';
    }

}

function _onKeyPressNumericControl(ChildCtl) {

    if (event.keyCode < 47 || event.keyCode > 57) {
        event.preventDefault();

        if (event.keyCode == 46 && ChildCtl != null) {
            ChildCtl.focus();
        }
    }
}

function _getDecimal(control) {

    control.select();

}