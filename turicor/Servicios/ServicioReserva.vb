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

    Public Function crearNuevaReserva(reserva As Reserva)
        Dim request As New ServicioWCF.ReservarVehiculoRequest()
        request.IdVehiculoCiudad = reserva.IdVehiculoCiudadP
        request.FechaHoraRetiro = reserva.FechaRetiroP
        request.FechaHoraDevolucion = reserva.FechaDevolucionP
        request.ApellidoNombreCliente = reserva.apellidoNombreClienteP
        request.NroDocumentoCliente = reserva.dniClienteP

        request.LugarDevolucion = LugarEnumMapping(reserva.lugarDevolucionP)
        request.LugarRetiro = LugarEnumMapping(reserva.lugarRetiroP)

        Dim response = cliente.ReservarVehiculo(credenciales, request)
        Return response.Reserva
    End Function

    Public Function cancelarReservaPorCodigo(codigoReserva)
        Dim request As New ServicioWCF.CancelarReservaRequest()
        request.CodigoReserva = codigoReserva
        Dim response As ServicioWCF.CancelarReservaResponse = cliente.CancelarReserva(credenciales, request)
        Return response.Reserva
    End Function

    Private Function LugarEnumMapping(lugar As String) As ServicioWCF.LugarRetiroDevolucion
        Select Case (lugar)
            Case "Hotel"
                Return ServicioWCF.LugarRetiroDevolucion.Hotel
            Case "Aeropuerto"
                Return ServicioWCF.LugarRetiroDevolucion.Aeropuerto
            Case "TerminalBuses"
                Return ServicioWCF.LugarRetiroDevolucion.TerminalBuses
            Case Else
                Return ServicioWCF.LugarRetiroDevolucion.Hotel
        End Select
    End Function
End Class
