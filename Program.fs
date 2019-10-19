module Program

open System
open LearnFP.Core
open FsUnit
open Utils
open Microsoft.FSharp.Quotations.Patterns
open Microsoft.FSharp.Core.Operators

let getModuleType = function
| PropertyGet (_, propertyInfo, _) -> propertyInfo.DeclaringType
| _ -> failwith "Expression is no property."

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
    Order: int * int
}

module ReadingFunctions = 
    let readingFunctions = ReadingFunctions()
    let rec moduleType = getModuleType <@ moduleType @>

    let ``Addone should add one`` =
        let readingFunctions = ReadingFunctions()
        {   
            ErrorMessage = "The function should return the value with 1 adding to it. You can use + to help"
            CompletedMessage =  sprintf "%s learnt" <| nameof readingFunctions.AddOne 
            RunLesson = fun () -> readingFunctions.AddOne(10) |> should equal 11
            Order = (1,1)
        }

    let ``SubtractOne should subract one`` =
        let readingFunctions = ReadingFunctions()
        {   
            ErrorMessage = "The function should return the value with 1 subtracted from it. You can use - to help"
            CompletedMessage =  sprintf "%s learnt" <| nameof  readingFunctions.SubtractOne
            RunLesson = fun () -> readingFunctions.SubtractOne(10) |> should equal 9 
            Order = (1,2)
        }

    let ``SubtractTwo should subract two`` =        
        {   
            ErrorMessage = "The function should return the value with 2 subtracted from it. You can use '-' to help"
            CompletedMessage =  sprintf "%s learnt" <| nameof  readingFunctions.SubtractTwo
            RunLesson = fun () -> readingFunctions.SubtractTwo(10) |> should equal 8
            Order = (1,2)
        }

    let ``identity should return the same input`` =
        {   
            ErrorMessage = "The function should return the input unchaged."
            CompletedMessage =  sprintf "%s learnt" <| nameof  Functions.identity
            RunLesson = fun () -> Functions.identity 10 |> should equal 10
            Order = (2,1)
        }

    let ``addTwo should add two`` =
        {   
            ErrorMessage = "The function should return the value with 1 adding to it. You can use + to help"
            CompletedMessage =  sprintf "%s learnt" <| nameof  Functions.addTwo 
            RunLesson = fun () -> Functions.addTwo 10 |> should equal 12
            Order = (2,2)
        }

    let ``consecutiveIdentity should return the input unchanged`` =
        {
            ErrorMessage = "The function should return the input unchaged."
            CompletedMessage =  sprintf "%s learnt" <| nameof  Functions.consecutiveIdentity 
            RunLesson = fun () -> Functions.consecutiveIdentity 10 |> should equal 10
            Order = (2,3)
        }

    let ``raiseToThePower to show return the pow of y applied to x`` = 
        {
            ErrorMessage = "The function should return x raised to the power of why. eg. 2.0 ** 2.0 = 4.08.8"
            CompletedMessage =  sprintf "%s learnt" <| nameof  PureFunctions.raiseToThePower 
            RunLesson = fun () -> PureFunctions.raiseToThePower 8. 2. |> should equal 64
            Order = (3,1)
        }  

    let ``isFooAPureFunction is true`` = 
        {   
            ErrorMessage = "isFooAPureFunction is not correct. Please reconsider your answer. \n\tTime is always moving forward. Meothds that don't take in any args are typically not pure functions."
            CompletedMessage =  sprintf "%s learnt" <| nameof  PureFunctions.isFooAPureFunction
            RunLesson = fun () -> PureFunctions.isFooAPureFunction () |> should equal true
            Order = (3,2)
        }  

    let ``addOneHundred is true`` = 
        {   
            ErrorMessage = "f is a function the takes a function and runs it with the input. the indentity function returns the input."
            CompletedMessage =  sprintf "%s learnt" <| nameof  HigherOrderFunctions.addOneHundred
            RunLesson = fun () -> HigherOrderFunctions.addOneHundred () |> should equal 100
            Order = (4,1)
        }  

    let ``addTwenty is true`` = 
        {   
            ErrorMessage = "The following function adds 10. This function should add 20 (fun x -> x + 10) x"
            CompletedMessage =  sprintf "%s learnt" <| nameof HigherOrderFunctions.addTwenty
            RunLesson = fun () -> HigherOrderFunctions.addTwenty 42 |> should equal (42 + 20)
            Order = (4,2)
        }

    let ``addOneInALoop is true`` = 
        {   
            ErrorMessage = "addOneInALoop should add 1 to each items in the loop"
            CompletedMessage =  sprintf "%s learnt" <| nameof PartialApplication.addOneInALoop
            RunLesson = fun () -> PartialApplication.addOneInALoop ()
            Order = (5,1)
        }

    let ``oddNumbers is created`` = 
        {   
            ErrorMessage = "oddNumbers should return a list of numbers between 10 and 20 that are odd. Consider List.filter"
            CompletedMessage =  sprintf "%s learnt" <| nameof CombinngConcepts.oddNumbers
            RunLesson = fun () -> CombinngConcepts.oddNumbers () |> should equal [11; 13; 15; 17; 19]
            Order = (6,1)
        }        

    let ``oneAdded is completed`` = 
        {   
            ErrorMessage = "Add one ( + 1) to each of the items. Consider List.map (fun x -> ....) xs"
            CompletedMessage =  sprintf "%s learnt" <| nameof CombinngConcepts.oneAdded
            RunLesson = fun () -> CombinngConcepts.oneAdded [1;2;3;4] |> should equal [2;3;4;5]
            Order = (6,2)
        }       

    let ``addingTen is completed`` = 
        {   
            ErrorMessage = "addingTen should use partial application. Consider List.map (f ...) xs"
            CompletedMessage =  sprintf "%s learnt" <| nameof CombinngConcepts.addingTen
            RunLesson = fun () -> CombinngConcepts.addingTen (+) [1;2;3;4] |> should equal [11;12;13;14]
            Order = (6,3)
        }    

    let ``receipt is completed`` = 
        {   
            ErrorMessage = "receipt should pattern match on values and return a sprint. Consider sprintf \"%s\" "
            CompletedMessage =  sprintf "%s learnt" <| nameof AnotherType.receipt
            RunLesson = fun () -> 
                AnotherType.receipt (AnotherType.CashAmount 42) |> should equal "Cash: 42"
                AnotherType.receipt (AnotherType.CreditCard Guid.Empty) |> should equal "Credit: 00000000-0000-0000-0000-000000000000"
            Order = (6,3)
        }      

    let ``toUpper is completed`` = 
        {   
            ErrorMessage = "toUpper should pattern match on the value. If there is a value return it inside Just otherwise return NoString"
            CompletedMessage =  sprintf "%s learnt" <| nameof AnotherType.receipt
            RunLesson = fun () ->  

                BuildingUsefulTypes.toUpper (BuildingUsefulTypes.Just "foo") |> should equal (BuildingUsefulTypes.Just "FOO")
                BuildingUsefulTypes.toUpper (BuildingUsefulTypes.NoString) |> should equal (BuildingUsefulTypes.NoString)
            Order = (7,1)
        }        

    let ``map is completed`` = 
        {   
            ErrorMessage = "map should use the map function to lower the value inside MaybeString"
            CompletedMessage =  sprintf "%s learnt" <| nameof AnotherType.receipt
            RunLesson = fun () ->  

                SeeingPatterns.Just "FOO" |> SeeingPatterns.map (fun x -> x.ToLower())  |> should equal (SeeingPatterns.Just "foo")
                SeeingPatterns.NoString |> SeeingPatterns.map (fun x -> x.ToLower())  |> should equal (SeeingPatterns.NoString)
            Order = (8,1)
        }                       

    let ``toLower is completed`` = 
        {   
            ErrorMessage = "toLower should use the map function to lower the value inside MaybeString"
            CompletedMessage =  sprintf "%s learnt" <| nameof AnotherType.receipt
            RunLesson = fun () ->  

                SeeingPatterns.Just "FOO" |> SeeingPatterns.lower |> should equal (SeeingPatterns.Just "foo")
                SeeingPatterns.NoString |> SeeingPatterns.lower |> should equal (SeeingPatterns.NoString)
            Order = (8,2)
        }                


let [<EntryPoint>] main _ = 
    printfn "Assesing your progress...\n"

    let getLessons (x:Reflection.MethodInfo) = 
        if x.IsStatic && x.ReturnType = typeof<Lesson> then     
                Some (x.Invoke(null, null) :?> Lesson)
            else None

    let lessons = 
        ReadingFunctions.moduleType.GetMethods() 
        |> Array.toList
        |> List.choose getLessons
        |> List.sortBy (fun x -> x.Order)        

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
