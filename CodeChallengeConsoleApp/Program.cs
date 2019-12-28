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
            List<int> numList3 = new List<int>() { 7, 1 ,3 ,4, 1, 7 };
            //7 1 3 4 1 7
            //Logic.HasPairWithSum(numList2, 8);
            //Logic.MinDistance(numList3);
            //Logic.BonApetit(new List<int> { 3, 10, 2 ,9 },1,12);
            //Logic.GradingStudents(new List<int> { 73, 67, 38, 33});
            //Logic.JumpingOnClouds(new int[] { 0, 0 ,0 ,0 ,1 ,0});
            //Logic.FindDigits(12);
            //Logic.AcmTeam(new string[] { "10101", "11100", "11010", "00101" });
           
            //Logic.Solve(5, new int[][]{

            //new int[] { 1,2,100 }, new int[] { 2, 5, 100 }, new int[] { 3,4,100 }});
            //Logic.MaxMin(4, new int[] { 1, 2, 3, 4, 10, 20, 30, 40, 100, 200 });

            //Logic.LeftRotation(4, new int[] { 1, 2, 3, 4, 5 });
            //Logic.GetIdealNums(200,405);
            Logic.Ways(5,3);
            Logic.MinimumBribes(new int[] { 1 ,2, 5, 3, 4, 7, 8, 6 });
            Logic.BalanceParanthesis("{}{(())[[]][({})]()(}");
            Console.ReadLine();

        }
    }
}
