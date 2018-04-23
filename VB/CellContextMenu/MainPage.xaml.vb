Imports Microsoft.VisualBasic
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.Grid

Namespace CellContextMenu
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			grid.DataSource = New ProductList()
		End Sub

		Private Sub copyCellDataItem_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			Dim menuInfo As GridCellMenuInfo = TryCast(view.GridMenu.MenuInfo, GridCellMenuInfo)
			If menuInfo IsNot Nothing AndAlso menuInfo.Row IsNot Nothing Then
				Dim text As String = "" & grid.GetCellValue(menuInfo.Row.RowHandle.Value, menuInfo.Column).ToString()
				Clipboard.SetText(text)
			End If
		End Sub

		Private Sub deleteRowItem_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			Dim menuInfo As GridCellMenuInfo = TryCast(view.GridMenu.MenuInfo, GridCellMenuInfo)
			If menuInfo IsNot Nothing AndAlso menuInfo.Row IsNot Nothing Then
				view.DeleteRow(menuInfo.Row.RowHandle.Value)
			End If
		End Sub
	End Class
End Namespace
