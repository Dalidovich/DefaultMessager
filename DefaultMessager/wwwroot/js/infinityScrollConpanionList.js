var pageAccountList = 0;
var _inCallback = false;
function loadAccountIconsItems() {
    let bottomlastComment = windowRelativeBottom = document.getElementById("scrolAccountIconsList").lastElementChild.getBoundingClientRect().bottom;
    var bottomListDiv = document.getElementById("scrolAccountIconsList").getBoundingClientRect().bottom;
    if (pageAccountList > -1 && !_inCallback && bottomlastComment - 30 < bottomListDiv) {
        _inCallback = true;
        pageAccountList++;
        $.ajax({
            type: 'GET',
            url: '/Relations/GetPartialCompanions',
            data: { "id": pageAccountList },
            success: function (data, textstatus) {
                if (data != '') {
                    $("#scrolAccountIconsList").append(data);
                }
                else {
                    pageAccountList = -1;
                }
                _inCallback = false;
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }
}