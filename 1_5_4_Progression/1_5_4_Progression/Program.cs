using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _1_5_4_Progression
{
    class Program
    {
        /// <summary>
        /// Ввод текста
        /// </summary>
        /// <returns></returns>
        static string Input()
        {
            return ReadLine();
        }
        /// <summary>
        /// Ввод числа и проверка соответствия условиям
        /// </summary>
        /// <param name="paramMax">Максимальное значение для вводимого числа</param>
        /// <param name="paramMin">Минимальное значение для вводимого числа</param>
        /// <returns>Проверенное введенное число</returns>
        static int Input(int paramMax, int paramMin)
        {
            int input;
            while (true)
            {
                if (int.TryParse(ReadLine(), out input) && input <= paramMax && input >= paramMin) break;
                else Write($"Число должно быть целым от {paramMin} до {paramMax}, попробуйте еще раз: ");
            }
            return input;
        }
        /// <summary>
        /// Преобразует строку в массив чисел, если это возможно
        /// </summary>
        /// <returns></returns>
        static int[] InputMulti()
        {
            int[] numbs = new int[1];
            bool check = true;
            while (check)
            {
                string[] wnumbs = ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                numbs = new int[wnumbs.Length];

                if (numbs.Length < 3)
                {
                    Write("Последовательность должна содержать минимум 3 элемента" +
                        "\nПопробуйте еще раз: ");
                    continue;
                }

                for (int ind = 0; ind < wnumbs.Length; ind++)
                {
                    if (int.TryParse(wnumbs[ind], out numbs[ind]))
                    {
                        if (ind == wnumbs.Length - 1) check = false;
                    }
                    else
                    {
                        Write($"Одно из чисел выходит за доспустимые пределы переменной, либо присутствуют лишние символы" +
                            $"\nПопробуйте еще раз: ");
                        break;
                    }
                }
            }

            return numbs;
        }

        /// <summary>
        /// Проверяет, является ли введенная последовательность чисел арифметической или геометрической прогрессией 
        /// </summary>
        /// <param name="numbs">Принимаемая последовательность чисел</param>
        static void ProgressionCheck (int[] numbs)
        {
            bool check = true;
            double buff;
            string fals = "\nДанная последовательность не является ни арифметической, ни геометрической прогрессией";
            string stationary = "\nЭто стационарная арифметическая и стационарная геометрическая прогрессия";

            if (numbs[1] - numbs[0] == numbs[2] - numbs[1])
            {
                buff = numbs[2] - numbs[1];
                for (int ind = 3; ind < numbs.Length; ind++)
                {
                    if (buff != numbs[ind] - numbs[ind-1])
                    {
                        WriteLine(fals);
                        check = false;
                        break;
                    }
                }
                if (buff == 0) WriteLine(stationary);
                else if (numbs.Length == 3 || check) WriteLine("\nЭто арифметическая прогрессия");
            }
            else if ((double)numbs[1] / (double)numbs[0] == (double)numbs[2] / (double)numbs[1])
            {
                buff = (double)numbs[2] / (double)numbs[1];
                for (int ind = 3; ind < numbs.Length; ind++)
                {
                    if (buff != (double)numbs[ind] / (double)numbs[ind - 1])
                    {
                        WriteLine(fals);
                        check = false;
                        break;
                    }
                }
                if (buff == 1) WriteLine(stationary);
                else if(numbs.Length == 3 || check) WriteLine("\nЭто геометрическая прогрессия");
            }
            else WriteLine(fals);
        }

        static void Main(string[] args)
        {
            while(true)
            {
                WriteLine("--------------------------------\n");
                Write("Введите последовательность чисел: ");
                ProgressionCheck(InputMulti());

                ReadKey(true);
                WriteLine("\n--------------------------------\n");

                #region Повтор или выход

                WriteLine("Запустить заново? 1 - Повтор | 0 - Выход");
                Write("Выбор: ");
                if (Input(1, 0) == 0) break; // Завершение программы
                WriteLine();

                #endregion
            }
        }
    }
}
