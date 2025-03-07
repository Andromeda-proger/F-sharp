open System

let rec Search n =
    if (n / 10) < 1 then n % 10
    else n % 10 + Search (n / 10)

let rec inputList () =
    printf "> "
    let number = Console.ReadLine()
    if number = "q" then []
    else
        match Int32.TryParse(number) with
        | true, number when number > 0 ->
             number :: inputList()
        | _ ->
            printfn "Некорректный ввод. Пожалуйста, введите натуральное число!"
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
    printfn "Выберите способ заполнения списка (1 - рандом 2 - ввод с клавиатуры)"
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
    
    printfn "Ваш список список: %A" Num
    
    let summ = List.map (fun x -> Search x) Num
    printfn "Список из суммы цифр элементов: %A" summ
    0