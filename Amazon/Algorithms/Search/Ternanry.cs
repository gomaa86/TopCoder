using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Search
{
    class Ternanry
    {
        private const Double OO = 1e8;
        private const Double EPS = (1e-7);
        public List<int> v;



        public double Distance(double x)
        {   // we could implement it faster
            double dist = 0;
            for (int i = 0; i < v.Count(); i++)
            {
                dist += Math.Abs(x - v[i]);
            }
            return dist;
        }

        Tuple<double, double> ternaryReal()
        {
            double left = v[0], right = v.Last(); // set your range
            while (right - left > EPS)
            { // stop when reaching almost right = left
                double g = left + (right - left) / 3, h = left + 2 * (right - left) / 3;

                if (Distance(g) < Distance(h)) // use > if f increase then decrease
                    right = h;
                else
                    left = g;
            }

            return Tuple.Create(left, Distance(left));
        }




        Tuple<int, int> ternaryDiscrete()
        {
            int left = v[0], right = v.Last(); // set your range
            while (right - left > 3)
            { // We need 4 different positions
                int g = left + (right - left) / 3, h = left + 2 * (right - left) / 3;

                if (Distance(g) < Distance(h)) // use > if f increase then decrease
                    right = h;
                else
                    left = g;
            }

            int solIdx = left, answer = (int)Distance(left++);
            for (int i = left; i <= right; ++i) // iterate on the remaining
                if (answer > Distance(i))
                {
                    answer = (int)Distance(i);
                    solIdx = i;
                }

            return Tuple.Create(solIdx, answer);
        }











    }
}
