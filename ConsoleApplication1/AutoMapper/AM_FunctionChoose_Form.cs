using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZero.ConsoleApp.TestDemo.AutoMapper;
using System.Windows.Forms;
using AutoMapper;
using System.Reflection;
using System.Diagnostics;

namespace DZero.ConsoleApp.TestDemo.AutoMapper
{
    public partial class AM_FunctionChoose_Form : Form
    {
        List<object> _TSourceList;
        List<object> _TDestionList;
        DataTable dtSource = new DataTable();
        DataTable dtDest = new DataTable();

        public AM_FunctionChoose_Form()
        {
            InitializeComponent();
        }

        private void btnSimple_Click(object sender, EventArgs e)
        {
            Source1Model sm = new Source1Model() { SomeValue = 20, OtherValue = "111" };
            OutputObjPropInfo(sm);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Destination1Model dm = Mapper.Map<Destination1Model>(sm);
            watch.Stop();
            Console.WriteLine($"Mapper.Map<Destination1Model>(sm)花费时间：{watch.ElapsedMilliseconds} 毫秒.");
            OutputObjPropInfo(dm);
        }

        public void OutputObjPropInfo(object oModel)
        {
            if (oModel != null)
            {
                PropertyInfo[] propertySourceInfoList = oModel.GetType().GetProperties();
                foreach (PropertyInfo _propertyInfo in propertySourceInfoList)
                {
                    Console.WriteLine($"Model类型：{oModel.GetType().Name}，属性：{_propertyInfo.Name}，属性类型：{_propertyInfo.PropertyType.Name}，属性值：{_propertyInfo.GetValue(oModel, null)}");
                }
            }
        }
    }
}
