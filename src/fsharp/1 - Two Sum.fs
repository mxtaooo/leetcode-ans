module Solution

let twoSum (array: int[]) target = 
    let dict = array |> Seq.mapi (fun index num -> (num, index)) |> Map.ofSeq
    array
    |> Seq.mapi (fun index num -> (num, index))
    |> Seq.tryFind (fun (num, index) -> dict.ContainsKey(target - num) && dict.[target - num] <> index)
    |> Option.map (fun (num, index) -> [|index; dict.[target - num]|])
    |> Option.get

let print array target = 
    let result = twoSum array target
    printfn "[%d, %d]" result.[0] result.[1]

[<EntryPoint>]
let main argv =
    print [| 2; 7; 11; 15 |] 9
    print [| 3; 2; 4 |] 6
    print [| 3; 3 |] 6
    0
