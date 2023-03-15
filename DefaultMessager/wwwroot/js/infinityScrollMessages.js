var page = 0;
var _inCallback = false;
document.getElementById('scrolMessageList').addEventListener('scroll', loadMessageItems)
function loadMessageItems() {
    if (document.getElementById("scrolMessageList").firstElementChild != null) {
        let topFirstMessage = document.getElementById("scrolMessageList").firstElementChild.getBoundingClientRect().top;
        var topListDiv = document.getElementById("scrolMessageList").getBoundingClientRect().top;
        if (page > -1 && !_inCallback && topFirstMessage == topListDiv) {
            _inCallback = true;
            page++;
            let compId = document.getElementById("compId").innerHTML;
            $.ajax({
                type: 'GET',
                url: '/Message/GetPartialMessages',
                data: { "id": page, "companionId": compId },
                success: function (data, textstatus) {
                    if (data != '') {
                        $("#scrolMessageList").prepend(data);
                        document.getElementById("scrolMessageList").scrollTop = 28;
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
}
document.getElementById("scrolMessageList").scrollTop = document.getElementById("scrolMessageList").scrollHeight;