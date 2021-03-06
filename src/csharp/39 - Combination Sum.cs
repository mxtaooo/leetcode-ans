using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#region Original Solution
namespace CSharpConsoleApp
{
    class IntListComparer : IEqualityComparer<IList<int>>
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

        public int GetHashCode([DisallowNull] IList<int> list)
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

    class Program
    {
        private static readonly IEqualityComparer<IList<int>> comparer = new IntListComparer();

        static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var raw = new HashSet<int>(candidates);
            var dict = new Dictionary<int, HashSet<IList<int>>>();
            for (int i = 1; i <= target; i++)
            {
                var set = new HashSet<IList<int>>(comparer);
                for (int j = 1; j <= i / 2; j++)
                {
                    if (dict.ContainsKey(j) && dict.ContainsKey(i - j))
                    {
                        foreach (var jl in dict[j])
                        {
                            foreach (var ol in dict[i - j])
                            {
                                var list = new List<int>(jl);
                                list.AddRange(ol);
                                set.Add(list);
                            }
                        }
                    }
                }
                if (raw.Contains(i))
                {
                    set.Add(new List<int>() { i });
                }
                if (set.Count > 0)
                {
                    dict[i] = set;
                }
            }
            var result = dict.ContainsKey(target) ? new List<IList<int>>(dict[target]) : new List<IList<int>>();
            return result;
        }

        static string Format(IList<IList<int>> list)
        {
            return $"[{string.Join(",", list.Select(l => $"[{string.Join(",", l)}]"))}]";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(Format(CombinationSum(new int[] { 2, 3, 5 }, 8)));
            Console.WriteLine(Format(CombinationSum(new int[] { 2 }, 1)));
            Console.WriteLine(Format(CombinationSum(new int[] { 1 }, 1)));
            Console.WriteLine(Format(CombinationSum(new int[] { 1 }, 2)));
        }
    }
}
#endregion
