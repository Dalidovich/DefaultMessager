var accountId
function setPostScrollEvent(parametrs) {
    $('div#loading').hide();
    accountId = parametrs.accountId;
    $(window).scroll(function () {
        if ($(window).scrollTop() == $(document).height() - $(window).height()) {
            loadPostItems();
        }
    });
}
var page = 0;
var _inCallback = false;
function loadPostItems() {
    if (page > -1 && !_inCallback) {
        _inCallback = true;
        page++;
        $('div#loading').show();
        $.ajax({
            type: 'GET',
            url: '/Post/GetPartialPostIcons',
            data: { "id": page, "accountId": accountId },
            success: function (data, textstatus)
            {
                if (data != '') {
                    $("#scrolPostList").append(data);
                }
                else {
                    page = -1;
                }
                _inCallback = false;
                $("div#loading").hide();
            }
        });
    }
}