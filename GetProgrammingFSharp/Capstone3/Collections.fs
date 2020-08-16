module GetProgrammingFSharp.Capstone3.Collections

open System.Collections.Generic

type FootballResult =
    { HomeTeam: string
      AwayTeam: string
      HomeGoals: int
      AwayGoals: int }

type TeamSummary = { Name: string; AwayWins: int }

let create (ht, hg) (at, ag) =
    { HomeTeam = ht
      AwayTeam = at
      HomeGoals = hg
      AwayGoals = ag }



let isAwayWin fResult = fResult.AwayGoals > fResult.HomeGoals
let awayTeam r = r.AwayTeam

[ create ("Messiville", 1) ("Ronaldo City", 2)
  create ("Messiville", 1) ("Bale Town", 3)
  create ("Bale Town", 3) ("Ronaldo City", 1)
  create ("Bale Town", 2) ("Messiville", 1)
  create ("Ronaldo City", 4) ("Messiville", 2)
  create ("Ronaldo City", 1) ("Bale Town", 2) ]
|> Seq.filter isAwayWin
|> Seq.countBy (awayTeam)
|> Seq.sortByDescending (fun (_, awayWins) -> awayWins)
|> printfn "%A"


// Lists
let numbers = [ 1; 2; 3; 4; 5; 6 ]
let numbersRange = [ 1 .. 6 ]
let h :: t = numbers
let moreNumbers = 0 :: numbers
let appendedNumbers = numbers @ [ 7 .. 9 ]

type Order = { OrderId: int }

type Customer =
    { CustomerId: int
      Orders: Order list
      Town: string }

let customer (id: int, town: string) =
    { CustomerId = id
      Orders = []
      Town = town }

let order id = { OrderId = id }
let customerOrders (customer, orders) = { customer with Orders = orders }

let customers: Customer list =
    [ customer (1, "Chicago")
      customer (2, "Lakeview")
      customer (3, "Boystown") ]
    |> List.map (fun c -> customerOrders (c, [ order (1); order (2) ]))
let orders = customers |> List.collect(fun c -> c.Orders) // flatMap

// Dictionary

open System.Collections.Generic
let inventory: IDictionary<_, _> = ["Apples", 20; "Oranges", 40; "Bananas", 10] |> dict

let bananas = inventory.["Bananas"]
inventory.Add("Pineapples", 10) // exception cannot be mutated -> immutable key value pairs are Maps
inventory.Remove("Bananas")

// Map
let inventoryMap = ["Apples", 20; "Oranges", 40; "Bananas", 10] |> Map.ofList
printfn "Inventory map is shape %A" inventoryMap
let logFindings itemType = function
    | Some(v) -> printfn "%s found: %i" itemType v
    | None -> printfn "%s not found" itemType

let apples = inventoryMap.TryFind("Apples")
apples |> logFindings "Apples"
let pineapples = inventoryMap.TryFind("Pineapples")
pineapples |> logFindings "Pineapples"
let addPineapplesAndRemoveApples = Map.add "Pineapples" 87 >> Map.remove "Apples"
let newInventory =
    inventoryMap
    |> addPineapplesAndRemoveApples
    
printfn "Immutable map is still shape %A" inventoryMap
printfn "New inventory immutable map without apples: %A" newInventory

// Set
let myBasket = ["Apples"; "Apples"; "Bananas"; "Carp"; "Spinach"] |> Set.ofList
printfn "Ems basket: %A" myBasket
let emmasBasket = ["Peaches"; "Apples"; "Broccoli"] |> Set.ofList
printfn "Emmas basket: %A" emmasBasket
let itemsWeBothGot = myBasket |> Set.intersect emmasBasket
printfn "Items we both got: %A" itemsWeBothGot

let itemsEmmaDidntGet = myBasket - emmasBasket
printfn "Items I got that emma didnt: %A" itemsEmmaDidntGet

// Fold Operations

//    foldBack—Same as fold, but goes backward from the last element in the collection.
//    mapFold—Combines map and fold, emitting a sequence of mapped results and a final state.
//    reduce—A simplified version of fold, using the first element in the collection as the initial state, so you don’t have to explicitly supply one. Perfect for simple folds such as sum (although it’ll throw an exception on an empty input—beware!)
//    scan—Similar to fold, but generates the intermediate results as well as the final state. Great for calculating running totals.
//    unfold—Generates a sequence from a single starting state. Similar to the yield keyword.

// Sequences
let flatSequence = seq { for i in 1 .. 10 do i * i } // has an implicit yield between 'do' and i * i
let flatSequenceNoDo = seq {for i in 1 .. 10 -> i * i} // can use -> for last returned value
let height, width = 10, 10

let nestedSequence = seq {
    for row in 0 .. width - 1 do
        for col in 0 .. height - 1 ->
            (row, col, row * width + col)
}