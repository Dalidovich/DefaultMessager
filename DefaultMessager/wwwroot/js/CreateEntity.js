function CreateCommentOnPost(parametrs) {
    const url = parametrs.url;
    const postId = parametrs.data;
    if (url == undefined || postId == undefined) {
        alert('model or url undefined')
    }
    let content = document.getElementById("commentField").value;
    //document.getElementById("commentField").value = "";
    if (content != "")
    {
        $.ajax({
            type: 'GET',
            url: url,
            data: { "postId": postId, "commentContent": content },
            success: function (data) {
                $("#scrolCommentList").prepend(data);
                sendInGroup();
            }
        });
    }
}
function sndBtnClk()
{
    if (event.keyCode === 13) {
        document.getElementById("sndCommBtn").click();
    }
}
