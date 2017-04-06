using System;
using System.Windows;

namespace ConsoleApplication1
{
    delegate void MyDelegate(string message);
    class Delegate_Event_Demo
    {
        public void ShowMsg(string message)
        {
            Console.WriteLine(message);
            //MessageBox.Show(message);
        }
        public void ShowMsgBox(string message)
        {
            MessageBox.Show(message);
        }
    }
}
