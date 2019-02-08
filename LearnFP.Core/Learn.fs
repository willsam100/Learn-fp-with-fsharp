namespace LearnFP.Core

[<AutoOpen>]
module Utils =
    exception NotCompleted of string
    let inline RemoveAndComplete name = 
        sprintf "%s: Remove `RemoveAndComplete(%s)` and fill in with the correct value" name name |> NotCompleted |> raise

type ReadingFunctions() = 

    // THe following is a function that is attached to a class. 
    // It takes in an integer and returns the integer
    // the return keyword is
    member this.Method(x:int):int = 
        x

    // Complete the following
    // NB: you do not need the return keyword. see the example above
    // return x with 1 added to it. 
    member this.AddOne (x:int): int = 
        RemoveAndComplete("AddOne")

    // Types and parenthes are options
    // For the tests to compile and pass, this should take in an int, and return and int
    member this.SubtractOne x = 
        RemoveAndComplete("SubtractOne")


// Static class 
module Functions = 

    // A method not attached to a module is a function
    // the identity function returns the input. 
    let identity x = 
        RemoveAndComplete("identity")

    // Values can be named with let as well
    let x: bool = true

    // types do not need to be declared. This will still be type checked 
    let y = true

    // Functions can be declared as data too.
    let id: 'a -> 'b = identity

    // Complete the following
    let addOne x = 
        RemoveAndComplete("addOne")

    // Complete the following using the id function
    let identifyAgain x = 
        RemoveAndComplete("addOne")id x


module PureFunctions = 
    open System

    // A pure function is a function that will always return the same result, given the same inputs
    let pureFunction x y =      
        x + y

    // This is NOT a pure function, the result changes when given the same input
    let impure x = 
        let r = Random()
        r.Next()


    // Complete the following
    // ie +
    let add x y = 
        RemoveAndComplete("add")id x

    // Complete the following
    // Will divide always return the same output for the same inputs. 
    // The output must always be of the same type for any inputs. eg + always returns a number
    let isDivideAPureFunction: bool = 
        RemoveAndComplete("isDivideAPureFunction")

        
module HigherOrderFunctions = 

    // A higher order function, is a function that takes in another function
    let f (g: int -> int) (x:int): int = 
        g x

    let id x = x

    // to use the function f, we supply two values with spaces in between
    // in OOP langugaes we would have written f(id,10)
    let callingWithTwoArguments = 
        f id 10

    // Complete the following 
    // the function should return 100
    let addOneHundres =     
        f id (RemoveAndComplete("addOneHundres"))

    // functions do not alwasy need a name. 
    // They are called annoymous functions or a lamda 
    // the keyword 'fun' is used to create an annoymous function
    let lamdafunction = (fun x -> x + 1)

    // We can pass a lamda in to a higher order function 
    let addTen x = 
        f (fun x -> x + 10) x

    // Complete the following 
    let addTwenty x = 
        f (RemoveAndComplete("addTwenty")) x


module ParitalApplication = 

    // a function that takes in two items
    let add x y = 
        x + y


    // If a argument is missing, then the result is a function
    let addOne: int -> int = add 1
        
        

    