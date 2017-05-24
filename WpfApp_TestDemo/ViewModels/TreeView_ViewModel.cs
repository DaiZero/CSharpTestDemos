using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp_TestDemo.Views;

namespace WpfApp_TestDemo.ViewModels
{
    class TreeView_ViewModel : NotificationObject
    {
        public TreeView_ViewModel()
        {
            _lstNode = new List<Node>();
            _lstNode = DataBind();
        }

        private List<Node> _lstNode;

        public List<Node> LstNode
        {
            get { return _lstNode; }
            set
            {
                _lstNode = value;
                this.RaisePropertyChange("LstNode");
            }
        }


        public List<Node> DataBind()
        {
            List<Node> nodes = new List<Node>()
            {
                new Node { ID = 1, Name = "中国" },
                new Node { ID = 2, Name = "北京市", ParentID = 1 },
                new Node { ID = 3, Name = "吉林省", ParentID = 1 },
                new Node { ID = 4, Name = "上海市", ParentID = 1 },
                new Node { ID = 5, Name = "海淀区", ParentID = 2 },
                new Node { ID = 6, Name = "朝阳区", ParentID = 2 },
                new Node { ID = 7, Name = "大兴区", ParentID = 2 },
                new Node { ID = 8, Name = "白山市", ParentID = 3 },
                new Node { ID = 9, Name = "长春市", ParentID = 3 },
                new Node { ID = 10, Name = "抚松县", ParentID = 8 },
                new Node { ID = 11, Name = "靖宇县", ParentID = 8 }
            };
            return Bind(nodes);
        }

        /// <summary>
        /// 绑定树
        /// </summary>
        List<Node> Bind(List<Node> nodes)
        {
            List<Node> outputList = new List<Node>();
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].ParentID == -1)
                {
                    outputList.Add(nodes[i]);
                }
                else
                {
                    FindDownward(nodes, nodes[i].ParentID).Nodes.Add(nodes[i]);
                }
            }
            return outputList;
        }
        /// <summary>
        /// 递归向下查找
        /// </summary>
        Node FindDownward(List<Node> nodes, int id)
        {
            if (nodes == null) return null;
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].ID == id)
                {
                    return nodes[i];
                }
                Node node = FindDownward(nodes[i].Nodes, id);
                if (node != null)
                {
                    return node;
                }
            }
            return null;
        }

    }





}
