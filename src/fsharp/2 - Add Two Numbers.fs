module Solution

// F#中只能用Option来表达“可空”
type ListNode(value: int, next: ListNode option) = 
    let mutable _value = value
    let mutable _next = next

    new() = ListNode(0, None)
    new(value: int) = ListNode(value, None)
    member _.Value 
        with get() = _value
        and set(value) = _value <- value
    member _.Next
        with get() = _next
        and set(value) = _next <- value
    member _.Print() = 
        printf "%d" value
        let mutable p = _next
        while p.IsSome do
            printf " -> "
            printf "%d" p.Value.Value
            p <- p.Value.Next
        printfn ""

    static member Build(array: int[]): ListNode = 
        let head = ListNode()
        let mutable p = head
        for i in array do
            p.Next <- Some(ListNode(i))
            p <- p.Next.Value
        head.Next.Value

// 这种实现非常的不F#，遍地mutable，拉胯
let addTwoNumbers (list1: ListNode) (list2: ListNode) =
    let mutable l1 = Some list1
    let mutable l2 = Some list2
    let mutable inc = 0
    let head = ListNode()
    let mutable pre = head
    while (l1.IsSome || l2.IsSome || inc <> 0) do
        let mutable value = inc
        value <- if l1.IsSome then value + l1.Value.Value else value
        l1 <- if l1.IsSome then l1.Value.Next else l1
        value <- if l2.IsSome then value + l2.Value.Value else value
        l2 <- if l2.IsSome then l2.Value.Next else l2
        inc <- value / 10
        pre.Next <- Some(ListNode(value % 10))
        pre <- pre.Next.Value
    head.Next.Value

[<EntryPoint>]
let main argv =
    let l1 = ListNode.Build [| 1; 2; 3; 4; 5 |]
    l1.Print()
    let l2 = ListNode.Build [| 5; 4; 3; 2; 1 |]
    l2.Print()
    let result = addTwoNumbers l1 l2
    result.Print()
    0