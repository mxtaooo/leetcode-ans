using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace CSharpConsoleApp
{

    static class Helper
    {
        public static List<int> AllIndexOf(this string s, string value)
        {
            var result = new List<int>();
            var slen = s.Length;
            var vlen = value.Length;

            List<int> InnerFunc(List<int> result, int start)
            {
                var index = s.IndexOf(value, start);
                if (index != -1)
                {
                    result.Add(index);
                    if (index + vlen < slen)
                    {
                        return InnerFunc(result, start + vlen);
                    }
                }
                return result;
            }
            return InnerFunc(result, 0);
        }

        public static string Format(this List<int> list)
        {
            if (list.Count == 0)
            {
                return "[ ]";
            }
            return "[ " + list.Select(i => i.ToString()).Aggregate((s1, s2) => s1 + ", " + s2) + " ]";
        }

    }

    class Program
    {
        static bool IsExist(int index, ImmutableHashSet<int> targets, Dictionary<int, int> lens, Dictionary<int, ImmutableHashSet<int>> dict)
        {
            if (targets.IsEmpty)
            {
                return true;
            }

            if (dict.ContainsKey(index))
            {
                var intersect = dict[index].Intersect(targets);
                if (intersect.Count == 1)
                {
                    foreach (var i in intersect)
                    {
                        return IsExist(index + lens[i], targets.Remove(i), lens, dict);
                    }
                }
                else if (intersect.Count > 1)
                {
                    foreach (var i in intersect)
                    {
                        if (IsExist(index + lens[i], targets.Remove(i), lens, dict))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        static List<int> FindSubstring(string s, string[] words)
        {
            // (id, index list)
            var list = new List<(int, List<int>)>(words.Length);
            // (id, len)
            var lens = new Dictionary<int, int>(words.Length);
            // len
            var len = 0;
            for (int i = 0; i < words.Length; i++)
            {
                len += words[i].Length;
                lens.Add(i, words[i].Length);
                var index = s.AllIndexOf(words[i]);
                if (index.Count == 0)
                {
                    return new List<int>();
                }
                list.Add((i, index));
            }

            // (index, id list)
            var dict = new Dictionary<int, List<int>>();
            foreach (var (id, ilist) in list)
            {
                foreach (var index in ilist)
                {
                    if (dict.ContainsKey(index))
                    {
                        dict[index].Add(id);
                    }
                    else
                    {
                        dict.Add(index, new List<int>() { id });
                    }
                }
            }

            var dict2 = new Dictionary<int, ImmutableHashSet<int>>(dict.Count);
            foreach (var (index, ids) in dict)
            {
                dict2[index] = ImmutableHashSet.CreateRange(ids);
            }

            var result = new List<int>();
            var targets = ImmutableHashSet.CreateRange(Enumerable.Range(0, words.Length));
            for (int i = 0; i < s.Length - len + 1; i++)
            {
                if (dict2.ContainsKey(i) && IsExist(i, targets, lens, dict2))
                {
                    result.Add(i);
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(FindSubstring("barfoothefoobarman", new string[] { "foo", "bar" }).Format());
            Console.WriteLine(FindSubstring("wordgoodgoodgoodbestword", new string[] { "word", "good", "best", "word" }).Format());
            Console.WriteLine(FindSubstring("barfoofoobarthefoobarman", new string[] { "bar", "foo", "the" }).Format());
        }
    }
}
