using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Project_04
{
    /// <summary>
    /// Логика взаимодействия для NewbornPeoplePage.xaml
    /// </summary>
    public partial class NewbornPeoplePage : Page
    {
        public NewbornPeoplePage()
        {
            InitializeComponent();

            //DGridDemography.ItemsSource = DemographyBaseEntities.GetContext().NewbornPeople.ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DemographyBaseEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridDemography.ItemsSource = DemographyBaseEntities.GetContext().NewbornPeople.ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var peopleForRemoving = DGridDemography.SelectedItems.Cast<NewbornPeople>().ToList();

            if (peopleForRemoving.Count == 0)
            {
                MessageBox.Show("Чтобы удалить элемент - выделите их в таблице.", "Подсказка");
                return;
            }

            if (MessageBox.Show($"Вы уверены, что хотите удалить слудующие {peopleForRemoving.Count} элементов?", "Предупреждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DemographyBaseEntities.GetContext().NewbornPeople.RemoveRange(peopleForRemoving);
                    DemographyBaseEntities.GetContext().SaveChanges();

                    DGridDemography.ItemsSource = DemographyBaseEntities.GetContext().NewbornPeople.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
