using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityTasks.Tasks
{
    public static class MyOnlineTest
    {
        /// <summary>
        /// Counts the max number of distinct points that can be 
        /// inside a circle with center in (0, 0)
        /// </summary>
        /// <param name="S">A vector of tags</param>
        /// <param name="X">Corresponding X coordinates</param>
        /// <param name="Y">Corresponding Y coordinates</param>
        /// <returns>Count of distinct points inside a circle</returns>
        public static int Task1(string S, int[] X, int[] Y)
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

        /// <summary>
        /// Calculates the shortest possible length of compressed representation 
        /// of string S after removing exactly K consecutive characters from S
        /// </summary>
        /// <param name="S">Input string with long blocks</param>
        /// <param name="K">A number of consecutive characters to be removed</param>
        /// <returns>The length of a shortest compressed string</returns>
        public static int Task2(string S, int K)
        {
            int n = S.Length;
            //if (n == K)
            //    return 0;
            var compressedLengths = new int[n - K + 1];
            for (int i = 0; i < n - K + 1; i++)
            {
                var newS = S.Remove(i, K);
                compressedLengths[i] = Compress(newS).Length;
            }
            return compressedLengths.Min();
        }

        /// <summary>
        /// For given string S, returns the number of possible
        /// ways of splitting S into 3 parts, such that each part contains
        /// the same number of letters 'a'
        /// </summary>
        /// <param name="S">Input string</param>
        /// <returns>The number of possible of splitting S as described above</returns>
        public static int Task3(string S)
        {
            if (S.Length < 3)
                return 0;
            var sArray = S.ToCharArray();
            int n = sArray.Length;
            int aCount = sArray.Count(s => s == 'a');
            if (aCount % 3 > 0)
                return 0;

            // if 'a' letters don't exist 
            // then we should return a 2-combination of N-1 set
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

        private static string Compress(string S)
        {
            int n = S.Length;
            int count = 1;
            char previousLetter = '\0';
            string result = string.Empty;
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
            if (previousLetter == '\0')
                return string.Empty;
            result += GetString(count, previousLetter);
            return result;
        }

        private static string GetString(int count, char letter)
        {
            if (count == 1)
                return letter.ToString();
            return string.Format("{0}{1}", count, letter);
        }

        private static int C(int n, int k)
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
