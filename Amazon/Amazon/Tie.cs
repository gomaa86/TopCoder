using System;
using System.Collections.Generic;

namespace Amazon
{
    public class Tie
    {
        public const int MAX_Char = 26;

        protected Tie[] child = null;
        protected bool isLeaf;

        Tie()
        {
            isLeaf = false;
            child = new Tie[MAX_Char];
        }

        public void insert(char[] statement)
        {
            if (statement == null || statement[statement.Length - 1] == '\0')
            {
                isLeaf = true;
            }
            else
            {
                int cur = statement[0] - 'a';
                if (child[cur] == null)
                {
                    child[cur] = new Tie();
                    child[cur].insert(statement.ToString().Substring(1).ToCharArray());
                }
            }

        }


        public bool checkWord(char[] word)
        {
            return false;



        }


        public bool checkSuffix()
        {
            return false;
        }
    }
}
