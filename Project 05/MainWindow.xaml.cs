using System.Windows;

namespace Project_05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          

            MainWindowFrame.Navigate(new MainPage());
            FrameManager.MainFrame = MainWindowFrame;
            
        }
    }
}
