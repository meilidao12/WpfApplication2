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
using System.Data;
using Services.DataBase;
using System.Diagnostics;
namespace WpfApplication2.Pages
{
    /// <summary>
    /// JinMaTest.xaml 的交互逻辑
    /// </summary>
    public partial class JinMaTest : Page
    {
        public JinMaTest()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlHelper sql = new SqlHelper();
                sql.Open();
                if (sql.TestConn == false)
                {
                    this.txtResult.Text = "连接数据库失败";
                    return;
                }
                //string s2 = string.Format("{0:s}", DateTime.Now);
                DateTime s3 = DateTime.Parse("2018-09-02 08:00:00");
                DateTime s4 = DateTime.Parse("2018-09-11 08:00:00");
                string com = string.Format("select sum(convert(float,[netsumweight])) from t_jzl_collect_balance_bill where [Name]= '焦炭' and AddTime BETWEEN '{0}' AND '{1}';", "2018-09-10 07:30:00", "2018-09-11 07:30:00");
                DataTable dt = sql.GetDataTable1(com);
                this.txtResult.Text = dt.Rows[0][0].ToString();
            }
            catch
            {
                this.txtResult.Text = "操作数据库有误";
            }
        }
    }
}
