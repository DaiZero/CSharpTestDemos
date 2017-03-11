
function IsFirstNameEmpty() {
    if (document.getElementById('TxtFName').value == "") {
        return 'First Name should not be empty';
    }
    else { return ""; }
}

function IsFirstNameInValid() {
    if (document.getElementById('TxtFName').value.indexOf("@") != -1) {
        return 'First Name should not contain @';
    }
    else { return ""; }
}
function IsLastNameInValid() {
    if (document.getElementById('TxtLName').value.length >= 5) {
        return 'Last Name should not contain more than 5 character';
    }
    else { return ""; }
}
function IsAgeEmpty() {
    if (document.getElementById('TxtAge').value == "") {
        return 'Age should not be empty';
    }
    else { return ""; }
}
function IsAgeInValid() {
    if (isNaN(document.getElementById('TxtAge').value)) {
        return 'Enter valid Age';
    }
    else { return ""; }
}
function IsValid() {

    var FirstNameEmptyMessage = IsFirstNameEmpty();
    var FirstNameInValidMessage = IsFirstNameInValid();
    var LastNameInValidMessage = IsLastNameInValid();
    var AgeEmptyMessage = IsAgeEmpty();
    var AgeInvalidMessage = IsAgeInValid();

    var FinalErrorMessage = "Errors:";
    if (FirstNameEmptyMessage != "")
        FinalErrorMessage += "\n" + FirstNameEmptyMessage;
    if (FirstNameInValidMessage != "")
        FinalErrorMessage += "\n" + FirstNameInValidMessage;
    if (LastNameInValidMessage != "")
        FinalErrorMessage += "\n" + LastNameInValidMessage;
    if (AgeEmptyMessage != "")
        FinalErrorMessage += "\n" + AgeEmptyMessage;
    if (AgeInvalidMessage != "")
        FinalErrorMessage += "\n" + AgeInvalidMessage;

    if (FinalErrorMessage != "Errors:") {
        $("#errorModel").find(".modal-body").html(FinalErrorMessage);
            $('#errorModel').modal({
                keyboard: true
            })
        //alert(FinalErrorMessage);
        return false;
    }
    else {
        return true;
    }
}