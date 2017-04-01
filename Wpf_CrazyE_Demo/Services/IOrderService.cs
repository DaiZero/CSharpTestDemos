using System.Collections.Generic;

namespace Wpf_CrazyE_Demo.Services
{
    interface IOrderService
    {
        void PlaceOrder(List<string> dishs);
    }
}
