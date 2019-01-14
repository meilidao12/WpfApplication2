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

namespace WpfApplication2.Pages
{
    /// <summary>
    /// TestString.xaml 的交互逻辑
    /// </summary>
    public partial class TestString : Page
    {
        public TestString()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(this.txt.Text.Length);
            Console.WriteLine(this.txt.Text.Substring(832, 12));
            Console.WriteLine(this.txt.Text.Substring(80, 10));
        }
    }
}
