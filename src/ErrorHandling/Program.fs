// Learn more about F# at http://fsharp.org

open System
open Cvdm.ErrorHandling

type User = {
    Name: string
}

let tryGetUser str = Some { Name = str }
let isPwdValid pass user = user.Name = "wk" && pass = "wk"

type LoginError = InvlidUser | InvalidPwd | Unauthroized of string

[<EntryPoint>]
let main argv =

    result {
        let! user = tryGetUser "wk" |> Result.requireSome InvlidUser
        let! passOk = isPwdValid "wu" user |> Result.requireTrue InvalidPwd
        return passOk
    }
    |> printfn "%A"

    0 // return an integer exit code
