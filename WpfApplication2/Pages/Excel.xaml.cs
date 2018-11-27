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
using Services.DataBase;
using System.Data;
using System.Threading;

namespace WpfApplication2.Pages
{
    /// <summary>
    /// Excel.xaml 的交互逻辑
    /// </summary>
    public partial class Excel : System.Windows.Controls.Page
    {
        ExcelHelper ex;
        public Excel()
        {
            InitializeComponent();
            this.Loaded += Excel_Loaded;
        }

        private void Excel_Loaded(object sender, RoutedEventArgs e)
        {
            ex  = new ExcelHelper();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.xiugai.IsEnabled = false;
            //AccessHelper accessHelper = new AccessHelper();
            //DataTable dt = accessHelper.GetDataTable("Select * from Hello1");
            Thread td = new Thread(() => {
                SqlHelper sql = new SqlHelper();
                DataTable dt = sql.GetDataTable1("Select TOP 200 * from YanGangFlowHistoryRecord");
                //---
                ex.Open(Helper.GetCurrentUri + @"\Excel\Hello.xlsx");
                ex.InsertTable(dt, "Sheet1", 2, 1);
                ex.SaveAs(@"C:\Users\MrGao\Desktop\excel\" + string.Format("{0:yyMMdd HHmmss}", DateTime.Now) + ".xlsx");
                ex.Close();
                Dispatcher.Invoke(new Action(() =>
                {
                    this.xiugai.IsEnabled = true;
                }));
            });
            td.Start();          
        }
    }
}
