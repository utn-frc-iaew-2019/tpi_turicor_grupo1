Public Class ServicioPaises
    Private credenciales As New ServicioWCF.Credentials
    Private cliente As New ServicioWCF.WCFReservaVehiculosClient

    Public Sub New()
        credenciales.UserName = "grupo_nro1"
        credenciales.Password = "AzArobmjV0"
    End Sub

    Public Function consultarPaises()
        Dim response As ServicioWCF.ConsultarPaisesResponse = cliente.ConsultarPaises(credenciales)
        Return response.Paises
    End Function

    Public Function consultarCiudades(idPais)
        Dim request As New ServicioWCF.ConsultarCiudadesRequest()
        request.IdPais = idPais
        Dim response As ServicioWCF.ConsultarCiudadesResponse = cliente.ConsultarCiudades(credenciales, request)
        Return response.Ciudades
    End Function

End Class
