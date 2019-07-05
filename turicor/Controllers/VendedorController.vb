Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class VendedorController
        Inherits ApiController

        ' GET: api/Vendedor
        Public Function GetValues()
            Dim servicioVendedor As New ServicioVendedor
            Return servicioVendedor.consultarVendedores()
        End Function

        ' GET: api/Vendedor/5
        Public Function GetValue(ByVal id As Integer) As String
            Return "value"
        End Function

        ' POST: api/Vendedor
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/Vendedor/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/Vendedor/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace