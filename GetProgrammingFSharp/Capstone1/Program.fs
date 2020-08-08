module GetProgrammingFSharp.Capstone1.Program
open System
open Car

let getDestination() =
    Console.Write("Enter destination: ")
    Console.ReadLine()

let rec mainCapstone1 petrol =
        try
            let destination = getDestination()
            printfn "Trying to drive to %s" destination
            driveTo(petrol, (destination |> Destination.Parse) )
            |> function
                | Some(result) ->
                    printfn "Made it to %s! You have %d petrol left" destination result
                    mainCapstone1 result
                | None ->
                    printfn "Not able to drive. Please provide an accurate destination or one within range"
                    mainCapstone1 petrol
        with ex ->
            printfn "ERROR: %s" ex.Message
            100
    