Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.Xpf
Imports Microsoft.EntityFrameworkCore
Imports System.Collections.Generic
Imports WPFDataGridGettingStartedNETCore.Models

Namespace WPFDataGridGettingStartedNETCore

    Public Class ViewModel
        Inherits ViewModelBase

        Private northwindDBContext As NorthwindEntities

        Public Property Orders As ICollection(Of Order)
            Get
                Return GetValue(Of ICollection(Of Order))()
            End Get

            Private Set(ByVal value As ICollection(Of Order))
                SetValue(value)
            End Set
        End Property

        Public Property Shippers As ICollection(Of Shipper)
            Get
                Return GetValue(Of ICollection(Of Shipper))()
            End Get

            Private Set(ByVal value As ICollection(Of Shipper))
                SetValue(value)
            End Set
        End Property

        Public Sub New()
            northwindDBContext = New NorthwindEntities()
            northwindDBContext.Orders.Load()
            Orders = northwindDBContext.Orders.Local
            northwindDBContext.Shippers.Load()
            Shippers = northwindDBContext.Shippers.Local
        End Sub

        <Command>
        Public Sub ValidateAndSave(ByVal args As RowValidationArgs)
            northwindDBContext.SaveChanges()
        End Sub
    End Class
End Namespace
