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

            while (regn)
            {
                Console.WriteLine("Indtast det første tal");
                tal1 = NumberChecker(Console.ReadLine());

                Console.WriteLine("\nIndtast regne metoden (f.eks. + eller -). for mere hjælp indtast \"?\"");

                double svar = CalculationSum(tal1, Console.ReadLine(), out forklaring);

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

        //Sørger for at brugeren har indtastet et tal eller Pi
        static double NumberChecker(string inputNumber)
        {
            double number = 0;
            try
            {
                if(inputNumber.ToLower() == "pi")
                    number = Math.PI;
                else
                    number = Double.Parse(inputNumber);
                 
            } catch
            {
                Console.WriteLine($"\"{inputNumber}\" er ikke et tal, indtast venligst et tal");
                number = NumberChecker(Console.ReadLine());
            }
            
            return number;
        }

        //Identificerer den valgte regnemetode, udregninger regnemetoderne & kalder anotherNumber hvis det er nødvendigt
        static double CalculationSum(double a, string calc, out string tempForklaring)
        {
            switch(calc.ToLower())
            {
                case "+":
                case "plus":
                    double plus = anotherNumber();
                    tempForklaring = $"{a} + {plus}";
                    return Math.Round(a + plus, 6);
                case "-":
                case "minus":
                    double minus = anotherNumber();
                    tempForklaring = $"{a} - {minus}";
                    return Math.Round(a - minus, 6);
                case "*":
                case "gange":
                    double gange = anotherNumber();
                    tempForklaring = $"{a} * {gange}";
                    return Math.Round(a * gange, 6);
                case "/":
                case "divider":
                    double divider = anotherNumber();
                    while(divider == 0)
                    {
                        Console.WriteLine("Der kan desværre ikke divideres med 0, prøv et andet tal");
                        divider = NumberChecker(Console.ReadLine());
                    }
                    tempForklaring = $"{a} / {divider}";
                    return Math.Round(a / divider, 6);
                case "sqrt":
                case "kvadratrod":
                    tempForklaring = $"Kvadratroden af {a}";
                    return Math.Round(Math.Sqrt(a), 6);
                case "pow":
                case "^":
                case "potens":
                    double pow = anotherNumber();
                    tempForklaring = $"potensen af {a} opløftet i {pow}";
                    return Math.Round(Math.Pow(a, pow), 6);
                case "?":
                    Console.WriteLine("\t+ (Plus)\tLægger to tal sammen");
                    Console.WriteLine("\t- (Minus)\tFratrækker det andet tal fra det første");
                    Console.WriteLine("\t* (Gange)\tMultiplicerer to tal");
                    Console.WriteLine("\t/ (Divider)\tDividerer to tal ");
                    Console.WriteLine("\tkvadratrod \tTager kvardratroden af et enkelt tal ");
                    Console.WriteLine("\t^ (Potens) \tMultiplicerer det første tal antallet af gange det andet tal henviser til");
                    return CalculationSum(a, Console.ReadLine(), out tempForklaring);
                default:
                    Console.WriteLine("Kunne ikke genkende den indtastede regnetype, prøv igen");
                    return CalculationSum(a, Console.ReadLine(), out tempForklaring);
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