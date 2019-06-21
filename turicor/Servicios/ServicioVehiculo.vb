Public Class ServicioVehiculo
    Private credenciales As New ServicioWCF.Credentials
    Private cliente As New ServicioWCF.WCFReservaVehiculosClient

    Public Sub New()
        credenciales.UserName = "grupo_nro1"
        credenciales.Password = "AzArobmjV0"
    End Sub

    Public Function consultarVehiculos()

        Dim request As New ServicioWCF.ConsultarVehiculosRequest()

        Dim listado = cliente.ConsultarVehiculosDisponibles(credenciales, request)
        Return listado
    End Function

End Class
