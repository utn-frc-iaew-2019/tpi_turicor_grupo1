﻿Public Class Reserva



    Private IdVehiculoCiudad As Integer
    Public Property IdVehiculoCiudadP() As Integer
        Get
            Return IdVehiculoCiudad
        End Get
        Set(ByVal value As Integer)
            IdVehiculoCiudad = value
        End Set
    End Property

    Private FechaRetiro As String

    Public Property FechaRetiroP() As String
        Get
            Return FechaRetiro
        End Get
        Set(ByVal value As String)
            FechaRetiro = value
        End Set
    End Property

    Private FechaDevolucion As String
    Public Property FechaDevolucionP() As String
        Get
            Return FechaDevolucion
        End Get
        Set(ByVal value As String)
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

    Private idPais As String
    Public Property idPaisP() As String
        Get
            Return idPais
        End Get
        Set(ByVal value As String)
            idPais = value
        End Set
    End Property

    Private idCiudad As String
    Public Property idCiudadP() As String
        Get
            Return idCiudad
        End Get
        Set(ByVal value As String)
            idCiudad = value
        End Set
    End Property
End Class
