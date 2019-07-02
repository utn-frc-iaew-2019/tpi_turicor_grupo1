function onSignIn(googleUser) {
    // Habilita los botones del menu
    $(".btn-navbar").removeClass("d-none");

    // Datos del usuario logueado:
    var profile = googleUser.getBasicProfile();
    console.log("ID: " + profile.getId()); 
    console.log('Full Name: ' + profile.getName()); 
    $("#lbl-ingreso").text("Hola " + profile.getName() + "! Ya podés usar el menú de la barra superior.");

    // ID token del usuario para pasar al backend:
    var id_token = googleUser.getAuthResponse().id_token;
    console.log("ID Token: " + id_token);
}
function signOut() {
    var auth2 = gapi.auth2.getAuthInstance();
    auth2.signOut().then(function () {
        // Oculta las opciones del menu
        $(".btn-navbar").addClass("d-none");
        $("#lbl-ingreso").text("Ingresá con tu usuario de Google para continuar:");
        console.log('Sesión cerrada.');
    });
}