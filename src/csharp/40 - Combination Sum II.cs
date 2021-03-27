using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpConsoleApp
{
    class Program
    {
        static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var dict = new Dictionary<int, int>();
            foreach (var candidate in candidates)
            {
                dict[candidate] = dict.TryGetValue(candidate, out var c) ? c + 1 : 1;
            }
            // (candidate, count)
            var list = dict.Select(kv => (kv.Key, kv.Value)).OrderBy(t => t.Key).ToList();

            var result = new List<IList<int>>();

            void DFS(int target, IList<int> combine, int idx)
            {
                if (target == 0)
                {
                    result.Add(new List<int>(combine));
                    return;
                }
                if (target < 0 || idx == list.Count)
                {
                    return;
                }
                DFS(target, combine, idx + 1);
                for (int i = 0; i < list[idx].Value; i++)
                {
                    target -= list[idx].Key;
                    combine.Add(list[idx].Key);
                    DFS(target, combine, idx + 1);
                }
                for (int i = 0; i < list[idx].Value; i++)
                {
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