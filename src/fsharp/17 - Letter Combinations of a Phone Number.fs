module Solution

let private map = 
    [('2', ['a'; 'b'; 'c']); ('3', ['d'; 'e'; 'f']); ('4', ['g'; 'h'; 'i']); ('5', ['j'; 'k'; 'l']); ('6', ['m'; 'n'; 'o']); ('7', ['p'; 'q'; 'r'; 's']); ('8', ['t'; 'u'; 'v']); ('9', ['w'; 'x'; 'y'; 'z'])]
    |> Map.ofList

let private append list chars = 
    match list with
    | [] -> chars |> List.map (fun c -> sprintf "%c" c)
    | _ -> (list, chars) ||> List.allPairs |> List.map (fun (s, c) -> sprintf "%s%c" s c)

let private innerFn = function
    | [c] -> map.[c] |> append []
    | [c1; c2] -> append (map.[c1] |> append []) map.[c2]
    | [c1; c2; c3] -> append (append (map.[c1] |> append []) map.[c2]) map.[c3]
    | [c1; c2; c3; c4] -> append (append (append (map.[c1] |> append []) map.[c2]) map.[c3]) map.[c4]
    | chars -> failwithf "Not Implement for %A" chars

let resolve (digits: string) = digits |> List.ofSeq |> innerFn

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    resolve "23" |> printfn "%A"
    resolve "2345" |> printfn "%A"
    resolve "23456" |> printfn "%A"
    0 // return an integer exit code