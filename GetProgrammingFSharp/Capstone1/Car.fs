module GetProgrammingFSharp.Capstone1.Car

let strToLower (str: string) = str.ToLower()
let strNoWhiteSpace (str: string) = str.Split(' ') |> String.concat ""
let strToLowerAndNoWhiteSpace = strToLower >> strNoWhiteSpace

type Destination =
    | Home
    | Office
    | Stadium
    | GasStation
    static member Parse(v: string) =
        match (v |> strToLowerAndNoWhiteSpace) with
        | "home" -> Some(Home)
        | "office" -> Some(Office)
        | "stadium" -> Some(Stadium)
        | "gasstation" -> Some(GasStation)
        | _ -> None
let drive petrol distance =
    let gasAfterDriving = petrol - distance
    if gasAfterDriving > 0 then Some(gasAfterDriving) else None


let maybeDriveDistance petrol maybeDistance =
    match maybeDistance with
    | (Some (distance), op) ->
        drive petrol distance |> op
    | _ -> None

let addWhenAtGasSTation p = Option.map (fun v -> v + 50) p

let maybeDistance destination =
    destination
    |> function
    | Some (Home) -> (Some(25), id)
    | Some (Office) -> (Some(50), id)
    | Some (Stadium) -> (Some(25), id)
    | Some (GasStation) -> (Some(10), addWhenAtGasSTation)
    | _ -> (None, id)

let driveTo (petrol, destination) = (maybeDistance destination) |> (maybeDriveDistance petrol)
