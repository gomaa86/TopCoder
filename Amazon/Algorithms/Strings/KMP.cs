using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class KMP
    {


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
