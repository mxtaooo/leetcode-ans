open System

// 为String类型扩展方法
type String with
    // 尾递归函数实现
    member this.AllIndexOf0 (value: string) = 
        let rec func start list =
            match this.IndexOf(value, (start: int)) with
            | -1 -> list
            | i -> func (i+1) (i::list)
        func 0 []
    // 序列生成式实现
    member this.AllIndexOf1 (value: string) =
        seq {
            let mutable i = this.IndexOf(value)
            while i <> -1 do
                yield i
                i <- this.IndexOf(value, i+1)
        } |> List.ofSeq
    member this.AllIndexOf value = this.AllIndexOf1 value

let findSubString (s: string) (words: string array) =
    // 所有单词总长度
    let len = words |> Array.sumBy (fun word -> word.Length)
    // 各单词需要出现的次数
    let count = words |> Array.countBy id |> Map.ofArray
    // 单词及其在句子中出现的位置
    let map = words |> Array.map (fun word -> (word, s.AllIndexOf(word) |> Set.ofList)) |> Map.ofArray
    // 尾递归实现、测试指定位置是否能匹配一个目标词、直到“吃掉”所有词语、此时便能保证所有单词完成连接
    let rec exist index (count: Map<string, int>) =
        if count.IsEmpty then true else 
            let hitted = map |> Map.filter (fun word indexes -> indexes.Contains(index) && count.ContainsKey(word))
            if hitted.IsEmpty then false else 
                let word = hitted |> Map.toSeq |> Seq.head |> fst
                let next = if count.[word] = 1 then count.Remove(word) else count.Add (word, count.[word]-1)
                exist (index+word.Length) next
    seq { for i in 0 .. s.Length-len+1 do if exist i count then yield i } |> List.ofSeq

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    //"barfoothefoobarman".AllIndexOf0 "foo" |> printfn "%A"
    //"barfoothefoobarman".AllIndexOf1 "foo" |> printfn "%A"
   
    ("barfoothefoobarman", [| "foo"; "bar" |]) ||> findSubString |> printfn "%A"
    ("wordgoodgoodgoodbestword", [| "word"; "good"; "best"; "word" |]) ||> findSubString |> printfn "%A"
    ("barfoofoobarthefoobarman", [| "bar"; "foo"; "the" |]) ||> findSubString |> printfn "%A"

    0 // return an integer exit code
