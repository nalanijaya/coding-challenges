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
            Logic.JumpingOnClouds(new int[] { 0, 0 ,0 ,0 ,1 ,0});
            Console.ReadLine();
        }
    }
}
