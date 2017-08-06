using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class KMP
    {

        public List<int> KMPFind(string st, string pat)
        {
            List<int> matches = new List<int>();
            int n = st.Length;
            int m = pat.Length;
            List<int> longestPrefix = CalculateSuffix(pat);

            for (int i = 0, k = 0; i < n; i++)
            {

                while (k > 0 && pat[k] != st[i])
                {
                    k = longestPrefix[k - 1];
                }


                if (pat[k] == st[i])
                    k++;

                if (k == m)
                {
                    matches.Add(i - m + 1);
                    k = longestPrefix[k - 1];
                }
            }

            return matches; 
        }


        public List<int> ComputePrefix(string pat)
        {
            int m = pat.Length;
            List<int> longestPrefix = new List<int>(m);
            for (int i = 1, k = 0; i < m; i++)
            {
                while (k > 0 && pat[k] != pat[i])
                {
                    k = longestPrefix[k - 1];
                }
                if (pat[k] == pat[i])
                    longestPrefix[i] = ++k;
                else
                    longestPrefix[i] = k;


            }

            return longestPrefix;

        }



        protected List<int> CalculateSuffix(string sentence)
        {
            List<int> sufTable = new List<int>(sentence.Length);

            for (int i = 1, k = 0; i < sentence.Length; i++)
            {
                if (k > 0 && sentence[k] != sentence[i])
                    k = sufTable[k - 1];

                if (sentence[k] == sentence[i])
                {
                    sufTable[i] = k + 1;
                    k++;
                }
                else
                {
                    sufTable[i] = k;
                }
            }

            return sufTable;
        }

        public List<int> findMactching(string pattern)
        {
            List<int> matchPositions = null;

            return matchPositions;
        }


    }
}
