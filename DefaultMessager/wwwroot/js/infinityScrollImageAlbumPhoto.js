var imageAlbumId
function setImageAlbumPhotoScrollEvent(parametrs) {
    $('div#loading').hide();
    imageAlbumId = parametrs.imageAlbumId;
    $(window).scroll(function () {
        if ($(window).scrollTop() == $(document).height() - $(window).height()) {
            loadImageAlbumPhotoItems();
        }
    });
}
var page = 0;
var _inCallback = false;
function loadImageAlbumPhotoItems() {
    if (page > -1 && !_inCallback) {
        _inCallback = true;
        page++;
        $('div#loading').show();
        $.ajax({
            type: 'GET',
            url: '/ImageAlbum/GetPartialPhotoOfAlbum',
            data: { "id": page, "imageAlbumId": imageAlbumId },
            success: function (data, textstatus)
            {
                if (data != '') {
                    $("#scrolImageAlbumPhotoList").append(data);
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