function SaveFilm() {
    var name = $('#Name').val();
    var description = $('#Description').val();
    var actorsList = [];
    var inputElements = document.getElementsByClassName('messageCheckbox');
    for (var i = 0; inputElements[i]; ++i) {
        if (inputElements[i].checked) {
            actorsList.push(inputElements[i].value);
        }
    }
    $.ajax({
        type: "POST",
        cache: false,
        url: "/Films/SaveFilm",
        contentType: 'application/json',
        data: JSON.stringify({
            Name: name,
            Description: description,
            SelectedActors: actorsList
        }),
        success: function () {
            window.location.replace("https://localhost:44349/Films/Index");
        },
    });
} 