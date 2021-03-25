using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpConsoleApp
{
    class Program
    {

        static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            // todo: HERE
            var result = new HashSet<IList<int>>(comparer);

            void DFS(int target, IList<int> combine, int idx)
            {
                if (target == 0)
                {
                    result.Add(new List<int>(combine));
                    return;
                }
                if (idx == candidates.Length)
                {
                    return;
                }
                DFS(target, combine, idx + 1);
                if (target - candidates[idx] >= 0)
                {
                    combine.Add(candidates[idx]);
                    DFS(target - candidates[idx], combine, idx + 1);
                    combine.RemoveAt(combine.Count - 1);
                }
            }

            var combine = new List<int>();
            DFS(target, combine, 0);
            return new List<IList<int>>(result);
        }

        static string Format(IList<IList<int>> list)
        {
            return $"[{string.Join(",", list.Select(l => $"[{string.Join(",", l)}]"))}]";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(Format(CombinationSum2(new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8)));
            Console.WriteLine(Format(CombinationSum2(new int[] { 2, 5, 2, 1, 2 }, 5)));
            Console.WriteLine(Format(CombinationSum2(new int[] { 1 }, 1)));
            Console.WriteLine(Format(CombinationSum2(new int[] { 1 }, 2)));
        }
    }
}