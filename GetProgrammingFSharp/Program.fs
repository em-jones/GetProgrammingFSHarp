// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
let main argv =
    let items = argv.Length
    printfn "Hello World from F#! \n"
    printfn "passed in %d items: %A" items argv
    0 // exit code
