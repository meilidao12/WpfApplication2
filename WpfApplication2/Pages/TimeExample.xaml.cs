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
using Services;
using System.Diagnostics;
namespace WpfApplication2.Pages
{
    /// <summary>
    /// TimeExample.xaml 的交互逻辑
    /// </summary>
    public partial class TimeExample : Page
    {
        public TimeExample()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TimeFormatHelper timeFormatHelper = new TimeFormatHelper();
            Debug.WriteLine(timeFormatHelper.HexTimeToDecTime("12091108201B"));
        }
    }
}
