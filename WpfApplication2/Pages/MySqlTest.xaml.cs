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
using Services.DataBase;
using System.Diagnostics;
using WpfApplication2.Models;
using WpfApplication2.CS;
using System.Threading;
using Services;
namespace WpfApplication2.Pages
{
    /// <summary>
    /// MySqlTest.xaml 的交互逻辑
    /// </summary>
    public partial class MySqlTest : Page
    {
        MysqlHelper mysqlHelper1 = new MysqlHelper();
        System.Timers.Timer timer;

        /// <summary>
        /// 初始化
        /// 初始化1
        /// </summary>
        public MySqlTest()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval= 30000;
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
            mysqlHelper1.Open();

        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Debug.WriteLine(mysqlHelper1.TestConn);
            SimpleLogHelper.Instance.WriteLog(LogType.Info, "开始复制");
            string sql = string.Format("select * from test1 ");
            List< MySqlModel > mySqlModels = mysqlHelper1.GetDataTable<MySqlModel>(sql);
            SimpleLogHelper.Instance.WriteLog(LogType.Info, "复制数据总数为：" + mySqlModels.Count);
            SimpleLogHelper.Instance.WriteLog(LogType.Info, "复制结束");
        }

        private void InsertTable1()
        {
            for(int i = 0; i<=10000;i++)
            {
                string phone = (15233240000 + i).ToString();
                string sql = string.Format("INSERT INTO test1 (Name,Age,Phone) VALUES ('WO{0}','{1}','{2}');", i, 20, phone);
                //if (mysqlHelper1.Execute(sql))
                //{
                //    Dispatcher.BeginInvoke(new Action(() =>
                //    {
                //        this.txtShow1.Text = i.ToString();
                //    }));
                //}
            }
        }

        private void btnSerch_Click(object sender, RoutedEventArgs e)
        {
            InsertTable1();
        }
    }
}
