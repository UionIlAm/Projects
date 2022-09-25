using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SystemsOfLinearEquationsManager;

namespace Project_03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static bool IsFirstLoad = true;

        public static double[,] Equation { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            FrameManager.CurrentFrame = MainWindowFrame;
            FrameManager.CurrentFrame.Navigate(new HelloPage());

            //double[,] vs = new double[3, 4] { { 0,0, 0, 0}, { 3, 4, -2, 9 }, { 2, -1, -1, 10 } };

            Dimension.Items.Add("Выберите размерность");
            Dimension.Items.Add("Две неизвестные"); 
            Dimension.Items.Add("Три неизвестные");

            Dimension.SelectedIndex = 0;

            //EquationsManager.Kramer(vs);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            AnimationStart(true);
        
        }

       

        private void EnableButtons(bool logic)
        {
            KramerButton.IsEnabled = logic;
            JordanGaussButton.IsEnabled = logic;
            GaussButton.IsEnabled = logic;
            SimpleIterationButton.IsEnabled = logic;
            SeidelButton.IsEnabled = logic;
        }

        private void Dimension_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Dimension.SelectedItem)
            {
                case "Выберите размерность":
                    MainPage();
                    break;

                case "Две неизвестные":
                    DualDimension();
                    break;

                case "Три неизвестные":
                    TripleDimension();
                    break;
            }
        }

        private async void MainPage()
        {
            EnableButtons(false);

            if (!IsFirstLoad)
            {
                await Task.Run(() =>
                {
                    AnimationShutdown();

                    Thread.Sleep(900);
                    Dispatcher.Invoke(() => { FrameManager.CurrentFrame.Content = null; });

                });

                FrameManager.CurrentFrame.Navigate(new HelloPage());

                AnimationStart();
            }

            IsFirstLoad = false;

        }

        private async void DualDimension()
        {
            EnableButtons(true);

            await Task.Run(() =>
            {
                AnimationShutdown();

                Thread.Sleep(900);
                Dispatcher.Invoke(() => { FrameManager.CurrentFrame.Content = null; });
                
            });

            FrameManager.CurrentFrame.Navigate(new DualDimensionPage());

            AnimationStart();
        }

        private async void TripleDimension()
        {
            EnableButtons(true);

            await Task.Run(() =>
            {
                AnimationShutdown();

                Thread.Sleep(900);
                Dispatcher.Invoke(() => { FrameManager.CurrentFrame.Content = null; });

            });

            FrameManager.CurrentFrame.Navigate(new TripleDimensionPage());

            AnimationStart();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl)
            {
                AnimationShutdown();
            }
            if (e.Key == Key.LeftShift)
            {
                AnimationStart();
            }
        }

        private async void AnimationStart(bool isWait = false)
        {
            await Task.Run(() =>
            {
                try
                {
                    if (isWait)
                    {
                        Thread.Sleep(350);
                    }

                    for (int i = 0; i <= 100; i++)
                    {
                        Dispatcher.Invoke((Action)(() =>
                        {
                            FrameManager.CurrentFrame.Opacity += 0.03;
                        }));

                        Thread.Sleep(6);
                    }
                }
                catch
                {

                }

            });
        }

        private async void AnimationShutdown()
        {
            await Task.Run(() =>
            {
                try
                {
                    //Thread.Sleep(350);

                    for (int i = 0; i <= 100; i++)
                    {
                        Dispatcher.Invoke((Action)(() =>
                        {
                            FrameManager.CurrentFrame.Opacity -= 0.03;
                        }));

                        Thread.Sleep(6);
                    }
                }
                catch
                {
                }
            });
        }

        private async void KramerButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                AnimationShutdown();

                Thread.Sleep(900);
                Dispatcher.Invoke(() => { FrameManager.CurrentFrame.Content = null; FrameManager.CurrentFrame.Navigate(new TripleDimensionPage()); });

                Thread.Sleep(100);


            });

           
            MessageBox.Show(EquationsManager.Kramer(Equation));
            AnimationStart();

      
            

        }
    }
}
