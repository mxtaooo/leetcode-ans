class Solution
{
    static ListNode SwapPairs(ListNode head)
    {
        var holder = new ListNode(next: head);

        for (var p = holder; p?.next?.next != null; p = p.next.next)
        {
            var (pp, ppp, pppp) = (p.next, p.next.next, p.next.next.next);
            p.next = ppp;
            ppp.next = pp;
            pp.next = pppp;
        }
        return holder.next;
    }
}