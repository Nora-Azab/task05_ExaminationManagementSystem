using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationManagementSystem
{
    public static class Helper
    {
        //TODO : make it generic عشان الدرجات برضو ممكن تكون ارقام كسرية
        public static int ValidateInputNumber(string  message)//in general , then i will check(1:3 => level) and (positive for mark) in Question...etc :)
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
    }
}
