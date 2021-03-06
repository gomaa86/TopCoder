﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Primes
    {

        public static List<int> generatePrimes(int N)
        {

            //(p-1)!%p==p-1 ==> prime 
            //235711
            List<int> primes = new List<int>();
            for (int i = 2; i < N; i += 1)
            {
                if (isPrime(i))
                    primes.Add(i);
            }
            return primes;
        }

        public static bool isPrime(int n)
        {
            if (n == 2) return true;
            if (n < 2 || n % 2 == 0) return false;

            for (int i = 3; i * i < n; i += 1)
            {
                if (n % i == 0) return false;
            }

            return true;

        }

        public static bool isPrimeWilson(int n)
        {
            if (fact(n - 1) % n == (n - 1)) return true;
            else return false;
        }

        public static int fact(int n)
        {
            return 0;
        }

        public static List<int> generatePrimesSieve(int N)
        {
            bool[] pimes = new bool[N];

            pimes[2] = true;

            for (int i = 0; i < pimes.Length - 1; i++)
            {
                pimes[i] = true;
            }
            pimes[0] = pimes[1] = false;
            for (int i = 2; i * i < N; i++)
            {
                if (isPrime(i))
                {
                    for (int J = i * 2; J < N - 1; J += i)
                    {
                        pimes[J] = false;
                    }
                }
            }

            List<int> primes = new List<int>();
            for (int i = 0; i < pimes.Length - 1; i++)
            {
                if (pimes[i].Equals(true))
                    primes.Add(i);
            }

            return primes;
        }
        public static List<long> generatePrimesNormal(long N)
        {
            List<long> primes = new List<long>();
            for (int i = 2; i < N; i++)
            {
                if (isPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        }
    }
}
