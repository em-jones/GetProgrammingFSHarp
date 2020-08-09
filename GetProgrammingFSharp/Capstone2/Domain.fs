module GetProgrammingFSharp.Capstone2.Domain

open System
open Input
type Customer =
    { FirstName: string
      LastName: string
      UserName: string }

type Account =
    { Id: Guid
      Balance: float
      Customer: Customer }

let newCustomer (userName, firstName, lastName) =
    { FirstName = firstName
      LastName = lastName
      UserName = userName }
let getAccount balance customer =
    { Customer = customer
      Balance = balance
      Id = Guid.NewGuid() }

let loadCustomer() =
    let firstName = promptFor "first name"
    let lastName = promptFor "last name" 
    let userName = promptFor "username"
    let balance = promptFor "balance" |> float
    newCustomer(userName, firstName, lastName)
    |> getAccount balance
