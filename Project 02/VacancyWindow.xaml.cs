using System.Windows;

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
            VacancyHelper.CreateVacancy(OrganiztionTB.Text, double.Parse(SalaryTB.Text), ProfessionTB.Text, WorkExpTB.Text);
            this.Close();
        }
    }
}
