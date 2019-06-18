Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class VehiculoController
        Inherits ApiController

        ' GET: api/Vehiculo
        Public Function GetValues() As IEnumerable(Of String)
            Dim servicioVehiculo As New ServicioVehiculo
            Return servicioVehiculo.consultarVehiculos()
        End Function

        ' GET: api/Vehiculo/5
        Public Function GetValue(ByVal id As Integer) As String
            Return "value"
        End Function

        ' POST: api/Vehiculo
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/Vehiculo/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/Vehiculo/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace