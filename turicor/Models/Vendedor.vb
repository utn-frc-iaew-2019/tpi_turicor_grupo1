Public Class Vendedor

    Private idVendedor As Integer
    Public Property idP() As Integer
        Get
            Return idVendedor
        End Get
        Set(ByVal value As Integer)
            idVendedor = value
        End Set
    End Property

    Private nombreVendedor As String
    Public Property nombreP() As String
        Get
            Return nombreVendedor
        End Get
        Set(ByVal value As String)
            nombreVendedor = value
        End Set
    End Property
End Class
