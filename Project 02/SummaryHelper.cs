using System.Collections.Generic;

namespace Project_02
{
    public class SummaryHelper
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Profession { get; set; }
        public string WorkExperience { get; set; }
        public static List<SummaryHelper> Summary { get; private set; }


        public static void CreateSummary(string fullName, int age, string profession, string workExperience)
        {
            SummaryHelper newSummary = new SummaryHelper()
            {
                FullName = fullName,
                Age = age,
                Profession = profession,
                WorkExperience = workExperience
            };

            Summary.Add(newSummary);
        }
    }
}