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
            Console.WriteLine(solutionString(@"my.song.mp3 11b
greatSong.flac 1000b
not3.txt 5b
video.mp4 200b
game.exe 100b
mov!e.mkv 10000b"));

            //Console.WriteLine(Binary(3, 7)); //3
            //Console.WriteLine(Binary(1, 7)); //3
            //Console.WriteLine(Binary(11, 7)); //
            //Console.WriteLine(Binary(100000000, 100000000)); //3


            //Console.WriteLine(solution(new int[] { 1, 1, 3, 3, 3, 4, 5, 5, 5, 5 }, 2)); //5
            //Console.WriteLine(solution(new int[] { 1, 1, 3, 3, 3, 3, 3, 4, 5, 5, 5, 5, 6, 6 }, 2));//7
            //Console.WriteLine(solution(new int[] { 1, 1, 1, 2, 3, 4, 5, 5, 5, 5, 5, 5 }, 0));//6
            //Console.WriteLine(solution(new int[] { 1, 2, 2, 3 }, 3));//4

            //Console.WriteLine(FibonacciSeries(8));

            //Console.WriteLine(PassingCars(new int[] { 0, 1, 0, 1, 1 }));//5

            //PrintArray(MaxCounters(5, new int[] { 3, 4, 4, 6, 1, 4, 4 }));

            //Console.WriteLine(MissingInteger(new int[] { 1, 3, 6, 4, 1, 2 }));//5
            //Console.WriteLine(MissingInteger(new int[] { 1, 2, 3 }));//4
            //Console.WriteLine(MissingInteger(new int[] { -1, -3 }));//1

            //Console.WriteLine(PermCheck(new int[] { 4, 1, 3, 2 }));//1
            //Console.WriteLine(PermCheck(new int[] { 4, 1, 3 }));//0
            //Console.WriteLine(FrogRiverOne(5, new int[] { 1, 3, 1, 4, 2, 3, 5, 4 }));//6
            //var bigRange = Enumerable.Range(1, 99999).ToArray();
            //Console.WriteLine(PermMissingElem(bigRange));
            //Console.WriteLine(TapeEquilibrium(new int[] { 3, 1, 2, 4, 3 }));
            //Console.WriteLine(FrogJmp(10, 85, 30));
            //Console.WriteLine(FindMultiplesInRange(2, 21, 2));

        }

        public static void PrintArray(int[] A)
        {
            Console.Write("[");
            foreach (int item in A)
            {
                Console.Write(item + ", ");
            }
            Console.Write("]");
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

        public static int FrogRiverOne(int X, int[] A)
        {
            long positionSum = (long)(X * (X + 1)) / 2;
            int[] Leaves = new int[X];
            int LeavesSum = 0, Seconds = 0;

            for (int i = 0; i < A.Length && LeavesSum != positionSum; i++)
            {
                if (Leaves[A[i] - 1] == 0)
                {
                    Leaves[A[i] - 1] = A[i];
                    LeavesSum += A[i];
                    Seconds = i;
                }
            }

            if (LeavesSum != positionSum)
                Seconds = -1;

            return Seconds;
        }//option 1 100%

        public static int FrogRiverOne2(int X, int[] A)
        {
            bool[] leavesInPosition = new bool[X + 1];

            int occupiedPositions = 0;
            for (int i = 0; i < A.Length; i++)
            {
                int position = A[i];
                if (position <= X && !leavesInPosition[position])
                {
                    leavesInPosition[position] = true;
                    occupiedPositions++;
                }

                if (occupiedPositions == X)
                {
                    return i;
                }
            }

            return -1;
        }//option 2

        public static int PermCheck(int[] A)
        {
            int isPermutation = 1, isNotPermutation = 0, N = A.Length;
            int[] Permutation = new int[N];

            for (int i = 0; i < N; i++)
            {
                if (A[i] <= N && Permutation[A[i] - 1] == 0)
                {
                    Permutation[A[i] - 1] = A[i];
                }
                else
                    return isNotPermutation;
            }
            return isPermutation;
        } //100%

        public static int MissingInteger(int[] A)
        {
            int N = A.Length;
            int[] FindingInteger = new int[N];

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] <= N && A[i] > 0)
                {
                    if (FindingInteger[A[i] - 1] == 0)
                        FindingInteger[A[i] - 1] = A[i];
                }
            }

            for (int j = 0; j < FindingInteger.Length; j++)
            {
                if (FindingInteger[j] == 0)
                    return j + 1;
            }
            return N + 1;
        }// 100%

        public static int MissingInteger2(int[] A)
        {
            int maxSize = 100000;
            int[] counter = new int[maxSize];

            foreach (int number in A)
            {
                if (number > 0 && number <= maxSize)
                {
                    counter[number - 1] = 1;
                }
            }

            for (int i = 0; i < maxSize; i++)
            {
                if (counter[i] == 0)
                {
                    return i + 1;
                }
            }

            return maxSize + 1;
        }

        public static int[] MaxCounters(int N, int[] A)
        {
            int CurrentMaxVal = 0, SetMaxCounter = 0;

            int[] Counters = new int[N];

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < N + 1)
                {
                    Counters[A[i] - 1] = Counters[A[i] - 1] < SetMaxCounter ? SetMaxCounter + 1 : Counters[A[i] - 1] + 1;
                    CurrentMaxVal = CurrentMaxVal > Counters[A[i] - 1] ? CurrentMaxVal : Counters[A[i] - 1];
                }
                else
                    SetMaxCounter = CurrentMaxVal;
            }

            for (int j = 0; j < Counters.Length; j++)
            {
                Counters[j] = Counters[j] < SetMaxCounter ? SetMaxCounter : Counters[j];
            }
            return Counters;
        } // 100%

        public static int PassingCars(int[] A)
        {
            int eastCars = 0, Passing = 0, MaxPass = 1000000000;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == 0)
                    eastCars++;
                else
                    Passing += eastCars;

                if (Passing > MaxPass)
                    return -1;
            }

            return Passing;
        } //100%

        public static int FibonacciSeries(int n)
        {
            if (n == 0) return 0; //To return the first Fibonacci number   
            if (n == 1) return 1; //To return the second Fibonacci number   
            return FibonacciSeries(n - 1) + FibonacciSeries(n - 2);
        }

        public static int solution(int[] A, int K)
        {
            int n = A.Length;
            int best = n - K == 1 ? 1 : 0;
            int count = 1;
            for (int i = 0; i < n - K - 1; i++)
            {//
                if (A[i] == A[i + 1])
                    count++;
                else
                    count = 1;
                if (count > best)
                    best = count;
            }
            int result = best + K;

            return result;
        }

        public static int Binary(int A, int B)
        {
            //long!
            long remainder = 0;
            int bitsCounter = 0;
            //string result = "";
            long turnToBinary = (long)A * B;
            //Console.WriteLine(long.MaxValue);
            //Console.WriteLine(turnToBinary);

            while (turnToBinary > 0)
            {
                remainder = turnToBinary % 2;
                turnToBinary /= 2;

                if (remainder == 1)
                    bitsCounter++;
                //result = remainder.ToString() + result;
            }
            //Console.WriteLine( result);
            return bitsCounter;
        }

        public static string solutionString(string S)
        {
            string[] TypeAndSize = S.Split('\n');
            int musicSize = 0, imageSize = 0, movieSize = 0, otherSize = 0;

            for (int i = 0; i < TypeAndSize.Length; i++)
            {
                string[] info = TypeAndSize[i].Split(' ');
                string type = info[0].Split('.').Last();
                int size = int.Parse(info[1].Replace("b", ""));

                if (type == "mp3" || type == "aac" || type == "flac")
                    musicSize += size;

                else if (type == "jpg" || type == "bmp" || type == "gif")
                    imageSize += size;

                else if (type == "mp4" || type == "avi" || type == "mkv")
                    movieSize += size;
                else
                    otherSize += size;
            }

            string result = string.Format("music {0}b\nimages {1}b\nmovies {2}b\nother {3}b", musicSize, imageSize, movieSize, otherSize);
            return result;
        }

    }
}
