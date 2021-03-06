﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ME
{
    public class Tie
    {
        public const int MAX_Char = 26;

        protected Tie[] child = null;
        protected bool isLeaf;

        public Tie()
        {
            isLeaf = false;
            child = new Tie[MAX_Char];
        }

        public void insert(string statement)
        {

            if (string.IsNullOrEmpty(statement))
            {
                isLeaf = true;
            }
            else
            {
                int cur = statement[0] - 'a';
                if (child[cur] == null)
                {
                    child[cur] = new Tie();
                    child[cur].insert(statement.Substring(1));
                }
            }

        }


        public bool checkWord(string word)
        {
            if (string.IsNullOrEmpty(word))
                return isLeaf;

            int cur = word[0] - 'a';
            if (child[cur] == null)
                return false;
            return child[cur].checkWord(word.Substring(1));
        }


        public bool checkSuffix(string word)
        {
            if (string.IsNullOrEmpty(word))
                return true;

            int cur = word[0] - 'a';
            if (child[cur] == null)
                return false;
            return child[cur].checkWord(word.Substring(1));
        }
    }
}