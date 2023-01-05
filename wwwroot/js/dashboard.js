"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/dashboardhub").build();

$(async function ()
{
    connection.start().then(function () {
        alert("Connected to dashboardhub");
        InvokeProducts();
    }).catch(function
        (error) {
        console.error(error);
    });
    setTimeout(start, 30_000);
});

connection.onclose(async () => {
    await start();
});



async function InvokeProducts() {
    await connection.invoke("SendProducts").catch(function (error) {
        console.log(error);
    })
}
  connection.on("ReceiveProducts", function (products) {
    BindProductsToGrid(products);
});
async function BindProductsToGrid(products) {

    $("#tableProduct tbody").empty();
    var tr;
    $.each(products, function (index, product) {
        tr = $('<tr/>');
        tr.append(`<td>${(index + 1)}</td>`);
        tr.append(`<td>${(product.name)}</td>`);
        tr.append(`<td>${(product.price)}</td>`);
        tr.append(`<td>${(product.category.name)}</td>`);
        $('#tableProduct').append(tr);
    })
}
