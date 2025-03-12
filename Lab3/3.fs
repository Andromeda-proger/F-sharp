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
        printfn "Файлы не найдены"
        exit 1

let rec Dirsearch() =
    printfn "Введите название каталога, в котором будем искать файлы:"
    let dirname = Console.ReadLine()
    
    if Directory.Exists(dirname) then
        Directory.EnumerateFiles(dirname, "*.*", SearchOption.AllDirectories)
    else
        printfn "Такой каталог не существует."
        exit 1

[<EntryPoint>]
let main _ =

    let files = Dirsearch()
    
    let fileNames = filename files
    
    printfn "Введите символ, на который начинается имя файла:"
    let s = Console.ReadLine()
    
    let res = simbsearch s fileNames
    
    if not (Seq.isEmpty res) then
        printfn "Найденные файлы:"
        Seq.iter (printfn "%s") res
    else
        printfn "Файлы, начинающиеся на '%s', не найдены." s
    0
