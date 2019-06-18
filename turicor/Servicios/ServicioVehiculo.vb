Public Class ServicioVehiculo

    Private cliente As New ServicioWCF.WCFReservaVehiculosClient

    Public Function consultarVehiculos()
        Dim usuario = "grupo_nro1"
        Dim pass = "AzArobmjV0"
        Dim credenciales As New ServicioWCF.Credentials()
        credenciales.UserName = usuario
        credenciales.Password = pass

        Dim request As New ServicioWCF.ConsultarVehiculosRequest()

        Dim listado = cliente.ConsultarVehiculosDisponibles(credenciales, request)
        Return listado
    End Function

End Class
