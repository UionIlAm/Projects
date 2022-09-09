using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;


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

            DelSummary.IsEnabled = SummaryHelper.Summary.Count != 0 ? true : false;
            Recruit.IsEnabled = SummaryHelper.Summary.Count != 0 ? true : false;

            DelVacancy.IsEnabled = VacancyHelper.Vacancy.Count != 0 ? true : false;
            Respond.IsEnabled = VacancyHelper.Vacancy.Count != 0 ? true : false;

        }

        private void AddSummary_Click(object sender, RoutedEventArgs e)
        {
            SummaryWindow summaryWindow = new SummaryWindow();
            summaryWindow.ShowDialog();

            LvSummary.HorizontalContentAlignment = HorizontalAlignment.Stretch;

            Update();
        }

        private void Recruit_Click(object sender, RoutedEventArgs e)
        {
            SummaryHelper.Summary.RemoveAt(LvSummary.SelectedIndex);

            Update();
        }

        private void DelSummary_Click(object sender, RoutedEventArgs e)
        {
            SummaryHelper.Summary.RemoveAt(LvSummary.SelectedIndex);

            Update();
        }

        private void AddVacancy_Click(object sender, RoutedEventArgs e)
        {
            VacancyWindow vacancyWindow = new VacancyWindow();
            vacancyWindow.ShowDialog();

            Update();
        }

        private void Respond_Click(object sender, RoutedEventArgs e)
        {
            VacancyHelper.Vacancy.RemoveAt(LvVacancies.SelectedIndex);

            Update();
        }

        private void DelVacancy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VacancyHelper.Vacancy.RemoveAt(LvVacancies.SelectedIndex);
                Update();
            }
            catch
            {
            }
        }

        private void LvSummary_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
        }
    }
}
