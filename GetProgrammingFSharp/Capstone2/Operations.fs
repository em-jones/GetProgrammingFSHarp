module GetProgrammingFSharp.Capstone2.Operations
open System
open Input

type Operation =
    | Withdraw
    | Deposit
    
type Command = Operation * float
let validateSelection v =
    match v with
    | 1 -> Ok Withdraw
    | 2 -> Ok Deposit
    | _ -> Error "Invalid operation, please try again!"
    
let rec getSelectionFrom selections validate =
    let prompt = Seq.map (fun (option, name) -> (sprintf "%i: %s" option name)) selections
                |> Seq.fold (fun options option -> (sprintf "%s\n%s" options option)) ""
    Console.WriteLine(sprintf "Please select an operation: \n%s" prompt)
    Console.ReadLine()
        |> int
        |> validate
        |> function
            | Ok result -> result
            | Error (e: string) ->
                Console.WriteLine(e)
                getSelectionFrom selections validate

let getOperation() = 
    getSelectionFrom [(1, "Withdraw"); (2, "Deposit")] validateSelection
let getAmountFor (operation: Operation) =
    let amount = promptFor "amount" |> float
    (operation, amount)
let getOperationAndAmount() = getOperation() |> getAmountFor
