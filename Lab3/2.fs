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

let c = lazy (readDigit ())

let rec Search (n: float) (m: float)=
    let n = abs n 
    if (n / 10.) < 1. then 
        if int(n % 10.) = c.Value then m
        else 0.
    else Search (n / 10.) m

let rec add () =
    printf "> "
    let i = Console.ReadLine()
    if i = "q" then
        Seq.empty
    else
        Seq.append (seq {yield i}) (add ())

let rec check (x: string) =
    match Double.TryParse(x) with
    | true, i -> Search i i 
    | _ -> 0.

[<EntryPoint>]
let main _ =
    printfn "Введите элементы последовательности (или 'q' для выхода):"
    let pos = add ()
    printfn "Ваша последовательность: %A" pos
    let summ = Seq.fold (fun (acc:float) x -> acc + (check x)) 0. pos
    printfn "Список из сумм цифр элементов последовательности: %A" summ
    0