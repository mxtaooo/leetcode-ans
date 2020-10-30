using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpSolution
{
    class Solution
    {
        static ListNode MergeTwoSortedLists(ListNode l1, ListNode l2)
        {
            var head = new ListNode();

            var p = head;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    p.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    p.next = l2;
                    l2 = l2.next;
                }
                p = p.next;
            }

            if (l1 != null) p.next = l1;

            if (l2 != null) p.next = l2;

            return head.next;
        }

        static void Main(string[] args)
        {
            var list = ListNode.Build(1, 2, 3, 4, 5);
            Console.WriteLine(list!.ToString());

            Console.WriteLine(MergeTwoSortedLists(ListNode.Build(1, 2, 3, 4, 5), ListNode.Build(0, 6, 7, 8, 9)).ToString());
            Console.WriteLine(MergeTwoSortedLists(ListNode.Build(1, 2, 4), ListNode.Build(1, 3, 4)).ToString());
            Console.WriteLine(MergeTwoSortedLists(ListNode.Build(1, 2, 4), ListNode.Build(1, 3, 4)).ToString());
            Console.WriteLine(MergeTwoSortedLists(ListNode.Build(), ListNode.Build(0)).ToString());
            Console.WriteLine(MergeTwoSortedLists(ListNode.Build(), ListNode.Build())?.ToString() ?? "null");
        }
    }

    class ListNode
    {
        public int val { get; set; }
        public ListNode next { get; set; }

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            sb.Append(val);
            for (var p = next; p != null; p = p.next)
            {
                sb.Append("->");
                sb.Append(p.val);
            }
            return sb.ToString();
        }

        public static ListNode Build(params int[] values)
        {
            if (values.Length == 0) return default;

            var head = new ListNode(val: values[0]);
            for (var (p, i) = (head, 1); i < values.Length; i++)
            {
                p.next = new ListNode();
                p = p.next;
                p.val = values[i];
            }

            return head;
        }
    }

}
