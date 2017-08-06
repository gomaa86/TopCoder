using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.ME;

namespace main
{
    class Program
    {

        // Function that count set bits
        static int countSetBits(int n)
        {
            int count = 0;
            while (n != 0)
            {
                count += n & 1;
                n >>= 1;
            }
            return count;
        }

        // Function that return count of
        // flipped number
        static int FlippedCount(int a, int b)
        {
            // Return count of set bits in
            // a XOR b
            return countSetBits(a ^ b);
        }
        static void Main(string[] args)
        {

            Dictionary<string, int> sufixIndex = new Dictionary<string, int>();

            //Tie tie = new Tie();

            //string welcome = "helloworld";
            //tie.insert(welcome);
            //Console.WriteLine("word inserted");
            //Console.ReadLine();
            //Console.WriteLine("check word existence");
            //Console.WriteLine(tie.checkWord(welcome));
            //Console.ReadLine();
            //Console.WriteLine("check Sufix existence");
            //Console.WriteLine(tie.checkSuffix(welcome.Substring(1, 2)));
            //Console.ReadLine();


            //LinkedList<int> lin = new LinkedList<int>();
            //Stack<int> vlaues = new Stack<int>();

            //lin.AddFirst(1);
            //lin.AddLast(2);

            //int sum = lin.Sum();
            //foreach (var item in lin)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //Console.WriteLine(sum);
            //Consumer();
            //Algorithms.StringPermutation strper = new Algorithms.StringPermutation();
            //strper.permuteString("abc");
            //List<int> primes = Algorithms.Primes.generatePrimes(100);
            //foreach (var item in primes)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //Console.WriteLine("**************************************");
            //List<long> primesNormal = Algorithms.Primes.generatePrimesNormal(100);
            //foreach (var item in primesNormal)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //SortedSet<int> i = new SortedSet<int>();
            //Console.WriteLine("**************************************");
            //List<int> primesSieve = Algorithms.Primes.generatePrimesSieve(100);
            //foreach (var item in primesSieve)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            // Console.WriteLine(FlippedCount(10, 20));

            Console.WriteLine(5.0 % 2);
            Console.ReadLine();


        }
        public static void Consumer()
        {
            foreach (int i in Integers())
            {
                Console.WriteLine(i.ToString());
            }
        }

        public static IEnumerable<int> Integers()
        {
            yield return 1;
            yield return 2;
            yield return 4;
            yield return 8;
            yield return 16;
            yield return 16777216;
        }
    }


}
