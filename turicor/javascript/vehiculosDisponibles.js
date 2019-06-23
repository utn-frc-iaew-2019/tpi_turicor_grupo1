$(document).ready(function () {
    // Función: Cargar datos a select
    function cargarSelect($select, array) {
        for (var i = 0; i < array.length; i++) {
            var option = document.createElement("option");
            option.value = array[i].Id;
            option.text = array[i].Nombre;

            $select.append(option)
        }
    }

    // Setup: Consulta todos los paises para cargar el select
    $.ajax({
        url: 'http://localhost:55669/api/Paises/',
        success: function (respuesta) {
            // Carga el select de países
            $("#slc-pais").empty();
            cargarSelect($("#slc-pais"), respuesta);
        },
        error: function (e) {
            $("#slc-pais").empty();
            $("#slc-pais").append('<option value=" - 1">Seleccione un país</option>');

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
                    $("#slc-ciudad").empty();
                    cargarSelect($("#slc-ciudad"), respuesta);
                },
                error: function (e) {
                    console.log("Error al obtener ciudades: ", e);
                }
            });
        } else {
            // Limpia el select de ciudades
            $("#slc-ciudad").empty();
            $("#slc-ciudad").append('<option value=" - 1">Seleccione una ciudad</option>');
        }
    });

    // Evento: Hace la petición cuando cambia la ciudad elegida
    $("#slc-ciudad").on("change", function () {
        var idCiudad = $(this).val();
        console.log("AA consulto ciudad: ", idCiudad);
        if (idCiudad != undefined && idCiudad !== "-1") {
            $.ajax({
                url: 'http://localhost:55669/api/Vehiculo',
                data: {
                    idCiudad: idCiudad
                },
                success: function (respuesta) {
                    console.log("exitooo");
                    console.log(respuesta);
                    // Cargar todos los datos de los autos en la tabla
                    // ** atributos **
                    //CantidadDisponible: 8
                    //CantidadPuertas: 4
                    //CiudadId: 1
                    //Id: 4
                    //Marca: "Ford"
                    //Modelo: "Ka"
                    //PrecioPorDia: 350
                    //Puntaje: "4"
                    //TieneAireAcon: true
                    //TieneDireccion: true
                    //TipoCambio: "M"
                    //VehiculoCiudadId: 21
                },
                error: function () {
                    console.log("No se ha podido obtener la información");
                }
            });
        }
    });

    

});