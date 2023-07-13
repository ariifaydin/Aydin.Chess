// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function onClick(x, y, karedolumu, id) {
    $.ajax({
        async: false,
        url: '/Satranc/OnClick',
        data: { X: x, Y: y, KareDolumu: karedolumu, Id: id },
        method: "POST",
        //contentType: "application/json;charset=utf-8",
        success: function (d) {
            $('body').html(d)
        }, error: function (e) {
            console.error(e);
            alert("hata olustu");
        }, complete: function () {
        }
    });
}

