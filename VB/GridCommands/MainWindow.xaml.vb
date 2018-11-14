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

            Dim rootNode_Renamed As TreeListNode = CreateRootNode(New Item() With { _
                .Value = 3, _
                .IsProcessed = False _
            })
            Dim childNode As TreeListNode = CreateChildNode(rootNode_Renamed, New Item() With { _
                .Value = 15, _
                .IsProcessed = True _
            })
            CreateChildNode(childNode, New Item() With { _
                .Value = 6, _
                .IsProcessed = False _
            })

            Dim childNode1 As TreeListNode = CreateChildNode(rootNode_Renamed, New Item() With { _
                .Value = 3, _
                .IsProcessed = False _
            })
            CreateChildNode(childNode1, New Item() With { _
                .Value = 9, _
                .IsProcessed = True _
            })

            'grid.ItemsSource = rootNode;
        End Sub

        Private Function CreateRootNode(ByVal dataObject As Object) As TreeListNode

            Dim rootNode_Renamed As New TreeListNode(dataObject)
            treeListView.Nodes.Add(rootNode_Renamed)
            RootNode.Add(rootNode_Renamed)
            Return rootNode_Renamed
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
