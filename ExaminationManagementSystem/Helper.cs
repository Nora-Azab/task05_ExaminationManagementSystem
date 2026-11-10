using ExaminationManagementSystem.Enums;
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
        public static string ValidateStringInput(string message)
        {
            string? input;
            do
            {
                Console.Write(message);
                input = Console.ReadLine().Trim();
                if (!string.IsNullOrWhiteSpace(input))
                    break;
                Console.WriteLine("invalid choice, try again:)");
            } while (true);
            return input;
        }
        //-------------------------
        public static int ValidateNumberInRange(string message , int min , int max)
        {
            int num;
            do
            {
                num = ValidateInputNumber(message);
                if (num >= min && num <=max)
                    break;
                Console.WriteLine("invalid answer, try again :)");
            } while (true);
            return num;
        }
        //-------------------------
        public static List<int> ValidateAndGetMultiChoices(string? input)
        {
            int num;
            bool converted;
            List<int> result = [];
            //------------
            string[] inputs = input.Split(",");

            if (inputs.Length == 0 || inputs.Length > 4)//1:4 choices only allowed
                return result;//which is empty
            foreach (var item in inputs)
            {
                converted = int.TryParse(item, out num) && num > 0 && num <= 4;// 0 => not allowed (1.true..1.choice one ....etc) i will start numbering the choices from 1 :)
                if (converted)
                    result.Add(num);
                else
                    return [];//one of choices is not allowed

            }
            return result;
        }
        //-------------------------
        public static T ValidateAndGetEnum<T>(string message) where T : struct,Enum
        {
            T myEnum;
            do
            {
                Console.Write(message);
                //if (Enum.TryParse(Console.ReadLine(), out Level l))//"this.Level" instead of "l"   wrong -> it's not "out"
                /// 1 | easy       -> l = easy
                /// 2 | medium     -> l = medium
                /// 3 | hard       -> l = hard
                /// 4              -> l = 4       => which is wrong :(
                /// Easy           -> invalid     => case sensitive
                ///

                //if (Enum.TryParse(Console.ReadLine(),ignoreCase: true, out Level l))
                /// EaSy -> l=easy
                /// easy -> l=easy
                /// 

                //عايزة احل مشكلة انه بيقبل ارقام مش متمثلة في الاينم اصلا
                if (Enum.TryParse(Console.ReadLine(), ignoreCase: true, out myEnum) && Enum.IsDefined(myEnum))//وطبعا لازم الترتيب ده عشان القيمة ال طلعت في الأوت الاول 
                                                                                                              //added "IsDefined" -> to avoid numbers outside the enum which is accepted for Enum.TryParse :)
                {
                    //Console.WriteLine($"level = {l}");
                    return myEnum;
                }
                Console.WriteLine($"invalid {typeof(T).Name} :(");

            } while (true);
        }
        //-------------------------
    }
}
