// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

showInPopup = (url, title) => {
    /*    let wizardList = {}*/
    var holder = $('#placeHolder');
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            holder.html(res);
            //$("#form-modal .modal-title").html(title);
            holder.find('.modal .modal-title').html(title);
            holder.find('.modal').modal('show');

        }
    })
}