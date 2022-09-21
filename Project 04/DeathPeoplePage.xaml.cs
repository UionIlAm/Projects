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
    /// Логика взаимодействия для DeathPeoplePage.xaml
    /// </summary>
    public partial class DeathPeoplePage : Page
    {
        public DeathPeoplePage()
        {

            InitializeComponent();

            Init();

            FullClear();

            DGridDemography.ItemsSource = DemographyBaseEntities.GetContext().DeathPeople.ToList();

        }

        private void Init()
        {
            //var i = DemographyBaseEntities.GetContext().DeathPeople.ToList();

            //MessageBox.Show($"{i[1].CountryInfo1.PlaceOfBirth} { i[1].CauseOfDeath.CauseOfDeath1} {i[1].Name}");

            string[] tmpSource = new string[] { "Любой пол", "Мужской", "Женский" };

            for (int i = 0; i < tmpSource.Length; i++)
            {
                GroupingByGenderCB.Items.Add(tmpSource[i]);
            }
            
            GroupingByGenderCB.SelectedIndex = 0;

            tmpSource = new string[] { "Все возраста", "Дети", "Молодые", "Пожилые" };

            for (int i = 0; i < tmpSource.Length; i++)
            {
                GroupingByAgeCB.Items.Add(tmpSource[i]);
            }

            GroupingByAgeCB.SelectedIndex = 0;

            GroupingByCauseOfDeathCB.Items.Add("Все виды болезней");

            var tmpList = DemographyBaseEntities.GetContext().CauseOfDeath.ToList();

            for (int i = 0; i < tmpList.Count; i++)
            {
                GroupingByCauseOfDeathCB.Items.Add(tmpList[i].CauseOfDeath1.ToString());
            }

            GroupingByCauseOfDeathCB.SelectedIndex = 0;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            FullClear();
            DGridDemography.ItemsSource = DemographyBaseEntities.GetContext().DeathPeople.ToList();

            GroupingByGenderCB.SelectedIndex = 0;
            GroupingByAgeCB.SelectedIndex = 0;
            GroupingByCauseOfDeathCB.SelectedIndex = 0;

            GroupingByAgeCB.IsEnabled = true;
            GroupingByGenderCB.IsEnabled = true;
            GroupingByCauseOfDeathCB.IsEnabled = true;
        }

        private void FullClear()
        {
            DGridDemography.ItemsSource = null;
            DGridDemography.Items.Clear();
        }

        private void GroupingByGenderCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (GroupingByGenderCB.SelectedItem)
            {
                case "Любой пол":
                    Reset_Click(sender, e);
                    break;
                case "Мужской":
                    FullClear();

                    foreach (var person in DemographyBaseEntities.GetContext().DeathPeople.ToList())
                    {
                        if (person.GenderType.Gender.Equals("Мужской"))
                        {
                            DGridDemography.Items.Add(person);    
                        }
                    }

                    GroupingByAgeCB.IsEnabled = false;
                    GroupingByCauseOfDeathCB.IsEnabled = false;
                    break;
                case "Женский":
                    FullClear();

                    foreach (var person in DemographyBaseEntities.GetContext().DeathPeople.ToList())
                    {
                        if (person.GenderType.Gender.Equals("Женский"))
                        {
                            DGridDemography.Items.Add(person);
                        }
                    }

                    GroupingByAgeCB.IsEnabled = false;
                    GroupingByCauseOfDeathCB.IsEnabled = false;
                    break;
            }
        }

        private void GroupingByAgeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GroupingByAgeCB.SelectedItem.Equals("Все возраста"))
            {
                Reset_Click(sender, e);
                return;
            }

            FullClear();

            //[0] - нижний предел, [1] - высший предел.
            byte[] ageRange = new byte[2];

            //сделать ageContext - диапозон для возрастных групп: дети, молодые, пожилые

            switch (GroupingByAgeCB.SelectedItem.ToString().ToLower())
            {
                case "дети":
                    ageRange[0] = 0;
                    ageRange[1] = 17;
                    break;
                case "молодые":
                    ageRange[0] = 18;
                    ageRange[1] = 64;
                    break;
                case "пожилые":
                    ageRange[0] = 65;
                    ageRange[1] = 120;
                    break;
            }

            foreach (var person in DemographyBaseEntities.GetContext().DeathPeople.ToList())
            {
                DateTime personAge = new DateTime(person.Deathday.Year - person.Birthday.Year, 1, 1);

                if (person.Birthday.Day > person.Deathday.Day && person.Birthday.Month > person.Deathday.Month)
                {
                    personAge = new DateTime(personAge.Year - 1, 1, 1);
                }

                if (personAge.Year >= ageRange[0] && personAge.Year <= ageRange[1]) // проверка по диапозону возрастов
                {
                    DGridDemography.Items.Add(person);
                }
            }

            GroupingByGenderCB.IsEnabled = false;
            GroupingByCauseOfDeathCB.IsEnabled = false;
        }

        private void GroupingByCauseOfDeathCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GroupingByCauseOfDeathCB.SelectedItem.Equals("Все виды болезней"))
            {
                Reset_Click(sender, e);
            }
            else
            {
                FullClear();

                foreach (var person in DemographyBaseEntities.GetContext().DeathPeople.ToList())
                {
                    if (person.CauseOfDeath.CauseOfDeath1.Equals(GroupingByCauseOfDeathCB.SelectedItem))
                    {
                        DGridDemography.Items.Add(person);
                    }
                }

                GroupingByGenderCB.IsEnabled = false;
                GroupingByAgeCB.IsEnabled = false;
            }
            
        }
    }
}