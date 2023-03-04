var accountId
function setImageAlbumScrollEvent(parametrs) {
    $('div#loading').hide();
    accountId = parametrs.accountId;
    $(window).scroll(function () {
        if ($(window).scrollTop() == $(document).height() - $(window).height()) {
            loadImageAlbumItems(accountId);
        }
    });
}
var page = 0;
var _inCallback = false;
function loadImageAlbumItems() {
    if (page > -1 && !_inCallback) {
        _inCallback = true;
        page++;
        $('div#loading').show();
        $.ajax({
            type: 'GET',
            url: '/ImageAlbum/GetPartialImageAlbums',
            data: { "id": page, "accountId": accountId },
            success: function (data, textstatus)
            {
                if (data != '') {
                    $("#scrolImageAlbumList").append(data);
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