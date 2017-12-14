using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodilitySolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 3, 1, 2, 4, 3 };

            Console.WriteLine(TapeEquilibrium(A));

            //Console.WriteLine(FrogJmp(10, 85, 30));
            //Console.WriteLine(FindMultiplesInRange(2, 21, 2));

        }

        public static int FindMultiplesInRange(int A, int B, int K)
        {
            return (B / K - A / K) + (A % K == 0 ? 1 : 0);
        }

        public static int FrogJmp(int X, int Y, int D)
        {
            int CounterD = 0;
            if (D != 0)
            {
                CounterD = (int)Math.Ceiling((double)(Y - X) / D);
            }

            return CounterD;
        }



        public static int TapeEquilibrium(int[] A)
        {
            int N = A.Length;
            int[] P = new int[N - 1];

            for (int i = 0; i < P.Length; i++)
            {
                P[i] = Math.Abs((A.Take(i).ToArray()).Sum() - (A.Skip(i).ToArray()).Sum());
            }

            return P.Min();
        }

        public static int TapeEquilibrium2(int[] A)
        {
            int N = A.Length;
            int[] P = new int[N - 1];

            for (int i = 0; i < P.Length; i++)
            {
                P[i] = Math.Abs((A.Take(i + 1).ToArray()).Sum() - (A.Skip(i + 1).ToArray()).Sum());
            }

            return P.Min();
        }// Not Good- O(N*N) instead of O(N)

    }
}
