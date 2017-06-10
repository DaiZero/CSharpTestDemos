using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using WpfApp_TestDemo.ViewModels;

namespace WpfApp_TestDemo.Views
{
    /// <summary>
    /// TreeViewDemo.xaml 的交互逻辑
    /// </summary>
    public partial class TreeListControl_View : Window
    {
        public TreeListControl_View()
        {
            InitializeComponent();
            this.DataContext = new TreeListControl_ViewModel();

        }



        private void TreeListView_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Console.WriteLine("PreviewMouseDown");
        }

        private void TreeListView_CustomNodeFilter(object sender, DevExpress.Xpf.Grid.TreeList.TreeListNodeFilterEventArgs e)
        {
            #region 方法一
            var view = (TreeListView)sender;
            if (string.IsNullOrEmpty(view.SearchString))
                return;

            if (e.Node.HasChildren)
            {
                SearchControl searchControl = view.SearchControl;
                string criteriaString = CriteriaOperator.LegacyToString(searchControl.FilterCriteria).Replace("DxFts_", "");
                var ee = new ExpressionEvaluator(TypeDescriptor.GetProperties(typeof(Employee)), criteriaString, false);

                e.Visible = ee.Fit(e.Node.Content) || new TreeListNodeIterator(e.Node).Select(x => x.Content).Any(ee.Fit);
                e.Handled = true;
            }
            #endregion


            #region 方法二（有缺陷）
            //TreeListNode node = e.Node;
            //TreeListNode parentNode = e.Node.ParentNode;
            //if (parentNode == null)
            //{
            //    e.Visible = true;
            //    e.Handled = true;
            //    return;
            //}
            //if (parentNode != null && node.IsExpanded)
            //{
            //    e.Visible = true;
            //    e.Handled = true;
            //}
            #endregion

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
    public class Employee
    {
        public string ID { get; set; }
        public string ParentID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }

        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee() { ID = "100001", ParentID = "", Name = "Gregory S. Price", Department = "", Position = "President" });
            employees.Add(new Employee() { ID = "100002", ParentID = "100001", Name = "Irma R. Marshall", Department = "Marketing", Position = "Vice President" });
            employees.Add(new Employee() { ID = "100003", ParentID = "100001", Name = "John C. Powell", Department = "Operations", Position = "Vice President" });
            employees.Add(new Employee() { ID = "100004", ParentID = "100001", Name = "Christian P. Laclair", Department = "Production", Position = "Vice President" });
            employees.Add(new Employee() { ID = "100005", ParentID = "100001", Name = "Karen J. Kelly", Department = "Finance", Position = "Vice President" });
            employees.Add(new Employee() { ID = "100006", ParentID = "100002", Name = "Brian C. Cowling", Department = "Marketing", Position = "Manager" });
            employees.Add(new Employee() { ID = "100007", ParentID = "100002", Name = "Thomas C. Dawson", Department = "Marketing", Position = "Manager" });
            employees.Add(new Employee() { ID = "100008", ParentID = "100002", Name = "Angel M. Wilson", Department = "Marketing", Position = "Manager" });
            employees.Add(new Employee() { ID = "100009", ParentID = "100002", Name = "Bryan R. Henderson", Department = "Marketing", Position = "Manager" });
            employees.Add(new Employee() { ID = "100010", ParentID = "100003", Name = "Harold S. Brandes", Department = "Operations", Position = "Manager" });
            employees.Add(new Employee() { ID = "100011", ParentID = "100003", Name = "Michael S. Blevins", Department = "Operations", Position = "Manager" });
            employees.Add(new Employee() { ID = "100012", ParentID = "100003", Name = "Jan K. Sisk", Department = "Operations", Position = "Manager" });
            employees.Add(new Employee() { ID = "100013", ParentID = "100003", Name = "Sidney L. Holder", Department = "Operations", Position = "Manager" });
            employees.Add(new Employee() { ID = "100014", ParentID = "100004", Name = "James L. Kelsey", Department = "Production", Position = "Manager" });
            employees.Add(new Employee() { ID = "100015", ParentID = "100004", Name = "Howard M. Carpenter", Department = "Production", Position = "Manager" });
            employees.Add(new Employee() { ID = "100016", ParentID = "100004", Name = "Jennifer T. Tapia", Department = "Production", Position = "Manager" });
            employees.Add(new Employee() { ID = "100017", ParentID = "100005", Name = "Judith P. Underhill", Department = "Finance", Position = "Manager" });
            employees.Add(new Employee() { ID = "100018", ParentID = "", Name = "Russell E. Belton", Department = "Finance", Position = "Manager" });
            return employees;
        }
    }
}
