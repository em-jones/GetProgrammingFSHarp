module GetProgrammingFSharp.Capstone4.Option

// using values
let maybeFive = Some(5)
let maybeFour = None

let printInt maybeInt =
    match maybeInt with
    | Some v -> printfn "%i" v
    | None -> printfn "no value provided"

printInt maybeFive
printInt maybeFour
// mapping values
let times2 v = v * 2

let maybeTen = maybeFive |> Option.map times2
maybeTen.Value = 10
let maybe8 = maybeFour |> Option.map times2
maybeFour.IsNone = true

// binding / flatMapping
let maybeTimes2 v = Some(v * 10)

// allows us to treat input option as the value it would return
let maybeTenValue = maybeFive |> Option.bind maybeTimes2

// filtering

let valueGreaterThan4 =
    maybeFive |> Option.filter (fun v -> v > 4) // Some(5)

let valueGreaterThan5 =
    maybeFive |> Option.filter (fun v -> v > 5) // None

// Transform to list
let fiveList = maybeFive |> Option.toList // list [5]

// List.choose
let tryLoadCustomer id =
    match id with
    | id when id < 4 -> Some(sprintf "Customer %i" id)
    | _ -> None

let customerIdList = [ 1 .. 10 ]
let customerIdStringList = customerIdList |> List.choose tryLoadCustomer
printfn "%A" customerIdStringList
