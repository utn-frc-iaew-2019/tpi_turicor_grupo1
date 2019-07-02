Imports System.Net
Imports System.Web.Http

Public Class ReservaController
    Inherits ApiController

    ' GET api/Reserva
    Public Function GetValues()
        Dim servicioReserva As New ServicioReserva
        Return servicioReserva.consultarTodasLasReservas()
    End Function

    ' GET api/Reserva/5
    Public Function GetValue(ByVal id As String)
        Dim servicioReserva As New ServicioReserva
        Return servicioReserva.consultarReservaPorCodigo(id)
    End Function

    ' POST api/Reserva
    Public Sub PostValue(<FromBody()> ByVal reserva As Reserva)

        ' **************** Acá crear el cliente y la reserva en la BD nuestra **************************
        ' Este controlador recibe los parámetros que se enviaron en el body y los pone en un objeto de la clase Reserva



        Dim idVendedor = reserva.idVendedorP
        Dim idVehiculoCiudad = reserva.IdVechiculoCiudad
        Dim fechaRetiro = reserva.FechaRetiroP
        Dim fechaDevolucion = reserva.FechaDevolucionP
        Dim lugarRetiro = reserva.lugarRetiroP
        Dim lugarDevolucion = reserva.lugarDevolucionP
        Dim apellidoNombreCliente = reserva.apellidoNombreClienteP
        Dim dniCliente = reserva.dniClienteP
        Dim costo = reserva.costoP
        Dim precioVenta = reserva.precioVentaP
        Dim idPais = reserva.idPaisP
        Dim idCiudad = reserva.idCiudadP


        ' Crea una nueva reserva en el servicio WCF y retorna el código de reserva
        Dim servicioReserva As New ServicioReserva
        ' Le pasa los datos del front 
        servicioReserva.crearCliente(apellidoNombreCliente, dniCliente)

        Dim codigoReserva = servicioReserva.crearNuevaReserva(reserva.IdVechiculoCiudad,
                                                 reserva.FechaRetiroP,
                                                 reserva.FechaDevolucionP,
                                                 reserva.apellidoNombreClienteP,
                                                 reserva.dniClienteP,
                                                 reserva.costoP,
                                                 reserva.precioVentaP,
                                                 reserva.lugarRetiroP,
                                                 reserva.lugarDevolucionP)

        servicioReserva.crearReserva(codigoReserva, apellidoNombreCliente, dniCliente, idVendedor, costo, precioVenta, idVehiculoCiudad, fechaRetiro, idPais, idCiudad)

    End Sub

    ' PUT api/Reserva/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/Reserva/5
    Public Function DeleteValue(ByVal id As String)
        Dim servicioReserva As New ServicioReserva
        Return servicioReserva.cancelarReservaPorCodigo(id)
    End Function
End Class
