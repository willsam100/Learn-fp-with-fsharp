module Program

open System
open Xunit
open LearnFP.Core
open FsUnit
open Utils

open Microsoft.FSharp.Quotations

let nameof (q:Expr<_>) = 
  match q with 
  | Patterns.Let(_, _, DerivedPatterns.Lambdas(_, Patterns.Call(_, mi, _))) -> mi.Name
  | Patterns.PropertyGet(_, mi, _) -> mi.Name
  | DerivedPatterns.Lambdas(_, Patterns.Call(_, mi, _)) -> mi.Name
  | _ -> failwith "Unexpected format"

type LessonsResult = 
    | InComplete of string
    | StillLearning of string
    | Learnt of string


let teach message learntMessage f = 
    try 
        f () 
        sprintf "%s" learntMessage |> Learnt
    with 
    | NotCompleted name -> InComplete name
    | _ -> message |> StillLearning

type Lesson = {
    ErrorMessage:string
    CompletedMessage:string
    RunLesson: unit -> unit
}

module ReadingFunctions = 

    let ``Addone should add one`` =
        let readingFunctions = ReadingFunctions()
        {   
            ErrorMessage = "The function should return the value with 1 adding to it. You can use + to help"
            CompletedMessage =  sprintf "%s learnt" <| nameof <@ readingFunctions.AddOne @>
            RunLesson = fun () -> readingFunctions.AddOne(10) |> should equal 11
        }

    let ``SubtractOne should subract one`` =
        let readingFunctions = ReadingFunctions()
        {   
            ErrorMessage = "The function should return the value with 1 subtracted from it. You can use - to help"
            CompletedMessage =  sprintf "%s learnt" <| nameof <@ readingFunctions.SubtractOne @>
            RunLesson = fun () -> readingFunctions.SubtractOne(10) |> should equal 9 
        }

module Functions = 

    let ``identity should return the same input`` =
        {   
            ErrorMessage = "The function should return the input unchaged."
            CompletedMessage =  sprintf "%s learnt" <| nameof <@ Functions.identity @>
            RunLesson = fun () -> Functions.identity 10 |> should equal 10
        }

    let ``addTwo should add two`` =
        {   
            ErrorMessage = "The function should return the value with 1 adding to it. You can use + to help"
            CompletedMessage =  sprintf "%s learnt" <| nameof <@ Functions.addTwo @>
            RunLesson = fun () -> Functions.addTwo 10 |> should equal 12
        }

    let ``doubleIdentity should return the input unchanged`` =
        {
            ErrorMessage = "The function should return the input unchaged."
            CompletedMessage =  sprintf "%s learnt" <| nameof <@ Functions.doubleIdentity @>
            RunLesson = fun () -> Functions.doubleIdentity 10 |> should equal 10
        }

module PureFunctions = 

    let ``raiseToThePower to show return the pow of y applied to x`` = 
        {
            ErrorMessage = "The function should return x raised to the power of why. eg. 2.0 ** 2.0 = 4.08.8"
            CompletedMessage =  sprintf "%s learnt" <| nameof <@ PureFunctions.raiseToThePower @>
            RunLesson = fun () -> PureFunctions.raiseToThePower 8. 2. |> should equal 64
        }  

    let ``isFooAPureFunction is false`` = 
        {   
            ErrorMessage = "isFooAPureFunction is not correct. Please reconsider your answer. \n\tTime is always moving forward. Meothds that don't take in any args are typically not pure functions."
            CompletedMessage =  sprintf "%s learnt" <| nameof <@ PureFunctions.isFooAPureFunction @>
            RunLesson = fun () -> PureFunctions.isFooAPureFunction () |> should equal false
        }  

module HigherOrderFunctions = 

    let ``addOneHundred is true`` = 
        {   
            ErrorMessage = "f is a function the takes a function and runs it with the input. the indentity function returns the input."
            CompletedMessage =  sprintf "%s learnt" <| nameof <@ HigherOrderFunctions.addOneHundred @>
            RunLesson = fun () -> HigherOrderFunctions.addOneHundred () |> should equal 100
        }  

    let ``addTwenty is true`` = 
        {   
            ErrorMessage = "The following function adds 10. This function should add 20 (fun x -> x + 10) x"
            CompletedMessage =  sprintf "%s learnt" <| nameof <@ HigherOrderFunctions.addTwenty @>
            RunLesson = fun () -> HigherOrderFunctions.addTwenty 42 |> should equal (42 + 20)
        }


let [<EntryPoint>] main _ = 
    printfn "Assesing your progress...\n"

    let lessons = 
        [
            ReadingFunctions.``Addone should add one``
            ReadingFunctions.``SubtractOne should subract one``
            Functions.``identity should return the same input``
            Functions.``addTwo should add two``
            Functions.``doubleIdentity should return the input unchanged``
            PureFunctions.``raiseToThePower to show return the pow of y applied to x``
            PureFunctions.``isFooAPureFunction is false``
            HigherOrderFunctions.``addOneHundred is true``
            HigherOrderFunctions.``addTwenty is true``
        ] 

    let results = 
        lessons 
        |> List.map (fun x -> teach x.ErrorMessage x.CompletedMessage x.RunLesson)

    results 
    |> List.choose (function | Learnt m -> Some m | _ -> None)
    |> function
    | [] -> ()
    | xs ->
        printfn "well done on these:"
        xs |> List.iter (printfn "%s")
        printfn ""

    results 
    |> List.choose (function | StillLearning m -> Some m | _ -> None)
        |> function
    | [] -> ()
    | xs ->
        printfn "Keep trying on here:"
        xs |> List.iter (printfn "%s")
        printfn ""

    results 
    |> List.choose (function | InComplete m -> Some m | _ -> None)
        |> function
    | [] -> ()
    | xs ->
        printfn "There is always more to learn. Enjoy the journey"
        printfn "Start here:"
        xs |> List.truncate 1 |> List.iter (printfn "%s")
        printfn ""
    0
