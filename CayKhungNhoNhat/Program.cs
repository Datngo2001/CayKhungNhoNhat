using System;
using System.Collections.Generic;

namespace CayKhungNhoNhat
{
    class Program
    {
        static void Main(string[] args)
        {
            const int max = 6;
            int[,] G = new int[,]
            {
                {0, 12, 0, 0, 0, 3 },
                {12, 0, 24, 0, 0, 4 },
                {0, 24, 0, 5, 7, 0 },
                {0, 0, 5, 0, 1, 0 },
                {0, 0, 7, 1, 0, 20 },
                {3, 4, 0, 0, 20, 0 }
            };
            List<int[]> E = new List<int[]>();
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if(G[i,j] != 0)
                    {
                        int[] a = new int[3];
                        a[0] = i;
                        a[1] = j;
                        a[2] = G[i, j];
                        E.Add(a);
                    }
                }
            }

            List<int[]> T = new List<int[]>();
            int[] MakeSet = new int[max];
            for (int i = 0; i < max; i++)
            {
                MakeSet[i] = i;
            }
            //xep cac canh tang dan theo trong so
            for (int i = 0; i < E.Count; i++)
            {
                for (int j = 0; j < E.Count - 1; j++)
                {
                    int[] c;
                    if (E[j][2] > E[j + 1][2])
                    {
                        c = E[j];
                        E[j] = E[j + 1];
                        E[j + 1] = c;
                    }
                }
            }
            for (int i = 0; i < E.Count && T.Count < max - 1; i++)
            {
                int u = E[i][0];
                int v = E[i][1];
                if (MakeSet[u] != MakeSet[v])
                {
                    T.Add(E[i]); //chon canh (u,v)
                    //union
                    for (int j = 0; j < max; j++)
                    {
                        if(MakeSet[j] == MakeSet[v])
                        {
                            MakeSet[j] = MakeSet[u];
                        }
                    }
                }
            }
            for (int i = 0; i < T.Count; i++)
            {
                Console.WriteLine(T[i][0] + ", " + T[i][1] + ", " + T[i][2]);
            }
        }
    }
}
