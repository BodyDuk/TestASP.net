$(function () {
    LoadData();
    $("#btnSave").click(function () {
        //alert("");
        var std = {};
        std.FirstName = $("#FirstName").val();
        std.studentAddress = $("#LastName").val();
        std.Age = $("#Age").val();
        $.ajax({
            type: "POST",
            url: '@Url.Action("createJS")',
            data: '{std: ' + JSON.stringify(std) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                // alert("Data has been added successfully.");
                LoadData();
            },
            error: function () {
                alert("Error while inserting data");
            }
        });
        return false;
    });
});

function LoadData() {
    $("#ActorTable tbody tr").remove();
    $.ajax({
        type: 'POST',
        url: '@Url.Action("getActorJS")',
        dataType: 'json',
        data: { id: '' },
        success: function (data) {
            writeDataToTable(data);
            //var items = '';
            //$.each(data, function (i, item) {
            //    це розбий на ыншу функцыю запису даних
            //    var rows = "<tr>"
            //        + "<td class='prtoducttd'>" + item.Id + "</td>"
            //        + "<td class='prtoducttd'>" + item.FirstName + "</td>"
            //        + "<td class='prtoducttd'>" + item.LastName + "</td>"
            //        + "<td class='prtoducttd'>" + item.Age + "</td>"
            //        + "</tr>";
            //    $('#ActorTable tbody').append(rows);
            //});
        },
        error: function (ex) {
            var r = jQuery.parseJSON(response.responseText);
            alert("Message: " + r.Message);
            alert("StackTrace: " + r.StackTrace);
            alert("ExceptionType: " + r.ExceptionType);
        }
    });
    return false;
}

function writeDataToTable(data) {
    var actorsTable = $('#actorsTable');
    actorsTable.empty();
    for (var i = 0; i < data.length; i++) {
        actorsTable.append('<tr><td class = "producttd">' + data.Id + '</td><td class="producttd">'
            + data.FirstName + '</td><td class="producttd">' + data.LastName + '</td><td class="producttd">'
            + data.Age + '</td></tr>');
    }
}