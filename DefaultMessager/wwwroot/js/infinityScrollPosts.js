$(window).scroll(function () {
    if ($(window).scrollTop() == $(document).height() - $(window).height())
    {
        loadPostItems();
    }
});
$('div#loading').hide();
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
            data: { "id": page },
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