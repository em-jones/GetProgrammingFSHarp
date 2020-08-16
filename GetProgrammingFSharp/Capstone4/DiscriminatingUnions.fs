module GetProgrammingFSharp.Capstone4.DiscriminatingUnions

type MMCDisk =
    | RSMMC
    | MMCPlus
    | SecureMMC
type RPM = int
type Platters = int
type Disk =
    | HardDisk of RPM: int * Platters: int
    | SolidState
    | MMC of MMCDisk * NumberOfPins: int

let hardDisk = HardDisk(RPM = 250, Platters = 7)
let myHardDiskShort = HardDisk(250, 5)
let args = 250, 2
let myHardDiskTupled = HardDisk args
let myMMC = MMC(RSMMC, 5)
let mySsd = SolidState

let discs: Disk list =
    [ hardDisk
      myHardDiskShort
      myHardDiskTupled
      myMMC
      mySsd ]

discs
|> List.iter (fun disk ->
    match disk with
    | HardDisk (rpm, platters) -> printfn "Hard disk with rpm %i and platters %i" rpm platters
    | SolidState -> printfn "Solid state"
    | MMC (_, pins) -> pins |> (printfn "MMC pins: %i"))

// enums
type Printer =
    | Inkjet = 0
    | Laserjet = 1
    | DotMatrix = 2