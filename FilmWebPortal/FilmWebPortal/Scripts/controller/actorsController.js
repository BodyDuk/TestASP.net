function data() {
    var firstName = $('#FirstName').val();
    var lastName = $('#LastName').val();
    var age = $('#Age').val();
    $.ajax({
        type: "POST",
        cache: false,
        url: "/Actors/createJs",
        data: { selectedUser: selectedUser, classID: classID },
        success: function (newListOfActors) {
            onSuccessActors(newListOfActors);
        }
    });
}

function onSuccessActors(newListOfActors) {
    var actorsTable = $('#actorsTable');
    actorsTable.empty();
    for (var i = 0; i < newListOfActors.length; i++) {
        actorsTable.append('<tr><td>' + newListOfActors[i].Id + '</td></tr>' 
            + '<tr><td>' + newListOfActors[i].FirstName + '</td></tr>'
            + '<tr><td>' + newListOfActors[i].LastName + '</td></tr>'
            + '<tr><td>' + newListOfActors[i].LastName + '</td></tr>');
    }
}