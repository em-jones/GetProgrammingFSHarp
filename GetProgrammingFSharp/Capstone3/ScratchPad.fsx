open GetProgrammingFSharp.Capstone3

#load "Domain.fs"
#load "Operations.fs"

open Domain
open System
let intToStr (v: int) = sprintf "%i" v
let strLen v = (string v).Length
let intStringLength = intToStr >> strLen
let stringLengthAsIntString = intToStr << strLen
let strLen1000 = intStringLength 1000 // 4
let numCharInHello = stringLengthAsIntString "Hello" // "5"

let isValidCommand c = ['w'; 'd'; 'x'] |> List.contains c
let isStopCommand = (=) 'x'
let getAmount c =
    (c, Console.ReadLine())
    
let processCommand (c, amount) =
    
let name =
        Console.Write "Please enter your name: "
        Console.ReadLine()
let openingAccount = { Owner = { Name = name }; Balance = 0M; AccountId = Guid.Empty } 
let closingAccount =
   let commands = ['d'; 'w'; 'z'; 'f'; 'd'; 'x'; 'w']
   
   commands
   |> Seq.filter isValidCommand
   |> Seq.takeWhile (not << isStopCommand)
   |> Seq.map getAmount
   |> Seq.fold processCommand openingAccount