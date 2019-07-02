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
    Public Function PostValue(<FromBody()> ByVal reserva As Reserva)

        ' **************** Acá crear el cliente y la reserva en la BD nuestra **************************
        ' Este controlador recibe los parámetros que se enviaron en el body y los pone en un objeto de la clase Reserva



        Dim idVendedor = reserva.idVendedorP



        ' Crea una nueva reserva en el servicio WCF y retorna el código de reserva
        Dim servicioReserva As New ServicioReserva
        Return servicioReserva.crearNuevaReserva(reserva.IdVechiculoCiudad,
                                                 reserva.FechaRetiroP,
                                                 reserva.FechaDevolucionP,
                                                 reserva.apellidoNombreClienteP,
                                                 reserva.dniClienteP,
                                                 reserva.costoP,
                                                 reserva.precioVentaP,
                                                 reserva.lugarRetiroP,
                                                 reserva.lugarDevolucionP)
    End Function

    ' PUT api/Reserva/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/Reserva/5
    Public Function DeleteValue(ByVal id As String)
        Dim servicioReserva As New ServicioReserva
        Return servicioReserva.cancelarReservaPorCodigo(id)
    End Function
End Class
