module GetProgrammingFSharp.Capstone2.BankAccountMain
open Domain
open Operations
open Auditing
open System

let creditToAccount account amount =
    {account with Balance = account.Balance + amount}
let debitFromAccount account amount = creditToAccount account -amount
let validateTransaction (account: Account) (operation, amount) =
    match operation with
    | Withdraw -> if account.Balance > amount then
        Ok (debitFromAccount account amount) else
            Error "Not Enough $$$"
    | Deposit -> Ok (creditToAccount account amount)
    
let adjust account (operation, amount) =
    validateTransaction account (operation, amount)
    
let rec run auditor account =
        let operationAndAmount = getOperationAndAmount()
        actionMessage account operationAndAmount |> auditor
        adjust account operationAndAmount
        |> function
            | Ok updatedAccount ->
                successMessage updatedAccount |> auditor
                run auditor updatedAccount
            | Error e ->
                errorMessage account (snd operationAndAmount)
                run auditor account                        
let runBankAccount auditor =
    loadCustomer()
    |> run auditor