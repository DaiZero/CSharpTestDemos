using System.Collections.Generic;
using System.Windows;
using WpfApp_TestDemo.ViewModels;

namespace WpfApp_TestDemo.Views
{
    /// <summary>
    /// TreeViewDemo.xaml 的交互逻辑
    /// </summary>
    public partial class TreeViewDemo : Window
    {
        public TreeViewDemo()
        {
            InitializeComponent();
            this.DataContext = new TreeView_ViewModel();
        }
    }
    public class Node
    {
        public Node()
        {
            this.Nodes = new List<Node>();
            this.ParentID = -1;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int ParentID { get; set; }
        public bool IsSelected { get; set; }
        public List<Node> Nodes { get; set; }
    }
}
