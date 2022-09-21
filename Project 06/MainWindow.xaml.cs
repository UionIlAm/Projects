using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_06
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Init();

        }

        private void Init()
        {
            double[] x = new double[60];

            Random random = new Random();

            //заполнение
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = -1/0.8 * Math.Log10(random.Next());
            }

            //сортировка по возрастанию
            for (int i = 0; i < x.Length; i++)
            {
                //Вложенный цикл (количество повторений, равно количеству элементов массива минус 1 и минус количество выполненных повторений основного цикла)
                for (int j = 0; j < x.Length - 1 - i; j++)
                {
                    //Если элемент массива с индексом j больше следующего за ним элемента
                    if (x[j] > x[j + 1])
                    {
                        //Меняем местами элемент массива с индексом j и следующий за ним
                        Swap(ref x[j], ref x[j + 1]);
                    }
                }
            }


            double[] newCollection = new double[30];

            for (int i = x.Length / 2 - 1; i >= 0; i--)
            {
                if (i != 0)
                {
                    newCollection[i] = x[i] - x[i - 1];
                }
                else
                {
                    x[i] = x[i] - x[i + 1];
                }
              
            }

        }

        public static void Swap(ref double aFirstArg, ref double aSecondArg)
        {
            double tmpParam = aFirstArg;

            aFirstArg = aSecondArg;

            aSecondArg = tmpParam;
        }

    }
}
