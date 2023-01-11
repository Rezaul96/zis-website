"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});
$("#registrationStart").click(function () {
    var sequenceId = document.getElementById("sequenceId").value;
    connection.invoke("RegistrationStart", sequenceId).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
    location.reload();
});
$("#registrationEnd").click(function () {
    var sequenceId = document.getElementById("sequenceId").value;
    connection.invoke("RegistrationEnd", sequenceId).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
    location.reload();
});