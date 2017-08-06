using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{

    /*
   What is Factorial? Some Facts
   How to implement it for big numbers?
   Number of factorial digits? bits?
   Given n and Prime p, what is max x such that n! % p^x = 0
   Factorial Factorization
   Given m & n, what is max x such that m^x % n! = 0
   How to calculate gcd(!m, n)
   How many trailing zeros in n!?
   What is right most non zero digit of factorial N?

   Exercises: UVA (160, 324, 10139, 568, 623, 884, 10323)

   Links:
   http://en.wikipedia.org/wiki/Factorial
   http://blmath.wordpress.com/2009/04/27/prime-factorization-of-factorials/
   */

    class Divisors
    {
        public static List<int> factorization(int n)
        {
            List<int> divisors = new List<int>();

            for (int i = 1; i * i < n; i++)
            {
                while (n % i == 0)
                {
                    divisors.Add(i);
                    n /= i;
                }
            }

            if (n > 1) divisors.Add(n);

            return divisors;
        }




        public static List<long> generate_divisors(long n)//     O(sqrt(n) )
        {
            List<long> v = new List<long>();
            long i;
            for (i = 1; i * i < n; ++i)
                if (n % i == 0)
                    v.Add(i); v.Add(n * i);

            if (i * i == n)
                v.Add(i);

            return v; //Not sorted
        }




        //Let D(i) is number of divisors of i.Return sum D(i) in range n
        public static int rangeFactorization1(int n)           //Forward thinking
        {
            int s = 0;
            for (int i = 1; i <= n; i++)
                s += generate_divisors(i).Count();

            return s;
        }


        public static int rangeFactorization2(int n)      // backward thinking
        {
            //suitable for range 210^6
            List<int> numFactors = new List<int>(n + 1);

            for (int i = 1; i <= n; i++) //For each divisor
                for (int k = i; k <= n; k += i) //For each divisble number
                    numFactors[k]++; //i divides k

            int s = 0;
            for (int i = 1; i <= n; i++)
                s += numFactors[i]; //sure you can do it without an array

            return s;
        }



        // Very important function
        public int FactN_PrimePowr(int n, int p)
        {
            int pow = 0;
            for (int i = p; i <= n; i *= p)
            {
                pow += n / i;
            }

            return pow;
        }



    }
}
