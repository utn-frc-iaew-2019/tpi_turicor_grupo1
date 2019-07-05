Public Class ServicioVendedor
    Private credenciales As New ServicioWCF.Credentials
    Private cliente As New ServicioWCF.WCFReservaVehiculosClient
    Dim cadena_conexion As String = "Provider=SQLNCLI11;Data Source=IRINA\BDSERVER12;Integrated Security=SSPI;Initial Catalog=TuricorBD"


    Public Sub New()
        credenciales.UserName = "grupo_nro1"
        credenciales.Password = "AzArobmjV0"
    End Sub

    Public Function consultarVendedores()
        Dim sql As String = " "
        Dim conexion As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand
        Dim tabla As New Data.DataTable
        Dim reserva As New Reserva

        conexion.ConnectionString = cadena_conexion
        conexion.Open()
        cmd.Connection = conexion
        cmd.CommandType = CommandType.Text


        sql = " SELECT * FROM Vendedor"

        cmd.CommandText = sql
        tabla.Load(cmd.ExecuteReader())
        conexion.Close()

        Dim vendedores As New ArrayList
        Dim c As Integer = 0
        For c = 0 To tabla.Rows.Count - 1
            Dim vendedor As New Vendedor
            vendedor.idP = tabla.Rows(c)(0)
            vendedor.nombreP = tabla.Rows(c)(1)
            vendedores.Add(vendedor)
        Next

        Return vendedores
    End Function
End Class
