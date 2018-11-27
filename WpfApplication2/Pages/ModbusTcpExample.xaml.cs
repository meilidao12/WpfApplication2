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
using CommunicationServers.Sockets;

namespace WpfApplication2.Pages
{
    /// <summary>
    /// ModbusTcpExample.xaml 的交互逻辑
    /// </summary>
    public partial class ModbusTcpExample : Page
    {
        public ModbusTcpExample()
        {
            InitializeComponent();
            this.Loaded += ModbusTcpExample_Loaded;
        }

        private void ModbusTcpExample_Loaded(object sender, RoutedEventArgs e)
        {
            string a = "65535";
            string hexb = MathHelper.DecToHex(a);
            Debug.WriteLine(hexb);
            a = "FFFF";
            string decb = MathHelper.HexToDec(a).ToString();
            Debug.WriteLine(decb);
        }
    }
}
