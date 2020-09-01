package leetcode

object Solution {

  def twoSum(nums: Array[Int], target: Int): Array[Int] = {
    v3(nums, target)
  }

  def v1(nums: Array[Int], target: Int): Array[Int] = {
    for {i <- nums.indices
         j <- (i + 1) until nums.length
         if nums(i) + nums(j) == target} {
      return Array(i, j)
    }

    throw new IllegalArgumentException("no solution")
  }

  def v2(nums: Array[Int], target: Int): Array[Int] = {
    val map = collection.mutable.Map[Int, Int]()
    for (i <- nums.indices) {
      if (map.contains(target - nums(i))) {
        return Array(i, map(target - nums(i)))
      }
      map += nums(i) -> i
    }

    throw new IllegalArgumentException("no solution")
  }

  // 相对前两者，更Scala-Style的实现
  def v3(nums: Array[Int], target: Int): Array[Int] = {
    val map = nums.zipWithIndex.toMap
    nums.zipWithIndex
      .find({ case (num, index) => map.contains(target - num) && map(target - num) != index })
      .map({ case (num, index) => Array(index, map(target - num))})
      .get
  }

  def main(args: Array[String]): Unit = {
    @inline def print(nums: Array[Int], target: Int): Unit = {
      println(twoSum(nums, target).mkString("[", ", ", "]"))
    }

    print(Array[Int](2, 7, 11, 15), 9)
    print(Array[Int](3, 2, 4), 6)
    print(Array[Int](3, 3), 6)

  }
}
