using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication2.Pages
{
    /// <summary>
    /// AsyncTest.xaml 的交互逻辑
    /// </summary>
    public partial class AsyncTest : Page
    {
        public AsyncTest()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            Task<body> task = new Task<body>(() =>
            {
                Console.WriteLine("开始执行异步");
                Thread.Sleep(5000);
                Console.WriteLine("异步执行完成");
                body by = new body { Age = 10, Name = "xiaoming" };
                return by;
            });
            task.Start();
            Console.WriteLine("开始执行");
            //回调
            Task tsk = task.ContinueWith(t =>
            {
                body by = (body)t.Result;
                Console.WriteLine(by.Name + "年龄是：" + by.Age );
            });
            Console.WriteLine("执行结束");
        }
    }
    public class body
    {
        private string name;
        private int age;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }
    }
}
