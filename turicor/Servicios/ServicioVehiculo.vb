Imports Newtonsoft.Json
Public Class ServicioVehiculo
    Private credenciales As New ServicioWCF.Credentials
    Private cliente As New ServicioWCF.WCFReservaVehiculosClient

    Public Sub New()
        credenciales.UserName = "grupo_nro1"
        credenciales.Password = "AzArobmjV0"
    End Sub

    Public Function consultarVehiculos(idCiudad As Int16)
        ' Consulta los vehiculos disponibles de la ciudad con id recibido por parametro
        Dim request As New ServicioWCF.ConsultarVehiculosRequest()
        request.IdCiudad = idCiudad
        request.FechaHoraRetiro = DateTime.Now()
        request.FechaHoraDevolucion = DateTime.Now().AddDays(3)


        Dim response As ServicioWCF.ConsultarVehiculosDisponiblesResponse = cliente.ConsultarVehiculosDisponibles(credenciales, request)

        Return response.VehiculosEncontrados
    End Function

End Class
