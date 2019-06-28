$(document).ready(function () {

    //$.ajax({
    //    url: 'http://localhost:55669/api/Reserva',
    //    success: function (respuesta) {
    //        console.log("exitooo");
    //        console.log(respuesta);
    //    },
    //    error: function () {
    //        console.log("No se ha podido obtener la información");
    //    }
    //});


    //ESTO ES DE GUIA PARA CONSULTAR EN LA BD Y CARGAR LA TABLA 

    //Private Sub cargar_grilla()
    //Dim sql As String = " "
    //Dim conexion As New OleDb.OleDbConnection
    //Dim cmd As New OleDb.OleDbCommand
    //Dim tabla As New Data.DataTable

    //conexion.ConnectionString = cadena_conexion
    //conexion.Open()
    //cmd.Connection = conexion
    //cmd.CommandType = CommandType.Text


    //sql = "SELECT Gusto_Helado.id_helado, Gusto_Helado.nombre, Gusto_Helado.precioxkg, Proveedores.razon_social"
    //sql &= ", Gusto_Helado.stock, Gusto_Helado.id_proveedor FROM Gusto_Helado INNER JOIN Proveedores ON Gusto_Helado.id_proveedor = Proveedores.cuit WHERE Proveedores.activo = 1 "

    //cmd.CommandText = sql
    //tabla.Load(cmd.ExecuteReader())
    //conexion.Close()

    //Me.grid_helados.Rows.Clear()

    //Dim c As Integer = 0
    //For c = 0 To tabla.Rows.Count - 1
    //Me.grid_helados.Rows.Add()
    //Me.grid_helados.Rows(c).Cells(0).Value = tabla.Rows(c)(0)
    //Me.grid_helados.Rows(c).Cells(1).Value = tabla.Rows(c)(1)
    //Me.grid_helados.Rows(c).Cells(2).Value = tabla.Rows(c)(2)
    //Me.grid_helados.Rows(c).Cells(3).Value = tabla.Rows(c)(3)
    //Me.grid_helados.Rows(c).Cells(4).Value = tabla.Rows(c)(4)
    //Next
    //End Sub

});