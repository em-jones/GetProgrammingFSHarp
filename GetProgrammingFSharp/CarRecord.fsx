type CarDoor =
    | Front
    | Rear
    | HatchBack

type Trunk = HatchBack

type Car =
    { Manufacturer: string
      EngineSize: float
      Doors: CarDoor []
      Trunk: Trunk }

let car = {
    Manufacturer    = "BMW"
    EngineSize      = 100.0
    Doors           = [|Front; Front; Rear; Rear;|]
    Trunk           = HatchBack
}
let car2 = {
    Manufacturer    = "BMW"
    EngineSize      = 100.0
    Doors           = [|Front; Front; Rear; Rear;|]
    Trunk           = HatchBack
}

let carsAreEqual c1 c2 = c1 = c2
let manufacturedBy manufacturer item =
    {item with Manufacturer = manufacturer}
    
let manufacturedByMercedes = manufacturedBy "Mercedes"
let manufacturedByBmw = manufacturedBy "BMW"

 
carsAreEqual {car with Manufacturer = "Mercedes"} (car |> manufacturedByMercedes) // true
carsAreEqual {car with Manufacturer = "Mercedes"} (car |> manufacturedByBmw) // false


