function SubmitForm(element,formName)
{
    if (element.value != "")
    {
        document.forms[formName].submit();
    }
}