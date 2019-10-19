namespace LearnFP.Core
open Utils
open System

// `type` is a keyword and is similiar to `class` in C#. This declares a class in F# with a default empty constructor. 
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
    // Here we have ommited the type of x
    // For the tests to compile and pass, this should take in an int, and return and int
    member this.SubtractOne (x): int = 
        RemoveAndComplete("SubtractOne")

    // Here we have ommited the type of x, parentheses and return type. 
    // This is idomatic of F# code. While learning it is fine to put the types in though. 
    // For the tests to compile and pass, this should take in an int, and return and int
    member this.SubtractTwo x = 
        RemoveAndComplete("SubtractTwo")        


// a module is a Static class 
// Use modules to hold functions and data types. 
// Do not use modules to store variables or application state (use classes instead)
module Functions = 

    // A method not attached to a module is a function
    // the identity function simply returns the input, unchanged
    // complete the following, by returning the input
    let inline identity (x: int): int = 
        RemoveAndComplete("identity")

    // Values can be named with let as well
    let x: bool = true

    // types do not need to be declared. This will still be type checked 
    let y = true

    // Functions can be declared as data too.
    // NB: the type of a function is written with `->` betweent the inputs and outputs. 
    // C#: Func<int, int> in F#: int -> int
    let id: int -> int = identity

    // F# has generics just as C#. The F# compiler is able to autmoatically make our code more general. 
    // Programming with generic code is quite common in F# compiler will always check they types match. 
    // A generic type is declared with a ' before the lower case letter: 'a, 'b
    let idTwo: 'a -> 'a = fun y -> y

    // Complete the following
    let addTwo x = 
        RemoveAndComplete("addTwo")

    // Complete the following using the id function
    // Implement the identity function using the id function created above
    // The function should take in a value and return the value unchanged
    let consecutiveIdentity x =
       (RemoveAndComplete("consecutiveIdentity"))


module PureFunctions = 

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

// To make more of the application pure, immutable data is required. 
// F# is suited for this and has syntax for this.
module ImmutableData = 

    // A record is an immutable class.
    type MyRecord = {
        Foo: int
    }

    let createMyRecord () = 
        // Records have a special syntax for creation. It's one of the few places where curly braces are used
        {
            Foo = 42
        } 
        // {Foo = 42} is also valid as a one-liner

    type AnotherRecord = 
        {
            Baz: int
            Bar: int
        }

    let updateMyRecods x = 
        // F# also has a special syntax for updating values. 
        // A copy of `AnotherRecord` will be returned
        // Only the value Baz will be updated, Bar will remain unchanged
        // The F# compiler is optimised for copy-on-write so this more efficiant than immutable objects in C# ()
        {x with Baz = 42}

// It turns out there are patterns for handling lots of immutable data with pure functions
// Higher order functions are techniques that help
module HigherOrderFunctions = 

    // A higher order function, is a function that takes in another function
    // f is the name of the function
    // g is an input into f. They type of g is a function. It takes in an int and returns an int
    // x is an input into f. the type of f is an int
    let f (g: int -> int) (x:int): int = 
        g x

    // We'll use this next with our function above
    // F# also defines this function (id) for us, so this code can be commented out. 
    // For the rest of this tutorial, this function will not be declared. - We'll use the one F# provides. 
    let id x = x

    // to use the function f, we supply two values with spaces in between
    // In OOP langugaes we would have written f(id,10)
    // This function returns the value 10. 
    // it first evaulates f, that then applies id to 10 (g x above) that returns the value 10
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

    // Higher order functions are used a lot in F#. We'll come back to use these again soon.

module PartialApplication = 

    // a function that takes in two items
    // int -> int -> int
    let add x y = 
        x + y

    // If a argument is missing, then the result is a function
    // This is called partial application
    let addOne: int -> int = add 1

    // Update the following to use the value i adding one to each value
    // The result will print the values to the console
    // NB: this the synax for a for loop in F#. [1 .. 10] will generate a list of numbers inclusive of 1 and 10
    let addOneInALoop () = 
        for i in 1 .. 10 do
            printfn "%d" (RemoveAndComplete("addOneInALoop"))


