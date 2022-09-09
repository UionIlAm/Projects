using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Project_02
{
    public class VacancyHelper
    {
        public string Organization { get; set; }
        public string Salary { get; set; }
        public string Profession { get; set; }
        public string WorkExperience { get; set; }

        public static ObservableCollection<VacancyHelper> Vacancy = new ObservableCollection<VacancyHelper>();

        public static void CreateVacancy(string organization, string salary, string profession, string workExperience)
        {
            VacancyHelper newVacancy = new VacancyHelper()
            {
                Organization = organization,
                Salary = salary,
                Profession = profession,
                WorkExperience = workExperience
            };

            Vacancy.Add(newVacancy);
        }
    }
}
