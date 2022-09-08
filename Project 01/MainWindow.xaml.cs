using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;

namespace Project_01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int leftBracketCount = 0;

        private static string[] operations = new string[] { " + ", " - ", " * ", " / "};

        private static string formatOfNum = "decimal";

        //private static string log = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GlobalCheckOut()
        {
            //Проверка для правильности отображения ввода.

            if (Result.Text == "0" || Result.Text == "Неверный ввод" || Result.Text == "Запятая - это зло")
            {
                Result.Text = null;
            }
            if (BtnBinaryCode.Content.Equals("Decimal"))
            {
                BtnBinaryCode.Content = "Binary";
            }
        }

        private void DefaultExpressionModule()
        {
            //Возвращает модуль выражений в исходное состояние.

            UsingOperands();
            ClearOperandFields();
            DisableOperandFields();
        }

        private void CheckOpeation(string simvol)
        {
            //Проверка для правильности отображения ввода мат. знаков.
            try
            {
                for (int i = 0; i < operations.Length; i++)
                {
                    if (Result.Text.Substring(Result.Text.Length - 3) == operations[i])
                    {
                        if (Result.Text.Substring(Result.Text.Length - 3) != simvol)
                        {
                            Result.Text = Result.Text.Remove(Result.Text.Length - 3);
                            Result.Text += simvol;

                            break;
                        }
                        else if (Result.Text.Substring(Result.Text.Length - 3) == simvol)
                        {
                            break;
                        }
                    }
                    if (i == operations.Length - 1)
                    {
                        Result.Text += simvol;
                    }
                }
            }
            catch
            {
                Result.Text += simvol;
            }
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            GlobalCheckOut();

            DefaultExpressionModule();

            Result.Text += "1";
            Log.Text = "";
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            GlobalCheckOut();

            DefaultExpressionModule();

            Result.Text += "2";
            Log.Text = "";
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            GlobalCheckOut();

            DefaultExpressionModule();

            Result.Text += "3";
            Log.Text = "";
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            GlobalCheckOut();

            DefaultExpressionModule();

            Result.Text += "4";
            Log.Text = "";
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            GlobalCheckOut();

            DefaultExpressionModule();

            Result.Text += "5";
            Log.Text = "";
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            GlobalCheckOut();

            DefaultExpressionModule();

            Result.Text += "6";
            Log.Text = "";
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            GlobalCheckOut();

            DefaultExpressionModule();

            Result.Text += "7";
            Log.Text = "";
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            GlobalCheckOut();

            DefaultExpressionModule();

            Result.Text += "8";
            Log.Text = "";
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            GlobalCheckOut();

            DefaultExpressionModule();

            Result.Text += "9";
            Log.Text = "";
        }

        private void BtnPoint_Click(object sender, RoutedEventArgs e)
        {
            DefaultExpressionModule();

            if (Result.Text.Substring(Result.Text.Length - 1) != ",")
            {
                Result.Text += ",";
            }
            
            Log.Text = "";
        }

        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            GlobalCheckOut();

            DefaultExpressionModule();

            Result.Text += "0";
            Log.Text = "";
        }

        private void BtnWipe_Click(object sender, RoutedEventArgs e)
        {
            if (Result.Text == "Неверный ввод" || Result.Text == "Запятая - это зло")
            {
                Result.Text = "0";
            }
            else if (Result.Text != "0" && Result.Text != null && Result.Text != "")
            {
                Result.Text = Result.Text.Remove(Result.Text.Length - 1);

                if (Result.Text == null || Result.Text == "")
                {
                    Result.Text = "0";
                }
            }

            BtnBinaryCode.Content = "Binary";

            Log.Text = "";
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            GlobalCheckOut();

            DefaultExpressionModule();

            CheckOpeation(" + ");

            Log.Text = "";
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            GlobalCheckOut();

            DefaultExpressionModule();

            CheckOpeation(" - ");

            Log.Text = "";
        }

        private void BtnMultiply_Click(object sender, RoutedEventArgs e)
        {
            GlobalCheckOut();

            DefaultExpressionModule();

            CheckOpeation(" * ");

            Log.Text = "";
        }

        private void BtnDivide_Click(object sender, RoutedEventArgs e)
        {
            GlobalCheckOut();

            DefaultExpressionModule();

            CheckOpeation(" / ");

            Log.Text = "";
        }

        private void BtnBracketL_Click(object sender, RoutedEventArgs e)
        {
            GlobalCheckOut();

            DefaultExpressionModule();

            leftBracketCount++;

            InsertExpression("( ");

            //Result.Text += "( ";

            Log.Text = "";
        }

        private void BtnBracketR_Click(object sender, RoutedEventArgs e)
        {
            if (leftBracketCount != 0)
            {
                Result.Text += " )";
                leftBracketCount--;

                Log.Text = "";
            }
        }

        private void BtnRoot_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GlobalCheckOut();

                DefaultExpressionModule();

                Log.Text = "";

                string rootNum = GetFuncNum();

                Result.Text += $"{Math.Sqrt(double.Parse(rootNum))}";
            }
            catch
            {
                Result.Text = "Неверный ввод";
            }
        }

        private string GetFuncNum()
        {
            //Метод получение последнего введённого числа.
            string num = null;

            try
            {
                DefaultExpressionModule();

                GlobalCheckOut();

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
                Result.Text = "Неверный ввод";
            }

            return num;
        }

        private void BtnCos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DefaultExpressionModule();

                Log.Text = "";

                string cosNum = GetFuncNum();

                Result.Text += $"{Math.Cos(double.Parse(cosNum))}";
            }
            catch
            {
                Result.Text = "Неверный ввод";
            }
        }

        private void BtnSin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DefaultExpressionModule();

                Log.Text = "";

                string sinNum = GetFuncNum();

                Result.Text += $"{Math.Sin(double.Parse(sinNum))}";
            }
            catch
            {
                Result.Text = "Неверный ввод";
            }
        }

        private void BtnTg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DefaultExpressionModule();

                Log.Text = "";

                string gtNum = GetFuncNum();

                Result.Text += $"{Math.Tan(double.Parse(gtNum))}";
            }
            catch
            {
                Result.Text = "Неверный ввод";
            }
        }

        private void BtnCtg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DefaultExpressionModule();

                Log.Text = "";

                string cgtNum = GetFuncNum();

                Result.Text += $"{Math.Cos(double.Parse(cgtNum)) / Math.Sin(double.Parse(cgtNum))}";
            }
            catch
            {
                Result.Text = "Неверный ввод";
            }
        }

        private void BtnArcsin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DefaultExpressionModule();

                Log.Text = "";

                string arcsinNum = GetFuncNum();

                Result.Text += $"{Math.Asin(double.Parse(arcsinNum))}";
            }
            catch
            {
                Result.Text = "Неверный ввод";
            }
        }

        private void BtnArccos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DefaultExpressionModule();

                Log.Text = "";

                string arccosNum = GetFuncNum();

                Result.Text += $"{Math.Acos(double.Parse(arccosNum))}";
            }
            catch
            {
                Result.Text = "Неверный ввод";
            }
        }

        private void BtnArctg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DefaultExpressionModule();

                Log.Text = "";

                string arctgNum = GetFuncNum();

                Result.Text += $"{Math.Atan(double.Parse(arctgNum))}";
            }
            catch
            {
                Result.Text = "Неверный ввод";
            }
        }

        private void BtnArcCtg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DefaultExpressionModule();

                Log.Text = "";

                string arcctgNum = GetFuncNum();

                Result.Text += $"{Math.PI / 2 - Math.Atan(double.Parse(arcctgNum))}";
            }
            catch
            {
                Result.Text = "Неверный ввод";
            }
        }

        private void BtnWipeAll_Click(object sender, RoutedEventArgs e)
        {
            BtnBinaryCode.Content = "Binary";
            Result.Text = "0";
            Log.Text = "";
        }

        private void BtnResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GlobalCheckOut();

                DefaultExpressionModule();

                Log.Text = Result.Text + " =";
                Result.Text = new DataTable().Compute(Result.Text.Replace(',', '.'), null).ToString();
            }
            catch
            {
                Result.Text = "Неверный ввод";
            }
        }


        private void BtnBinaryCode_Click(object sender, RoutedEventArgs e)
        {
            string requestNum = "";

            try
            {
                DefaultExpressionModule();

                Regex binary = new Regex("^[01]{1,32}$", RegexOptions.Compiled);

                if (Result.Text != "Неверный ввод")
                {
                    requestNum = GetFuncNum();


                    if (binary.IsMatch(requestNum))
                    {
                        Result.Text += $"{Convert.ToInt32(requestNum, 2)}";
                        BtnBinaryCode.Content = "Binary";
                        formatOfNum = "to decimal";
                    }
                    else
                    {
                        Result.Text += $"{Convert.ToString(int.Parse(requestNum), 2)}";
                        BtnBinaryCode.Content = "Decimal";
                        formatOfNum = "to binary";
                    }

                    try
                    {
                        if (Log.Text.Substring(Log.Text.Length - 1) == "=")
                        {
                            Log.Text += $" {requestNum}({formatOfNum}) =";
                        }
                        else
                        {
                            Log.Text += $" = {requestNum}({formatOfNum})";
                        }
                    }
                    catch
                    {
                    }

                    if (Log.Text == "")
                    {
                        Log.Text += $"{requestNum}({formatOfNum}) =";
                    }
                }
            }
            catch
            {
                if (Result.Text != "Неверный ввод" || Result.Text != "")
                {
                    Log.Text += $">{requestNum}({formatOfNum}) --> Неверный ввод";
                    Result.Text = "Запятая - это зло";
                }
            }
        }

        private void InsertExpression(string expression)
        {
            //Осуществляет корректную вставку сложных выражений.

            try
            {
                GlobalCheckOut();

                for (int i = 0; i < operations.Length; i++)
                {
                    if (Result.Text.Length != 0)
                    {
                        if (Result.Text.Length >= 2)
                        {
                            if (Result.Text.Substring(Result.Text.Length - 3) == operations[i])
                            {
                                Result.Text += $"{expression}";
                                break;
                            }
                            else if(i == operations.Length - 1)
                            {
                                Result.Text += $" * {expression}";
                                break;
                            }
                        }
                        else
                        {
                            Result.Text += $" * {expression}";
                            break;
                        }
                    }
                    else
                    {
                        Result.Text += $"{expression}";
                        break;
                    }
                }
            }
            catch
            {
                Result.Text = "Неверный ввод";
            }
        }

        private void ClearOperandFields()
        {
            FirstOperand.Text = "";
            SecondOperand.Text = "";
        }

        private void UsingOperands()
        {
            //Проверяет используются ли поля операндов, если да - обнуляет их.

            if (FirstOperand.IsEnabled == true)
            {
                BtnDegree.Content = "степень";
                BtnRootSecondOper.Content = "√ 2nd";
                BtnLogSecondOper.Content = "log 2nd";

                LblFirstOperand.Content = "1й операнд";
                LblSecondOperand.Content = "2й операнд";
            }
        }

        private void DisableOperandFields()
        {
            FirstOperand.IsEnabled = false;
            SecondOperand.IsEnabled = false;
        }

        private void BtnDegree_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GlobalCheckOut();

                if (!BtnDegree.Content.Equals("вставить"))
                {
                    UsingOperands();
                }

                if (BtnDegree.Content.Equals("вставить"))
                {
                    if (FirstOperand.Text != "" && SecondOperand.Text != "")
                    {
                        CheckOperandFraction();

                        InsertExpression(Math.Pow(double.Parse(FirstOperand.Text), double.Parse(SecondOperand.Text)).ToString());
                    }

                    BtnDegree.Content = "степень";

                    DefaultExpressionModule();
                }
                else
                {
                    BtnDegree.Content = "вставить";

                    LblFirstOperand.Content = "число";
                    LblSecondOperand.Content = "степень";

                    FirstOperand.IsEnabled = true;
                    SecondOperand.IsEnabled = true;
                }

                ClearOperandFields();
            }
            catch
            {
                Result.Text = "Неверный ввод";
            }
        }

        private void BtnLn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InsertExpression(Math.Log(double.Parse(GetFuncNum())).ToString());
            }
            catch
            {
                Result.Text = "Неверный ввод";
            }
        }

        private void BtnLog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InsertExpression(Math.Log10(double.Parse(GetFuncNum())).ToString());
            }
            catch
            {
                Result.Text = "Неверный ввод";
            }
        }

        private void CheckOperandFraction()
        {
            FirstOperand.Text = new DataTable().Compute(FirstOperand.Text.Replace(',', '.'), null).ToString();

            SecondOperand.Text = new DataTable().Compute(SecondOperand.Text.Replace(',', '.'), null).ToString();
        }

        private void BtnLogSecondOper_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GlobalCheckOut();

                if (!BtnLogSecondOper.Content.Equals("вставить"))
                {
                    UsingOperands();
                }

                if (BtnLogSecondOper.Content.Equals("вставить"))
                {
                    if (FirstOperand.Text != "" && SecondOperand.Text != "")
                    {
                        CheckOperandFraction();

                        InsertExpression(Math.Log(double.Parse(FirstOperand.Text), double.Parse(SecondOperand.Text)).ToString());
                    }

                    BtnLogSecondOper.Content = "log 2nd";

                    DefaultExpressionModule();
                }
                else
                {
                    BtnLogSecondOper.Content = "вставить";

                    LblFirstOperand.Content = "число";
                    LblSecondOperand.Content = "основание";

                    FirstOperand.IsEnabled = true;
                    SecondOperand.IsEnabled = true;
                }

                ClearOperandFields();
            }
            catch
            {
                Result.Text = "Неверный ввод";
            }
        }

        private void FirstOperand_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(FirstOperand.Text[FirstOperand.Text.Length - 1]) || !Char.IsDigit(FirstOperand.Text[0]))
                {
                    FirstOperand.Text = FirstOperand.Text.Remove(FirstOperand.Text.Length - 1);
                }
            }
            catch
            {
            }
        }

        private void SecondOperand_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(SecondOperand.Text[FirstOperand.Text.Length - 1]) || !Char.IsDigit(SecondOperand.Text[0]))
                {
                    SecondOperand.Text = SecondOperand.Text.Remove(SecondOperand.Text.Length - 1);
                }
            }
            catch
            {
            }
        }

        private void BtnRootSecondOper_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GlobalCheckOut();

                if (!BtnRootSecondOper.Content.Equals("вставить"))
                {
                    UsingOperands();
                }

                if (BtnRootSecondOper.Content.Equals("вставить"))
                {
                    if (FirstOperand.Text != "" && SecondOperand.Text != "")
                    {
                        CheckOperandFraction();

                        //Math.Pow(value, 1d/3)

                        InsertExpression(Math.Pow(double.Parse(FirstOperand.Text), 1d / double.Parse(SecondOperand.Text)).ToString());
                    }

                    BtnRootSecondOper.Content = "√ 2nd";

                    DefaultExpressionModule();
                }
                else
                {
                    BtnRootSecondOper.Content = "вставить";

                    LblFirstOperand.Content = "число";
                    LblSecondOperand.Content = "индекс";

                    FirstOperand.IsEnabled = true;
                    SecondOperand.IsEnabled = true;
                }

                ClearOperandFields();
            }
            catch
            {
                Result.Text = "Неверный ввод";
            }
        }
    }
}