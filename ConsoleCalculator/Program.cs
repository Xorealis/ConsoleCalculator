using System;

namespace HelloWorld
{
    class Calculator
    {
        public static double compute(double val1, double val2, string operand)
        {
            double result = double.NaN; //Initializes as Not a Number
            //Will perform the appropriate operation for the provided operand, with checks for divide by 0 and invalid operand
            switch (operand) 
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
                        //Exit loop and print problem if divide by 0
                        Console.WriteLine("Cannot divide by 0");
                        break;
                    }
                    result = val1 / val2;
                    break;
                case "*":
                    result = val1 * val2;
                    break;
                default:
                    //Exit loop and explain invalid operand
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
            string operand = ""; //To store operand
            string firstVal = ""; //To store first user entered number
            string secondVal = ""; //To store second user entered number
            string input = ""; //To store whole user input
            double output = double.NaN; //To store output value
            int temp = 0; //dummy variable for TryParse output
            int charCount = 0; //For keeping track of "Cursor" in input parsing
            while (true)
            {
                startLoop: //for goto statements
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~Console Calculator~~~~~~~~~~~~~~~~~~~~~~~");
                Console.Write("Please enter an equation in the format # operand #, or Q to quit: ");
                input = Console.ReadLine();
                //Reinitialize variables for sequential instances of the loop
                charCount = 0;
                firstVal = "";
                secondVal = "";
                operand = "";
                output = double.NaN;

                //Checks if user wants to quit
                if(input == "q" || input == "Q")
                {
                    return;
                }

                //Iterates through loop until end of number detected by either operand or space
                while (charCount < input.Length)
                {
                    if (input[charCount] == ' ') //If space encountered, end of first value
                    {
                        charCount++;
                        break;
                    }
                    //Tries to convert current place to digit, if it fails, checks if it's a decimal or negative sign
                    else if (!(int.TryParse(input[charCount].ToString(), out temp)))
                    {
                        if (!((input[charCount] == '.') || input[charCount] == '-'))
                        {
                            break;
                        }
                    }
                 
                    firstVal += input[charCount]; //If digit or symbol is determined to be part of first input, concatenate onto firstVal
                    charCount++; //Increment place in input string
                }
                //Try catch block designed to catch if the user didn't enter anything after first value
                try
                {
                    operand += input[charCount];
                }
                //Prints explanation for error and returns to loop start
                catch
                {
                    Console.WriteLine("Insufficient Variables entered");
                    goto startLoop;
                }
                //Increments to next character and checks if it's a space
                charCount++;
                if (input[charCount] == ' ')
                {
                    charCount++; //If user added a space, skip past it
                }

                //Similar loop to the first, but with error checking handled by the final output calculation
                while (charCount < input.Length)
                {
                    secondVal += input[charCount];
                    charCount++;
                }

                //Tries to convert first and second Val to double, if successful, passes to Compute method
                try
                {   
                    output = Calculator.compute(double.Parse(firstVal), double.Parse(secondVal), operand);
                }
                //Outputs error and returns to first loop
                catch
                {
                    Console.WriteLine("An invalid value was entered");
                    goto startLoop;
                }
                //Outputs final computed Value
                Console.WriteLine("Answer: "+ output.ToString());
            }
           
        }
    }
}