using System;

namespace Lommeregner
{
    class Program
    {
        static void Main(string[] args)
        {
            bool regn = true;
            string forklaring = "";
            double tal1;
            string calType;
            double tal2;

            while (regn)
            {
                Console.WriteLine("Indtast det første tal");
                tal1 = NumberChecker(Console.ReadLine());

                Console.WriteLine("\nIndtast regne metoden (f.eks. + eller -)");
                calType = CalculationType(Console.ReadLine());

                Console.WriteLine("\nIndtast det næste tal som der skal beregnes med");
                tal2 = NumberChecker(Console.ReadLine());

                double svar = CalculationSum(tal1, calType, out forklaring, tal2);
                Console.WriteLine($"\n{forklaring} = {svar}");
                Console.WriteLine("Ønsker du resultatet i procent? y/n");
                bool procent = Console.ReadLine() == "y";
                if(procent)
                {
                    Console.WriteLine($"\n{svar * 100}%");
                }

                Console.WriteLine("\nLav en ny udregning? y/n");
                regn = Console.ReadLine() == "y";
                Console.Clear();
            }


        }


        static double NumberChecker(string inputNumber)
        {
            double number = 0;
            try
            {
                 number = Double.Parse(inputNumber);
            } catch
            {
                Console.WriteLine($"\"{inputNumber}\" er ikke et tal, indtast venligst et tal");
                number = NumberChecker(Console.ReadLine());
            }
            
            return number;
        }

        static string CalculationType(string calType)
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

        static double CalculationSum(double a, string calc, out string tempForklaring, double b = 0)
        {
            switch(calc)
            {
                case ("+"):
                    
                    tempForklaring = $"{a} + {b}";
                    return Math.Round(a + b, 3);
                case ("-"):
                    tempForklaring = $"{a} - {b}";
                    return Math.Round(a - b, 3);
                case ("*"):
                    tempForklaring = $"{a} * {b}";
                    return Math.Round(a * b, 3);
                case ("/"):
                    tempForklaring = $"{a} / {b}";
                    return Math.Round(a / b, 3);
                case ("sqrt"):
                    tempForklaring = $"Kvadratroden af {a}";
                    return Math.Sqrt(a);
                default:
                    tempForklaring = "der er ingen forklaring på hvad du prøver på";
                    return 0;
            }
        }
        //static int anotherNumber()
        //{
        //    Console.WriteLine("\nIndtast det næste tal som der skal beregnes med");
        //    return NumberChecker(Console.ReadLine());

        //}


    }
}