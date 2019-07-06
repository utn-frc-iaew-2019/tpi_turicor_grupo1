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

    function agregarEventoAbotonesReservar() {
        // Evento: Realiza la reserva del vehículo
        $(".btn-reservar").click(function () {
           
            var idVehiculoCiudadValidado = $(this).data('id');
            var fechaRetiroValidada = $("#txt-fecha-reserva").val() + "T00:00:00";
            var fechaDevolucionValidada = $("#txt-fecha-devolucion").val() + "T00:00:00";
            var lugarRetiroValidado = $("#slc-lugar-retiro").val();
            var lugarDevolucionValidado = $("#slc-lugar-devolucion").val();
            var apellidoNombreClienteValidado = $("#txt-nombre-cliente").val();
            var dniClienteValidado = $("#txt-dni-cliente").val();
            var costoPorDia = $(this).data('costo');
            var precioVentaValidado = costoPorDia + (0.2 * costoPorDia);
            var idVendedorSeleccionado = "1" //$("#slc-vendedor").val();

            $.ajax({
                type: "POST",
                url: 'http://localhost:55669/api/Reserva',
                data: {
                    idVehiculoCiudadP: idVehiculoCiudadValidado,
                    fechaRetiroP: fechaRetiroValidada,
                    fechaDevolucionP: fechaDevolucionValidada,
                    lugarRetiroP: lugarRetiroValidado,
                    lugarDevolucionP: lugarDevolucionValidado,
                    apellidoNombreClienteP: apellidoNombreClienteValidado,
                    dniClienteP: dniClienteValidado,
                    costoP: costoPorDia,
                    precioVentaP: precioVentaValidado,
                    idVendedorP: idVendedorSeleccionado
                },
                success: function (respuesta) {
                    console.log("exitoo");
                    console.log(respuesta);
                },
                error: function (e) {
                    console.log("Error al reservar: ", e);
                }
            });

        });
    }

    // Función: Carga los vehículos a la tabla
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
            
            var botonTD = document.createElement("td");
            botonTD.innerHTML = '<button class="btn btn-primary btn-reservar" data-id="' + vehiculos[i].VehiculoCiudadId + '" data-costo="' + vehiculos[i].PrecioPorDia + '">Reservar</button>' ;
            
            fila.append(id);
            fila.append(marca);
            fila.append(modelo);
            fila.append(puntaje); 
            fila.append(puertas);
            fila.append(disponibles);
            fila.append(precioTD);
            fila.append(botonTD);

            body.append(fila);
        }
        agregarEventoAbotonesReservar();
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
            $("#slc-pais").append('<option value=" - 1">Seleccione un país</option>');

            console.log("Error al obtener paises: ", e);
        }
    });

    $.ajax({
        url: 'http://localhost:55669/api/Vendedor/',
        success: function (respuesta) {
            // Carga el select de vendedores
            console.log(respuesta);
            cargarSelectVendedor($("#slc-vendedor"), respuesta);
        },
        error: function (e) {
            $("#slc-vendedor").empty();
            $("#slc-vendedor").append('<option value=" - 1">Seleccione un vendedor</option>');

            console.log("Error al obtener vendedores: ", e);
        }
    });

    function cargarSelectVendedor($select, array) {
        $select.empty();
        for (var i = 0; i < array.length; i++) {
            var option = document.createElement("option");
            option.value = array[i].idP;
            option.text = array[i].nombreP;

            $select.append(option)
        }
        $select.focus().trigger("change");
    }

    function cargarSelectVendedor($select, array) {
        $select.empty();
        for (var i = 0; i < array.length; i++) {
            var option = document.createElement("option");
            option.value = array[i].idP;
            option.text = array[i].nombreP;

            $select.append(option)
        }
        $select.focus().trigger("change");
    }

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

    // Evento: Hace la petición de vehículos cuando cambia la ciudad elegida
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

                    // Muestra todo el formulario y la tabla y oculta el cargando
                    $("#div-formulario").removeClass("d-none");
                    $("#contenedor-tbl-vehiculos").removeClass("d-none");
                    $(".loading").remove();
                },
                error: function (e) {
                    console.log("Error al obtener vehiculos disponibles: ", e);
                }
            });
        }
    });
    $("form").submit(function (event) {
        event.preventDefault();
    });
});