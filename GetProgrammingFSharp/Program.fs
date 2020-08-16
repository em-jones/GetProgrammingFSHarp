open GetProgrammingFSharp.Capstone2.Auditing
open GetProgrammingFSharp.Capstone2.BankAccountMain
module main = 
    [<EntryPoint>]
    let main argv =
//        mainCapstone1 100
            runBankAccount consoleAudit
