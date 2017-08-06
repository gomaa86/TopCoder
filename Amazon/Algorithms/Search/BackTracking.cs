using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Search
{
    class BackTracking
    {
        char[][] maze;  // filled with S (for start), E (for end), . (could pass) and X (block can't path)
        int pathsCnt = 0;
        void countSEPaths(int r, int c)     // Recursion State: r, c
        {
            if (maze[r][c] == 'E')
            {
                pathsCnt++;
                return;
            }

            // Try the 4 neighbor cells
            int[] dx = { 0, 1, 0, -1 };
            int[] dy = { 1, 0, -1, 0 };

            for (int d = 0; d < 4; d++)
            {
                int nr = r + dx[d];
                int nc = c + dy[d];

                if (valid(nr, nc) && (maze[nr][nc] == '.' || maze[nr][nc] == 'E'))
                {
                    if (maze[nr][nc] != 'E')         // do
                        maze[nr][nc] = 'X';

                    countSEPaths(nr, nc);           // rec

                    if (maze[nr][nc] != 'E')         // undo
                        maze[nr][nc] = '.';
                }
            }
        }

        private bool valid(int nr, int nc)
        {
            throw new NotImplementedException();
        }

        const int MAX = 8;

        int[] ithRowQueen;
        bool[] visited_col;
        bool[] diag_right = new bool[2 * MAX + 1];
        bool[] diag_left = new bool[2 * MAX + 1];

        int sols = 1;

        void Queens8(int r)     // Recursion guarantee no same rows taken
        {
            if (r == 8) //So we reach the end
            {
                // Print
                return;
            }

            for (int c = 0; c < 8; c++)           // j represent the column
            {
                if (!visited_col[c] && !diag_right[c + r] && !diag_left[MAX + c - r])  // Guarantee no repeated cols or diagonals
                {
                    ithRowQueen[r] = c;

                    visited_col[c] = diag_right[c + r] = diag_left[MAX + c - r] = true;  // Do
                    Queens8(r + 1);
                    visited_col[c] = diag_right[c + r] = diag_left[MAX + c - r] = false;  //Undo
                }
            }
        }


    }
}
