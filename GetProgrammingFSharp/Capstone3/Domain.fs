namespace GetProgrammingFSharp.Capstone3

module Domain =
    open System

    type Customer = { Name: string }

    type Account =
        { AccountId: Guid
          Owner: Customer
          Balance: decimal }

    type ValidOperation =
        | Withdraw of char
        | Deposit of char

    type Transaction =
        { Result: Result<string, string>
          Operation: ValidOperation
          Timestamp: DateTime
          Amount: decimal}

    module Transactions =
        let private resultMessage transaction =
            match transaction.Result with
            | Ok _ -> true
            | Error _ -> false

        let operationToString transaction =
            match transaction.Operation with
            | Withdraw _ -> "Withdrawal"
            | Deposit _ -> "Deposit"

        let serialized transaction =
            sprintf
                "%O***%s***%M***%b"
                transaction.Timestamp
                (transaction |> operationToString)
                transaction.Amount
                (transaction |> resultMessage)
