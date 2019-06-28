Public Class ServicioReserva
    Private credenciales As New ServicioWCF.Credentials
    Private cliente As New ServicioWCF.WCFReservaVehiculosClient
    Dim cadena_conexion As String = "Data Source=IRINA\BDSERVER12;Initial Catalog=TuricorBD;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework"
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

    Public Sub crearReserva(codigo, nombre, dni, idVendedor, costo, precioVenta, idVehiculoCiudad, fechaRetiro, idPais, idCiudad)
        Dim conexion As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand
        Dim id As Integer
        id = Int((10000 * Rnd()) + 1)

        Dim idCliente As Integer
        idCliente = crearCliente(nombre, dni)
        conexion.ConnectionString = cadena_conexion
        conexion.Open()
        cmd.Connection = conexion
        cmd.CommandType = CommandType.Text

        Dim sql As String = ""


        sql = "INSERT INTO Reservas ("
        sql &= "id, codigoReserva, fechaReserva, idCliente, idVendedor, costo, precioVenta, idVehiculoCiudad, idCiudad, idPais ) "
        sql &= " VALUES ("
        sql &= id
        sql &= " ," & codigo
        sql &= " ," & idCliente
        sql &= " ," & idVendedor
        sql &= " ," & costo
        sql &= " ," & precioVenta
        sql &= " ," & idVehiculoCiudad
        sql &= " ," & idCiudad
        sql &= " ," & idPais
        sql &= ")"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
        conexion.Close()

    End Sub

    Public Function crearNuevaReserva(idVehiculoCiudad, fechaRetiro, fechaDevolucion, apellidoNombreCliente, dniCliente, costo, precioVenta, lugarRetiro, lugarDevolucion)
        Dim request As New ServicioWCF.ReservarVehiculoRequest()
        request.IdVehiculoCiudad = idVehiculoCiudad
        request.FechaHoraRetiro = fechaRetiro
        request.FechaHoraDevolucion = fechaDevolucion
        request.ApellidoNombreCliente = apellidoNombreCliente
        request.NroDocumentoCliente = dniCliente
        Dim lugarDevol As ServicioWCF.LugarRetiroDevolucion = lugarDevolucion
        Dim lugarRet As ServicioWCF.LugarRetiroDevolucion = lugarRetiro

        request.LugarDevolucion = lugarDevol
        request.LugarRetiro = lugarRet

        Dim response = cliente.ReservarVehiculo(credenciales, request)
        Return response.Reserva
    End Function

    Public Function cancelarReservaPorCodigo(codigoReserva)
        Dim request As New ServicioWCF.CancelarReservaRequest()
        request.CodigoReserva = codigoReserva
        Dim response As ServicioWCF.CancelarReservaResponse = cliente.CancelarReserva(credenciales, request)
        Return response.Reserva
    End Function

End Class
