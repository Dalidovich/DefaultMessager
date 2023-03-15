function GetCompanion(parametrs) {
    const accountId = parametrs.accountId;
    $.ajax({
        type: 'GET',
        url: '/Account/GetAccountIconViewModel',
        data: { "accountId": accountId },
        success: function (data) {
            $("#companionDiv").html(data);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function GetCorrespondence(parametrs) {
    const companionId = parametrs.accountId;
    $.ajax({
        type: 'GET',
        url: '/Message/GetPartialMessages',
        data: { "companionId": companionId },
        success: function (data) {
            $("#scrolMessageList").html(data);
            document.getElementById("scrolMessageList").scrollTop = document.getElementById("scrolMessageList").scrollHeight;
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

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