function OpenPostModelWindow(parametrs) {
    const url = parametrs.url;
    const postId = parametrs.data;
    const modal = $('#modal');
    if (url == undefined || postId == undefined) {
        alert('model or url undefined')
    }
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
function OpenEditDescriptionModelWindow(parametrs) {
    const url = parametrs.url;
    const descriptionId = parametrs.data;
    const modal = $('#modal');
    if (url == undefined || descriptionId == undefined) {
        alert('model or url undefined')
    }
    $.ajax({
        type: 'GET',
        url: url,
        data: { "descriptionId": descriptionId },
        success: function (response) {
            modal.html(response);
            modal.modal('show')
        },
        failure: function () {
            modal.modal('hide')
        },
        error: function (response) {
            console.log(response.responseText);
        }
    });
}
function OpenCreatePostModelWindow(parametrs) {
    const url = parametrs.url;
    const modal = $('#modal');
    if (url == undefined ) {
        alert('url undefined')
    }
    $.ajax({
        type: 'GET',
        url: url,
        data: {},
        success: function (response) {
            modal.html(response);
            modal.modal('show')
        },
        failure: function () {
            modal.modal('hide')
        },
        error: function (response) {
            console.log(response.responseText);
        }
    });
}
function OpenDeleteImageAlbumModelWindow(parametrs) {
    const url = parametrs.url;
    const imageAlbumId = parametrs.data;
    const modal = $('#modal');
    if (url == undefined || imageAlbumId == undefined) {
        alert('model or url undefined')
    }
    $.ajax({
        type: 'GET',
        url: url,
        data: { "imageAlbumId": imageAlbumId },
        success: function (response) {
            modal.html(response);
            modal.modal('show')
        },
        failure: function () {
            modal.modal('hide')
        },
        error: function (response) {
            console.log(response.responseText);
        }
    });
}
function CloseModelWindow() {
    $('#modal').html('');
    $('#modal').modal('hide')
}