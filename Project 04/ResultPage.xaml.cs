using System;
using System.Linq;
using System.Windows.Controls;


namespace Project_04
{
    /// <summary>
    /// Логика взаимодействия для ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        private static DateTime periodStarts;

        private static DateTime periodEnds;

        public ResultPage()
        {
            InitializeComponent();

            Growth();
            Decline();
            FindPeriod();
            FindAverageLifeExpectancy();
        }

        private void FindPeriod()
        {
            foreach (var person in DemographyBaseEntities.GetContext().DeathPeople.ToList())
            {
                if (periodStarts > person.Birthday || periodStarts == new DateTime())
                {
                    periodStarts = person.Birthday;
                }
            }

            foreach (var person in DemographyBaseEntities.GetContext().NewbornPeople.ToList())
            {
                if (periodEnds < person.BirthdayDate || periodEnds == new DateTime())
                {
                    periodEnds = person.BirthdayDate;
                }
            }

            PeriodInfo.Content = $"Период\nс {periodStarts.ToShortDateString()} по {periodEnds.ToShortDateString()}";
        }

        private void FindAverageLifeExpectancy()
        {
            double result = 0;
            int peopleCount = 0;


            foreach (var person in DemographyBaseEntities.GetContext().DeathPeople.ToList())
            {
                DateTime personAge = new DateTime(person.Deathday.Year - person.Birthday.Year, 1, 1);

                if (person.Birthday.Day > person.Deathday.Day && person.Birthday.Month > person.Deathday.Month)
                {
                    personAge = new DateTime(personAge.Year - 1, 1, 1);
                }

                result += personAge.Year;
                peopleCount++;
            }

            AleInfo.Content = $"Средняя\nпродолжительность жизни: {Math.Round(result / peopleCount, 1)}";
        }

        private void Growth()
        {
            int growth = DemographyBaseEntities.GetContext().NewbornPeople.ToList().Count - DemographyBaseEntities.GetContext().DeathPeople.ToList().Count;

            GrowthInfo.Content = $"Прирост населения: {growth}";
        }

        private void Decline()
        {
            int decline = DemographyBaseEntities.GetContext().DeathPeople.ToList().Count - DemographyBaseEntities.GetContext().NewbornPeople.ToList().Count;

            DeclineInfo.Content = $"Убыль населения: {decline}";
        }
    }
}
