using System;
//using System.Collections.Generic;
using System.Linq;
using CodilityTasks.Tasks;

namespace CodilityTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(10 % 3);
            string S = "ABB";
            int[] X = new[] { 1, 2, 2 };
            int[] Y = new[] { 2, -1, 1 };

            int result = solution(S, X, Y);
        }

        static int solution2(string S, int K)
        {
            int n = S.Length;
            if (n < K)
                return Compress(S).Length;
            var compressedLengths = new int[n - K + 1];
            for (int i = 0; i < n - K + 1; i++)
            {
                var newS = S.Remove(i, K);
                compressedLengths[i] = Compress(newS).Length;
            }
            return compressedLengths.Min();
        }

        static string Compress(string S)
        {
            int n = S.Length;
            int count = 1;
            char previousLetter = '0';
            string result = "";
            for (int i = 0; i < n; i++)
            {
                if (previousLetter == S[i])
                    count++;
                else if (i > 0)
                {
                    result += GetString(count, previousLetter);
                    count = 1;
                }
                previousLetter = S[i];
            }
            result += GetString(count, previousLetter);
            return result;
        }

        static string GetString(int count, char letter)
        {
            if (count == 1)
                return letter.ToString();
            return string.Format("{0}{1}", count, letter);
        }

        static int DemoTask()
        {
            int[] A = new int[] { 1, 2, 3, 8, 0, -3, 4 };
            int leastNatural = 1;
            Array.Sort(A);
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < 1)
                    continue;
                if (A[i] == leastNatural)
                    leastNatural++;
                if (A[i] > leastNatural)
                    break;
            }
            return leastNatural;
        }

        static int solution(string S, int[] X, int[] Y)
        {
            int n = S.Length;

            int[] SquareLengths = new int[n];
            //string tags = new List<string>();
            for (int i = 0; i < n; i++)
            {
                SquareLengths[i] = X[i] * X[i] + Y[i] * Y[i];
            }

            char[] tags = S.ToCharArray();
            Array.Sort(SquareLengths, tags);
            Array.Sort(SquareLengths);

            int inCircleCounter = 0;
            string tagsInCircle = "";
            for (int i = 0; i < n; i++)
            {
                int tagPosition = tagsInCircle.IndexOf(tags[i]);
                if (tagPosition > -1)
                {
                    int j = i - 1;
                    while (SquareLengths[j] == SquareLengths[i])
                    {
                        inCircleCounter--;
                        j--;
                        if (j < 0)
                            break;
                    }
                    break;
                }
                tagsInCircle += tags[i];
                inCircleCounter++;
            }

            return inCircleCounter;
        }

        static int solution3(string S)
        {
            if (S.Length < 3)
                return 0;
            var sArray = S.ToCharArray();
            int n = sArray.Length;
            int aCount = sArray.Count(s => s == 'a');
            if (aCount % 3 > 0)
                return 0;

            if (aCount == 0)
                return C(n - 1, 2);

            int aInPart = aCount / 3;
            int leftResidCount = 1;
            int rightResidCount = 1;
            int aCounter = 0;

            for (int i = 0; i < n; i++)
            {
                if (sArray[i] == 'a')
                {
                    aCounter++;
                    continue;
                }
                if (aCounter == aInPart)
                    leftResidCount++;
                if (aCounter == aInPart * 2)
                    rightResidCount++;
            }

            return leftResidCount * rightResidCount;
        }

        static int C(int n, int k)
        {
            if (n < k || n < 1 || k < 1)
                return 0;
            if (n == k)
                return 1;
            if (k == 1)
                return n;
            return C(n - 1, k - 1) + C(n - 1, k);
        }
    }
}
