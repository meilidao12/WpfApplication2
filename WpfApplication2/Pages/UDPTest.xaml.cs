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
using CommunicationServers.Sockets;
using Services;

namespace WpfApplication2.Pages
{
    /// <summary>
    /// UDPTest.xaml 的交互逻辑
    /// </summary>
    public partial class UDPTest : Page
    {
        SocketServerEx UDPServer = new SocketServerEx();
        public UDPTest()
        {
            InitializeComponent();
            this.Loaded += UDPTest_Loaded;
            this.Unloaded += UDPTest_Unloaded;
        }

        private void UDPTest_Unloaded(object sender, RoutedEventArgs e)
        {
            this.UDPServer.Dispose();
        }

        private void UDPTest_Loaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// 服务器侦听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnServerListen_Click(object sender, RoutedEventArgs e)
        {
            UDPServer.Listen("8080");
            this.UDPServer.NewMessage2Event += UDPServer_NewMessage2Event;
        }

        private void UDPServer_NewMessage2Event(System.Net.IPEndPoint remoteIpEndPoint, string Message)
        {
            UDPServer.IpEndPoints.Add(remoteIpEndPoint);
            Dispatcher.BeginInvoke(new Action(() =>
            {
                //this.txtServerReceive.Text +=  (Message + Helper.NewLine());
                
            }));
        }

        /// <summary>
        /// 服务器断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnServerDisContect_Click(object sender, RoutedEventArgs e)
        {
            UDPServer.Disconnect();
        }

        /// <summary>
        /// 服务器发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnServerSend_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtServerSend.Text))
            {
                foreach(var item in UDPServer.IpEndPoints)
                {
                    this.UDPServer.Send(item,UDPServer.ASCIIConvertToByte(this.txtServerSend.Text));
                }
            }
        }

        /// <summary>
        /// 客户端向服务器发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClientSend_Click(object sender, RoutedEventArgs e)
        {
            UDPServer.IpEndPoint = UDPServer.GetIPEndPoint("10.0.1.252", "6000");
            this.UDPServer.Send(UDPServer.IpEndPoint, UDPServer.ASCIIConvertToByte(this.txtClientSend.Text));
        }
    }
}
