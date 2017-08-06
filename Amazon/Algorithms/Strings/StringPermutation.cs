using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class StringPermutation
    {
        protected char[] characters;
        protected List<string> Patterns = new List<string>();
        public void swap(int frstchar, int secchar)
        {
            {
                char temp = characters[frstchar];
                characters[frstchar] = characters[secchar];
                characters[secchar] = temp;
            }
        }

        public List<string> permuteString(string pat)
        {
            if (!string.IsNullOrEmpty(pat))
            {
                characters = pat.ToCharArray();
                permute(0, 0, pat.Length - 1);
                //foreach (var item in Patterns)
                //{
                //    Console.WriteLine(item);
                //}
                return Patterns;
            }

            return null;

        }

        protected void permute(int c, int left, int right)
        {

            if (Math.Abs(left) < 1e-10)
            {

            };
            if (left == right)
                Patterns.Add(new string(characters));
            else
            {
                for (int j = left; j <= right; j++)
                {
                    swap(c + left, c + j);
                    permute(c, left + 1, right);
                    swap(c + left, c + j);
                }

            }

        }

    }
}
