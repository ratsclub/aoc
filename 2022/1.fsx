open System.IO

let input = File.ReadLines("1.txt")

module List =
    let rec tryTake n xs =
        if xs = [] then []
        else
            if List.length xs <= n
            then xs
            else tryTake n (List.tail xs)

let solveOne x =
    x
    |> List.map (List.sum)
    |> List.max

let solveTwo x =
    x
    |> List.map (List.sum)
    |> List.sort
    |> List.tryTake 3
    |> List.sum

let read input =
    let rec loop lines acc groups =
        match lines with
        | ""::r -> loop r [] (acc::groups)
        | x::r -> loop r ((x |> int)::acc) groups
        | [] -> acc::groups
    loop input [] []

(List.ofSeq >> read) input 
|> solveOne
|> printfn "%A"

(List.ofSeq >> read) input 
|> solveTwo
|> printfn "%A"