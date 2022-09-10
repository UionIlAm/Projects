using System.Windows;
using System.Windows.Controls;

namespace Project_02
{
    /// <summary>
    /// Логика взаимодействия для SummaryWindow.xaml
    /// </summary>
    public partial class SummaryWindow : Window
    {
        public SummaryWindow()
        {
            InitializeComponent();
        }

        private void SaveSummary_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in SummaryGrid.Children)
            {
                if (element is TextBox)
                {
                    if (string.IsNullOrWhiteSpace(((TextBox)element).Text))
                    {
                        ((TextBox)element).Text = "Не указано";
                    }
                }
            }
            SummaryHelper.CreateSummary(FullNameTB.Text, AgeTB.Text, ProfessionTB.Text, WorkExpTB.Text);
            this.Close();
        }
    }
}
