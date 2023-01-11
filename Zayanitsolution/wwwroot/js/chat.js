var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
connection.on("ReceiveMessage", function (sequenceId, message) {
    var data = JSON.parse(message);
    console.log(data)
    var li = ` <section class="section companey-logo-section registration-box">
                <div class="container">
                    <h4>Current Stage : ${data.ObjectName}</h4>
                </div>
            </section>

            <section class="section reg-section" id="reg-section">
                <div class="container">
                    <div class="reg-content-box">
                        <div class="reg-logo">
                            <img src="/${data.ParticipantImage}" alt="logo" class="img-fluid mx-auto" width="180px">
                        </div>
                        <div class="reg-details">
                            <h4>You have Successfully registered You have joined ${data.ObjectTitle}</h4>
                        </div>
                    </div>
                </div>
            </section>`;
    $("#messagesList").html(li);
});
connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

$("#sendButton").click(function () {
    var sequenceId = document.getElementById("sequenceId").value;
    connection.invoke("SendMessage", sequenceId).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
