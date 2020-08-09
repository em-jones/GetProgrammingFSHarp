module GetProgrammingFSharp.Capstone2.Auditing

open System
open Domain
open Operations
let fileStore (message: string) =
    Console.WriteLine(message)
    
let consoleStore (message: string) =
    Console.WriteLine(message)

let successMessage account =
    sprintf "Transaction accepted! Balance is now %.2f" account.Balance 
let actionMessage (account: Account) (operation, amount) =
    sprintf "Account: %A: Performing a %A for %.2f" account.Id operation amount
let errorMessage account amount = 
    sprintf "Transaction failed: balance %.2f is not enough to withdraw %.2f" account.Balance amount
    
let audit (store: string -> Unit) (message: string) =
    store(message)
    
let fileAudit = audit fileStore
let consoleAudit = audit consoleStore