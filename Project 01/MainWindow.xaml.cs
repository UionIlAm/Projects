using System;
using System.Data;
using System.Windows;

namespace Project_01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int leftBracketCount = 0;

        private static string[] operations = new string[] { "+", "-", "*", "/"};

        //private static string log = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckOutForNumbers()
        {
            if (Result.Text == "0" || Result.Text == "Ошибка")
            {
                Result.Text = null;
            }
        }

        private void CheckOpeation(string simvol)
        {
            
            // Result.Text = Result.Text.Remove(Result.Text.Length - 1);

            for (int i = 0; i < operations.Length; i++)
            {
                if (Result.Text.Substring(Result.Text.Length - 2) == operations[i])
                {
                    if (Result.Text.Substring(Result.Text.Length - 2) != simvol)
                    {
                        Result.Text = Result.Text.Remove(Result.Text.Length - 2);
                        Result.Text += " " + simvol + " ";

                        break;
                    }
                    else if (Result.Text.Substring(Result.Text.Length - 2) == simvol)
                    {
                        break;
                    }
                }
                if (i == operations.Length - 1)
                {
                    Result.Text += " " + simvol + " ";
                }
            }
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            CheckOutForNumbers();

            Result.Text += "1";
            Log.Text = "";
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            CheckOutForNumbers();

            Result.Text += "2";
            Log.Text = "";
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            CheckOutForNumbers();

            Result.Text += "3";
            Log.Text = "";
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            CheckOutForNumbers();

            Result.Text += "4";
            Log.Text = "";
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            CheckOutForNumbers();

            Result.Text += "5";
            Log.Text = "";
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            CheckOutForNumbers();

            Result.Text += "6";
            Log.Text = "";
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            CheckOutForNumbers();

            Result.Text += "7";
            Log.Text = "";
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            CheckOutForNumbers();

            Result.Text += "8";
            Log.Text = "";
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            CheckOutForNumbers();

            Result.Text += "9";
            Log.Text = "";
        }

        private void BtnPoint_Click(object sender, RoutedEventArgs e)
        {
            if (Result.Text.Substring(Result.Text.Length - 1) != ",")
            {
                Result.Text += ",";
            }
            
            Log.Text = "";
        }

        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            CheckOutForNumbers();

            Result.Text += "0";
            Log.Text = "";
        }

        private void BtnWipe_Click(object sender, RoutedEventArgs e)
        {
            if (Result.Text != "0" && Result.Text != null && Result.Text != "")
            {
                Result.Text = Result.Text.Remove(Result.Text.Length - 1);

                if (Result.Text == null || Result.Text == "")
                {
                    Result.Text = "0";
                }
            }

            Log.Text = "";
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            CheckOpeation("+");
            Log.Text = "";
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            CheckOpeation("-");
            Log.Text = "";
        }

        private void BtnMultiply_Click(object sender, RoutedEventArgs e)
        {
            CheckOpeation("*");
            Log.Text = "";
        }

        private void BtnDivide_Click(object sender, RoutedEventArgs e)
        {
            CheckOpeation("/");
            Log.Text = "";
        }

        private void BtnBracketL_Click(object sender, RoutedEventArgs e)
        {
            CheckOutForNumbers();

            leftBracketCount++;

            Result.Text += " ( ";

            Log.Text = "";
        }

        private void BtnBracketR_Click(object sender, RoutedEventArgs e)
        {
            if (leftBracketCount != 0)
            {
                Result.Text += " ) ";
                leftBracketCount--;

                Log.Text = "";
            }
        }

        private void BtnRoot_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Log.Text = "";

                string rootNum = GetFuncNum();

                Result.Text += $"{Math.Sqrt(double.Parse(rootNum))}";
            }
            catch
            {
                Result.Text = "Ошибка";
            }
        }

        private string GetFuncNum()
        {
            string num = null;

            try
            {
                string res = null;

                for (int i = Result.Text.Length - 1; i >= 0; i--)
                {
                    if (Result.Text[i].Equals(' '))
                    {
                        break;
                    }

                    res += Result.Text[i];
                    Result.Text = Result.Text.Remove(i);
                }

                for (int i = res.Length - 1; i >= 0; i--)
                {
                    num += res[i];
                }

            }
            catch
            {
                Result.Text = "Ошибка";
            }

            return num;
        }

        private void BtnCos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Log.Text = "";

                string cosNum = GetFuncNum();

                Result.Text += $"{Math.Cos(double.Parse(cosNum))}";
            }
            catch
            {
                Result.Text = "Ошибка";
            }
        }

        private void BtnSin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Log.Text = "";

                string sinNum = GetFuncNum();

                Result.Text += $"{Math.Sin(double.Parse(sinNum))}";
            }
            catch
            {
                Result.Text = "Ошибка";
            }
        }

        private void BtnTg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Log.Text = "";

                string gtNum = GetFuncNum();

                Result.Text += $"{Math.Tan(double.Parse(gtNum))}";
            }
            catch
            {
                Result.Text = "Ошибка";
            }
        }

        private void BtnCtg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Log.Text = "";

                string cgtNum = GetFuncNum();

                Result.Text += $"{Math.Cos(double.Parse(cgtNum)) / Math.Sin(double.Parse(cgtNum))}";
            }
            catch
            {
                Result.Text = "Ошибка";
            }
        }

        private void BtnArcsin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Log.Text = "";

                string arcsinNum = GetFuncNum();

                Result.Text += $"{Math.Asin(double.Parse(arcsinNum))}";
            }
            catch
            {
                Result.Text = "Ошибка";
            }
        }

        private void BtnArccos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Log.Text = "";

                string arccosNum = GetFuncNum();

                Result.Text += $"{Math.Acos(double.Parse(arccosNum))}";
            }
            catch
            {
                Result.Text = "Ошибка";
            }
        }

        private void BtnArctg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Log.Text = "";

                string arctgNum = GetFuncNum();

                Result.Text += $"{Math.Atan(double.Parse(arctgNum))}";
            }
            catch
            {
                Result.Text = "Ошибка";
            }
        }

        private void BtnArcCtg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Log.Text = "";

                string arcctgNum = GetFuncNum();

                Result.Text += $"{Math.PI / 2 - Math.Atan(double.Parse(arcctgNum))}";
            }
            catch
            {
                Result.Text = "Ошибка";
            }
        }

        private void BtnWipeAll_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = "0";
            Log.Text = "";
        }

        private void BtnResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Log.Text = Result.Text + " =";

                Result.Text = new DataTable().Compute(Result.Text.Replace(',', '.'), null).ToString();
            }
            catch
            {
                Result.Text = "Ошибка";
            }
        }

        private void BtnBinaryCode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string binaryCode = GetFuncNum();

                if (Log.Text.Substring(Log.Text.Length - 1) == "=")
                {
                    Log.Text += $" {binaryCode}(двоичная)";
                }
                else
                {
                    Log.Text += $" = {binaryCode}(двоичная)";
                }
                

                Result.Text += $"{Convert.ToString(int.Parse(binaryCode), 2)}";
            }
            catch
            {
                Log.Text += $" --> Ошибка";
                Result.Text = "Ошибка";
            }
        }
    }
}
