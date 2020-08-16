module GetProgrammingFSharp.Capstone4.ControlFlow

type Department = Engineering | Sales | CA
type Employee =
    {
        EmployeeId : int
        FirstName : string
        LastName : string
        Department : Department
    }

// Loops
// for-each for <binding> in <collection> do <code> 
// Comprehensions
open System
let aToZ = [|'a' .. 'z'|]
let arrayOfChars = [| for c in aToZ -> Char.ToUpper c |]
let arrayOfMappedChars = aToZ |> Array.map Char.ToUpper
printfn "Array of chars: %A" arrayOfChars
printfn "Array of mapped chars: %A" arrayOfMappedChars

// Pattern matching
// collections
let handleCustomers customers =
    match customers with
    | [] -> Error "No customers supplied"
    | [ customer ] -> Ok "single customer"
    | [ first; second ] -> Ok "only two customers"
    | customers -> Ok (sprintf "Customers supplied: %i" customers.Length)
    

// records
let seeIfEmployeeIsId1 employee =
    match employee with
    | { EmployeeId = 1 } -> "Employee is first employee"
    | { EmployeeId = id } -> (sprintf "Employee is %s" (id.ToString()))

// tuples
let getCreditLimit customer =
    match customer with
    | "medium", 1 -> 500
    | "good", years when years < 2 -> 750 // guards
    
// nesting
let getCreditLimitNested customer =
    match customer with
    | "medium", 1 -> 500
    | "good", years ->
        match years with // nested
        | 0 | 1 -> 750
        | 2 -> 1000
        | _ -> 2000
    | _ -> 250 