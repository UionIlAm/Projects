using System;
using System.Collections.Generic;
using System.Windows;


namespace Project_02
{
    /// <summary>
    /// Логика взаимодействия для SummaryWindow.xaml
    /// </summary>
    public partial class SummaryWindow : Window
    {
        public SummaryWindow()
        {
            InitializeComponent();
        }

        private void SaveSummary_Click(object sender, RoutedEventArgs e)
        {
            SummaryHelper.CreateSummary(FullNameTB.Text, int.Parse(AgeTB.Text), ProfessionTB.Text, WorkExpTB.Text);
            this.Close();
        }
    }
}
