using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Project_02
{
    public class SummaryHelper
    {
        public string FullName { get; set; }
        public string Age { get; set; }
        public string Profession { get; set; }
        public string WorkExperience { get; set; }
        public static ObservableCollection<SummaryHelper> Summary = new ObservableCollection<SummaryHelper>();


        public static void CreateSummary(string fullName, string age, string profession, string workExperience)
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
        public static void DeleteSummary()
        {

        }
    }
}