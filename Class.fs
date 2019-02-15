module Utils

exception NotCompleted of string
let inline RemoveAndComplete name = 
    sprintf "%s: Remove `RemoveAndComplete(%s)` and fill in with the correct value" name name |> NotCompleted |> raise