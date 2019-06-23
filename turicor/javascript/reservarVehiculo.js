$(document).ready(function () {

    $.ajax({
        url: 'http://localhost:55669/api/Paises',
        success: function (respuesta) {
            console.log("exitooo");
            console.log(respuesta);
        },
        error: function () {
            console.log("No se ha podido obtener la información");
        }
    });

});