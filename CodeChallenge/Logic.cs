using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge
{
    public class Logic
    {
        public static bool HasPairWithSum(List<int> numList, int sum)
        {
            HashSet<int> complements = new HashSet<int>();
            foreach(var item in numList)
            {
                if(complements.Contains(item))
                {
                    Console.WriteLine("Pair Available");
                    return true;
                }
                complements.Add(sum - item);
            }
            Console.WriteLine("Pair Not Available");
            return false;
        }

        public static void MinDistance(List<int> numList, int[]a)
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

            if(indices.Count > 0)
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
            foreach(var item in grades)
            {
                if(item >= 38)
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
                Select((a, b) => new { value = a, idx = b}).Where(x=> x.value == 0);

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

    }
}
