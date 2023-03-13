var page = 0;
var _inCallback = false;
function loadMessageItems() {
    let bottomlastComment = windowRelativeBottom = document.getElementById("scrolMessageList").lastElementChild.getBoundingClientRect().bottom;
    var bottomListDiv = document.getElementById("scrolMessageList").getBoundingClientRect().bottom;
    if (page > -1 && !_inCallback && bottomlastComment - 30 < bottomListDiv) {
        _inCallback = true;
        page++;
        let compId = document.getElementById("compId").innerHTML;
        $.ajax({
            type: 'GET',
            url: '/Message/GetPartialMessages',
            data: { "id": page, "companionId": compId },
            success: function (data, textstatus) {
                if (data != '') {
                    $("#scrolMessageList").append(data);
                }
                else {
                    page = -1;
                }
                _inCallback = false;
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }
}