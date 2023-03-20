let _connection,chatUrl,groupId;

function startSignalR(){
    chatUrl = "http://localhost:7033/comment";
    groupId = document.getElementById("chatId").innerHTML;

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

function disconnect() {

    if (_connection && _connection.state === 'Connected') {
        console.log("Disconnecting...");
        _connection.stop();
    }
    return;
}

function buildConnection() {
    _connection = new signalR.HubConnectionBuilder()
        .withUrl(chatUrl,
            {
            })
        .build();
    _connection.on("SendMessageInGroupAsync", (user, message, group) => {
        GetMessage({ content: message });
        console.log(`${user} in ${group}: ${message}`);
    });
    _connection.on("RemoveConnectionInGroup", (group) => {
        console.log(`${user} not in ${group}`);
    });
}

function sendInMessageGroup() {
    var message = document.getElementById("messageField").value;
    const userName = document.getElementById("UserName").innerHTML;
    if (!message) {
        alert("Message is required");
        return;
    }
    if (!userName) {
        alert("you should be authorized for send message");
        return;
    }
    console.log(`${userName} send ${message}`)
    _connection.invoke("SendMessageInGroupAsync", userName, message, groupId);
    document.getElementById("messageField").value = "";
}

function removeConnectFromChattingGroup() {
    _connection.invoke("RemoveConnectionInGroup", groupId);
}
