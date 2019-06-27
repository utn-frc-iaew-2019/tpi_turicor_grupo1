Public Class Reserva

    Private IdVehiculoCiudad As Integer
    Public Property IdVechiculoCiudad() As Integer
        Get
            Return IdVehiculoCiudad
        End Get
        Set(ByVal value As Integer)
            IdVehiculoCiudad = value
        End Set
    End Property

    Private FechaRetiro As Date
    Public Property FechaRetiroP() As Date
        Get
            Return FechaRetiro
        End Get
        Set(ByVal value As Date)
            FechaRetiro = value
        End Set
    End Property

    Private FechaDevolucion As Date
    Public Property FechaDevolucionP() As Date
        Get
            Return FechaDevolucion
        End Get
        Set(ByVal value As Date)
            FechaDevolucion = value
        End Set
    End Property

    Private lugarRetiro As String
    Public Property lugarRetiroP() As String
        Get
            Return lugarRetiro
        End Get
        Set(ByVal value As String)
            lugarRetiro = value
        End Set
    End Property

    Private lugarDevolucion As String
    Public Property lugarDevolucionP() As String
        Get
            Return lugarDevolucion
        End Get
        Set(ByVal value As String)
            lugarDevolucion = value
        End Set
    End Property

    Private apellidoNombreCliente As String
    Public Property apellidoNombreClienteP() As String
        Get
            Return apellidoNombreCliente
        End Get
        Set(ByVal value As String)
            apellidoNombreCliente = value
        End Set
    End Property
    Private dniCliente As String
    Public Property dniClienteP() As String
        Get
            Return dniCliente
        End Get
        Set(ByVal value As String)
            dniCliente = value
        End Set
    End Property

    Private costo As Double
    Public Property costoP() As Double
        Get
            Return costo
        End Get
        Set(ByVal value As Double)
            costo = value
        End Set
    End Property

    Private precioVenta As Double
    Public Property precioVentaP() As Double
        Get
            Return precioVenta
        End Get
        Set(ByVal value As Double)
            precioVenta = value
        End Set
    End Property

    Private idVendedor As Integer
    Public Property idVendedorP() As Integer
        Get
            Return idVendedor
        End Get
        Set(ByVal value As Integer)
            idVendedor = value
        End Set
    End Property
End Class
