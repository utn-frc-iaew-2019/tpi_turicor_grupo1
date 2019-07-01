Public Class ServicioReserva
    Private credenciales As New ServicioWCF.Credentials
    Private cliente As New ServicioWCF.WCFReservaVehiculosClient

    Public Sub New()
        credenciales.UserName = "grupo_nro1"
        credenciales.Password = "AzArobmjV0"
    End Sub

    Public Function consultarReservaPorCodigo(codigoReserva)
        Dim request As New ServicioWCF.ConsultarReservasRequest()
        request.CodigoReserva = codigoReserva
        Dim response As ServicioWCF.ConsultarReservasResponse = cliente.ConsultarReserva(credenciales, request)
        Return response.Reserva
    End Function

    Public Function crearNuevaReserva(idVehiculoCiudad, fechaRetiro, fechaDevolucion, apellidoNombreCliente, dniCliente, costo, precioVenta, lugarRetiro, lugarDevolucion)
        Dim request As New ServicioWCF.ReservarVehiculoRequest()
        request.IdVehiculoCiudad = idVehiculoCiudad
        request.FechaHoraRetiro = fechaRetiro
        request.FechaHoraDevolucion = fechaDevolucion
        request.ApellidoNombreCliente = apellidoNombreCliente
        request.NroDocumentoCliente = dniCliente

        Dim ld As ServicioWCF.LugarRetiroDevolucion = lugarDevolucion
        Dim lr As ServicioWCF.LugarRetiroDevolucion = lugarRetiro
        request.LugarDevolucion = ld
        request.LugarRetiro = lr

        Dim response = cliente.ReservarVehiculo(credenciales, request)
        Return response.Reserva
    End Function

    Public Function cancelarReservaPorCodigo(codigoReserva)
        Dim request As New ServicioWCF.CancelarReservaRequest()
        request.CodigoReserva = codigoReserva
        Dim response As ServicioWCF.CancelarReservaResponse = cliente.CancelarReserva(credenciales, request)
        Return response.Reserva
    End Function

End Class
