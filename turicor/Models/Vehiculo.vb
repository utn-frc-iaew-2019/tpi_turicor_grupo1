Public Class Vehiculo
    Private id As Int16
    Public Property prop_id() As Int16
        Get
            Return id
        End Get
        Set(ByVal value As Int16)
            id = value
        End Set
    End Property
End Class
