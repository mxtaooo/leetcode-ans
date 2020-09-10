package leetcode

object Solution {

  def addTwoNumbers(l1: ListNode, l2: ListNode): ListNode = {
    val head = new ListNode()
    var (fir, sec) = (l1, l2)
    var (inc, p) = (0, head)
    while (fir != null || sec != null || inc != 0) {
      var x = inc
      if (fir != null) {
        x = x + fir.x
        fir = fir.next
      }
      if (sec != null) {
        x = x + sec.x
        sec = sec.next
      }
      inc = x / 10
      p.next = new ListNode(x % 10)
      p = p.next
    }
    head.next
  }

  def main(args: Array[String]): Unit = {
    val l1 = build(9, 9, 9)
    println(l1.toString)
    val l2 = build(1, 2, 3, 4)
    println(l2.toString)
    val l3 = addTwoNumbers(l1, l2)
    println(l3.toString)
  }

  def build(ints: Int*): ListNode = {
    val head = new ListNode()
    var p = head
    for (i <- ints) {
      p.next = new ListNode(i)
      p = p.next
    }
    head.next
  }

  class ListNode(_x: Int = 0, _next: ListNode = null) {
    var x: Int = _x
    var next: ListNode = _next

    override def toString: String = {
      val sb = new StringBuilder()
      sb.append(x)
      var p = next
      while (p != null) {
        sb.append(" -> ")
        sb.append(p.x)
        p = p.next
      }
      sb.toString()
    }
  }
}
