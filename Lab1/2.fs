open System

// Функция для поиска минимальной цифры числа (рекурсивная)
let rec search number =
    if number < 10 then
        number
    else
        let lastDigit = number % 10 // Последняя цифра числа
        let Min = search (number / 10) // Рекурсивный вызов для оставшейся части числа
        min lastDigit Min // Возвращаем минимум из последней цифры и результата рекурсии

// Основная программа
let main() =
    printf "Введите натуральное число: "
    let input = Console.ReadLine()
    
    match Int32.TryParse input with
    | true, number when number > 0 -> // Проверяем, что число натуральное
        let mini = search number
        printfn "Минимальная цифра в числе %d: %d" number mini
    | _ ->
        printfn "Некорректный ввод!"

// Запуск программы
main()