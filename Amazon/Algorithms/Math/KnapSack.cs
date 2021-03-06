﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class KnapSack
    {
        public static int CalculateKnapSack(int w, int[] wt, int[] val, int n)
        {
            if (n == 0 || w == 0)
                return 0;

            if (wt[n - 1] > w)
                return CalculateKnapSack(w, wt, val, n - 1);
            else
                return Math.Max(val[n - 1] + CalculateKnapSack(w - wt[n - 1], wt, val, n - 1), CalculateKnapSack(w, wt, val, n - 1));
        }
    }
}
