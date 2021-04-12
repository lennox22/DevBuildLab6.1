using System;

namespace PrimeNumbers
{
    public class PrimeCalc
    {
        public int GetPrime(int sequenceNo)
        {
            int primeNo;

            for (primeNo = 2; sequenceNo > 0; primeNo++)
            {
                int canDivide = 0;
                for (int i = 2; i <= Math.Sqrt(primeNo); i++)  //for efficiency you only need to count to the sqrt of the number. After that you will repeat the division table
                {
                    if (primeNo % i == 0)
                    {
                        canDivide++;
                    }
                }
                if (canDivide == 0)
                {
                    sequenceNo--;
                }
            }
            return primeNo - 1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            int primeSeq;
            PrimeCalc findNum = new PrimeCalc();
            int primeNum;

            do
            {
                Console.Write("Let's locate some primes!\n\nThis application will find you any prime, in order, from the first prime number on.\n\n");
                primeSeq = InputVerify();

                primeNum = findNum.GetPrime(primeSeq);

                PrintIt(primeNum, primeSeq);

                loop = ContinueYN();

            } while (loop);
        }

        public static bool ContinueYN()
        {
            bool inValid = true;
            bool reloop = true;
            string input;

            do
            {
                Console.Write($"Do you want to find another prime number? (y/n): ");
                input = Console.ReadLine().ToLower();

                if (input != "y" && input != "n")
                {
                    InvalidMessage(2);
                }
                else if (input == "y")
                {
                    inValid = false;
                    reloop = true;
                    Console.WriteLine();
                }
                else
                {
                    inValid = false;
                    reloop = false;
                }
            } while (inValid);

            return reloop;
        }
        public static void PrintIt(int primeNum, int primeSeq)  //not exactly the console output. See commented out below. Wanted to get the st, nd, rd, th, correct for practice
        {
            string onesPlace = primeSeq.ToString();   
            Console.Write($"\nThe {primeSeq}");
            if (onesPlace[onesPlace.Length - 1] == '1' && onesPlace[onesPlace.Length-2] != '1')
            {
                Console.Write($"st ");
            }
            else if (onesPlace[onesPlace.Length - 1] == '2' && onesPlace[onesPlace.Length-2] != '1')
            {
                Console.Write($"nd ");
            }
            else if (onesPlace[onesPlace.Length - 1] == '3' && onesPlace[onesPlace.Length-2] != '1')
            {
                Console.Write("rd ");
            }
            else
            {
                Console.Write("th ");
            }
            Console.Write($"prime number is {primeNum}.\n\n");

            //Console.Write($"\nThe number {primeSeq} prime is {primeNum}.");  //this is what is in the consol app. it's boring, and I wanted to challenge myself with the suffixes
        }
        public static int InputVerify()
        {
            int realSeq = 0;
            string input;
            bool inValid = true;

            do
            {
                Console.Write("Which prime numer are you looking for? ");
                input = Console.ReadLine().ToLower();

                try
                {
                    realSeq = Int32.Parse(input);
                    if (realSeq < 1)
                    {
                        InvalidMessage(1);
                    }
                    else
                    {
                        inValid = false;
                    }
                }
                catch
                {
                    InvalidMessage(1);
                }

            } while (inValid);

            return realSeq;
        }
        public static void InvalidMessage(int error)
        {
            switch (error)
            {
                case 1:
                    Console.Write($"\n\nThat isn't a valid answer. Please enter a positive wholenumber (not including 0).\n\n");
                    break;
                case 2:
                    Console.Write($"\n\nThat isn't a valid answer. Please enter either y or n for yes or no.\n\n");
                    break;
            }
        }
    }
}
