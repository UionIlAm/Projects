using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Project_05
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void TicketBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key != Key.Back)
                {
                    string numberStr = "";
                    char numberChar = ' ';

                    try
                    {
                        numberStr = e.Key.ToString();
                        numberChar = char.Parse(numberStr);
                    }
                    catch
                    {
                        numberChar = char.Parse(numberStr.Remove(0, 1));
                    }

                    if (!Char.IsDigit(numberChar))
                    {
                        e.Handled = true;
                    }
                }
            }
            catch
            {
                e.Handled = true;
            }
        }

        private void TicketBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            CheckTicket.IsEnabled = Range1Box.Text.Length == 6 && Range2Box.Text.Length == 6;
            
            CheckTicket.Visibility = (Range1Box.Text.Length == 6 && Range2Box.Text.Length == 6) ? Visibility.Visible : Visibility.Hidden;

        }

        private void CheckTicket_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new ResultPage(Range1Box.Text, Range2Box.Text));

            Range1Box.Text = "";
            Range2Box.Text = "";
        }
    }
}
