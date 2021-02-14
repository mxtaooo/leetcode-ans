
open System

let solveSudoku (board: char array array): unit = 
    let candidates row column = 
        if board.[row].[column] <> '.' then ArgumentException($"position ({row},{column}) not empty.") |> raise
        let mutable set = ['1';'2';'3';'4';'5';'6';'7';'8';'9'] |> Set.ofList
        for i = 0 to 8 do
            set <- set.Remove board.[row].[i]
            set <- set.Remove board.[i].[column]
        let (top, left) = (row / 3 * 3, column / 3 * 3)
        for i = 0 to 2 do
            for j = 0 to 2 do 
                set <- set.Remove board.[top+i].[left+j]
        set
    let fillFixed () =
        let mutable changed = false
        for i = 0 to 8 do
            for j = 0 to 8 do
                if board.[i].[j] = '.' then
                    let candidates = candidates i j
                    if candidates.Count = 1 then
                        board.[i].[j] <- candidates |> Set.toList |> List.head
                        changed <- true
        changed
    let rec solve () =
        let mutable row = -1
        let mutable column = -1
        for i = 0 to 8 do
            for j = 0 to 8 do
                if board.[i].[j] = '.' then
                    row <- i
                    column <- j
        if row <> -1 then
            let candidates = candidates row column
            if candidates.IsEmpty |> not then 
                let mutable succ = false
                for c in candidates do
                    if not succ then board.[row].[column] <- c
                    if not succ && solve() then succ <- true
                if not succ then board.[row].[column] <- '.'
                succ
            else false
        else false
    while fillFixed() do 
    solve() |> ignore


[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let board = [|
        [|'5';'3';'.';'.';'7';'.';'.';'.';'.'|];
        [|'6';'.';'.';'1';'9';'5';'.';'.';'.'|];
        [|'.';'9';'8';'.';'.';'.';'.';'6';'.'|];
        [|'8';'.';'.';'.';'6';'.';'.';'.';'3'|];
        [|'4';'.';'.';'8';'.';'3';'.';'.';'1'|];
        [|'7';'.';'.';'.';'2';'.';'.';'.';'6'|];
        [|'.';'6';'.';'.';'.';'.';'2';'8';'.'|];
        [|'.';'.';'.';'4';'1';'9';'.';'.';'5'|];
        [|'.';'.';'.';'.';'8';'.';'.';'7';'9'|]
    |]
    printfn "%A" board

    solveSudoku board

    printfn "%A" board

    0