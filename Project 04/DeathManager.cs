using System;
using System.Windows;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.IO;

namespace Project_04
{
    /// <summary>
    /// Помощник в работе со списком умерших людей. 
    /// </summary>
    public class DeathManager
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime Deathday { get; set; }
        public string PlaceOfDeath { get; set; }
        public string CauseOfDeath { get; set; }

        public static ObservableCollection<DeathManager> DeathPeople { get; private set; }
        
        private static string xmlBasePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\XmlDatabase";

        /// <summary>
        /// 0 - имя<br/>
        /// 1 - фамилия<br/>
        /// 2 - отчество<br/>
        /// 3 - пол<br/>
        /// 4 - день рождения<br/>
        /// 5 - место рождения<br/>
        /// 6 - день смерти<br/>
        /// 7 - место смерти<br/>
        /// 8 - причина смерти
        /// </summary>
        /// <param name="deathPersonInfo"></param>
        public static void AddPerson(string[] deathPersonInfo)
        {
            if (DeathPeople == null)
            {
                DeathPeople = new ObservableCollection<DeathManager>();
            }

            DeathManager deathPerson = new DeathManager()
            {
                Name = deathPersonInfo[0],
                Surname = deathPersonInfo[1],
                Patronymic = deathPersonInfo[2],
                Gender = deathPersonInfo[3],
                Birthday = DateTime.Parse(deathPersonInfo[4]),
                PlaceOfBirth = deathPersonInfo[5],
                Deathday = DateTime.Parse(deathPersonInfo[6]),
                PlaceOfDeath = deathPersonInfo[7],
                CauseOfDeath = deathPersonInfo[8]
            };

            DeathPeople.Add(deathPerson);
        }

        /// <summary>
        /// Удаляет умершего человека из списка по индексу.
        /// </summary>
        /// <param name="index"></param>
        public static void DeleteDeathPerson(int index) => DeathPeople.RemoveAt(index);

        //public static ObservableCollection<DemographyBaseEntities> GroupingByGender(string genderType, ObservableCollection<DemographyBaseEntities> sourceList = null)
        //{

    

        //    //if (genderGroup.Count == 0)
        //    //{
        //    //    MessageBox.Show($"Люди с половым признаком {genderType} не найдены.", "Оповещение");
        //    //    return null;
        //    //}

        //    //return genderGroup;
        //}

        //public static ObservableCollection<DeathManager> GroupingByAgeGroup(string ageGroupType, ObservableCollection<DeathManager> sourceList = null)
        //{
        //    ObservableCollection<DeathManager> ageGroup = new ObservableCollection<DeathManager>();

        //    //[0] - нижний предел, [1] - высший предел.
        //    byte[] ageRange = new byte[2];

        //    //сделать ageContext - диапозон для возрастных групп: дети, молодые, пожилые

        //    if (sourceList == null)
        //    {
        //        if (DeathPeople.Count == 0)
        //        {
        //            MessageBox.Show("Список умерших людей пуст.", $"Невозможно сгруппировать по возрастной группе \"{ageGroupType}\"");
        //            return null;
        //        }

        //        sourceList = DeathPeople;
        //    }

        //    switch (ageGroupType.ToLower())
        //    {
        //        case "дети":
        //            ageRange[0] = 0;
        //            ageRange[1] = 17;
        //            break;
        //        case "молодые":
        //            ageRange[0] = 18;
        //            ageRange[1] = 64;
        //            break;
        //        case "пожилые":
        //            ageRange[0] = 65;
        //            ageRange[1] = 120;
        //            break;
        //    }

        //    foreach (var person in sourceList)
        //    {
        //        DateTime personAge = new DateTime(person.Deathday.Year - person.Birthday.Year, 1, 1);

        //        if (person.Birthday.Day > person.Deathday.Day && person.Birthday.Month > person.Deathday.Month)
        //        {
        //            personAge = new DateTime(personAge.Year - 1, 1, 1);
        //        }

        //        if (personAge.Year >= ageRange[0] && personAge.Year <= ageRange[1]) // проверка по диапозону возрастов
        //        {
        //            ageGroup.Add(person);
        //        }
        //    }

        //    return ageGroup;
        //}

        ////public static object GroupingByCauseOfDeath(string causeOfDeath, ObservableCollection<object> sourceList = null)
        ////{
        ////    ObservableCollection<DeathManager> causeOfDeathGroup = new ObservableCollection<DeathManager>();

        ////    //!!! сделать занесение в комбо бокс причин смерти из существующих в списке умерших людей



        ////    foreach (var person in sourceList)
        ////    {
        ////        if (person.CauseOfDeath.Equals(causeOfDeath))
        ////        {
        ////            causeOfDeathGroup.Add(person);
        ////        }
        ////    }

        ////    return causeOfDeathGroup;
        ////}

        //private void CreateXmlFile()
        //{
        //    try
        //    {
        //        if (Directory.Exists(xmlBasePath) == false)
        //        {
        //            Directory.CreateDirectory(xmlBasePath);
        //        }

        //        XDocument deathPeople = new XDocument();

        //        XElement xRoot = new XElement("DeathPeople");

        //        deathPeople.Add(xRoot);

        //        foreach (var person in DeathPeople)
        //        {
        //            xRoot.Add(new XElement("person",
        //                new XElement("name", person.Name),
        //                new XElement("surname", person.Surname),
        //                new XElement("patronymic", person.Patronymic),
        //                new XElement("gender", person.Gender),
        //                new XElement("birthday", person.Birthday),
        //                new XElement("placeofbirth", person.PlaceOfBirth),
        //                new XElement("death", person.Deathday),
        //                new XElement("placeofdeath", person.PlaceOfDeath),
        //                new XElement("causeofdeath", person.CauseOfDeath)));
        //        }

        //        deathPeople.Save($@"{xmlBasePath}\DeathPeopleBase.xml");
        //    }
        //    catch
        //    {
        //    } 
        //}
    }
}