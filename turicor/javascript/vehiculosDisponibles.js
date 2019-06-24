$(document).ready(function () {
    // Función: Cargar datos a select
    function cargarSelect($select, array) {
        $select.empty();
        for (var i = 0; i < array.length; i++) {
            var option = document.createElement("option");
            option.value = array[i].Id;
            option.text = array[i].Nombre;

            $select.append(option)
        }
        $select.focus().trigger("change");
    }
    // Función: Carga los vehículos a la tabla}
    function cargarTablaVehiculos(vehiculos) {
        var body = $("#tbl-vehiculos tbody");
        body.empty();
        for (var i = 0; i < vehiculos.length; i++) {
            var fila = document.createElement("tr");

            var id = document.createElement("td");
            id.appendChild(document.createTextNode(vehiculos[i].Id));

            var marca = document.createElement("td");
            marca.appendChild(document.createTextNode(vehiculos[i].Marca));

            var modelo = document.createElement("td");
            modelo.appendChild(document.createTextNode(vehiculos[i].Modelo));

            var puntaje = document.createElement("td");
            puntaje.appendChild(document.createTextNode(vehiculos[i].Puntaje));

            var puertas = document.createElement("td");
            puertas.appendChild(document.createTextNode(vehiculos[i].CantidadPuertas));

            var disponibles = document.createElement("td");
            disponibles.appendChild(document.createTextNode(vehiculos[i].CantidadDisponible));

            var precioAlquiler = vehiculos[i].PrecioPorDia + (vehiculos[i].PrecioPorDia) * 0.2;
            var precioTD = document.createElement("td");
            precioTD.appendChild(document.createTextNode("$" + precioAlquiler));

            fila.append(id);
            fila.append(marca);
            fila.append(modelo);
            fila.append(puntaje);
            fila.append(puertas);
            fila.append(disponibles);
            fila.append(precioTD);

            body.append(fila);
        }
    }

    // Setup: Consulta todos los paises para cargar el select
    $.ajax({
        url: 'http://localhost:55669/api/Paises/',
        success: function (respuesta) {
            // Carga el select de países
            cargarSelect($("#slc-pais"), respuesta);
        },
        error: function (e) {
            $("#slc-pais").empty();
            $("#slc-pais").append('<option value=" - 1">Elegir país...</option>');

            console.log("Error al obtener paises: ", e);
        }
    });

    // Evento: Hace la petición  de ciudades cuando cambia el pais elegido
    $("#slc-pais").on("change", function () {
        var idPais = $(this).val();
        if (idPais != undefined && idPais !== "-1") {
            $.ajax({
                url: 'http://localhost:55669/api/Paises/' + idPais + '/',

                success: function (respuesta) {
                    // Carga el select de ciudades
                    cargarSelect($("#slc-ciudad"), respuesta);
                },
                error: function (e) {
                    console.log("Error al obtener ciudades: ", e);
                }
            });
        } else {
            // Limpia el select de ciudades
            $("#slc-ciudad").empty();
            $("#slc-ciudad").append('<option value=" - 1">Elegir ciudad...</option>');
        }
    });

    // Evento: Hace la petición cuando cambia la ciudad elegida
    $("#slc-ciudad").on("change", function () {
        var idCiudad = $(this).val();
        if (idCiudad != undefined && idCiudad !== "-1") {
            $.ajax({
                url: 'http://localhost:55669/api/Vehiculo',
                data: {
                    idCiudad: idCiudad
                },
                success: function (respuesta) {
                    // Carga todos los datos de los autos en la tabla
                    cargarTablaVehiculos(respuesta);
                },
                error: function (e) {
                    console.log("Error al obtener vehiculos disponibles: ", e);
                }
            });
        }
    });

    

});