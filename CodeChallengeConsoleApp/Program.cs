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
			//Logic.Ways(5,3);
			//Logic.MinimumBribes(new int[] { 1 ,2, 5, 3, 4, 7, 8, 6 });
			//Logic.BalanceParanthesis("{}{(())[[]][({})]()(}");
			//Logic.SimpleArraySum(new int[] { 1, 2 ,3 ,4,10, 11 });
			//Logic.MinimumSwaps(new int[] { 1, 3, 5, 2 ,4, 6, 7 });
			//		Logic.MinimumSwaps(new int[] { 2 ,31, 1, 38, 29, 5, 44, 6, 12, 18, 39, 9, 48, 49, 13, 11, 7, 27, 14, 33, 50, 21, 46, 23, 15, 26, 8, 47, 40,
			//3, 32, 22, 34, 42, 16, 41, 24, 10, 4, 28, 36, 30, 37, 35, 20, 17, 45, 43, 25, 19 });
			//           Console.ReadLine();

			//Logic.findSubstring("qwdftr", 2);
			//Logic.getBattery(new List<int> { -10, 60, 10 });
			//Logic.nonDivisibleSubset(7, new List<int> { 278, 576, 496, 727, 410, 124, 338, 149, 209, 702, 282, 718,
			//771, 575, 436 });
			//Logic.DiagonalDifference(new List<List<int>>()
			//{
			//	new List<int>(){ 6,6,7,-10,9,-3,8,9,-1},
			//	new List<int>(){9,7,-10,6,4,1,6,1,1},
			//	new List<int>(){ -1, -2, 4, -6, 1, -4, -6, 3, 9 },
			//	new List<int>(){ -8,7,6,-1,-6,-6,6,-7,2 },
			//	new List<int>(){ -10,-4,9,1,-7,8,-5,3,-5 },
			//	new List<int>(){ -8,-3,-4,2,-3,7,-5,1,-5 },
			//	new List<int>(){-2,-7,-4,8,3,-1,8,2,3 },
			//	new List<int>(){ -3,4,6,-7,-7,-8,-3,9,-6 },
			//	new List<int>(){ -2,0,5,4,4,4,-3,3,0 },
			//});
			Logic.StrangeCounter(17);
			Console.ReadLine();
		}
    }
}
