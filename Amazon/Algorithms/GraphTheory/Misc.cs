using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.GraphTheory
{
    class Misc
    {


        //  Fibonacci numbers: F(n) = F(n-1) + F(n-2) with F(0) = 0 and F(1) = 1

        int fib(int n)
        {
            if (n <= 1)
                return n;

            return fib(n - 1) + fib(n - 2);
        }

        void iterativeFib()
        {
            int a = 0, b = 1;
            for (int i = 2; i < 10; ++i)
            {
                int c = a + b;
                a = b;
                b = c;
            }
        }

        long[] Fib ={0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987,
    1597, 2584, 4181, 6765,  10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811,
    514229, 832040, 1346269, 2178309, 3524578,  5702887, 9227465, 14930352, 24157817,
    39088169, 63245986, 102334155, 165580141, 267914296, 433494437, 701408733,
    1134903170, 1836311903};


        int gcd(int a, int b)
        {
            if (b == 0)
                return a;
            return gcd(b, a % b);
        }





        // How to calc 5^3? Simple, loop 3 times, multiple 1 times 5        O(power)


        // Divide and Conquer
        // 10^16 = (10^8)^2
        // 10^17 = (10^8)^2 * 10
        int pow(int b, int p)
        {         // O(log(p) base 2)
            if (p == 0) return 1;
            int sq = pow(b, p / 2);
            sq = sq * sq;

            if (p % 2 == 1)
                sq = sq * b;

            return sq;
        }


        // What about calculating: (a^1+a^2+a^3+a^4+a^5+a^n) ???

        // Let's try even power
        // (a^1+a^2+a^3+a^4+a^5+a^6)       = (a^1+a^2+a^3)+(a^1*a^3+a^2*a^3+a^3*a^3)
        // (a^1+a^2+a^3)+a^3*(a^1+a^2+a^3) = (a^1+a^2+a^3)*(1+a^3)
        // (a^1+a^2+a^3)+a^3*(a^1+a^2+a^3) = (a^1+a^2+a^3)*(1+ a^1+a^2+a^3 - (a^1+a^2))
        //

        // what about odd n
        // (a^1+a^2+a^3+a^4+a^5+a^6+a^7)   = a + a*(a^1+a^2+a^3+a^4+a^5+a^6)
        //                                 = a(1+(a^1+a^2+a^3+a^4+a^5+a^6))


        long sumPows(long a, int k)
        { // Return a^1+a^1+a^2+.....a^k    in O(k)
            if (k == 0)
                return 0;

            if (k % 2 == 1)
                return a * (1 + sumPows(a, k - 1));

            long half = sumPows(a, k / 2);
            return half * (1 + half - sumPows(a, k / 2 - 1));
        }

    }
}
