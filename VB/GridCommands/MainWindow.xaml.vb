Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.Grid
Imports System.Collections.ObjectModel

Namespace DxTreeViewTest

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            AddHandler Loaded, AddressOf Me.MainWindow_Loaded
        End Sub

        Private Sub MainWindow_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            BuildTree()
        'treeListView.DataContext = treeListView;
        End Sub

        Private RootNode As ObservableCollection(Of TreeListNode) = New ObservableCollection(Of TreeListNode)()

        Private Sub BuildTree()
            Dim rootNode As TreeListNode = CreateRootNode(New Item() With {.Value = 3, .IsProcessed = False})
            Dim childNode As TreeListNode = CreateChildNode(rootNode, New Item() With {.Value = 15, .IsProcessed = True})
            CreateChildNode(childNode, New Item() With {.Value = 6, .IsProcessed = False})
            Dim childNode1 As TreeListNode = CreateChildNode(rootNode, New Item() With {.Value = 3, .IsProcessed = False})
            CreateChildNode(childNode1, New Item() With {.Value = 9, .IsProcessed = True})
        'grid.ItemsSource = rootNode;
        End Sub

        Private Function CreateRootNode(ByVal dataObject As Object) As TreeListNode
            Dim rootNode As TreeListNode = New TreeListNode(dataObject)
            Me.treeListView.Nodes.Add(rootNode)
            Me.RootNode.Add(rootNode)
            Return rootNode
        End Function

        Private Function CreateChildNode(ByVal parentNode As TreeListNode, ByVal dataObject As Object) As TreeListNode
            Dim childNode As TreeListNode = New TreeListNode(dataObject)
            parentNode.Nodes.Add(childNode)
            Return childNode
        End Function
    End Class

    Public Class Item

        Public Property Value As Integer

        Public Property IsProcessed As Boolean
    End Class
End Namespace
