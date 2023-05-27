let _connection,chatUrl,groupId;

function startSignalR(){
    chatUrl = "http://localhost:7150/comment";
    groupId = document.getElementById("postIdDiv").innerHTML;

    buildConnection();
    start();
}

async function start() {
    try {
        await _connection.start();
        console.log(groupId);
        _connection.invoke("SetConnectionInGroup", groupId);
        console.log(`SignalR Connected to ${chatUrl}`);
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
}

function buildConnection() {
    _connection = new signalR.HubConnectionBuilder()
        .withUrl(chatUrl,
            {
            })
        .build();
    _connection.on("SendMessageInGroupAsync", (user, message, group) => {
        GetComment({ postId: group, login: user });
        console.log(`${user} in ${group}: ${message}`);
    });
}

function sendInGroup() {
    var message = document.getElementById("commentField").value;
    const userName = document.getElementById("UserName").innerHTML;
    if (!message) {
        alert("Message is required");
        return;
    }
    if (!userName) {
        alert("you should be authorized for send comments");
        return;
    }
    console.log(`${userName} send ${message}`)
    _connection.invoke("SendMessageInGroupAsync", userName, message, groupId);
    document.getElementById("commentField").value = "";
}

function removeConnectFromGroup() {
    _connection.invoke("RemoveConnectionInGroup", groupId);
    document.getElementById("modal").innerHTML = "";
}
