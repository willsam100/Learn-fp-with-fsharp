module Program
open Tests


let [<EntryPoint>] main _ = 
    printfn "Assesing your progress...\n"

    let lessons = 
        [
            ReadingFunctions.``Addone should add one``
            ReadingFunctions.``SubtractOne should subract one``
            Functions.``identity should return the same input``
            Functions.``addone should add one``
            PureFunctions.``raiseToThePower to show return the pow of y applied to x``
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
        xs |> List.iter (printfn "%s")
        printfn ""
    0
