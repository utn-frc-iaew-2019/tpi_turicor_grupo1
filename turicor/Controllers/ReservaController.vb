Imports System.Net
Imports System.Web.Http

Public Class ReservaController
    Inherits ApiController

    ' GET api/Reserva
    Public Function GetValues() As IEnumerable(Of String)
        Dim null As New List(Of String)
        Return null
    End Function

    ' GET api/Reserva/5
    Public Function GetValue(ByVal id As String)
        Dim servicioReserva As New ServicioReserva
        Return servicioReserva.consultarReservaPorCodigo(id)
    End Function

    ' POST api/Reserva
    Public Function PostValue(<FromBody()> ByVal idVehiculoCiudad, <FromBody()> ByVal fechaRetiro, <FromBody()> ByVal fechaDevolucion, <FromBody()> ByVal apellidoNombreCliente, <FromBody()> ByVal dniCliente, <FromBody()> ByVal costo, <FromBody()> ByVal precioVenta)
        Dim servicioReserva As New ServicioReserva
        Return servicioReserva.crearNuevaReserva(idVehiculoCiudad, fechaRetiro, fechaDevolucion, apellidoNombreCliente, dniCliente, costo, precioVenta)
    End Function

    ' PUT api/Reserva/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/Reserva/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class
