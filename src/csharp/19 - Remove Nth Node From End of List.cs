/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution 
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var list = new ListNode(next: head);
        var (index, pre) = (1, list);

        for (var p = list; p.next != null; p = p.next)
        {
            if (index == n + 1)
            {
                pre = pre.next;
            }
            else
            {
                index++;
            }
        }

        pre.next = pre.next.next;

        return pre == list ? pre.next : head;
    }
}