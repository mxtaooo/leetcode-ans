using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpConsoleApp
{
    class Program
    {
        static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<IList<int>>();

            void DFS(int target, IList<int> combine, int idx)
            {
                if (idx == candidates.Length)
                {
                    return;
                }
                if (target == 0)
                {
                    result.Add(new List<int>(combine));
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
            // 需要对result中的元素去重
            return result;
        }

        static string Format(IList<IList<int>> list)
        {
            return $"[{string.Join(",", list.Select(l => $"[{string.Join(",", l)}]"))}]";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("CombinationSumII");
            Console.WriteLine(Format(CombinationSum(new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8)));
            Console.WriteLine(Format(CombinationSum(new int[] { 2, 5, 2, 1, 2 }, 5)));
            Console.WriteLine(Format(CombinationSum(new int[] { 1 }, 1)));
            Console.WriteLine(Format(CombinationSum(new int[] { 1 }, 2)));
        }
    }
}