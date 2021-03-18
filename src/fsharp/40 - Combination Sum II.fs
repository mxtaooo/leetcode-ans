open System
open System.Collections.Generic

// let combinationSum ints target = 
//     let raw = Set.ofArray ints
//     let dict = new Dictionary<int, HashSet<int list>>()
//     for i = 1 to target do
//         let set = new HashSet<int list>()
//         for j = 1 to i/2 do
//             if dict.ContainsKey(j) && dict.ContainsKey(i-j) then
//                 (dict.[j], dict.[i-j])
//                 ||> Seq.allPairs
//                 |> Seq.map (fun (l1, l2) -> l1 @ l2 |> List.sort)
//                 |> Seq.iter (fun list -> set.Add(list) |> ignore)
//         if raw.Contains(i) then set.Add([i]) |> ignore
//         if set.Count > 0 then dict.[i] <- set
//     dict.GetValueOrDefault(target, new HashSet<int list>()) |> List.ofSeq

let combinationSumII (ints: int array) target = 
    let result = new HashSet<int list>()
    let rec dfs target (combine: int list) idx =
        if target = 0 then result.Add(combine |> List.sort) |> ignore; ()
        elif idx = ints.Length then ()
        else
            dfs target combine (idx + 1)
            if target >= ints.[idx] then
                dfs (target - ints.[idx]) (ints.[idx] :: combine) idx
            else ()
    dfs target [] 0
    result

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"

    ([|2;3;5|], 8) ||> combinationSumII |> printfn "%A"
    ([|10;1;2;7;6;1;5|], 8) ||> combinationSumII |> printfn "%A"
    ([|2;5;2;1;2|], 5) ||> combinationSumII |> printfn "%A"
    ([|1|], 1) ||> combinationSumII |> printfn "%A"
    ([|1|], 2) ||> combinationSumII |> printfn "%A"

    0