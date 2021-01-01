open System

type String with
    member this.AllIndexOf0 (value: string) = 
        let rec func start list =
            match this.IndexOf(value, (start: int)) with
            | -1 -> list
            | i -> func (i+1) (i::list)
        func 0 []
    member this.AllIndexOf1 (value: string) =
        seq {
            let mutable i = this.IndexOf(value)
            while i <> -1 do
                yield i
                i <- this.IndexOf(value, i+1)
        } |> List.ofSeq
    member this.AllIndexOf value = this.AllIndexOf1 value

let findSubString (s: string) (words: string array) =
    let len = words |> Array.sumBy (fun word -> word.Length)
    let count = words |> Array.countBy id |> Map.ofArray

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    "barfoothefoobarman".AllIndexOf0 "foo" |> printfn "%A"
    "barfoothefoobarman".AllIndexOf1 "foo" |> printfn "%A"
    0 // return an integer exit code
