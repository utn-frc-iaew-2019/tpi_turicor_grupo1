Imports System.Net
Imports System.Web.Http

Public Class PaisesController
    Inherits ApiController

    ' GET api/Paises
    Public Function GetValues()
        Dim servicioPaises As New ServicioPaises
        Return servicioPaises.consultarPaises()
    End Function

    ' GET api/Paises/5
    Public Function GetValue(ByVal id As Integer)
        Dim servicioPaises As New ServicioPaises
        Return servicioPaises.consultarCiudades(id)
    End Function

    ' POST api/<controller>
    Public Sub PostValue(<FromBody()> ByVal value As String)

    End Sub

    ' PUT api/<controller>/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/<controller>/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class
