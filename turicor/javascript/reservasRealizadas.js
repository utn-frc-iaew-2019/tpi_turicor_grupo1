$(document).ready(function () {

    $.ajax({
        url: 'http://localhost:55669/api/Reserva',
        success: function (respuesta) {
            console.log("exitooo");
            console.log(respuesta);
            cargarDatosReserva(respuesta);
        },
        error: function () {
            console.log("No se ha podido obtener la información");
        }
    });
    function cargarDatosReserva(reserva) {
        $("#lbl-identificador").text(reserva.Identificador);
        $("#lbl-codigo-reserva").text(reserva.CodigoReserva);
        $("#lbl-fecha-reserva").text(reserva.FechaReserva);
        $("#lbl-cliente").text(reserva.Cliente);
        $("#lbl-vendedor").text(reserva.Vendedor);
        $("#lbl-costo").text(reserva.PrecioPorDia);
        $("#lbl-precio-venta").text(reserva.PrecioVenta);
    }

    
    

    }

});