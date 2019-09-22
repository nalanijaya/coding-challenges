using CodeChallenge;
using System;
using System.Collections.Generic;

namespace CodeChallengeConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> numList1 = new List<int>() { 1, 2, 4, 4 };
            List<int> numList2 = new List<int>() { 1, 2, 2, 6 };
            Logic.HasPairWithSum(numList2, 8);
            Console.ReadLine();
        }
    }
}
