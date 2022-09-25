using System;
using System.Collections.Generic;
using System.Windows;

namespace SystemsOfLinearEquationsManager
{
    public static class EquationsManager
    {
        public static string Kramer(double[,] equation)
        {
            //
            //http://mathprofi.ru/pravilo_kramera_matrichnyi_metod.html
            //
            // a1 b1 c1 s1
            // a2 b2 c2 s2
            // a3 b3 c3 s3
            //
            // a1 b1 s1
            // a2 b2 s2
            //
            try
            {
                double mainDeterminant = 0;

                if (equation.GetLength(0) == 3)
                {
                    //Решение системы с тремя неизвестными
                    mainDeterminant = (equation[0, 0] * ((equation[1, 1] * equation[2, 2]) - (equation[1, 2] * equation[2, 1]))) -
                        (equation[0, 1] * ((equation[1, 0] * equation[2, 2]) - (equation[1, 2] * equation[2, 0]))) +
                        (equation[0, 2] * ((equation[1, 0] * equation[2, 1]) - (equation[1, 1] * equation[2, 0])));

                    if (mainDeterminant == 0)
                    {
                        MessageBox.Show("Решить систему методом Крамера невозможно.\nИспользуйте метод Гаусса.", "Главный определитель равен нулю.", MessageBoxButton.OK);
                        return "0";
                    }

                    double determinant1 = (equation[0, 3] * ((equation[1, 1] * equation[2, 2]) - (equation[1, 2] * equation[2, 1]))) -
                        (equation[0, 1] * ((equation[1, 3] * equation[2, 2]) - (equation[1, 2] * equation[2, 3]))) +
                        (equation[0, 2] * ((equation[1, 3] * equation[2, 1]) - (equation[1, 1] * equation[2, 3])));

                    double determinant2 = equation[0, 0] * ((equation[1, 3] * equation[2, 2]) - (equation[1, 2] * equation[2, 3])) -
                        (equation[0, 3] * ((equation[1, 0] * equation[2, 2]) - (equation[1, 2] * equation[2, 0]))) +
                        (equation[0, 2] * ((equation[1, 0] * equation[2, 3]) - (equation[1, 3] * equation[2, 0])));

                    double determinant3 = (equation[0, 0] * ((equation[1, 1] * equation[2, 3]) - (equation[1, 3] * equation[2, 1]))) -
                        (equation[0, 1] * ((equation[1, 0] * equation[2, 3]) - (equation[1, 3] * equation[2, 0]))) +
                        (equation[0, 3] * ((equation[1, 0] * equation[2, 1]) - (equation[1, 1] * equation[2, 0])));


                    double res1 = Math.Round(determinant1 / mainDeterminant, 3);

                    double res2 = Math.Round(determinant2 / mainDeterminant, 3);

                    double res3 = Math.Round(determinant3 / mainDeterminant, 3);

                    //MessageBox.Show($"a = {res1}; b = {res2}; c = {res3}", "", MessageBoxButton.OK);

                    return $"a = {res1}; b = {res2}; c = {res3}";
                }
                else
                {
                    //Решение системы с двумя неизвестными
                    mainDeterminant = (equation[0, 0] * equation[1, 1]) - (equation[0, 1] * equation[1, 0]);

                    if (mainDeterminant == 0)
                    {
                        MessageBox.Show("Решить систему методом Крамера невозможно.\nИспользуйте метод Гаусса.", "Главный определитель равен нулю.", MessageBoxButton.OK);
                        return "0";
                    }
                    else
                    {
                        double determinant1 = (equation[0, 2] * equation[1, 1]) - (equation[0, 1] * equation[1, 2]);

                        double determinant2 = (equation[0, 0] * equation[1, 2]) - (equation[0, 2] * equation[1, 0]);

                        double res1 = Math.Round(determinant1 / mainDeterminant, 3);

                        double res2 = Math.Round(determinant2 / mainDeterminant, 3);
                        
                        //MessageBox.Show($"a = {res1}; b = {res2}", "", MessageBoxButton.OK);

                        return $"a = {res1}; b = {res2}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return "Ошибка";
            }
        }

        public static void JordanGauss(double[,] equation)
        {

        }

        public static void Gauss(double[,] equation)
        {

        }

        public static void SimpleIteration(double[,] equation)
        {

        }

        public static void Seidel(double[,] equation)
        {

        }
    }
}
