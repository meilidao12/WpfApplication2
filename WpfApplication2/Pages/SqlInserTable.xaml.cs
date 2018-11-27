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
using Services;
using WpfApplication2.Models;
namespace WpfApplication2.Pages
{
    /// <summary>
    /// SqlInserTable.xaml 的交互逻辑
    /// </summary>
    public partial class SqlInserTable : Page
    {
        int beijiahangshu=0;
        public SqlInserTable()
        {
            InitializeComponent();
            this.Loaded += SqlInserTable_Loaded;
        }

        private void SqlInserTable_Loaded(object sender, RoutedEventArgs e)
        {
            List<ModIdModel> modids = new List<ModIdModel>();
            modids.Add(new ModIdModel { Name = "水流量报表" ,Value="010"});
            modids.Add(new ModIdModel { Name = "高炉冷风量报表", Value = "011" });
            modids.Add(new ModIdModel { Name = "冷凝水报表", Value = "012" });
            modids.Add(new ModIdModel { Name = "周统计报表—机前富氧" ,Value="013"});
            this.cmbmodId.ItemsSource = modids;
            this.cmbmodId.DisplayMemberPath = "Name";
            this.cmbmodId.SelectedValuePath = "Value";
            this.cmbmodId.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            JiaModel model = new JiaModel();
            for(int j = 5;j<=44;j++)
            {
                model.Modid = "039";
                model.Exlmc = j.ToString("000");
                model.Execute();
            }


            //JianModel model = new JianModel();
            //LeiJiModel model = new LeiJiModel();
            //for (int j = 108; j <= 110; j++)
            //{
            //    model.Modid = "015";
            //    model.Exlmc = j.ToString("000");
            //    //model.Exlmc = this.txtexlmc.Text;
            //    model.Execute();
            //}

            //LeiJiModel model = new LeiJiModel();
            //model.Modid = "015";
            //model.Wzy = this.txtwzy.Text;
            //model.Exlmc = this.txtexlmc.Text;
            //model.Execute();


            //EnergyReportModel er = new EnergyReportModel();
            //er.Execute();
            //MessageBox.Show("插入完成");
        }

        private void cmbmodId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (this.cmbmodId.SelectedValue.ToString())
            {
                case "010":
                    beijiahangshu = 2;
                    break;
                case "011":
                case "012":
                case "013":
                    beijiahangshu = 1;
                    break;
            }
        }
    }
}
