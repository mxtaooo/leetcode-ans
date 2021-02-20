open System
open System.Collections.Generic

let combinationSum ints target = 
    let raw = Set.ofArray ints
    let dict = new Dictionary<int, HashSet<int list>>()
    for i = 1 to target do
        let set = new HashSet<int list>()
        for j = 1 to i/2 do
            if dict.ContainsKey(j) && dict.ContainsKey(i-j) then
                for jl in dict.[j] do
                    for ol in dict.[i-j] do
                        jl @ ol |> List.sort |> set.Add |> ignore
        if raw.Contains(i) then set.Add([i]) |> ignore
        if set.Count > 0 then dict.[i] <- set
    dict.GetValueOrDefault(target, new HashSet<int list>()) |> List.ofSeq

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"

    ([|2;3;5|], 8) ||> combinationSum |> printfn "%A"
    ([|2|], 1) ||> combinationSum |> printfn "%A"
    ([|1|], 1) ||> combinationSum |> printfn "%A"
    ([|1|], 2) ||> combinationSum |> printfn "%A"

    0
