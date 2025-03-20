open System

type BinaryTree =
    | Node of string * BinaryTree * BinaryTree 
    | Empty

// Функция для вычисления глубины дерева
let rec depth tree =
    match tree with
    | Empty -> 0
    | Node(_, left, right) -> 1 + max (depth left) (depth right)

// Функция для добавления элемента в дерево с учетом балансировки
let rec add (tree: BinaryTree) (value: string): BinaryTree =
    match tree with
    | Empty -> Node(value, Empty, Empty)
    | Node(data, left, right) ->
        let leftDepth = depth left
        let rightDepth = depth right
        if leftDepth <= rightDepth then
            Node(data, add left value, right)
        else
            Node(data, left, add right value)

// Функция для формирования корня дерева и добавления элементов
let rec createTree (): BinaryTree =
    printfn "Введите корень дерева ('q' для выхода):"
    printf ">"
    let input = Console.ReadLine()
    if input = "q" then
        Empty
    else
        let tree = add Empty input
        printfn "Введите элементы дерева ('q' для выхода):"
        let rec loop (currentTree: BinaryTree): BinaryTree =
            printf ">"
            let input = Console.ReadLine()
            if input = "q" then
                currentTree
            else
                let newTree = add currentTree input
                loop newTree
        loop tree

let rec TreeMap (tree: BinaryTree): BinaryTree =
    match tree with
    | Node(data, left, right) ->
        let newdata = data + data
        Node(newdata, TreeMap left, TreeMap right)
    | Empty -> Empty

//обход в ширину
let rec printtree1 (tree:BinaryTree)=
    match tree with
    |Node (data, left, right)
        -> printtree1 left
           printfn "%s" data
           printtree1 right
    |Empty
        ->()

//вывод дерева в виде дерева
let rec printTree2 (tree: BinaryTree) (indent: string) (isLast: bool) =
    match tree with
    | Node(data, left, right) ->
        printfn "%s%s%s" indent (if isLast then "└── " else "├── ") data

        printTree2 left (indent + (if isLast then "    " else "│   ")) (right = Empty)

        printTree2 right (indent + (if isLast then "    " else "│   ")) true
    | Empty -> () 

[<EntryPoint>]
let main _ =
    let binTree1 = createTree()
    printTree2 binTree1 "" true
    
    let binTree2 = TreeMap binTree1 
    printTree2 binTree2 "" true
    0