Imports System.Collections.ObjectModel
Imports Microsoft.EntityFrameworkCore
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.Native
Imports WPFDataGridGettingStartedNETCore.Models

Namespace WPFDataGridGettingStartedNETCore

    Public Class ViewModel
        Inherits ViewModelBase

        Private northwindDBContext As NorthwindEntities

        Public Sub New()
            If IsInDesignMode Then
                Orders = New ObservableCollection(Of Order)()
                Shippers = New ObservableCollection(Of Shipper)()
            Else
                northwindDBContext = New NorthwindEntities()
                northwindDBContext.Orders.Load()
                Orders = northwindDBContext.Orders.ToObservableCollection()
                northwindDBContext.Shippers.Load()
                Shippers = northwindDBContext.Shippers.ToObservableCollection()
            End If

            ValidateAndSaveCommand = New DelegateCommand(AddressOf ValidateAndSave)
        End Sub

        Public Property Orders As ObservableCollection(Of Order)
            Get
                Return GetValue(Of ObservableCollection(Of Order))()
            End Get

            Private Set(ByVal value As ObservableCollection(Of Order))
                SetValue(value)
            End Set
        End Property

        Public Property Shippers As ObservableCollection(Of Shipper)
            Get
                Return GetValue(Of ObservableCollection(Of Shipper))()
            End Get

            Private Set(ByVal value As ObservableCollection(Of Shipper))
                SetValue(value)
            End Set
        End Property

        Public ReadOnly Property ValidateAndSaveCommand As DelegateCommand

        Private Sub ValidateAndSave()
            northwindDBContext.SaveChanges()
        End Sub
    End Class
End Namespace
