using System;
using System.Threading.Tasks;

namespace PrimeConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int start = int.Parse(args[0]);
            int stop = int.Parse(args[1]);

            for (int i = start; i <= stop; i++)
            {
                Console.WriteLine(await IsPrimeNumber(i));
            }            
        }

        static async Task<string> IsPrimeNumber(int primeCandidate)
        {
            /// 1 is a special case, it can't be a prime number
            if (primeCandidate == 1) return "1 is not prime, it is a special case";
            /// 2 is a prime number since it can be divided by only 1 and 2, and 2 being itself.
            if (primeCandidate == 2) return "2 is a prime number";

            return await IsPrimeNumberDivider(primeCandidate);
        }

        /// <summary>
        /// A prime number should only be divisable by 1 and itself.
        /// 
        /// We only have to check until the divisor is half the value of the divider
        /// </summary>
        static Task<string> IsPrimeNumberDivider(int primeCandidate)
        {
            for (int i = 2; i <= primeCandidate / 2; i++)
            {
                if (primeCandidate % i == 0)
                {
                    return Task.FromResult($"{primeCandidate} is not a prime number, it is divisible by {i}");
                }
            }
            return Task.FromResult($"{primeCandidate} is a prime number");
        }
    }
}