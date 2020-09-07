
public class Solution {

    public ListNode addTwoNumbers(ListNode l1, ListNode l2) {
        var inc = 0;
        var head = new ListNode();
        for (var pre = head; l1 != null || l2 != null || inc != 0; pre = pre.next) {
            int val = inc;
            if (l1 != null) {
                val += l1.val;
                l1 = l1.next;
            }
            if (l2 != null) {
                val += l2.val;
                l2 = l2.next;
            }
            inc = val / 10;
            pre.next = new ListNode(val % 10);
        }
        return head.next;
    }

    public static void main(String[] args) {
        System.out.println("Hello World");
        var l1 = build(9, 9, 9);
        l1.print();
        var l2 = build(1, 2, 3, 4);
        l2.print();
        var res = new Solution().addTwoNumbers(l1, l2);
        res.print();
    }

    public static ListNode build(int... ints) {
        var head = new ListNode();
        var p = head;
        for (int i : ints) {
            p.next = new ListNode(i);
            p = p.next;
        }
        return head.next;
    }

    public static class ListNode {
        int val;
        ListNode next;

        ListNode() {}

        ListNode(int val) {
            this.val = val;
        }

        ListNode(int val, ListNode next) {
            this.val = val;
            this.next = next;
        }

        void print() {
            System.out.print(val);
            for (var p = next; p != null; p = p.next) {
                System.out.print(" -> ");
                System.out.print(p.val);
            }
            System.out.println();
        }
    }
}
