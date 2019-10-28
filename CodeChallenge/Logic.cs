using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge
{
    public class Logic
    {
        public static bool HasPairWithSum(List<int> numList, int sum)
        {
            HashSet<int> complements = new HashSet<int>();
            foreach (var item in numList)
            {
                if (complements.Contains(item))
                {
                    Console.WriteLine("Pair Available");
                    return true;
                }
                complements.Add(sum - item);
            }
            Console.WriteLine("Pair Not Available");
            return false;
        }

        public static void MinDistance(List<int> numList, int[] a)
        {
            List<int> lst = a.OfType<int>().ToList();
            HashSet<int> complements = new HashSet<int>();
            List<List<int>> indices = new List<List<int>>();
            List<int> diffList = new List<int>();

            foreach (var item in numList)
            {
                int sum = item * 2;
                if (complements.Contains(item))
                {
                    //When pair available
                    indices.Add(new List<int> { numList.FindIndex(x => x == item),
                        numList.FindLastIndex(x => x == item) });
                }
                complements.Add(sum - item);
            }

            if (indices.Count > 0)
            {
                //Add diff to another list
                indices.ForEach(x => x.ForEach(y => diffList.Add(x[1] - x[0])));
                //Take min value
                Console.WriteLine(diffList.Min());
            }
            Console.WriteLine("No Pairs Available");
        }

        public static void BonApetit(List<int> bill, int k, int b)
        {
            int sumWithNotEatItem = bill.Where((x, i) => i != k).Sum();

            int halfBill = sumWithNotEatItem / 2;
            if (halfBill == b)
            {
                Console.WriteLine("Bon Appetit");
            }
            else
            {
                Console.WriteLine(b - halfBill);
            }
        }

        public static void GradingStudents(List<int> grades)
        {
            List<int> roundedGrades = new List<int>();
            foreach (var item in grades)
            {
                if (item >= 38)
                {
                    if (item % 5 == 0)
                    {
                        roundedGrades.Add(item);
                    }
                    else if (item % 5 != 0)
                    {
                        int closetMultiplyOfFive = ((item / 5) + 1) * 5;
                        if ((closetMultiplyOfFive - item) < 3)
                            roundedGrades.Add(closetMultiplyOfFive);
                        else
                            roundedGrades.Add(item);
                    }
                }
                else
                {
                    roundedGrades.Add(item);
                }

            }
            Console.WriteLine(String.Join("\n", roundedGrades));
        }
        public static int JumpingOnClouds(int[] pathArray)
        {
            var possiblePairList = pathArray.OfType<int>().ToList().
                Select((a, b) => new { value = a, idx = b }).Where(x => x.value == 0);

            List<int> possibleIndexList = possiblePairList.Select(x => x.idx).ToList();

            int jumps = 0;

            for (int i = 0; i < possibleIndexList.Count;)
            {
                int currentItem = possibleIndexList[i];
                if (possibleIndexList.Contains(currentItem + 2))
                {
                    jumps++;
                    i = possibleIndexList.IndexOf(currentItem + 2);
                }
                else if (possibleIndexList.Contains(currentItem + 1))
                {
                    jumps++;
                    i = possibleIndexList.IndexOf(currentItem + 1);
                }
                else
                    i++;

            }
            return jumps;
        }

        // Complete the findDigits function below.
        public static int FindDigits(int n)
        {
            List<int> digitArray = n.ToString().ToCharArray().
                Select(x => (int)Char.GetNumericValue(x)).ToList();
            int count = 0;
            digitArray.ForEach(x =>
            {

                if (x != 0 && n % x == 0)
                {
                    count++;
                }
            });
            Console.WriteLine(count);
            return count;
        }

        // Complete the acmTeam function below.
        public static int[] AcmTeam(string[] topic)
        {

            int numOfAttendees = topic.Length;
            List<int> permutationLst = Enumerable.Range(1, numOfAttendees).ToList();
            List<string> permutationCombination = new List<string>();

            int count = 0;
            foreach (var item in permutationLst)
            {
                int index = count;
                while (index < permutationLst.Count - 1)
                {
                    permutationCombination.Add(item + "," + permutationLst[index + 1]);
                    index++;
                }
                count++;
            }

            List<int> numOfTopic = new List<int>();
            foreach (var item in permutationCombination)
            {
                var firstStrMember = item.Split(',')[0];
                var secondStrMember = item.Split(',')[1];
                var firstMember = (topic[(Convert.ToInt32(firstStrMember)) - 1]).
                    ToCharArray().Select(x => (long)Char.GetNumericValue(x)).ToArray();

                var secondMember = (topic[(Convert.ToInt32(secondStrMember)) - 1]).
                    ToCharArray().Select(x => (long)Char.GetNumericValue(x)).ToArray();
                int counter = 0;
                for (int i = 0; i < firstMember.Length; i++)
                {

                    if ((firstMember[i] + secondMember[i]) >= 1)
                    {
                        counter++;
                    }

                }
                if (counter > 0)
                    numOfTopic.Add(counter);

            }

            int maxTopics = numOfTopic.Max();
            int numOfTeams = numOfTopic.Count(x => x == maxTopics);
            return new int[] { maxTopics, numOfTeams };

            //Console.WriteLine(String.Join("\n", permutationCombination));

        }
        // Complete the solve function below.
        public static int Solve(int n, int[][] operations)
        {
          
            List<long> candleList = Enumerable.Repeat<long>(0, n).ToList();

            for (int x = 0; x < operations.Length; x++)
            {
                int firstIndex = operations[x][0];
                int secIndex = operations[x][1];
                int thirdIndex = operations[x][2];

                for (int i = firstIndex; i <= secIndex; i++)
                {

                    candleList[i - 1] = candleList[i - 1]
                        + thirdIndex;
                }
            }
            int sum = (int)candleList.Sum() / n;
            return sum;
            //Console.WriteLine(String.Join("/n", candleList));        }

        }

        public static int MaxMin(int k, int[] arr)
        {
            var list = arr.OfType<int>().ToList();
            var listCombi = GetPermutations(list, k);
            var listA = new List<int>();
            var listOfListAMaxMinDiff = new List<int>();
            foreach (var item in listCombi)
            {
                foreach (var im in item)
                {
                    listA.Add(im);
                
                }
                listOfListAMaxMinDiff.Add(listA.Max() - listA.Min());
               
              
            }
            //Console.WriteLine(listOfListAMaxMinDiff.Min());

            return listOfListAMaxMinDiff.Min();
        }

        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
                return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(o => !t.Contains(o)),
            (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        public static long HalloweenParty(int k)
        {
            long firstCut = 0;
            long secondCut = 0;
            long allCuts = 0;

            if (k % 2 == 0)
            {
                long halfVal = k / 2;
                allCuts = halfVal * halfVal;
            }
            else
            {
                firstCut = k / 2;
                secondCut = k - firstCut;
                allCuts = firstCut * secondCut;
            }
           
            return allCuts;
        }
    }
}
