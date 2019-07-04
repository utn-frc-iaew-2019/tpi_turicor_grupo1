$(document).ready(function () {
    var reservaSeleccionada = null;

    // Función: carga los datos de la reserva en los labels
    function cargarDatosReserva(reserva) {
        $("#lbl-id").text(reserva.Id);
        $("#lbl-id-vehiculo-ciudad").text(reserva.VehiculoPorCiudadId);
        $("#lbl-vehiculo").text(reserva.VehiculoPorCiudadEntity.VehiculoEntity.Marca + " " + VehiculoPorCiudadEntity.VehiculoEntity.Modelo);
        $("#lbl-codigo-reserva").text(reserva.CodigoReserva);
        $("#lbl-fecha-reserva").text(reserva.FechaReserva);
        $("#lbl-fecha-retiro").text(reserva.FechaHoraRetiro);
        $("#lbl-fecha-cancelacion").text(reserva.FechaHoraCancelacion);
        $("#lbl-fecha-devolucion").text(reserva.FechaHoraDevolucion);
        $("#lbl-cliente").text(reserva.ApellidoNombreCliente);
        $("#lbl-estado").text(reserva.Estado);
        $("#lbl-lugar-devolucion").text(reserva.LugarDevolucion);
        $("#lbl-lugar-retiro").text(reserva.LugarRetiro);
        $("#lbl-total").text(reserva.TotalReserva);
        $("#lbl-usuario-cancelacion").text(reserva.UsuarioCancelacion);
    }
    // Evento: busca la reserva por codigo
    $("#btn-buscar").click(function (e) {
        e.preventDefault();
        reservaSeleccionada = $("#txt-codigo-reserva").val().trim();
        if (reservaSeleccionada !== "" && reservaSeleccionada != null) {
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
        } else {
            $("#txt-codigo-reserva").focus();
            alert("Debe escribir el código de la reserva que quiere buscar.");
        }
    });

    // Evento: cancela la reserva por codigo
    $("#btn-cancelar").click(function (e) {
        e.preventDefault();
        reservaSeleccionada = $("#txt-codigo-reserva").val().trim();
        if (reservaSeleccionada !== "" && reservaSeleccionada != null) {
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
        } else {
            $("#txt-codigo-reserva").focus();
            alert("Debe escribir el código de la reserva que quiere cancelar.");
        }
    });

});