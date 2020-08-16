module GetProgrammingFSharp.Capstone1.Operators

// Piping
let pipeForward = [| 1; 2; 3 |] |> Array.append [| 2 |]

let pipeBackward = Array.append [| 2 |] <| [| 1; 2; 3 |]

// Composition
let intToStr (v: int) = sprintf "%i" v
let strLen v = (string v).Length
let intStringLength = intToStr >> strLen
let stringLengthAsIntString = intToStr << strLen
let strLen1000 = intStringLength 1000 // 4
let numCharInHello = stringLengthAsIntString "Hello" // "5"

// Point-free style
let filterStaticArrayForGreaterThan x = [| 1 .. 10 |] |> Array.filter ((>=) x)
let safeSqRt: Option<float> -> Option<float> =
    Option.filter ((<=) 0.0) >> Option.map sqrt
    