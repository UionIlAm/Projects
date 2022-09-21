using System;

namespace Project_09
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите дерево вида \"Д (Б (А, Ф (В,)), Е (,З (Ж, И)))\"\n");

            Console.Write("Ввод: ");
            OutPut(Console.ReadLine());

            Console.ReadKey();
        }

        static void OutPut(string tree)
        {
            Console.WriteLine("\nДерево преведено к виду \"б\":\n");
            Console.WriteLine($"{tree[0]}\n\n" +
                $"\t{tree[3]}\n\n" +
                $"\t\t {tree[6]}\n" +
                $"\t\t  {tree[9]}\t\t{tree[12]}\n" +
                $"\t{tree[18]}\n" +
                $"\t\t  {tree[22]}\n" +
                $"\t\t  \t\t {tree[25]}\n" +
                $"\t\t  \t\t  {tree[28]}\n");
        }
    }
}
