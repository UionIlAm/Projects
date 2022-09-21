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
using System.Windows.Shapes;

namespace Project_04
{
    /// <summary>
    /// Логика взаимодействия для AddDeathPersonWindow.xaml
    /// </summary>
    public partial class AddDeathPersonWindow : Window
    {
        private DeathPeople _currentPerson = new DeathPeople();
        public AddDeathPersonWindow()
        {
            InitializeComponent();

            DataContext = _currentPerson;

            GenderBox.ItemsSource = DemographyBaseEntities.GetContext().GenderType.ToList();
            CountryBox.ItemsSource = DemographyBaseEntities.GetContext().CountryInfo.ToList();
            DeathPlaceBox.ItemsSource = DemographyBaseEntities.GetContext().CountryInfo.ToList();

            CauseOfDeathBox.ItemsSource = DemographyBaseEntities.GetContext().CauseOfDeath.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder builder = new StringBuilder();

            if (string.IsNullOrEmpty(_currentPerson.Name) || string.IsNullOrEmpty(_currentPerson.Surname))
                builder.AppendLine("Данные не введены: Имя и/или Фамилия");
            if (CountryBox.SelectedIndex == -1 || DeathPlaceBox.SelectedIndex == -1)
                builder.AppendLine("Данные не введены: Место рождения и/или Место смерти");
            if (GenderBox.SelectedIndex == -1)
                builder.AppendLine("Данные не введены: Пол");
            

            if (builder.Length > 0)
            {
                MessageBox.Show(builder.ToString(), "Ошибка сохранения");
                return;
            }

            if (_currentPerson.Id == 0)
            {
                DemographyBaseEntities.GetContext().DeathPeople.Add(_currentPerson);
            }

            try
            {
                DemographyBaseEntities.GetContext().SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
    }
}
