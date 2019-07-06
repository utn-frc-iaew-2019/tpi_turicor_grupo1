$(document).ready(function () {

    $.ajax({
        url: 'http://localhost:55669/api/Reserva',
        success: function (respuesta) {
            console.log("exitooo");
            cargarTablaReservas(respuesta);
        },
        error: function () {
            console.log("No se ha podido obtener la información");
        }
    });

    // Función: Carga las reservas a la tabla
    function cargarTablaReservas(reservas) {
        var body = $("#tbl-reservas tbody");
        body.empty();
        for (var i = 0; i < reservas.length; i++) {
            var fila = document.createElement("tr");

            var id = document.createElement("td");
            id.appendChild(document.createTextNode(reservas[i].IdP));


            var cod = document.createElement("td");
            cod.appendChild(document.createTextNode(reservas[i].CodigoP));

            var fechaReserva = document.createElement("td");
            fechaReserva.appendChild(document.createTextNode(reservas[i].FechaRetiroP));

            var cliente = document.createElement("td");
            cliente.appendChild(document.createTextNode(reservas[i].apellidoNombreClienteP));

            var vendedor = document.createElement("td");
            vendedor.appendChild(document.createTextNode(reservas[i].nombreVendedorP));

            var costo = document.createElement("td");
            costo.appendChild(document.createTextNode(reservas[i].costoP));

            var precioVenta = document.createElement("td");
            precioVenta.appendChild(document.createTextNode(reservas[i].precioVentaP));

            var vehiculo = document.createElement("td");
            vehiculo.appendChild(document.createTextNode(reservas[i].IdVehiculoCiudadP));

            var ciudad = document.createElement("td");
            ciudad.appendChild(document.createTextNode(reservas[i].idCiudadP));

            var pais = document.createElement("td");
            pais.appendChild(document.createTextNode(reservas[i].idPaisP));

            fila.append(id);
            fila.append(cod);
            fila.append(fechaReserva);
            fila.append(cliente);
            fila.append(vendedor);
            fila.append(costo);
            fila.append(precioVenta);
            fila.append(vehiculo);
            fila.append(ciudad);
            fila.append(pais);
            body.append(fila);
        }
    }
    

});