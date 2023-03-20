function CreateCommentOnPost(parametrs) {
    const url = parametrs.url;
    const postId = parametrs.data;
    if (url == undefined || postId == undefined) {
        alert('model or url undefined')
    }
    let content = document.getElementById("commentField").value;
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
function sndBtnClk(id)
{
    if (event.keyCode === 13) {
        document.getElementById(id).click();
    }
}

function CreateMessage(parametrs) {
    const url = parametrs.url;
    let companion = document.getElementById('compId').innerHTML
    if (url == undefined) {
        alert('model or url undefined')
    }
    let content = document.getElementById("messageField").value;
    if (content != "") {
        $.ajax({
            type: 'GET',
            url: url,
            data: { "companionId": companion, "messageContent": content },
            success: function (data) {
                $("#scrolMessageList").append(data);
                sendInMessageGroup();
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }
}