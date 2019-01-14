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
namespace WpfApplication2.Pages
{
    /// <summary>
    /// Access.xaml 的交互逻辑
    /// </summary>
    public partial class Access : Page
    {
        AccessHelper accessHelper = new AccessHelper();
        public Access()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            string commandText = "Insert into model ([BianHao],[AddTime1]) values ('123','234')";
            Console.WriteLine(accessHelper.Execute(commandText));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
