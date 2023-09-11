using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string operand = "";
            string firstVal = "";
            string secondVal = "";
            float output = 0;
            while (true)
            {
                Console.WriteLine("~~~~Console Calculator~~~~");
                Console.Write("What are you looking to do?\n1.Addition\n2.Subtraction\n3.Multiplication\n4.Division\nQ.Quit\n");
                bool valid = false;
                while (!valid)
                {
                    Console.Write("Please enter the value associated with your desired operand:");
                    operand = Console.ReadLine();
                    if (operand == "1" || operand == "2" || operand == "3" || operand == "4")
                    {
                        valid = true;
                    }
                    else if(operand == "Q" || operand == "q")
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid operand");
                    }
                }
                valid = false;
                while (!valid)
                {
                    Console.Write("\nPlease enter your first value:");
                    firstVal = Console.ReadLine();
                    float temp = 0;
                    valid = float.TryParse(firstVal, out temp);
                    if (!valid)
                    {
                        Console.WriteLine("That is not a valid input");
                    }
                }
                valid = false;
                while (!valid)
                {
                    Console.Write("\nPlease enter your second value:");
                    secondVal = Console.ReadLine();
                    float temp = 0;
                    valid = float.TryParse(secondVal, out temp);
                    if (!valid)
                    {
                        Console.WriteLine("That is not a valid input");
                    }
                    if(operand == "4" && secondVal == "0")
                    {
                        valid = false;
                        Console.WriteLine("Cannot divide by 0");
                    }
                }
                Console.Write(firstVal + " ");
                if (operand == "1")
                {
                    output = float.Parse(firstVal) + float.Parse(secondVal);
                    Console.Write("+");
                }
                else if (operand == "2")
                {
                    output = float.Parse(firstVal) - float.Parse(secondVal);
                    Console.Write("-");
                }
                else if (operand == "3")
                {
                    output = float.Parse(firstVal) * float.Parse(secondVal);
                    Console.Write("*");
                }
                else
                {
                    output = float.Parse(firstVal) / float.Parse(secondVal);
                    Console.Write("/");
                }
                Console.Write(" " + secondVal + " = " + output + "\n");
            }
        }
    }
}