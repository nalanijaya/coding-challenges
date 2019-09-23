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
    }
}
