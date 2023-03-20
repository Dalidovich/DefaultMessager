function SubmitForm(element,formName)
{
    if (element.value != "")
    {
        document.forms[formName].submit();
    }
}
function getFileExtension(fileName) {
    var fileExtension;
    fileExtension = fileName.replace(/^.*\./, '');
    return fileExtension;
}
function isImage(fileName) {
    var fileExt = getFileExtension(fileName);
    var imagesExtension = ["png", "jpg", "jpeg"];
    if (imagesExtension.indexOf(fileExt) !== -1) {
        return true;
    }
    else {
        return false;
    }
}
function dropElement(event) {
    let files = event.dataTransfer.files;
    if (document.getElementById("inputField") != null)
    {
        document.getElementById("inputField").files = files;
        document.forms["inputForm"].submit();
    }
    document.getElementById("dropZone").style.display = "none";
}
function leaveElement() {
    document.getElementById("dropZone").style.display = "none";
}
function formChange(element) {
    if (element.value != "") {
        document.forms["inputForm"].submit();
    }
}