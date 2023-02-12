function OpenPostModelWindow(parametrs) {
    const url = parametrs.url;
    const postId = parametrs.data;
    const modal = $('#modal');
    if (url == undefined || postId == undefined) {
        alert('model or url undefined')
    }
    console.log(postId);
    $.ajax({
        type: 'GET',
        url: url,
        data: { "postId": postId },
        success: function (response) {
            modal.html(response);
            modal.modal('show')
        },
        failure: function () {
            modal.modal('hide')
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}