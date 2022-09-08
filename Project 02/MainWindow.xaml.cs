using System;
using System.Collections.Generic;
using System.Windows;


namespace Project_02
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static List<SummaryHelper> summaries = SummaryHelper.Summary;

        private void AddSummary_Click(object sender, RoutedEventArgs e)
        {
            SummaryWindow summaryWindow = new SummaryWindow();
            summaryWindow.ShowDialog();
        }

        private void Recruit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelSummary_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddVacancy_Click(object sender, RoutedEventArgs e)
        {
            VacancyWindow vacancyWindow = new VacancyWindow();
            vacancyWindow.ShowDialog();
        }

        private void Respond_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelVacancy_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
