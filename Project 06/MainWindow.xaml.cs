using System;
using System.Windows;

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

            VertBar.Text = "\n\n2.0 \n\n\n1.5 \n\n\n1.0 \n\n\n0.5 ";

            Start();
        }

        private void Repeat_Click(object sender, RoutedEventArgs e) => Start();

        private void Start()
        {
            //Оригинальная последовательность.
            double[] originalSequence = new double[60];

            Random random = new Random();

            //Заполнение.
            for (int i = 0; i < originalSequence.Length; i++)
            {
                //60 случайных чисел с экспоненци-альным законом распределения с параметром 0,8.
                originalSequence[i] = -1/0.8 * Math.Log(random.Next());
            }

            //сортировка по возрастанию
            for (int i = 0; i < originalSequence.Length; i++)
            { 
                for (int j = 0; j < originalSequence.Length - 1 - i; j++)
                {
                    if (originalSequence[j] > originalSequence[j + 1])
                    {
                        Swap(ref originalSequence[j], ref originalSequence[j + 1]);
                    }
                }
            }

            //Новая последовательность
            double[] newSequence = new double[30];

            int newSequenceCount = 29;
            //Образовать новую последовательность, состоящую из разности соседних элементов Xi - Xi-1
            for (int i = originalSequence.Length - 1; i > 0; i--)
            {
                newSequence[newSequenceCount] = Math.Round(originalSequence[i] - originalSequence[i - 1], 3);

                i--;
                newSequenceCount--;
            }

            //среднее значение
            double sampleMean = 0;
            for (int i = 0; i < newSequence.Length; i++)
            {
                sampleMean += newSequence[i];
            }

            sampleMean = Math.Round(sampleMean / newSequence.Length, 3);

            //Вычитание выборочного среднего из каждого значения в выборке и возведение в квадрат.
            double[] samples = new double[newSequence.Length];
            for (int i = 0; i < samples.Length; i++)
            {
                samples[i] = Math.Round(Math.Pow(newSequence[i] - sampleMean, 2), 2);
            }

            //Вычисление суммы квадратов разностей ряда.
            double sum = 0;
            for (int i = 0; i < samples.Length; i++)
            {
                sum += samples[i];
            }

            //Дисперсия.
            double dispersion = sum / samples.Length - 1;

            //Заполнение и создание гистограммы.
            SampleMeanLabel.Content = $"Ср. значение: {Math.Round(sampleMean, 3)}";
            DispersionLabel.Content = $"Дисперсия: {Math.Round(dispersion, 3)}";

            Bar1.Height = newSequence[0] * 100;
            Bar1Value.Text = newSequence[0].ToString();

            Bar2.Height = newSequence[9] * 100;
            Bar2Value.Text = newSequence[9].ToString();

            Bar3.Height = newSequence[29] * 100;
            Bar3Value.Text = newSequence[29].ToString();
        }

        public static void Swap(ref double aFirstArg, ref double aSecondArg)
        {
            double tmpParam = aFirstArg;

            aFirstArg = aSecondArg;

            aSecondArg = tmpParam;
        }
    }
}