using System;
using System.Collections.Generic;

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
    }
}
