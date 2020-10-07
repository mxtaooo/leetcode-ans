open System

let intToRoman number =
    // 尾递归以提升性能
    let rec innerFunc prefix num = 
        match num with
        | _ when num >= 1000 -> innerFunc (prefix + String('M', num / 1000)) (num % 1000)
        | _ when num >= 900 -> innerFunc (prefix + "CM") (num - 900)
        | _ when num >= 500 -> innerFunc (prefix + "D") (num - 500)
        | _ when num >= 400 -> innerFunc (prefix + "CD") (num - 400)
        | _ when num >= 100 -> innerFunc (prefix + String('C', num / 100)) (num % 100)
        | _ when num >= 90 -> innerFunc (prefix + "XC") (num - 90)
        | _ when num >= 50 -> innerFunc (prefix + "L") (num - 50)
        | _ when num >= 40 -> innerFunc (prefix + "XL") (num - 40)
        | _ when num >= 10 -> innerFunc (prefix + String('C', num / 10)) (num % 10)
        | _ when num >= 9 -> innerFunc (prefix + "IX") (num - 9)
        | _ when num >= 5 -> innerFunc (prefix + "V") (num - 5)
        | _ when num >= 4 -> innerFunc (prefix + "IV") (num - 4)
        | _ -> prefix + String('I', num)
    innerFunc String.Empty number

[<EntryPoint>]
let main argv =
    intToRoman 1 |> printfn "1 = %s"
    intToRoman 3 |> printfn "3 = %s"
    intToRoman 4 |> printfn "4 = %s"
    intToRoman 9 |> printfn "9 = %s"
    intToRoman 58 |> printfn "58 = %s"
    intToRoman 1994 |> printfn "1994 = %s"
    intToRoman 3999 |> printfn "3999 = %s"
    0
