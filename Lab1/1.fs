open System
 
let c= 
    printfn "Введите цифру от 0 до 9 для поиска элементов в списке которые начинаются на нее:"
    Console.ReadLine()|>int 

let rec Search n m =
    if (n / 10) < 1 then 
        if (n%10) = c then m
        else 0
    else Search (n/10) m

let rec inputList () =
    printf "> "
    let number = Console.ReadLine()
    if number = "q" then []
    else 
        match Int32.TryParse(number) with
        | true, number when number > 0 ->
             number :: inputList()
        | false, _ ->
            printfn "Некорректный ввод. Пожалуйста, введите целое число!"
            inputList()

[<EntryPoint>]
let main _ =
    printfn "Введите элементы списка из натуральных чисел (q для выхода):"
    let Num = inputList()
    printfn "Вы ввели список: %A" Num
    
    let summ = List.fold (fun acc x -> acc + (Search x x)) 0 Num
    printfn "Сумма элементов в списке начинающиеся на %i равна: %A"c summ
    0