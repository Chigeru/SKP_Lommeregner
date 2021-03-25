using System;

namespace Lommeregner
{
    class Program
    {
        static void Main(string[] args)
        {
            bool regn = true;
            string forklaring = "";
            int tal1;
            string calType;
            int tal2;

            while (regn)
            {
                Console.WriteLine("Indtast det første tal");
                tal1 = NumberChecker(Console.ReadLine());

                Console.WriteLine("\nIndtast regne metoden (f.eks. + eller -)");
                calType = CalculationType(Console.ReadLine());

                Console.WriteLine("\nIndtast det næste tal som der skal beregnes med");
                tal2 = NumberChecker(Console.ReadLine());

                double svar = CalculationSum(tal1, tal2, calType, out forklaring);
                Console.WriteLine($"\n{forklaring} = {svar}");



                Console.WriteLine("\nLav en ny udregning? y/n");
                regn = Console.ReadLine() == "y";
                Console.Clear();
            }


        }
        public static int NumberChecker(string inputNumber)
        {
            int number = 0;
            try
            {
                 number = Int32.Parse(inputNumber);
            } catch
            {
                Console.WriteLine($"\"{inputNumber}\" er ikke et tal, indtast venligst et tal");
                number = NumberChecker(Console.ReadLine());
            }
            
            return number;
        }

        public static string CalculationType(string calType)
        {
            switch (calType)
            {
                case "+":
                case "plus":
                    return "+";
                case "-":
                case "minus":
                    return "-";
                case "*":
                case "gange":
                    return "*";
                case "/":
                case "divider":
                    return "/";
                case "kvadratrod":
                    return "sqrt";
                case "potens":
                    return "pow";
                default:
                    Console.WriteLine("Kunne ikke genkende den indtastede regnetype, prøv igen");
                    return CalculationType(Console.ReadLine());
            }
        }

        static double CalculationSum(int a, int b, string calc, out string tempForklaring)
        {
            switch(calc)
            {
                case ("+"):
                    tempForklaring = $"{a} + {b}";
                    return a + b;
                case ("-"):
                    tempForklaring = $"{a} - {b}";
                    return a - b;
                case ("*"):
                    tempForklaring = $"{a} * {b}";
                    return a * b;
                case ("/"):
                    tempForklaring = $"{a} / {b}";
                    return a / b;
                case ("sqrt"):
                    tempForklaring = $"";
                    return Math.Sqrt(a);
                default:
                    tempForklaring = "der er ingen forklaring på hvad du prøver på";
                    return 0;
            }
        }
        static int anotherNumber()
        {
            Console.WriteLine("\nIndtast det næste tal som der skal beregnes med");
            return NumberChecker(Console.ReadLine());

        }


    }
}