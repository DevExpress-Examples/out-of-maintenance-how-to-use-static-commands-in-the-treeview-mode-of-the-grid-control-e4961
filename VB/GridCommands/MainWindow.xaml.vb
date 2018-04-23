Imports Microsoft.VisualBasic
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
			Dim rootNode As TreeListNode = CreateRootNode(New Item() With {.Value = 3, .IsProcessed = False})
			Dim childNode As TreeListNode = CreateChildNode(rootNode, New Item() With {.Value = 15, .IsProcessed = True})
			CreateChildNode(childNode, New Item() With {.Value = 6, .IsProcessed = False})

			Dim childNode1 As TreeListNode = CreateChildNode(rootNode, New Item() With {.Value = 3, .IsProcessed = False})
			CreateChildNode(childNode1, New Item() With {.Value = 9, .IsProcessed = True})

			'grid.ItemsSource = rootNode;
		End Sub

		Private Function CreateRootNode(ByVal dataObject As Object) As TreeListNode
			Dim rootNode As New TreeListNode(dataObject)
			treeListView.Nodes.Add(rootNode)
			Me.RootNode.Add(rootNode)
			Return rootNode
		End Function

		Private Function CreateChildNode(ByVal parentNode As TreeListNode, ByVal dataObject As Object) As TreeListNode
			Dim childNode As New TreeListNode(dataObject)
			parentNode.Nodes.Add(childNode)
			Return childNode
		End Function
	End Class

	Public Class Item
		Private privateValue As Integer
		Public Property Value() As Integer
			Get
				Return privateValue
			End Get
			Set(ByVal value As Integer)
				privateValue = value
			End Set
		End Property
		Private privateIsProcessed As Boolean
		Public Property IsProcessed() As Boolean
			Get
				Return privateIsProcessed
			End Get
			Set(ByVal value As Boolean)
				privateIsProcessed = value
			End Set
		End Property
	End Class

End Namespace
