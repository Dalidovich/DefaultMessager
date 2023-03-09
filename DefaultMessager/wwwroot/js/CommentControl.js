function GetComment(parametrs) {
    const postId = parametrs.postId;
    const login = parametrs.login;
    $.ajax({
        type: 'GET',
        url: '/Comment/GetComment',
        data: { "postId": postId, "login": login },
        success: function (data) {
            $("#scrolCommentList").prepend(data);
        }
    });
}