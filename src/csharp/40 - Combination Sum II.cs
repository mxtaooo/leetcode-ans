using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpConsoleApp
{
    class Program
    {
        private class IntListComparer : IEqualityComparer<IList<int>>
        {
            public bool Equals(IList<int>? x, IList<int>? y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (x != null && y != null && x.Count == y.Count)
                {
                    var list1 = new List<int>(x);
                    list1.Sort();
                    var list2 = new List<int>(y);
                    list2.Sort();
                    for (int i = 0; i < list1.Count; i++)
                    {
                        if (list1[i] != list2[i])
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }

            public int GetHashCode(IList<int> list)
            {
                var tmp = new List<int>(list);
                tmp.Sort();
                unchecked
                {
                    int hash = 19;
                    foreach (var i in tmp)
                    {
                        hash = hash * 31 + i.GetHashCode();
                    }
                    return hash;
                }
            }
        }

        private static readonly IEqualityComparer<IList<int>> comparer = new IntListComparer();

        static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
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