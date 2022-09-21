using System;
using System.Collections.Generic;

namespace Project_04
{
    public class LifeManager
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string PlaceOfBirth { get; set; }
        public string MotherInfo { get; set; }
        public string FatherInfo { get; set; }

        public static List<LifeManager> NewbornPeople { get; private set; }

        /// <summary>
        /// 0 - имя<br/>
        /// 1 - фамилия<br/>
        /// 2 - отчество<br/>
        /// 3 - пол<br/>
        /// 4 - день рождения<br/>
        /// 5 - место рождения<br/>
        /// 6 - информация о матери<br/>
        /// 7 - информация об отце<br/>
        /// </summary>
        /// <param name="newbornInfo"></param>
        public static void AddPerson(string[] newbornInfo)
        {
            if (NewbornPeople == null)
            {
                NewbornPeople = new List<LifeManager>();
            }

            LifeManager newborn = new LifeManager()
            {
                Name = newbornInfo[0],
                Surname = newbornInfo[1],
                Patronymic = newbornInfo[2],
                Gender = newbornInfo[3],
                Birthday = DateTime.Parse(newbornInfo[4]),
                PlaceOfBirth = newbornInfo[5],
                MotherInfo = newbornInfo[6],
                FatherInfo = newbornInfo[7]
            };

            NewbornPeople.Add(newborn);
        }

        /// <summary>
        /// Удаляет новорожденного из списка по индексу
        /// </summary>
        /// <param name="index"></param>
        public static void DeleteNebornPerson(int index) => NewbornPeople.RemoveAt(index);
    }
}
