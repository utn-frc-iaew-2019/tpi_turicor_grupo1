Public Class ServicioReserva
    Private credenciales As New ServicioWCF.Credentials
    Private cliente As New ServicioWCF.WCFReservaVehiculosClient
    Dim cadena_conexion As String = "Data Source=IRINA\BDSERVER12;Initial Catalog=TuricorBD;Integrated Security=True"
    Public Sub New()
        credenciales.UserName = "grupo_nro1"
        credenciales.Password = "AzArobmjV0"
    End Sub

    Public Function consultarReservaPorCodigo(codigoReserva)
        Dim request As New ServicioWCF.ConsultarReservasRequest()
        request.CodigoReserva = codigoReserva
        Dim response As ServicioWCF.ConsultarReservasResponse = cliente.ConsultarReserva(credenciales, request)
        Return response.Reserva
    End Function

    Public Function consultarTodasLasReservas()
        Dim sql As String = " "
        Dim conexion As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand
        Dim tabla As New Data.DataTable
        Dim reserva As New Reserva

        conexion.ConnectionString = cadena_conexion
        conexion.Open()
        cmd.Connection = conexion
        cmd.CommandType = CommandType.Text


        sql = " SELECT Reservas.id, Reservas.codigoReserva, Reservas.fechaReserva, Clientes.nombre, Vendedor.nombre, Reservas.costo, Reservas.precioVenta, Reservas.idVehiculoCiudad, Reservas.idCiudad, Reservas.idPais"
        sql &= " FROM Reservas INNER JOIN Clientes ON Reservas.idCliente = Clientes.id INNER JOIN Vendedor ON Reservas.idVendedor = Vendedor.id"

        cmd.CommandText = sql
        tabla.Load(cmd.ExecuteReader())
        conexion.Close()


        Dim c As Integer = 0
        For c = 0 To tabla.Rows.Count - 1
            ' id = tabla.Rows(c)(1)
            ' codigo = tabla.Rows(c)(2)
            reserva.FechaRetiroP = tabla.Rows(c)(3)
            reserva.apellidoNombreClienteP = tabla.Rows(c)(4)
            ' reserva.nombreVendedor = tabla.Rows(c)(5)
            reserva.costoP = tabla.Rows(c)(6)
            reserva.precioVentaP = tabla.Rows(c)(7)
            reserva.IdVehiculoCiudadP = tabla.Rows(c)(8)
            reserva.idCiudadP = tabla.Rows(c)(9)
            reserva.idPaisP = tabla.Rows(c)(10)

        Next


        Return reserva
    End Function


    Public Function crearCliente(nombre, dni)
        Dim conexion As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand
        Dim id As Integer
        id = Int((10000 * Rnd()) + 1)
        conexion.ConnectionString = cadena_conexion
        conexion.Open()
        cmd.Connection = conexion
        cmd.CommandType = CommandType.Text

        Dim sql As String = ""


        sql = "INSERT INTO Clientes ("
        sql &= "id, nombre, apellido, nroDocumento ) "
        sql &= " VALUES ("
        sql &= id
        sql &= " ,'" & nombre.Text.Trim & "'"
        sql &= " ," & "''"
        sql &= " ," & dni.Text.Trim
        sql &= ")"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
        conexion.Close()

        Return id

    End Function

    Public Function crearNuevaReserva(reserva As Reserva)
        Dim request As New ServicioWCF.ReservarVehiculoRequest()
        request.IdVehiculoCiudad = reserva.IdVehiculoCiudadP
        request.FechaHoraRetiro = reserva.FechaRetiroP
        request.FechaHoraDevolucion = reserva.FechaDevolucionP
        request.ApellidoNombreCliente = reserva.apellidoNombreClienteP
        request.NroDocumentoCliente = reserva.dniClienteP

        request.LugarDevolucion = LugarEnumMapping(reserva.lugarDevolucionP)
        request.LugarRetiro = LugarEnumMapping(reserva.lugarRetiroP)

        Dim response = cliente.ReservarVehiculo(credenciales, request)
        Return response.Reserva
    End Function

    Private Function LugarEnumMapping(lugar As String) As ServicioWCF.LugarRetiroDevolucion
        Select Case (lugar)
            Case "Hotel"
                Return ServicioWCF.LugarRetiroDevolucion.Hotel
            Case "Aeropuerto"
                Return ServicioWCF.LugarRetiroDevolucion.Aeropuerto
            Case "TerminalBuses"
                Return ServicioWCF.LugarRetiroDevolucion.TerminalBuses
            Case Else
                Return ServicioWCF.LugarRetiroDevolucion.Hotel
        End Select
    End Function

    Public Function cancelarReservaPorCodigo(codigoReserva)
        Dim request As New ServicioWCF.CancelarReservaRequest()
        request.CodigoReserva = codigoReserva
        Dim response As ServicioWCF.CancelarReservaResponse = cliente.CancelarReserva(credenciales, request)
        Return response.Reserva
    End Function

End Class
