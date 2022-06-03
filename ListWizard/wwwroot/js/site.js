// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

showInPopup = (url, title) => {

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


function submitFormData() {

    var wizardList = {
        ListId : 0,
        ListName : $('#listname').val(),
        AssignedTo : $('#assignedto').val(),
        CreatedDate: $('#createdate').val(),
        ModifiedDate: null,
        IsDeleted: null,
        CsvContents: {}
    }

   // console.log(wizardList);

    $.ajax({
        type: "POST",
        url: "/Wizard/CreateNewListPartial",
        data: { 'wizardList' : wizardList },
        success: function () {
            showInPopup("/Wizard/FileUploadPartial",'Upload')
        }
    });
}
                                                                                    
                                                                                
function onUploadSubmit() {

    //var form = new FormData();
    //form.append("uploadfile", fileInputElement.files[0]);
    //console.log(form);

    var files = $('#uploadfile')[0].files;
   // console.log(files[0]);
    //var dat = document.getElementById('#uploadpart');
    
    //console.log(dataform);
    //var uploadedFile = new FormData($('#uploadpart'));
    ////uploadedFile.append("File", files[0]);
    ////uploadedFile.append("ImportedField", 1);
    ////uploadedFile.append("MissingField", 2);
    ////uploadedFile.append("csvContents", {});
    //console.log(uploadedFile.serialize());

    var data = {
     
        File: files[0],
        //ImportedField :1,
        //MissingField : 5,
        //csvContents: {}
    }
    var dataform = new FormData();
    dataform.set('uploadedFile', files[0], files[0].name);
    console.log(dataform);
    console.log(files[0]);
    console.log(typeof (files[0]));
    $.ajax({
        type: "POST",
        url: "/Wizard/FileUploadPartial",
        contentType: "multipart/form-data; boundary=something",
        processData: false,
        data: { 'uploadedFile': files[0] }
       
        //success: function () {
        //    showInPopup("/Wizard/FileUploadPartial", 'Upload')
        //}
        //JSON.stringify(data)
    })
}