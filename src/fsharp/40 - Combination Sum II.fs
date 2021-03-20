open System

let combinationSumII (ints: int array) target = 
    let mutable result = []
    let rec dfs target (combine: int list) idx =
        if target = 0 then result <- combine :: result
        elif idx = ints.Length then ()
        else
            dfs target combine (idx + 1)
            if target >= ints.[idx] then
                dfs (target - ints.[idx]) (ints.[idx] :: combine) (idx + 1)
            else ()
    dfs target [] 0
    result |> List.map List.sort |> List.distinct

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"

    ([|10;1;2;7;6;1;5|], 8) ||> combinationSumII |> printfn "%A"
    ([|2;3;5|], 8) ||> combinationSumII |> printfn "%A"
    ([|2;5;2;1;2|], 5) ||> combinationSumII |> printfn "%A"
    ([|2|], 1) ||> combinationSumII |> printfn "%A"
    ([|1|], 1) ||> combinationSumII |> printfn "%A"
    ([|1|], 2) ||> combinationSumII |> printfn "%A"

    0