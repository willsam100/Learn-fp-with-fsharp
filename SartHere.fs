namespace LearnFP.Core
open Utils

type ReadingFunctions() = 

    // THe following is a function that is attached to a class. 
    // The name of the class is above - ReadingFunctions
    // This method below takes in an integer, named x, and returns the integer
    // In FP languages, the return type type typically comes last
    // the return keyword is also not needed
    member this.Method(x:int):int = 
        x

    // Complete the following
    // NB: you do not need the return keyword. see the example above
    // return x with 1 added to it, as you would in statndard maths. 
    member this.AddOne (x:int): int = 
        RemoveAndComplete("AddOne")

    // Types and parenthes are options
    // For the tests to compile and pass, this should take in an int, and return and int
    member this.SubtractOne x = 
        RemoveAndComplete("SubtractOne")


// Static class 
module Functions = 

    // A method not attached to a module is a function
    // the identity function simply returns the input, unchanged
    // complete the following, by returning the input
    let inline identity x = 
        RemoveAndComplete("identity")

    // Values can be named with let as well
    let x: bool = true

    // types do not need to be declared. This will still be type checked 
    let y = true

    // Functions can be declared as data too.
    let id: 'a -> 'a = identity

    // Complete the following
    let addTwo x = 
        RemoveAndComplete("addTwo")

    // Complete the following using the id function
    // Implement the identity function using the id function created above
    let doubleIdentity x = 
        id (RemoveAndComplete("doubleIdentity"))


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
    // you can use Math.Pow or infix **
    let raiseToThePower (x:float) y = 
        RemoveAndComplete("add") y


    let foo () = 
        DateTime.Now

    // Complete the following
    // is the funciton abve named `foo` a pure function? 
    let isFooAPureFunction (): bool = 
        RemoveAndComplete("isFooAPureFunction")

        
module HigherOrderFunctions = 

    // A higher order function, is a function that takes in another function
    let f (g: int -> int) (x:int): int = 
        g x

    // We'll use this next with our function above
    // F# also defines this function for us, so this code can be commented out. 
    // In the future, this function will not be declared. 
    let id x = x

    // to use the function f, we supply two values with spaces in between
    // in OOP langugaes we would have written f(id,10)
    let callingWithTwoArguments = 
        f id 10

    // Complete the following 
    // the function should return 100
    let addOneHundred () =     
        f id (RemoveAndComplete("addOneHundred"))

    // functions do not always need a name. 
    // They are called annoymous functions or a lamda 
    // the keyword 'fun' is used to create an annoymous function
    let lamdafunction: int -> int = (fun x -> x + 1)

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
        
        

    