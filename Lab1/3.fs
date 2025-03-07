open System

// Добавление элемента в список
let addElement element lst = element :: lst

// Удаление элемента из списка
let rec removeElement element lst =
    if List.isEmpty lst then
        []
    elif lst.Head = element then
        lst.Tail
    else
        lst.Head :: removeElement element lst.Tail

// Поиск элемента в списке
let findElement element lst = List.contains element lst

// Сцепка двух списков
let concatLists lst1 lst2 = lst1 @ lst2

// Получение элемента по номеру
let getElementAtIndex index lst =
    if index < 0 || index >= List.length lst then
        None
    else
        Some (List.item index lst)

// Функция для ввода списка от пользователя с использованием рекурсии
let rec inputList () =
    printf "> "
    let input = Console.ReadLine()
    if input = "q" then
        []
    else
        input :: inputList()

// Основная программа
[<EntryPoint>]
let main argv =
    // Ввод исходного списка
    printfn "Введите элементы списка(q для выхода):"
    let myList = inputList()
    printfn "Исходный список: %A" myList

    // Добавление элемента
    printf "Введите  для добавления: "
    let elementToAdd = Console.ReadLine()
    let listAfterAdd = addElement elementToAdd myList
    printfn "Список после добавления в начало: %A" listAfterAdd

    // Удаление элемента
    printf "Введите строку для удаления: "
    let elementToRemove = Console.ReadLine()
    let listAfterRemove = removeElement elementToRemove myList
    printfn "Список после удаления: %A" listAfterRemove

    // Поиск элемента
    printf "Введите строку для поиска: "
    let elementToFind = Console.ReadLine()
    let exists = findElement elementToFind myList
    printfn "Строка \"%s\": %b" elementToFind exists

    // Сцепка двух списков
    printfn "Введите второй список для сцепки:"
    let list2 = inputList()
    let concatenatedList = concatLists myList list2
    printfn "Список после сцепки: %A" concatenatedList

    // Получение элемента по индексу
    printf "Введите индекс элемента для поиска: "
    let index = Console.ReadLine() |> int
    let element = getElementAtIndex index myList
    match element with
    | Some x -> printfn "Элемент по индексу %d: \"%s\"" index x
    | None -> printfn "Элемент с индексом %d не найден" index

    0 // Возвращаем код завершения программы