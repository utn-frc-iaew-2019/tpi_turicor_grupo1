function onSignIn(googleUser) {
    // Datos del usuario logueado:
    var profile = googleUser.getBasicProfile();
    console.log("ID: " + profile.getId()); 
    console.log('Full Name: ' + profile.getName());
    console.log('Given Name: ' + profile.getGivenName());
    console.log('Family Name: ' + profile.getFamilyName());
    console.log("Image URL: " + profile.getImageUrl());
    console.log("Email: " + profile.getEmail());

    // ID token del usuario para pasar al backend:
    var id_token = googleUser.getAuthResponse().id_token;
    console.log("ID Token: " + id_token);
   
}
function signOut() {
    var auth2 = gapi.auth2.getAuthInstance();
    auth2.signOut().then(function () {
        console.log('Sesión cerrada.');
    });
}

$(document).ready(function () {

    $.ajax({
        url: 'http://localhost:55669/api/Vehiculo',
        success: function (respuesta) {
            console.log("exitooo");
            console.log(respuesta);
        },
        error: function () {
            console.log("No se ha podido obtener la información");
        }
    });

});