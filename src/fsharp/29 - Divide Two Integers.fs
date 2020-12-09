open System

let divide dividend divisor =
    // 快速判断是否到达溢出临界点
    let half0 = Int32.MaxValue >>> 1
    let half1 = Int32.MinValue >>> 1
    // 映射到负整数域、规避溢出问题
    let inline negative x = if x > 0 then -x else x
    // 判断是否同号
    let inline same x y = (x > 0 && y > 0) || (x < 0 && y < 0)
    // 倍增被除数、减法实现除法、尾递归实现
    let rec fn value dividend divisor =
        if negative dividend > negative divisor then value
        else
            let mutable (k, v) = if (same dividend divisor) then (1, divisor) else (-1, -divisor)
            let mutable (pk, pv) = (k, v)
            while (v > 0 && dividend > v && v <= half0) || (v < 0 && dividend < v && v >= half1) do
                pk <- k
                pv <- v
                k <- k <<< 1
                v <- v <<< 1
            fn (value + pk) (dividend - pv) divisor
    match (dividend, divisor) with
    | (_, 1) -> dividend
    | (Int32.MinValue, -1) -> Int32.MaxValue
    | (_, -1) -> -dividend
    | _ -> fn 0 dividend divisor

[<EntryPoint>]
let main argv =
    (Int32.MaxValue, 2) ||> divide |> printfn "%d"
    (1100540749, -1090366779) ||> divide |> printfn "%d"
    (Int32.MaxValue / 2, Int32.MinValue) ||> divide |> printfn "%d"
    (Int32.MinValue, -3) ||> divide |> printfn "%d"
    (Int32.MaxValue, 3) ||> divide |> printfn "%d"
    (Int32.MinValue, 2) ||> divide |> printfn "%d"
    (Int32.MinValue, -1) ||> divide |> printfn "%d"
    (Int32.MinValue, 1) ||> divide |> printfn "%d"
    (10, 3) ||> divide |> printfn "%d"
    (-10, -3) ||> divide |> printfn "%d"
    (7, -3) ||> divide |> printfn "%d"
    (0, 1) ||> divide |> printfn "%d"
    (1, 1) ||> divide |> printfn "%d"
    (12, 3) ||> divide |> printfn "%d"
    (-12, -3) ||> divide |> printfn "%d"
    (12, -3) ||> divide |> printfn "%d"
    (-12, 3) ||> divide |> printfn "%d"
    0