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
    console.log(files[0]);
    //var newObject = {
    //    'lastModified': files[0].lastModified,
    //    'lastModifiedDate': files[0].lastModifiedDate,
    //    'name': files[0].name,
    //    'size': files[0].size,
    //    'type': files[0].type
    //};
    //console.log(newObject);

    var data = {
     
        File: files,
        ImportedField :1,
        MissingField : 5,
        csvContents: {}
    }
  
    $.ajax({
        type: "POST",
        url: "/Wizard/FileUploadPartial",
        //dataType: "text/csv",
        contentType: true,
        processData: false,
        data: { 'uploadedFile': data }
       
        //success: function () {
        //    showInPopup("/Wizard/FileUploadPartial", 'Upload')
        //}
        //JSON.stringify(data)
    })
}