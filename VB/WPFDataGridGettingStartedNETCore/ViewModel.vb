Imports System.Collections.ObjectModel
Imports Microsoft.EntityFrameworkCore
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.Native
Imports DXGridGetStartedCore.Models

Namespace DXGridGetStartedCore
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
				Orders = northwindDBContext.Orders.ToObservableCollection(Of Order)()

				northwindDBContext.Shippers.Load()
				Shippers = northwindDBContext.Shippers.ToObservableCollection(Of Shipper)()
			End If
			ValidateAndSaveCommand = New DelegateCommand(AddressOf ValidateAndSave)
		End Sub
		Public ReadOnly Property Orders() As ObservableCollection(Of Order)
		Public ReadOnly Property Shippers() As ObservableCollection(Of Shipper)
		Public ReadOnly Property ValidateAndSaveCommand() As DelegateCommand
		Private Sub ValidateAndSave()
			northwindDBContext.SaveChanges()
		End Sub
	End Class
End Namespace