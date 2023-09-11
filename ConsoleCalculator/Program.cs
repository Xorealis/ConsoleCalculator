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
                    if(val2 == 0)
                    {
                        Console.WriteLine("Cannot divide by 0");
                        break;
                    }
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
            double output = double.NaN;
            int temp = 0;
            int charCount = 0;
            while (true)
            {
                Console.WriteLine("~~~~Console Calculator~~~~");
                Console.Write("Please enter an equation in the format # operand #, or Q to quit: ");
                input = Console.ReadLine();
                charCount = 0;
                firstVal = "";
                secondVal = "";
                operand = "";
                output = double.NaN;

                if(input == "q" || input == "Q")
                {
                    return;
                }
                while (charCount < input.Length)
                {
                    if (input[charCount] == ' ')
                    {
                        charCount++;
                        break;
                    }
                    else if (!(int.TryParse(input[charCount].ToString(), out temp)))
                    {
                        if (!(input[charCount] == '.'))
                        {
                            break;
                        }
                    }
                    firstVal += input[charCount];
                    charCount++;
                }

                operand += input[charCount];
                if (input[charCount + 1] == ' ')
                {
                    charCount++;
                }

                while (charCount < input.Length)
                {
                    secondVal += input[charCount];
                    charCount++;
                }
                try
                {
                    output = Calculator.compute(double.Parse(firstVal), double.Parse(secondVal), operand);
                }
                catch (Exception e)
                {
                    Console.WriteLine("An invalid value was entered");
                }
                Console.WriteLine("Answer: "+ output.ToString());
            }
           
        }
    }
}