using System.Collections.Generic;

namespace Wpf_CrazyE_Demo.Services
{
    class MockOrderService : IOrderService
    {
        public void PlaceOrder(List<string> dishs)
        {
            System.IO.File.WriteAllLines(@"C:\order.txt", dishs.ToArray());
        }
    }
}
