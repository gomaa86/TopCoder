﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Search
{
    public class BinarySearch
    {
        public int[] Values;
        public double[] dValues;
        private const double EPS = (1e-7);



        public int BSfindFirst(int start, int end, int val)
        {
            while (start < end)
            {
                int mid = start + (end - start) / 2;
                if (Values[mid] < val) start = mid + 1;
                else if (Values[mid] > val) end = mid - 1;
                else end = mid;
            }
            return start;
        }

        int BSfindLast(int start, int end, int val)
        {
            while (start < end)
            {
                int mid = start + (end - start) / 2;
                if (Values[mid] < val) start = mid + 1;
                else if (Values[mid] > val) end = mid - 1;
                else start = mid;
            }
            return start;
        }



        double BS_double(double start, double end, double val)
        {
            while (Math.Abs(end - start) > EPS)
            { // iterate 100-500 iteration
                double mid = start + (end - start) / 2;
                if (dValues[(int)mid] < val) start = mid;
                else end = mid;
            }
            return start;
        }

    }
}
