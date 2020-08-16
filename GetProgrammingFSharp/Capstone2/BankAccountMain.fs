module GetProgrammingFSharp.Capstone2.BankAccountMain
open Domain
open Operations
open Auditing
open System

let creditToAccount amount account =
    {account with Balance = account.Balance + amount}
let debitFromAccount amount = creditToAccount -amount
let validateTransaction (account: Account) (operation, amount) =
    match operation with
    | Withdraw -> if account.Balance > amount then
        Ok (debitFromAccount amount account) else
            Error "Not Enough $$$"
    | Deposit -> Ok (creditToAccount amount account)
    
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