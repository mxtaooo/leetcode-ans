
open System

// more F#-smell
let solveSudoku (board: char array array) = 
    // 将二维数组转换成坐标及值的序列
    let seq = seq {
        let mutable row = 0
        while row < 9 do
            let mutable column = 0
            while column < 9 do
                yield ((row, column), board.[row].[column])
                column <- column + 1
            row <- row + 1
    }

    // 找出当前空白位置的所有可行候选者
    let candidates row column = 
        if board.[row].[column] <> '.' then ArgumentException($"position ({row},{column}) not empty.") |> raise
        let (top, left) = (row/3, column/3)
        let pred (r, c) = r = row || c = column || (r / 3 = top && c / 3 = left)
        let total = ['1';'2';'3';'4';'5';'6';'7';'8';'9'] |> Set.ofList
        let other = seq |> Seq.filter (fst >> pred) |> Seq.map snd |> Set.ofSeq
        total - other

    // 填上所有“单候选”空白位置
    // 某空白位置被填入后，会立即影响其它空白位置的取值，因此必须循环执行、最终到达一个不动点
    let fillFixed () =
        let isSingle set = set |> Set.count = 1
        let head set = set |> Set.toSeq |> Seq.head
        let position = seq |> Seq.tryFind (fun ((row, column), char) -> char = '.' && candidates row column |> isSingle) |> Option.map fst
        match position with
        | Some (row, column) -> board.[row].[column] <- candidates row column |> head; true
        | None -> false

    // 递归对“多候选”空白位置进行尝试、最终命中结果
    let rec solve () =
        let position = seq |> Seq.tryFind (snd >> fun char -> char = '.') |> Option.map fst
        match position with
        | Some (row, column) ->
            let correct =
                candidates row column
                |> Seq.filter (fun c -> board.[row].[column] <- c; solve())
                |> Seq.tryHead
            match correct with
            | Some c -> board.[row].[column] <- c; true
            | None -> board.[row].[column] <- '.'; false
        | _ -> false

    while fillFixed () do ()
    solve () |> ignore

// just convert C# code
let solveSudoku (board: char array array): unit = 
    // 找出当前空白位置的所有可行候选者
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
    // 填上所有“单候选”空白位置
    // 某空白位置被填入后，会立即影响其它空白位置的取值，因此必须循环执行、最终到达一个不动点
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
    // 递归对“多候选”空白位置进行尝试、最终命中结果
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