$(document).ready(function () {
    var reservaSeleccionada = null;

    // Función: carga los datos de la reserva en los labels
    function cargarDatosReserva(reserva) {
        $("#lbl-identificador").text(reserva.Identificador);
        $("#lbl-codigo-reserva").text(reserva.CodigoReserva);
        $("#lbl-fecha-reserva").text(reserva.FechaReserva);
        $("#lbl-fecha-devolucion").text(reserva.FechaDevolucion);
        $("#lbl-cliente").text(reserva.Cliente);
        $("#lbl-vendedor").text(reserva.Vendedor);
        $("#lbl-costo").text(reserva.PrecioPorDia);
        $("#lbl-precio-venta").text(reserva.PrecioVenta);
    }
    // Evento: busca la reserva por codigo
    $("#btn-buscar").click(function () {
        reservaSeleccionada = $("#txt-codigo-reserva").val().trim();
        if (reservaSeleccionada !== null) {
            $.ajax({
                url: 'http://localhost:55669/api/Reserva/' + reservaSeleccionada + '/',
                success: function (respuesta) {
                    console.log("exitooo");
                    console.log(respuesta);
                    cargarDatosReserva(respuesta);
                },
                error: function (e) {
                    console.log("Error al obtener reserva: ", e.responseText);
                }
            });
        }
    });

    // Evento: cancela la reserva por codigo
    $("#btn-cancelar").click(function () {
        if (reservaSeleccionada !== null) {
            $.ajax({
                url: 'http://localhost:55669/api/Reserva/' + codigoAbuscar + '/',
                success: function (respuesta) {
                    console.log("exitooo");
                    console.log(respuesta);
                    cargarDatosReserva(respuesta);
                },
                error: function (e) {
                    console.log("Error al obtener reserva: ", e.responseText);
                }
            });
        }
    });

});