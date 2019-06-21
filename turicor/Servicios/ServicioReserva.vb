Public Class ServicioReserva
    Private credenciales As New ServicioWCF.Credentials
    Private cliente As New ServicioWCF.WCFReservaVehiculosClient

    Public Sub New()
        credenciales.UserName = "grupo_nro1"
        credenciales.Password = "AzArobmjV0"
    End Sub

    Public Function consultarReservasRealizadas()

        Dim request As New ServicioWCF.ConsultarReservasRequest()

        Dim listado = cliente.ConsultarReserva(credenciales, request)
        Return listado
    End Function


End Class
