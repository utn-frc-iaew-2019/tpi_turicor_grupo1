Public Class ServicioPaises
    Private credenciales As New ServicioWCF.Credentials
    Private cliente As New ServicioWCF.WCFReservaVehiculosClient

    Public Sub New()
        credenciales.UserName = "grupo_nro1"
        credenciales.Password = "AzArobmjV0"
    End Sub

    Public Function consultarPaises()
        Dim listado = cliente.ConsultarPaises(credenciales)
        Return listado
    End Function

End Class
