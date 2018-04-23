using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;
using System.Collections;
using System.Collections.ObjectModel;

namespace DxTreeViewTest
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
            this.Loaded+=MainWindow_Loaded;			
		}

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            BuildTree();
            //treeListView.DataContext = treeListView;
        }

        ObservableCollection<TreeListNode> RootNode = new ObservableCollection<TreeListNode>();
        private void BuildTree()
        {
            TreeListNode rootNode = CreateRootNode(new Item() { Value = 3, IsProcessed = false });
            TreeListNode childNode = CreateChildNode(rootNode, new Item() { Value = 15, IsProcessed = true });
            CreateChildNode(childNode, new Item() { Value = 6, IsProcessed = false });

            TreeListNode childNode1 = CreateChildNode(rootNode, new Item() { Value = 3, IsProcessed = false });
            CreateChildNode(childNode1, new Item() { Value = 9, IsProcessed = true });

            //grid.ItemsSource = rootNode;
        }

        private TreeListNode CreateRootNode(object dataObject)
        {
            TreeListNode rootNode = new TreeListNode(dataObject);
            treeListView.Nodes.Add(rootNode);
            RootNode.Add(rootNode);
            return rootNode;
        }

        private TreeListNode CreateChildNode(TreeListNode parentNode, object dataObject)
        {
            TreeListNode childNode = new TreeListNode(dataObject);
            parentNode.Nodes.Add(childNode);
            return childNode;
        }
    }

    public class Item {
        public int Value { get; set; }
        public bool IsProcessed { get; set; }
    }
	
}
