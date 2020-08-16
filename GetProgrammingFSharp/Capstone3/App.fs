module GetProgrammingFSharp.Capstone3.App

open System
open Operations
open Domain
open Auditing

let isStopCommand _ = false
let main()=
    let name =
        Console.Write "Please enter your name: "
        Console.ReadLine()

    let withdrawWithAudit = auditAs "withdraw" composedLogger withdraw
    let depositWithAudit = auditAs "deposit" composedLogger deposit

    let openingAccount = { Owner = { Name = name }; Balance = 0M; AccountId = Guid.Empty } 

    let closingAccount =
        let commands = ['d'; 'w'; 'z'; 'f'; 'd'; 'x'; 'w']
        
        commands
        |> Seq.filter isValidCommand
        |> Seq.takeWhile (not << isStopCommand)
        |> Seq.map getAmount
        |> Seq.fold processCommand openingAccount

    Console.Clear()
    printfn "Closing Balance:\r\n %A" closingAccount
    Console.ReadKey() |> ignore

    0