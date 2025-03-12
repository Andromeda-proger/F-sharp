open System

let rec Search n =
    if (n / 10) < 1 then n % 10
    else n % 10 + Search (n / 10)

let rec add () =
    printf "> "
    let i = Console.ReadLine()
    if i = "q" then
        Seq.empty
    else
        match Int32.TryParse(i) with
        | true, num when num > 0->
            Seq.append (seq {yield num}) (add ())
        | false, _ ->
            printfn "Некорректный ввод, попробуйте снова."
            add ()
let pos = lazy(add ())

[<EntryPoint>]
let main _ =
    printfn "Введите элементы (натуральные числа) последовательности (или 'q' для выхода):"
    printfn "Ваша последовательность: %A" pos.Value
    let summ = Seq.map (fun x -> Search x) pos.Value
    printfn "Список из сумм цифр элементов последовательности: %A" summ
    0