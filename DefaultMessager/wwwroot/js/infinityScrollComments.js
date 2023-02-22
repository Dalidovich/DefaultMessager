var page = 0;
var _inCallback = false;
function loadCommentItems() {
    let bottomlastComment = windowRelativeBottom = document.getElementById("scrolCommentList").lastElementChild.getBoundingClientRect().bottom;
    var bottomListDiv = document.getElementById("scrolCommentList").getBoundingClientRect().bottom;
    if (page > -1 && !_inCallback && bottomlastComment - 30 < bottomListDiv) {
        _inCallback = true;
        page++;
        let postId = document.getElementById("postIdDiv").innerHTML;
        $.ajax({
            type: 'GET',
            url: '/Comment/GetPartialComments',
            data: { "id": page, "postId": postId },
            success: function (data, textstatus)
            {
                if (data != '')
                {
                    $("#scrolCommentList").append(data);
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
function cleanPage()
{
    page = 0;
}