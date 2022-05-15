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

		// Complete the gameOfThrones function below.
		public static string GameOfThrones(string str)
		{
			// Create a list 
			List<char> list = new List<char>();

			// For each character in input strings, 
			// remove character if list contains 
			// else add character to list 
			for (int i = 0; i < str.Length; i++)
			{
				if (list.Contains(str[i]))
					list.Remove((char)str[i]);
				else
					list.Add(str[i]);
			}

			// if character length is even 
			// list is expected to be empty 
			// or if character length is odd  
			// list size is expected to be 1 
			if (str.Length % 2 == 0 && list.Count == 0 || // if string length is even 
			   (str.Length % 2 == 1 && list.Count == 1)) // if string length is odd 
				return "YES";
			else
				return "NO";

		}

		// Complete the jimOrders function below.
		public static int[] JimOrders(int[][] orders)
		{
			Dictionary<int, int> orderTime = new Dictionary<int, int>();
			int customerNo = 0;
			for (int i = 0; i < orders.Length; i++)
			{
				int sum = 0;
				customerNo++;
				for (int j = 0; j < orders[i].Length; j++)
				{
					sum = sum + orders[i][j];

				}
				orderTime.Add(customerNo, sum);
			}
			return orderTime.OrderBy(x => x.Value).
				Select(y => y.Key).ToArray();
		}

		public static int HourglassSum(int[][] mat)
		{
			int R = 5;
			int C = 5;
			if (R < 3 || C < 3)
				return -1;

			// Here loop runs (R-2)*(C-2)  
			// times considering different 
			// top left cells of hour glasses. 
			int max_sum = int.MinValue;
			for (int i = 0; i < R - 2; i++)
			{
				for (int j = 0; j < C - 2; j++)
				{
					// Considering mat[i][j] as top  
					// left cell of hour glass. 
					int sum = (mat[i][j] + mat[i][j + 1] +
							   mat[i][j + 2]) + (mat[i + 1][j + 1]) +
							  (mat[i + 2][j] + mat[i + 2][j + 1] +
							   mat[i + 2][j + 2]);

					// If previous sum is less then  
					// current sum then update 
					// new sum in max_sum 
					max_sum = Math.Max(max_sum, sum);
				}
			}
			return max_sum;
		}

		public static int[] LeftRotation(int d, int[] inputArr)
		{
			int len = inputArr.Length;
			int[] tempArr = new int[len];
			for (int i = 0; i < len; i++)
			{
				tempArr[(i + len - d) % len] = inputArr[i];

			}
			Console.WriteLine(String.Join(" ", tempArr));
			return inputArr;
		}

		public static int[] JobOffers(int[] scores, int[] lowerLimits,
			int[] upperLimits)
		{
			int min = 0;
			int max = 0;
			List<int> countArray = new List<int>();
			for (int i = 0; i < lowerLimits.Length; i++)
			{
				min = lowerLimits[i];
				max = upperLimits[i];
				int count = 0;
				for (int j = 0; j < scores.Length; j++)
				{
					if (min <= scores[j] && scores[j] <= max)
					{
						count++;
					}
				}
				countArray.Add(count);
			}
			return countArray.ToArray();
		}


		public static void PrintLinkedList(SinglyLinkedListNode head)
		{
			SinglyLinkedListNode tempNode = head;
			while (tempNode != null)
			{

				Console.WriteLine(tempNode.data);
				tempNode = head.next;
			}
		}

		public static long GetIdealNums(long low, long high)
		{
			int count = 0;

			for (long i = low; i <= high; i++)
			{
				long dVal = i;
				while (dVal % 3 == 0)
					dVal /= 3;
				while (dVal % 5 == 0)
					dVal /= 5;
				if (dVal == 1)
					count++;
			}
			return count;
		}

		public static int FillMissingBrackets(string s)
		{
			for (int i = 0; i < s.Length; i++)
			{
				string firstStr = s.Substring(0, i);
				string secondStr = s.Substring(i, s.Length - 1);
				var allowedChars = new HashSet<char>(new[] { '(', '[', '?', ')', ']' });
				var firstStrStack = new Stack<char>(firstStr.Where(c => allowedChars.Contains(c)));
				var secondStrStack = new Stack<char>(secondStr.Where(c => allowedChars.Contains(c)));

				for (int j = 0; j < firstStrStack.Count; j++)
				{

				}
			}

			return 0;
		}

		/* Function to find out all combinations of 
   positive numbers that add upto given number. 
   It uses findCombinationsUtil() */
		public static int Ways(int total, int k)
		{
			// array to store the combinations 
			// It can contain max n elements 
			int[] arr = new int[total];

			//find all combinations 
			int returnVal = WaysUtil(arr, 0, total, total, k);
			return returnVal % 1000000007;
		}

		public static int WaysUtil(int[] arr, int index,
					   int num, int reducedNum, int limit)
		{

			// Base condition 
			if (reducedNum < 0)
				return 0;

			//// If combination is found, print it 
			if (reducedNum == 0)
			{
				int count = 0;
				count++;
				return count;
			}

			// Find the previous number stored in arr[] 
			// It helps in maintaining increasing order 
			int prev = (index == 0) ? 1 : arr[index - 1];

			// note loop starts from previous number 
			// i.e. at array location index - 1 
			for (int k = prev; k <= num; k++)
			{
				if (k <= limit)
				{
					// next element of array is k 
					arr[index] = k;

					// call recursively with reduced number 
					WaysUtil(arr, index + 1, num,
											 reducedNum - k, limit);
				}

			}
			return 0;
		}

		// Complete the minimumBribes function below.
		public static void MinimumBribes(int[] q)
		{
			int count = 0;
			string msg = "";
			for (int i = 1; i < q.Length; i++)
			{
				if (q[i - 1] != i && q[i - 1] > i)
				{
					int val = q[i - 1] - i;
					if (val <= 2)
						count = count + val;
					else
					{
						msg = "Too chaotic";
						Console.WriteLine(msg);
						return;
					}

				}
			}
			Console.WriteLine(count.ToString());
		}

		// Complete the reverseArray function below.
		public static int[] ReverseArray(int[] a)
		{
			return a.Reverse().ToArray();

		}

		public static bool BalanceParanthesis(string expression)
		{
			Stack<char> stack = new Stack<char>();

			foreach (var item in expression.ToCharArray())
			{
				if (IsOpenTerm(item))
				{
					stack.Push(item);
				}
				else
				{
					if (stack.Count == 0 && !IsMatch(stack.Pop(), item))
					{
						Console.WriteLine("Not Balanced");
						return false;
					}
				}
			}
			Console.WriteLine("Balanced");
			return stack.Count == 0;
		}

		private static bool IsOpenTerm(char c)
		{
			char[][] tokens = new char[][]{ new char[]{ '{', '}' },
				new char[]{ '[', ']' }, new char[]{ '(', ')' } };
			foreach (char[] item in tokens)
			{
				if (item[0] == c)
				{
					return true;
				}
			}
			return false;
		}

		private static bool IsMatch(char openTerm, char closeTerm)
		{
			char[][] tokens = new char[][]{ new char[]{ '{', '}' },
				new char[]{ '[', ']' }, new char[]{ '(', ')' } };
			foreach (var item in tokens)
			{
				if (item[0] == openTerm)
				{
					return item[1] == closeTerm;
				}
			}
			return false;
		}

		public static int SimpleArraySum(int[] ar)
		{
			Console.WriteLine(ar.Sum());
			return ar.Sum();
		}

		public static int MinimumSwaps(int[] ar)
		{
			int misMatchPlc = 0;
			for (int i = 0; i < ar.Length - 1; i++)
			{
				int val = ar[i];
				if (val != Array.IndexOf(ar, val) + 1)
				{
					int minValueOfRestOfArray = ar.Skip(i).ToArray().Min();
					int indexOfMinValueOfRestOfArray = Array.IndexOf(ar, minValueOfRestOfArray);
					ar[i] = minValueOfRestOfArray;
					ar[indexOfMinValueOfRestOfArray] = val;

					misMatchPlc++;
				}
			}
			Console.WriteLine(misMatchPlc);
			return misMatchPlc;
		}

		public static string findSubstring(string s, int k)
		{
			var vowelLst = new List<char> { 'a', 'e', 'i', 'o', 'u' };
			var subStrVowelCount = new List<Tuple<string, int>>();
			int maxCount = 0;
			string maxVowelSubStr = "";

			for (int i = 0; (i + k) <= s.Length; i++)
			{
				var substr = s.Substring(i, k).ToCharArray();
				int count = 0;
				substr.ToList().ForEach(x =>
				{
					if (vowelLst.Contains(x))
					{
						count++;
					}
				});
				if(count != 0)
				subStrVowelCount.Add(Tuple.Create(new string(substr), count));
			}
			if(subStrVowelCount.Count > 0)
			{
				 maxCount = subStrVowelCount.Max(x => x.Item2);
				 maxVowelSubStr = subStrVowelCount.FirstOrDefault(x => x.Item2 == maxCount).Item1;
			}

			Console.WriteLine(maxVowelSubStr);
			return maxVowelSubStr == "" ? "Not found!" : maxVowelSubStr;
		}

		public static int getBattery(List<int> events)
		{
			//var events = new List<int> { 25, -30, 70, 10 };			
			int total = 50;
			foreach (var item in events)
			{
				if (item > 0)
				{
					if(total < 100)
					{
						total = total + item;						
					}					
					else
					{
						total = 100 - item;
					}
				}
				else
				{
					if (total < 100)
						total = total - Math.Abs(item);
					else
					{
						total = 100 - Math.Abs(item);
					}
				}
			}
			Console.WriteLine(total);
			return total;
		}

		public static long aVeryBigSum(long[] ar)
		{
			Console.WriteLine(ar.Sum());
			return ar.Sum();

		}

		public static int nonDivisibleSubset(int k, List<int> s)
		{
			var lst = new List<int>();
			for (int i = 0; i < s.Count; i++)
			{
				for (int j = i+1; j < s.Count; j++)
				{
					var sum = s[i] + s[j];
					if (sum%k != 0)
					{
						lst.Add(s[i]);
						lst.Add(s[j]);
					}
				}
			}

			//lst.ForEach(x=> Console.Write(x+" "));
			var distinctListCount = lst.Distinct().Count();
			var distinctLst = lst.Distinct().ToList();
			distinctLst.ForEach(x => Console.Write(x + " "));
			Console.WriteLine(distinctListCount);
			return distinctListCount;
		}

		public static int DiagonalDifference(List<List<int>> arr)
		{
			
			int leftDiff = 0;
			int rightDiff = 0;
			if (arr.Count > 0)
			{
				int j = arr.Count - 1;
				for (int i = 0; i < arr.Count; i++) {
					leftDiff = (leftDiff + arr[i][i]);
					Console.Write(" left  ");
					Console.Write(arr[i][i]);
					rightDiff = (rightDiff + arr[i][j]);
					Console.Write("  right  ");
					Console.Write( arr[i][j]);
					--j;
				} 

				Console.WriteLine(Math.Abs(leftDiff));
				Console.WriteLine("------------");
				Console.WriteLine(Math.Abs(rightDiff));
				Console.WriteLine("------------");
				Console.WriteLine(Math.Abs(leftDiff - rightDiff));
				Console.ReadLine();
				return Math.Abs(leftDiff - rightDiff);
			}
			else
				return 0;
		}

		public static long StrangeCounter(long t)
		{			
			long initialInputNUmber = 3;
			long decrementInputNUmber = 3;

			var timeWithValue = new Dictionary<long, long>();
			long time = 1;
			while (initialInputNUmber != 0)
			{			
				timeWithValue.Add(time, initialInputNUmber);
				initialInputNUmber--;
				if (time++ > (t))
					break;

				if (initialInputNUmber == 1)
				{
					timeWithValue.Add(time, initialInputNUmber);
					time++;
					decrementInputNUmber = decrementInputNUmber * 2;
					initialInputNUmber = decrementInputNUmber;
				}
				
			}

			Console.WriteLine(timeWithValue[t]);
			return timeWithValue[t];
		}

		public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
		{
			Dictionary<string, int> itemN = new Dictionary<string, int>();
			employees.GroupBy(emp => emp.Company).Select(ditem => new
			{
				CompanyName = ditem.Key,
				AverageAge = (ditem.Sum(g=>g.Age)/ditem.Count())
			}).OrderBy(u => u.CompanyName).ToList().ForEach(b => itemN.Add(b.CompanyName, b.AverageAge));

			return itemN;
		}

		public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
		{
			Dictionary<string, int> itemN = new Dictionary<string, int>();
			employees.GroupBy(emp => emp.Company).Select(ditem => new
			{
				CompanyName = ditem.Key,
				EmployeeCount = ditem.Count()
			}).OrderBy(u => u.CompanyName).ToList().ForEach(b => itemN.Add(b.CompanyName, b.EmployeeCount));

			return itemN;
		}

		public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
		{
			Dictionary<string, Employee> itemN = new Dictionary<string, Employee>();
			employees.GroupBy(emp => emp.Company).Select(ditem => new
			{
				CompanyName = ditem.Key,
				OldestAgeEmployee = ditem.OrderByDescending(e=>e.Age).First()
			}).OrderBy(u => u.CompanyName).ToList().ForEach(b => itemN.Add(b.CompanyName, b.OldestAgeEmployee));

			return itemN;
		}
	}
}

public class SinglyLinkedListNode
{
	public int data;
	public SinglyLinkedListNode next;

	public SinglyLinkedListNode(int nodeData)
	{
		this.data = nodeData;
		this.next = null;
	}
}

public class SinglyLinkedList
{
	public SinglyLinkedListNode head;
	public SinglyLinkedListNode tail;

	public SinglyLinkedList()
	{
		this.head = null;
		this.tail = null;
	}

	public void InsertNode(int nodeData)
	{
		SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

		if (this.head == null)
		{
			this.head = node;
		}
		else
		{
			this.tail.next = node;
		}

		this.tail = node;
	}
}


public class Employee
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public int Age { get; set; }
	public string Company { get; set; }
}