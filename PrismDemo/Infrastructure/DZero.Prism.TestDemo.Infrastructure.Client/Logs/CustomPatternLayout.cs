using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZero.Prism.TestDemo.Infrastructure.Client.Logs
{
    public class CustomPatternLayout : PatternLayout
    {
        public CustomPatternLayout()
        {
            this.AddConverter("property", typeof(XPatternLayoutConverter));
        }
    }
}