// A quick tour of the collection types in F#
module FsharpCollections = 

    // This is an array, exaclty the same as C#. The binding `myArray` is imuutable, but the items in array are mutable
    // Note the special syntax to create the array. 
    let myArray = 
        [| 1; 2; 3|]

    // seq<'a> is IEnummerable<T>. F# choose to use a shorter name, but the two are the same types. 
    let mySeq = 
        // This a is special syntax in F# to create a seq. 
        seq { 1; 2;}

    // in F# it's more common to use lists. 
    // List is a singlely linked-list
    // note the square baracks syntax and ; to seperate items
    let myList = 
        [1;2;3]

    // short-and to create a list of values
    let oneToOneHundred = [1 .. 10]

    // pattern matching
    // similary to a switch statement in C#
    // after each `->` the value will be returned (no return keyword needed)
    // this functipn retuns a bool
    let isEmpty (x: list<'a>): bool = 
        match x with 
        | [] -> true
        | xs -> false


// It's now time to combine the concepts we have learned together
module CombinngConcepts = 

    // `List.filter` takes in a function (List.filter is higher order function)
    // NB: F# uses a single `=` for equality
    // Generate a list from 1 to 200, then create a copy with the only the even numbers. 
    let evenNumbers = 
        List.filter (fun x -> x % 0 = 0 ) [ 1 .. 200]

    // create a list of odd numbers between 10 to 20
    let oddNumbers (): list<int> = 
        RemoveAndComplete("oddNumbers")

    // transforming a list
    // `List.map` transforms a list, one element at a time. the list is processed from left to right, ie 1, 2, 3 in this case
    let numbersAsStrings = 
        List.map (fun x -> x.ToString()) [1 .. 10]

    // AddOne 
    // given the input xs, a list of numbers. 
    // using `List.map` add one to each number. 
    let oneAdded xs = 
        RemoveAndComplete("oneAdded")

    // Use partial application make f compile with `List.map`. 
    // It should add 10 to each item
    // `List.map f xs` - does not compile and does not add 10
    // Do not use the keyword `fun`
    // Parenthesis are needed for partial application ie around f
    let addingTen (f: int -> int -> int) (xs: list<int>):  list<int> =   
        RemoveAndComplete("addingTen")

// F# has a native unique type - it's super awesome
module AnotherType =         

    // Records are great for joining data together ie logical AND
    // What about a logical OR
    type MyDescrimindatedUnion = 
        | Cash
        | Credit

    // payment type is a value of MyDescrimindatedUnion
    // So far this is pretty much the same as an enum. 
    let paymentType = Cash

    // A Descrimindated Union can also hold data on each branch
    type Payment = 
        | CashAmount of cents:int
        | CreditCard of cardToken:Guid

    // a pyament of cash with the amount paid. 
    let payment = 
        CashAmount 1000

    // Payment can never be null - uncomment and internalize the joy of this compiler error. 
    // let payment: payment = null

    // pattern matching is how we get the values out
    let printPaymentAmount payment = 
        match payment with 
        | CashAmount amount -> printfn "%d" amount
        | CreditCard token -> printfn "%A" token


    // The compiler issue a warning if a branch is missed in the match
    let badPatternMatch payment = 
        match payment with // Compiler warning here. For release builds enable compiler warnings as errors in fsproj
        | CashAmount amount -> printfn "%d" amount

    // each line of a pattern match returns a value
    // use a pattern match to get the value. 
    // use `sprintf` and `%A` to the type of payment along with the amount 
    // https://fsharpforfunandprofit.com/posts/printf/ - for help on string formatting
    let receipt (payment: Payment): string = 
        RemoveAndComplete("receipt")

// Can we use these types to model common patterns
module BuildingUsefulTypes =         

    // Use a DU to capture if we have a string or not. 
    // This means we don't need to use null. 
    type MaybeString = 
        | Just of string
        | NoString  

    // Yes we have a string
    let withString = Just "myString"

    // No we don't have a string
    let noString = NoString

    // Complete the following 
    // If we have a string call ToUpper() on the string and put the result back into a MaybeString
    // If no string, then return NoString
    let toUpper (maybeString: MaybeString): MaybeString = 
        RemoveAndComplete("toString")

// do we want to always be pattern matching
module SeeingPatterns =         
    // Declare the type in this module
    type MaybeString = 
        | Just of string
        | NoString  

    // if we need to pattern match all the time, our code with be a mess
    // Let caputre the common parts in a clear abstraction 
    // use f and apply it to s, then put it back in into a MaybeString
    let map (f: string -> string) (maybeString: MaybeString): MaybeString = 
        match maybeString with 
        | Just s -> RemoveAndComplete("map")
        | NoString -> RemoveAndComplete("map")

    // Let's use our new map function 
    // call ToLower on x
    // see how we don't need to use pattern matching - that is taken care of in the map function
    let lower a: MaybeString = 
        map (fun (x: string) -> RemoveAndComplete("toLower()") ) a

    let lowered = lower (Just "FOOO")
    let safeOp = lower NoString
