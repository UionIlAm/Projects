using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Project_02
{
    public class Employee
    {
        public string DisplayName { get; set; }
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Update()
        {
            LvSummary.ItemsSource = SummaryHelper.Summary;
            LvVacancies.ItemsSource = VacancyHelper.Vacancy;

            LvVacancies.SelectedIndex = -1;
            LvSummary.SelectedIndex = -1;

            //DelSummary.IsEnabled = SummaryHelper.Summary.Count != 0 ? true : false;
            //Recruit.IsEnabled = SummaryHelper.Summary.Count != 0 ? true : false;

            //DelVacancy.IsEnabled = VacancyHelper.Vacancy.Count != 0 ? true : false;
            //Respond.IsEnabled = VacancyHelper.Vacancy.Count != 0 ? true : false;

        }

        private void AddSummary_Click(object sender, RoutedEventArgs e)
        {
            InfoLabel.Content = "";

            SummaryWindow summaryWindow = new SummaryWindow();
            summaryWindow.ShowDialog();

            Update();
        }

        private void Recruit_Click(object sender, RoutedEventArgs e)
        {
            //SummaryHelper.Summary.RemoveAt(LvSummary.SelectedIndex);

            try
            {
                InfoLabel.Content = $"Организация \"{VacancyHelper.Vacancy[LvVacancies.SelectedIndex].Organization}\" " +
                    $"приняла на работу человека под именем \"{SummaryHelper.Summary[LvSummary.SelectedIndex].FullName}\"!";

                SummaryHelper.Summary.RemoveAt(LvSummary.SelectedIndex);

                Recruit.IsEnabled = false;

                Update();
            }
            catch
            {
                SummaryGuide_Click(sender, e);
            }
        }

        private void DelSummary_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InfoLabel.Content = "";

                SummaryHelper.Summary.RemoveAt(LvSummary.SelectedIndex);

                Recruit.IsEnabled = false;

                Update();
            }
            catch
            {
                SummaryGuide_Click(sender, e);
            }
        }

        private void AddVacancy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InfoLabel.Content = "";

                VacancyWindow vacancyWindow = new VacancyWindow();
                vacancyWindow.ShowDialog();

                Update();
            }
            catch
            {
                VacancyGuide_Click(sender, e);
            }
        }

        private void Respond_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InfoLabel.Content = $"Человек под именем \"{SummaryHelper.Summary[LvSummary.SelectedIndex].FullName}\" " +
                    $"подал(а) заявку в организацию \"{VacancyHelper.Vacancy[LvVacancies.SelectedIndex].Organization}\"!";

                VacancyHelper.Vacancy.RemoveAt(LvVacancies.SelectedIndex);

                Respond.IsEnabled = false;

                Update();
            }
            catch
            {
                VacancyGuide_Click(sender, e);
            }
        }

        private void DelVacancy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InfoLabel.Content = "";

                VacancyHelper.Vacancy.RemoveAt(LvVacancies.SelectedIndex);

                DelVacancy.IsEnabled = false;

                Update();
            }
            catch
            {
                VacancyGuide_Click(sender, e);
            }
        }

        private void SummaryGuide_Click(object sender, RoutedEventArgs e)
        {
            InfoLabel.Content = "";

            _ = MessageBox.Show("\"Добавить резюме\"\n1) Нажмите на кнопку \"Добавить резюме.\"\n2) В открывшемся окне заполните поля.\n3) Нажмите на кнопку \"Подать резюме.\"\n" +
                "*если какое-то поле не заполнено, то будет выводиться \"Не указано\".\n\n" +
                "\"Принять на работу\"\n1) Выберите из списка \"вакансий\" организацию.\n2) Выберите из списка \"резюме\" человека, которого хотите принять на работу.\n" +
                "3) Нажмите кнопку \"Принять на работу\".\n\n" +
                "\"Удалить резюме\"\n" +
                "1) Выберите из списка резюме, которое хотите удалить.\n" +
                "2) Нажмите кнопку \"Удалить резюме\".\n\nПриятного Вам пользования!", "Справка по разделу \"Резюме\"");
        }

        private void VacancyGuide_Click(object sender, RoutedEventArgs e)
        {
            InfoLabel.Content = "";

            _ = MessageBox.Show("\"Добавить вакансию\"\n1) Нажмите на кнопку \"Добавить вакансию.\"\n2) В открывшемся окне заполните поля.\n3) Нажмите на кнопку \"Подать вакансию.\"\n" +
                "*если какое-то поле не заполнено, то будет выводиться \"Не указано\".\n\n" +
                "\"Откликнуться\"\n1) Выберите из списка \"резюме\" человека.\n2) Выберите из списка \"вакансий\" организацию, в которую хотите подать заявку.\n" +
                "3) Нажмите кнопку \"Откликнуться\".\n\n" +
                "\"Удалить вакансию\"\n" +
                "1) Выберите из списка вакансию, которое хотите удалить.\n" +
                "2) Нажмите кнопку \"Удалить вакансию\".\n\nПриятного Вам пользования!", "Справка по разделу \"Вакансии\"");
        }

        private void LvVacancies_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                DelVacancy.IsEnabled = true;

                if (LvSummary.SelectedIndex != -1)
                {
                    Recruit.IsEnabled = true;

                    Respond.IsEnabled = true;
                }
            }
            catch
            {
                //вывод справки
                VacancyGuide_Click(sender, e);
            }

        }

        private void LvSummary_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                DelSummary.IsEnabled = true;

                if (LvVacancies.SelectedIndex != -1)
                {
                    Respond.IsEnabled = true;

                    Recruit.IsEnabled = true;
                }
            }
            catch
            {
                //вывод справки
                SummaryGuide_Click(sender, e);
            }
        }
    }
}
