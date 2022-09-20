using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exzamen
{
    class Program
    {
        static void Main(string[] args)
        {
            int a; // Общее количество работ по проекту
            int[] b = new int[20]; // Вектор-пара, представляющая работу.
            int[] c = new int[20];
            int[] dbc = new int[20];// продолжительность 
            int[] s1 = new int[20]; // первый срок начала 
            int[] s2 = new int[20]; // последний срок начала 
            int[] f1 = new int[20]; // первый срок завершения
            int[] f2 = new int[20]; // последний срок завершения 
            int[] tf = new int[20]; // полный ресурс времени 
            int[] ff = new int[20]; // свободный ресурс 
            int d; // цикл

            Console.Write("Введите общее количество работ по проекту: ");
            a = int.Parse(Console.ReadLine());
            for (d = 0; d < a; d++)
            {
                Console.Write("");
                Console.Write("Введите начало дуги: ");
                b[d] = int.Parse(Console.ReadLine());
                Console.Write("");
                Console.Write("Введите конец дуги: ");
                c[d] = int.Parse(Console.ReadLine());
                Console.Write("");
                Console.Write("Введите продолжительность дуги: ");
                dbc[d] = int.Parse(Console.ReadLine());
                Console.Write("");
            }
            Critical_Path(a, b, c, dbc, s1, s2, f1, f2, tf, ff);
            Console.Write("Подсчёт дней всех путей: ");
            for (d = 0; d < a; d++) Console.Write("{0} ", f2[d]);

            // Определение критического пути. Критический путь задается стрелками, соединяющими события, для которых полный ресурс времени = 0
            Console.Write("");
            Console.Write("Критический путь: ");
            for (d = 0; d < a; d++)
                if (tf[d] == 0) Console.Write("{0} ", c[d]);
            Console.ReadKey();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="dbc"></param>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <param name="tf"></param>
        /// <param name="ff"></param>
        public static void Critical_Path(int a, int[] b, int[] c, int[] dbc, int[] s1, int[] s2, int[] f1, int[] f2, int[] tf, int[] ff)
        {
            int d, index, max, min;
            int[] ti = new int[20];
            int[] te = new int[20];

            index = 0;
            for (d = 0; d < a; d++)
            {
                if (b[d] == index + 1) index = b[d];
                ti[d] = 0; te[d] = 9999;
            }

            for (d = 0; d < a; d++)
            {
                max = ti[b[d]] + dbc[d];
                if (ti[c[d]] < max) ti[c[d]] = max;
            }

            te[c[a - 1]] = ti[c[a - 1]];
            for (d = a - 1; d >= 0; d--)
            {
                min = te[c[d]] - dbc[d];
                if (te[b[d]] > min) te[b[d]] = min;
            }

            for (d = 0; d < a; d++)
            {
                s1[d] = ti[b[d]]; f1[d] = s1[d] + dbc[d];
                f2[d] = te[c[d]]; s2[d] = f2[d] - dbc[d];
                tf[d] = f2[d] - f1[d]; ff[d] = ti[c[d]] - f1[d];
            }
        }
    }
}
