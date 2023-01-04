"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/dashboardhub").build();

$(function ()
{
    connection.start().then(function () {
        alert("Connected to dashboardhub");
    }).catch(function
        (error) {
        console.error(error);
    });

});