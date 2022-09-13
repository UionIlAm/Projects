using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Project_05
{
    /// <summary>
    /// Логика взаимодействия для ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        public ResultPage(string range1, string range2)
        {
            InitializeComponent();

            if (int.Parse(range1) > int.Parse(range2))
            {
                string tmp = range1;
                range1 = range2;
                range2 = tmp;
            }

            ViewLuckyTicket(int.Parse(range1), int.Parse(range2));
        }

        static bool CheckTicket(string ticket)
        {
            try
            {
                int firstPart = 0;

                int secondPart = 0;

                if (ticket.Length < 6)
                {
                    while (ticket.Length != 6)
                    {
                        ticket = ticket.Insert(0, "0");
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    firstPart += int.Parse(ticket[i].ToString());

                    secondPart += int.Parse(ticket[i + 3].ToString());
                }

                return firstPart == secondPart;
            }
            catch
            {
                return false;
            }         
        }

        private void ViewLuckyTicket(int range1, int range2)
        {
            for (int i = range1; i <= range2; i++)
            {
                if (CheckTicket(i.ToString()))
                {
                    if (i.ToString().Length < 6)
                    {
                        string ticketStr = i.ToString();

                        while (ticketStr.Length != 6)
                        {
                            ticketStr = ticketStr.Insert(0, "0");
                        }

                        ResultList.Items.Add(ticketStr);

                        continue;
                    }
                    ResultList.Items.Add(i);
                }
            }

            if (ResultList.Items.Count == 0)
            {
                ResultList.Items.Add("Счастливых билетов нет");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.GoBack();
        }
    }
}
