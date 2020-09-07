module Solution

open System.Collections.Generic

let V1 (array: int[]) target = 
    let mutable result = null
    for i = 0 to (array.Length - 1) do
        for j = 0 to (array.Length - 1) do
            if array.[i] + array.[j] = target then result <- [| i; j|]
    result

let V2 (array: int[]) target =
    let mutable result = null
    let mutable found = false
    let dict = new Dictionary<int, int>()
    for i = 0 to (array.Length - 1) do
        if not found then
            if dict.ContainsKey(target - array.[i]) then
                found <- true
                result <- [| i; dict.[target - array.[i]] |]
            else
                dict.TryAdd(array.[i], i) |> ignore
    result

// 更具F#自身特色的实现
let V3 (array: int[]) target = 
    let dict = array |> Seq.mapi (fun index num -> (num, index)) |> Map.ofSeq
    array
    |> Seq.mapi (fun index num -> (num, index))
    |> Seq.tryFind (fun (num, index) -> dict.ContainsKey(target - num) && dict.[target - num] <> index)
    |> Option.map (fun (num, index) -> [|index; dict.[target - num]|])
    |> Option.get

let twoSum array target = v1 array target

let print array target = 
    let result = twoSum array target
    printfn "[%d, %d]" result.[0] result.[1]

[<EntryPoint>]
let main argv =
    print [| 2; 7; 11; 15 |] 9
    print [| 3; 2; 4 |] 6
    print [| 3; 3 |] 6
    0
