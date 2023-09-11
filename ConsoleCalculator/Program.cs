using System;

namespace HelloWorld
{
    class Calculator
    {
        public static double compute(double val1, double val2, string operand)
        {
            double result = double.NaN;
            Console.WriteLine("Calculating...");
            switch(operand)
            {
                case "+":
                    result = val1 + val2;
                    break;
                case "-":
                    result = val1 - val2;
                    break;
                case "/":
                    result = val1 / val2;
                    break;
                case "*":
                    result = val1 * val2;
                    break;
                default:
                    Console.WriteLine("An invalid Operand was entered");
                    break;
                    
            }    
            
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string operand = "";
            string firstVal = "";
            string secondVal = "";
            string input = "";
            double output = 0;
            double temp = 0;
            int charCount = 0;
            while (true)
            {
                Console.WriteLine("~~~~Console Calculator~~~~");
                Console.Write("Please enter an equation in the format # operand #: ");
                input = Console.ReadLine();
                charCount = 0;
                firstVal = "";
                secondVal = "";
                operand = "";

                    while(charCount < input.Length)
                    {
                    if (input[charCount] == ' ')
                    {
                        charCount++;
                        break;
                    }
                        firstVal += input[charCount];
                        charCount++;
                    }
                Console.WriteLine(firstVal);

                operand += input[charCount];
                charCount++;

                while (charCount < input.Length)
                {
                    secondVal += input[charCount];
                    charCount++;
                }

                output = Calculator.compute(double.Parse(firstVal), double.Parse(secondVal), operand);
                Console.WriteLine(firstVal + " " + operand + " " + secondVal + " = " + output.ToString());
            }
           
        }
    }
}