Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Grid
Imports System.Collections
Imports System.Collections.ObjectModel

Namespace DxTreeViewTest
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
			AddHandler Me.Loaded, AddressOf MainWindow_Loaded
		End Sub

		Private Sub MainWindow_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			BuildTree()
			'treeListView.DataContext = treeListView;
		End Sub

		Private RootNode As New ObservableCollection(Of TreeListNode)()
		Private Sub BuildTree()
'INSTANT VB NOTE: The variable rootNode was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim rootNode_Conflict As TreeListNode = CreateRootNode(New Item() With {
				.Value = 3,
				.IsProcessed = False
			})
			Dim childNode As TreeListNode = CreateChildNode(rootNode_Conflict, New Item() With {
				.Value = 15,
				.IsProcessed = True
			})
			CreateChildNode(childNode, New Item() With {
				.Value = 6,
				.IsProcessed = False
			})

			Dim childNode1 As TreeListNode = CreateChildNode(rootNode_Conflict, New Item() With {
				.Value = 3,
				.IsProcessed = False
			})
			CreateChildNode(childNode1, New Item() With {
				.Value = 9,
				.IsProcessed = True
			})

			'grid.ItemsSource = rootNode;
		End Sub

		Private Function CreateRootNode(ByVal dataObject As Object) As TreeListNode
'INSTANT VB NOTE: The variable rootNode was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim rootNode_Conflict As New TreeListNode(dataObject)
			treeListView.Nodes.Add(rootNode_Conflict)
			RootNode.Add(rootNode_Conflict)
			Return rootNode_Conflict
		End Function

		Private Function CreateChildNode(ByVal parentNode As TreeListNode, ByVal dataObject As Object) As TreeListNode
			Dim childNode As New TreeListNode(dataObject)
			parentNode.Nodes.Add(childNode)
			Return childNode
		End Function
	End Class

	Public Class Item
		Public Property Value() As Integer
		Public Property IsProcessed() As Boolean
	End Class

End Namespace
