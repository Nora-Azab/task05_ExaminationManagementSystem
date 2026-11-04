using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationManagementSystem
{
    public static class Helper
    {
        public static int ValidateInputNumber(string  message)//in general , then i will check(1:3 => level)  in Question :)
        {
            int num;
            do
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out num))
                    break;
                Console.WriteLine("invalid input, try again :)");
            } while (true);
            return num;
        }
        //-------------------------
        public static double ValidateDoubleNumber(string message)//in general, i will check (positive for mark) in Question :)
        {
            double num;
            do
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out num))
                    break;
                Console.WriteLine("invalid input, try again :)");
            } while (true);
            return num;
        }
        //-------------------------

    }
}
