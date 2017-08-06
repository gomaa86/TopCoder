using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class DFS
    {
        protected int n, e;
        protected List<List<int>> adj;
        protected List<bool> visited;


        protected List<int> topsort;
        protected List<int> start, finish;
        protected bool anyCycle = true;
        protected int timer = 0;

        public void Search(int node)
        {
            visited[node] = true;

            for (int i = 0; i < adj.Count; i++)
            {
                int child = adj[node][i];
                if (!visited[child])    // To avoid cyclic behavior
                    Search(child);
            }
            topsort.Add(node);    // DAG // Other way Indegree / Outdegree
        }


        void dfs_EdgeClassification(int node)
        {
            start[node] = timer++;

            for (int i = 0; i < adj.Count; i++)
            {
                int child = adj[node][i];
                if (start[child] == -1) // Not visited Before. Treed Edge
                    dfs_EdgeClassification(child);
                else
                {
                    if (finish[child] == -1)// then this is ancestor that called us and waiting us to finish. Then Cycle. Back Edge
                        anyCycle = true;
                    else if (start[node] < start[child])    // then you are my descendant
                        ;   // Forward Edge
                    else
                        ;   // Cross Edge
                }
            }

            finish[node] = timer++;
        }




        int ConnectedComponenetsCnt()
        {
            int cnt = 0;
            for (int i = 0; i < visited.Count; i++)
            {
                if (!visited[i])    // Then no one reach this isolated node yet and its neighbors.
                {
                    Search(i);
                    cnt++;
                }
            }
            return cnt;
        }


        protected List<List<int>> adjLst;
        // There are some nodes that must be part of the diameter
        // Diameter either pass with me (sum of 2 highest sub-trees) or don't, then diameter pass with a children
        // return pair(diameter, height)
        public Tuple<int, int> diameter(int i, int parent = -1)
        {
            int diam = 0;
            int[] mxHeights = { -1, -1, -1 };    // keep 2 highest trees

            for (int j = 0; j < adj[i].Count; j++)
                if (adjLst[i][j] != parent)
                {
                    Tuple<int, int> p = diameter(adjLst[i][j], i);
                    diam = Math.Max(diam, p.Item1);

                    // Keep only the 2 maximum children
                    mxHeights[0] = p.Item2 + 1;//if the tree weighted add weight instead of 1 
                    Array.Sort(mxHeights);
                }

            for (int j = 0; j < mxHeights.Count(); j++)
                if (mxHeights[i] == -1)
                    mxHeights[i] = 0;

            diam = Math.Max(diam, mxHeights[1] + mxHeights[2]);

            return Tuple.Create(diam, mxHeights[2]);
        }

        //using it to compare between two trees 
        public string treeCanoincalForm(int i, int par)
        {
            List<string> childern = new List<string>();

            for (int J = 0; J < adjLst[i].Count; J++)
                if (adjLst[i][J] != par)
                    childern.Add(treeCanoincalForm(adjLst[i][J], i));

            string nodeRep = "(";
            childern.Sort();

            for (int K = 0; K < childern.Count(); K++)
                nodeRep += childern[K];
            nodeRep += ")";
            return nodeRep;
        }


        public string getNodeCanoincalForm(int v, List<List<string>> subCan)    // we could use hashing for a better performance
        {
            string nodeRep = "(";
            subCan[v].Sort();
            for (int i = 0; i < subCan[v].Count; i++)
            {
                nodeRep += subCan[v][i];
            }
            nodeRep += ")";

            return nodeRep;
        }


    }
}
