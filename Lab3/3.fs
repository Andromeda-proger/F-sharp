open System
open System.IO

let simbsearch s files =
    Seq.filter (fun x -> 
        let file = Path.GetFileName(x)
        file.StartsWith(s)) files

let filename pos =
    if not (Seq.isEmpty pos) then
        Seq.map Path.GetFileName pos
    else
        printfn "����� �� �������"
        exit 1

let rec Dirsearch() =
    printfn "������� �������� ��������, � ������� ����� ������ �����:"
    let dirname = Console.ReadLine()
    
    if Directory.Exists(dirname) then
        Directory.EnumerateFiles(dirname, "*.*", SearchOption.AllDirectories)
    else
        printfn "����� ������� �� ����������."
        exit 1

[<EntryPoint>]
let main _ =

    let files = Dirsearch()
    
    let fileNames = filename files
    
    printfn "������� ������, �� ������� ���������� ��� �����:"
    let s = Console.ReadLine()
    
    let res = simbsearch s fileNames
    
    if not (Seq.isEmpty res) then
        printfn "��������� �����:"
        Seq.iter (printfn "%s") res
    else
        printfn "�����, ������������ �� '%s', �� �������." s
    0