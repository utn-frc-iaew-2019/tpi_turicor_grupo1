Public Class ServicioVehiculo

    Private cliente As ServicioWCF.WCFReservaVehiculosClient
    Public Property propCliente() As ServicioWCF.WCFReservaVehiculosClient
        Get
            Return cliente
        End Get
        Set(ByVal value As ServicioWCF.WCFReservaVehiculosClient)
            cliente = value
        End Set
    End Property

End Class
