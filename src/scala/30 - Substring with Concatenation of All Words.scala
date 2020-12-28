object Solution {

  // 当前题解存在问题、对于 "aaaaaaaaaaaaaaaaaaaaa" ["a", "a", "a" ...]这种、会出现内存问题

  import scala.annotation.tailrec
  import collection.mutable.ListBuffer

  def allIndexOf(s: String, value: String): List[Int] = {
    @tailrec
    def func(result: ListBuffer[Int], start: Int): ListBuffer[Int] = {
      val index = s.indexOf(value, start)
      if (index != -1) {
        result.addOne(index)
      }
      if (index != -1 && index + 1 < s.length) func(result, start + 1) else result
    }
    val result = ListBuffer.empty[Int]
    func(result, 0).toList
  }

  def isExist(index: Int, targets: Set[Int], lens: Map[Int, Int], dict: Map[Int, Set[Int]]): Boolean = {
    if (targets.isEmpty) {
      return true
    }

    if (dict.contains(index)) {
      val intersect = dict(index).intersect(targets)
      intersect.size match {
        case i if i >= 1 =>
          for (i <- intersect) {
            return isExist(index + lens(i), targets - i, lens, dict)
          }
        case _ => ()
      }
    }
    false
  }


  def findSubstring(s: String, words: Array[String]): List[Int] = {
    val len = words.map(_.length).sum
    val lens = words.zipWithIndex.map({ case (str, i) => i -> str.length }).toMap
    val dict = words.zipWithIndex
      .map({ case (str, i) => i -> allIndexOf(s, str) })
      .flatMap({ case (i, list) => list.map(_ -> i) })
      .groupBy(_._1)
      .map({ case (i, tuples) => i -> tuples.map(_._2).toSet })

    val targets = words.indices.toSet
    Range.inclusive(0, s.length - len).filter(i => dict.contains(i) && isExist(i, targets, lens, dict)).toList
  }


}