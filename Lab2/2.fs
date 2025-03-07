open System

let rec readDigit () =
    printfn "Введите цифру от 0 до 9 для поиска элементов в списке, которые начинаются на нее:"
    printf "> "
    let i = Console.ReadLine()
    match Int32.TryParse(i) with
    | true, i when i >= 0 && i <= 9 -> i
    | _ -> 
        printfn "Некорректный ввод. Пожалуйста, введите цифру от 0 до 9!"
        readDigit()

let c = readDigit()

let rec Search n m =
    if (n / 10) < 1 then 
        if (n % 10) = c then m
        else 0
    else Search (n / 10) m

let rec inputList () =
    printf "> "
    let number = Console.ReadLine()
    if number = "q" then []
    else 
        match Int32.TryParse(number) with
        | true, number->
             number :: inputList()
        | _ ->
            printfn "Некорректный ввод. Пожалуйста, введите целое число!"
            inputList()

let Rand n =
    let rnd = Random()
    let rec generate i acc =
        if i = 0 then acc
        else
            let number = rnd.Next(1, 1000) // Генерация случайного числа от 1 до 1000
            generate (i - 1) (number :: acc)
    generate n []

[<EntryPoint>]
let main _ =
    printfn "Выберите способ заполнения списка (1 - рандом, 2 - ввод с клавиатуры)"
    let s = Console.ReadLine()
    let Num = 
        if s = "1" then 
            printfn "Введите количество элементов списка для заполнения рандомными значениями"
            let n = Console.ReadLine()
            match Int32.TryParse(n) with
            | true, n when n > 0 -> Rand n
            | _ -> 
                printfn "Некорректный ввод!"
                []
        elif s = "2" then 
            printfn "Введите элементы списка из натуральных чисел (q для выхода):"
            inputList()
        else 
            printfn "Неверное действие"
            []
    
    printfn "Ваш список: %A" Num
    
    let summ = List.fold (fun acc x -> acc + (Search x x)) 0 Num
    printfn "Сумма элементов в списке, начинающихся на %i, равна: %A" c summ
    0