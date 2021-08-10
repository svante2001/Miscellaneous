#light
open System

let mutable divisable = false
let mutable j = 2

for i = 2 to 100 do
    j <- 2
    while j < i do
        if i % j = 0 then divisable <- true
        j <- j + 1

    if divisable = false then Console.WriteLine(i)
    divisable <- false