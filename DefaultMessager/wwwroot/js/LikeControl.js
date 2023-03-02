function ChengeLike(parametrs) {
    const postId = parametrs.data;
    $.ajax({
        type: 'GET',
        url: '/Like/ManipulateLikeOnPost',
        data: { "postId": postId},
        success: function (data) {
            document.getElementById("LikeCount").innerHTML = (data);
        }
    });
}

function GetLikes(parametrs) {
    const postId = parametrs.data;
    $.ajax({
        type: 'GET',
        url: '/Like/GetLikes',
        data: { "postId": postId },
        success: function (data) {
            document.getElementById("LikeCount").innerHTML = (data);
        }
    });
}