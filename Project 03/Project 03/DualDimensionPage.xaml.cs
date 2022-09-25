using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Project_03
{
    /// <summary>
    /// Логика взаимодействия для DualDimensionPage.xaml
    /// </summary>
    public partial class DualDimensionPage : Page
    {
        public DualDimensionPage()
        {
            InitializeComponent();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            MainWindow.Equation = new double[,] { {double.Parse(a1.Text), double.Parse(b1.Text), double.Parse(s1.Text)},
                { double.Parse(a2.Text), double.Parse(b2.Text), double.Parse(s2.Text) } };
        }
    }
}
