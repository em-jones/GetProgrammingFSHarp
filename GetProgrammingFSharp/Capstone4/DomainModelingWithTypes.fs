module GetProgrammingFSharp.Capstone4.DomainModelingWithTypes

type Customer = {
    CustomerId: string
    Email : string
    Phone : string
}

let createCustomer id email phone = {CustomerId = id; Email = email; Phone = phone}
// nothing stops us from going out of order
let id = "1"
let email = "913.961.5921"
let phone = "emjonesdev@gmail.com"
let customerWithEmailAsPhone = createCustomer id email phone 

type Email = Email of string
type Phone = Phone of string
type Id = Id of string

type SafeCustomer = {
    CustomerId : Id
    Email : Email
    Phone : Phone
}

let createSafeCustomer id email phone = {CustomerId = id; Email = email; Phone = phone}
let customerId = Id "1"
let customerEmail = Email "emjonesdev@gmail.com"
let customerPhone = Phone "913.961.5921"
let safelyBuiltCustomer = createSafeCustomer customerId customerEmail customerPhone

type ContactInfo =
    | Email of string
    | Phone of string
type SafeCustomerWithOneRequiredContact = {
    CustomerId : Id
    PrimaryContact : ContactInfo
    SecondaryContact : ContactInfo option
}

let emsEmail = Email "emjonesdev@gmail.com"
let emsId = Id "1"
let emThatDoesntWantPhoneCalls = {CustomerId = emsId; PrimaryContact = emsEmail; SecondaryContact = None}

type GenuineCustomer = GenuineCustomer of SafeCustomerWithOneRequiredContact

let validateCustomer customer =
    match customer.PrimaryContact with
    | Email e when e.EndsWith "gmail.com" -> Some(GenuineCustomer customer)
    