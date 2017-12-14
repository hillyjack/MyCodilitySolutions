﻿using System;
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

            
            //var bigRange = Enumerable.Range(1, 99999).ToArray();
            //Console.WriteLine(PermMissingElem(bigRange));
            //Console.WriteLine(TapeEquilibrium(new int[] { 3, 1, 2, 4, 3 }));
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
        } //100%

        public static int TapeEquilibrium2(int[] A)
        {
            int N = A.Length;
            int[] P = new int[N - 1];

            for (int i = 0; i < P.Length; i++)
            {
                P[i] = Math.Abs((A.Take(i).ToArray()).Sum() - (A.Skip(i).ToArray()).Sum());
            }

            return P.Min();
        }// Not Good- O(N*N) instead of O(N)

        public static int TapeEquilibrium(int[] A)
        {
            int[] Sums = new int[A.Length];
            Sums[0] = A[0];

            for (int i = 1; i < A.Length; i++)
            {
                Sums[i] = (Sums[i - 1] + A[i]);
            }

            int MinDifference = int.MaxValue;
            int ArraySum = Sums.Length - 1;

            for (int j = 0; j < Sums.Length - 1; j++)
            {
                int Difference = Math.Abs(Sums[j] - (Sums[ArraySum] - Sums[j]));
                MinDifference = (Difference < MinDifference ? Difference : MinDifference);
            }

            return MinDifference;
        }// 100%

        public static int PermMissingElem2(int[] A)
        {
            long ArraySum = 0, RangeSum = A.Length + 1;

            for (int i = 0; i < A.Length; i++)
            {
                RangeSum += i + 1;
                ArraySum += A[i];
            }

            return (int)(RangeSum - ArraySum);
        }//option 2 100%

        public static int PermMissingElem(int[] A)
        {
            long ArraySum = 0;

            foreach (int Num in A)
            {
                ArraySum += Num;
            }

            long TopRange = A.Length + 1;
            long RangeSum = (TopRange * (TopRange + 1)) / 2;

            return (int)(RangeSum - ArraySum);
        }//option 1 100%

        public static int FrogRiverOne(int X, int[] A) {
            return 0;
        }

    }
}
