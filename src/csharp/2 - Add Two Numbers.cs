class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var inc = 0;
        var head = new ListNode();
        for (var pre = head; l1 != null || l2 != null || inc != 0; pre = pre.next)
        {
            var val = inc + (l1?.val ?? 0) + (l2?.val ?? 0);
            l1 = l1?.next;
            l2 = l2?.next;
            inc = val / 10;
            pre.next = new ListNode(val % 10);
        }
        return head.next;
    }

    static void Main(string[] args)
    {
        var l1 = ListNode.Build(9, 9, 9);
        l1.Print();
        var l2 = ListNode.Build(1);
        l2.Print();
        var res = new Solution().AddTwoNumbers(l1, l2);
        res.Print();
    }
}
class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
    public void Print()
    {
        Console.Write(val);
        for (var p = next; p != null; p = p.next)
        {
            Console.Write(" -> ");
            Console.Write(p.val);
        }
        Console.WriteLine();
    }

    public static ListNode Build(params int[] ints)
    {
        var head = new ListNode();
        var p = head;
        foreach (var i in ints)
        {
            p.next = new ListNode(i);
            p = p.next;
        }
        return head.next;
    }
}
