using System.Windows;
using System.Windows.Controls;

namespace Project_02
{
    /// <summary>
    /// Логика взаимодействия для VacancyWindow.xaml
    /// </summary>
    public partial class VacancyWindow : Window
    {
        public VacancyWindow()
        {
            InitializeComponent();
        }

        private void SaveVacancy_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in VacancyGrid.Children)
            {
                if (element is TextBox textBoxElement)
                {
                    if (string.IsNullOrWhiteSpace(textBoxElement.Text))
                    {
                        textBoxElement.Text = "Не указано";
                    }
                }
            }
            VacancyHelper.CreateVacancy(OrganiztionTB.Text, SalaryTB.Text, ProfessionTB.Text, WorkExpTB.Text);
            this.Close();
        }
    }
}
