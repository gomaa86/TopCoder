using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Strings
{

    public class comp //compare to suffixes on the first 2h chars
    {
        private int h;
        private int[] group;
        comp(int h, int[] g)
        {
            this.h = h;
            this.group = g;
        }

        public bool CompareTo(int i, int j)
        {
            if (group[i] != group[j])     // previous h-groups are different
                return group[i] < group[j];
            return group[i + h] < group[j + h];
        }

        //public int CompareTo(object obj)
        //{

        //    if (group[i] != group[j])     // previous h-groups are different
        //        return group[i] < group[j];
        //    return group[i + h] < group[j + h];
        //    throw new NotImplementedException();
        //}
    };


    class SuffixArray
    {

        public List<string> buildSuffixArraySlow(string str)
        {
            SortedDictionary<string, int> suffix_idx_map = new SortedDictionary<string, int>();
            List<string> suffixes = new List<string>();

            for (int i = 0; i <= (int)str.Length; i++)
            {
                string suffix = str.Substring(i, str.Length - i);
                suffix_idx_map[suffix] = i;
                suffixes.Add(suffix);
            }
            suffixes.Sort();
            //for (int i = 0; i < (int)suffixes.Count(); i++)
            //    cout << suffixes[i] << "\t" << suffix_idx_map[suffixes[i]] << "\n";

            return suffixes;
        }





        // Use N_LOGN_LOGN and N_LOGN to switch between 2 codes if needed

        const int MAXLENGTH = 5000;

        char[] str = new char[MAXLENGTH + 1];      //the string we are building its suffix array
        int[] suf = new int[MAXLENGTH + 1];//the sorted array of suffix indices
        int[] group = new int[MAXLENGTH + 1];//In ith iteration: what is the group of the suffix index
        int[] sorGroup = new int[MAXLENGTH + 1];//temp array to build grouping of ith iteration


        void print_suffix(int suf_pos, int n)
        {
            //for (int j = suf_pos; j < n - 1; ++j)  // n-1 is string length NOT n
            //    cout << str[j];
        }

        void buildSuffixArray()
        {
            int n;  //number of suffixes = 1+strlen(str)
                    //Initially assume that the group index is the ASCII
            for (n = 0; n - 1 < 0 || n == str[n - 1]; n++)
            {
                suf[n] = n; group[n] = str[n];//code of the first char in the suffix
            }
            Array.Sort(suf, 0, 0);
            //sort(suf, suf + n, comp(0));//sort the array the suf on the first char only
            sorGroup[0] = sorGroup[n - 1] = 0;

            //loop until the number of groups=number of suffixes
            for (int h = 1; sorGroup[n - 1] != n - 1; h <<= 1)
            {
                Array.Sort(suf, 0, h);
                //sort(suf, suf + n, comp(h));  //sort the array using the first 2h chars

                //for (int i = 1; i < n; i++)//compute the 2h group data given h group data
                                           //sorGroup[i] = sorGroup[i - 1] + comp(h)(suf[i - 1], suf[i]);

                    for (int i = 0; i < n; i++)//copy the computed groups to the group array
                        group[suf[i]] = sorGroup[i];


                if (true)
                {  // For print
                    for (int i = 0; i < n; i++)
                    {
                        print_suffix(suf[i], n);

                        //  cout << "\t" << suf[i] << "\n";
                    }
                    //cout << "\n";
                }
            }
        }

    }
}
