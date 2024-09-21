using System;
using System.Threading.Channels;

namespace CalcInterface
{

    class Program
    {

        static ILogger Logger { get; set; }
        static void Main()
        {
            Logger = new Logger();
            Console.WriteLine("Введите 2 целочисленных значения: ");
            int a = 0, b = 0;
            try
            {
                Console.Write("Введите значение a: ");
                a = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите значение b: ");
                b = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Неверно введены значения. Пожалуйста, введите целые числа.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка: Введенное значение слишком велико или слишком мало. Пожалуйста, введите целое число в допустимом диапазоне.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
            }
            var fin1 = new Fin1(Logger);
            MiniCalc minicalc = new MiniCalc();
            minicalc.Sum(a, b);

            fin1.Fin();
            Console.ReadKey();

        }
        

    }

    public interface IMiniCalc
    {
        void Sum(int a, int b);
    }

    public class MiniCalc : IMiniCalc
    {
        public void Sum(int a, int b)
        {
            Console.WriteLine("Сумма введенных значений: {0}", a + b);
        }
    }

    public interface ILogger
    {
        void Event(string message);
    }

    public class Logger : ILogger
    {
        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
        }
    }

    public interface IFin
    {
        void Fin();
    }
}