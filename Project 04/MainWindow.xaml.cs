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

namespace Project_04
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Page[] pages = new Page[] {new NewbornPeoplePage(), new DeathPeoplePage()};
        public MainWindow()
        {
            InitializeComponent();

            FrameManager.CurrentFrame = MainWindowFrame;

            ListControlCB.Items.Add("--Выберите таблицу--");
            ListControlCB.Items.Add("Новорождённые");
            ListControlCB.Items.Add("Умершие");

            ListControlCB.SelectedIndex = 0;

            
        }

        private void ListControlCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ListControlCB.SelectedItem)
            {
                case "--Выберите таблицу--":
                    FrameManager.CurrentFrame.Content = null;
                    break;
                case "Новорождённые":
                    FrameManager.CurrentFrame.Navigate(pages[0]);
                    break;
                case "Умершие":
                    FrameManager.CurrentFrame.Navigate(pages[1]);
                    break;
            }
        }

        private void GetResult_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.CurrentFrame.Navigate(new ResultPage());
        }
    }
}
