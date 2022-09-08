using System.Collections.Generic;

namespace Project_02
{
    public class VacancyHelper
    {
        public string Organization { get; set; }
        public double Salary { get; set; }
        public string Profession { get; set; }
        public string WorkExperience { get; set; }
        public static List<VacancyHelper> Vacancy { get; private set; }

        public static void CreateVacancy(string organization, double salary, string profession, string workExperience)
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
