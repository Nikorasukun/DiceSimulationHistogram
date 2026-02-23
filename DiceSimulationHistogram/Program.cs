using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiceSimulationHistogram
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //makes the cursor invisible for more clarity
            Console.CursorVisible = false;

            //variable declaration
            Random rand = new Random();
            int[] values;
            int diceDimension = 20;

            //repeating the program forever
            while (true)
            {
                //variable initialization
                values = new int[diceDimension];

                //throwing dice 300 times
                for (int i = 0; i < 1000; i++)
                {
                    values[rand.Next(0, diceDimension)]++;
                }

                //displaying array values
                //for (int i = 0; i < values.Length; i++)
                //{
                //    Console.Write(values[i] + " ");
                //}

                Console.WriteLine();    //spacing a bit
                Console.WriteLine();    //spacing a bit
                Console.WriteLine();    //spacing a bit


                //start creation of histogram

                //creation of variables
                char[,] histogram = new char[diceDimension, /*values.Max()*/250];

                //histogram filling algorithm
                for (int i = 0; i < histogram.GetLength(0); i++)
                {
                    for (int j = 0; j < histogram.GetLength(1); j++)
                    {
                        histogram[i, j] = values[i] > 0 ? '*' : ' ';
                        values[i] = values[i] == 0 ? values[i] : values[i]-1;
                    }
                }

                //matrix printing
                for (int i = histogram.GetLength(1)-1; i > -1; i--)
                {
                    //spacing a bit
                    Console.Write(new string(' ', 150));

                    for (int j = histogram.GetLength(0) - 1; j > -1; j--)
                    {
                        Console.Write(histogram[j, i] + "  ");
                    }

                    //spacing a bit
                    Console.WriteLine();
                }

                //waiting for the user to be satisfied, reset console
                //Console.ReadKey(true);
                Thread.Sleep(100);
                Console.Clear();
            }
        }
    }
}
