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

                Console.WriteLine("\nIndtast regne metoden (f.eks. + eller -). for mere hjælp indtast \"?\"");
                calType = CalculationType(Console.ReadLine());

                

                double svar = CalculationSum(tal1, calType, out forklaring);
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

        /* ------------ METODER ---------- */

        //Sørger for at brugeren har indtastet et tal
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

        //Identificerer regne metoden
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
                case "?":
                    Console.WriteLine("Mulige regne muligheder: \n + - * / kvardratrod potens");
                    return CalculationType(Console.ReadLine());
                default:
                    Console.WriteLine("Kunne ikke genkende den indtastede regnetype, prøv igen");
                    return CalculationType(Console.ReadLine());
            }
        }

        //Udregninger på regnemetoderne & kalder anotherNumber hvis det er nødvendigt
        static double CalculationSum(double a, string calc, out string tempForklaring)
        {
            switch(calc)
            {
                case ("+"):
                    double plus = anotherNumber();
                    tempForklaring = $"{a} + {plus}";
                    return Math.Round(a + plus, 3);
                case ("-"):
                    double minus = anotherNumber();
                    tempForklaring = $"{a} - {minus}";
                    return Math.Round(a - minus, 3);
                case ("*"):
                    double gange = anotherNumber();
                    tempForklaring = $"{a} * {gange}";
                    return Math.Round(a * gange, 3);
                case ("/"):
                    double divider = anotherNumber();
                    tempForklaring = $"{a} / {divider}";
                    return Math.Round(a / divider, 3);
                case ("sqrt"):
                    tempForklaring = $"Kvadratroden af {a}";
                    return Math.Sqrt(a);
                case ("pow"):
                    double pow = anotherNumber();
                    tempForklaring = $"potensen af {a} opløftet i {pow}";
                    return Math.Pow(a, pow);
                default:
                    tempForklaring = "der er ingen forklaring på hvad du prøver på";
                    return 0;
            }
        }

        //Efterspørger et tal mere
        static double anotherNumber()
        {
            Console.WriteLine("\nIndtast endnu et tal som der skal beregnes med");
            return NumberChecker(Console.ReadLine());

        }


    }
}