#define rep(i, v)		for(int i=0;i<sz(v);++i);
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Algorithms.Search
{
    class TernarySearch
    {
        private const double EPS = (1e-7);
        List<int> v;
        double f(double x)
        {   // we could implement it faster
            double dist = 0;

            for (int i = 0; i < v.Count; ++i)
                dist += Math.Abs(x - v[i]);

            return dist;
        }



        Tuple<double, double> ternaryReal()
        {
            double left = v[0], right = v.Last(); // set your range
            while (right - left > EPS)
            { // stop when reaching almost right = left
                double g = left + (right - left) / 3, h = left + 2 * (right - left) / 3;

                if (f(g) < f(h)) // use > if f increase then decrease
                    right = h;
                else
                    left = g;
            }

            return Tuple.Create(left, f(left));
        }


    }
}
