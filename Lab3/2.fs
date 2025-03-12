open System

let rec readDigit () =
    printfn "������� ����� �� 0 �� 9 ��� ������ ��������� � ������, ������� ���������� �� ���:"
    printf "> "
    let i = Console.ReadLine()
    match Int32.TryParse(i) with
    | true, i when i >= 0 && i <= 9 -> i
    | _ -> 
        printfn "������������ ����. ����������, ������� ����� �� 0 �� 9!"
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
    printfn "������� �������� ������������������ (��� 'q' ��� ������):"
    let pos = add ()
    printfn "���� ������������������: %A" pos
    let summ = Seq.fold (fun (acc:float) x -> acc + (check x)) 0. pos
    printfn "������ �� ���� ���� ��������� ������������������: %A" summ
    0