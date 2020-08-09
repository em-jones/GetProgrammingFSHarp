module GetProgrammingFSharp.Capstone2.Input
open System
let promptFor information =
    Console.Write(sprintf "Please enter your %s: " information)
    Console.ReadLine()
