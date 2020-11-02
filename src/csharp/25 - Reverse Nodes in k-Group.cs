class Solution
{
    static ListNode ReverseKGroup(ListNode head, int k)
    {
        static (ListNode, ListNode) Reverse(ListNode list)
        {
            if (list.next == null) return (list, list);

            var (pre, cur) = (default(ListNode), list);
            while (cur != null)
            {
                var tail = cur.next;
                cur.next = pre;
                pre = cur;
                cur = tail;
            }
            return (pre, list);
        }

        if (k == 1) return head;

        var holder = new ListNode(next: head);

        for (var pre = holder; pre != null; )
        {
            var (p, c) = (pre, 0);
            while (p?.next != null && c < k)
            {
                p = p.next;
                c++;
            }

            if (c == k)
            {
                var tail = p.next;
                p.next = null;
                var (h, t) = Reverse(pre.next);
                pre.next = h;
                t.next = tail;
                pre = t;
                c = 0;
            }
            else
            {
                pre = null;
            }
        }

        return holder.next;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(ReverseKGroup(ListNode.Build(1, 2, 3, 4, 5), 1).ToString());
        Console.WriteLine(ReverseKGroup(ListNode.Build(1, 2, 3, 4, 5), 2).ToString());
        Console.WriteLine(ReverseKGroup(ListNode.Build(1, 2, 3, 4, 5), 3).ToString());
        Console.WriteLine(ReverseKGroup(ListNode.Build(1, 2, 3, 4, 5), 4).ToString());
        Console.WriteLine(ReverseKGroup(ListNode.Build(1, 2, 3, 4, 5), 5).ToString());
        Console.WriteLine(ReverseKGroup(ListNode.Build(1, 2, 3, 4, 5), 6).ToString());

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
