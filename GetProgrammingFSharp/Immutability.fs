module GetProgrammingFSharp.Immutability

type Distance =
    | Short
    | Medium
    | Far

let mutable mPetrol = 100.0
let reportMutablePetrol distance =
    printfn "Mutable petrol after %A: %f" distance mPetrol
let mDrive distance =
    if distance = Far then mPetrol <- mPetrol / 2.0
    elif distance = Medium then mPetrol <- mPetrol / 1.5
    else mPetrol <- mPetrol - 1.0
    reportMutablePetrol distance
    
mDrive Far
mDrive Medium

let petrol = 100.0
let reportPetrol distance petrol =
    printfn "Petrol after %A: %f" distance petrol
let drive petrol distance =
    if distance = Far then petrol / 2.0
    elif distance = Medium then petrol / 1.5
    else petrol - 1.0 
let petrolAfterFar = drive petrol Far 
reportPetrol Far petrolAfterFar
let petrolAfterMedium = drive petrol Medium
reportPetrol Medium petrolAfterFar 