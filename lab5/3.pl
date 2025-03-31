start :-
    write('Enter the first list [1,2,3]: '),
    read(List1),
    write('Enter the second list [1,2,3]: '),
    read(List2),

    intersection(List1, List2, Result), 
    write('Intersection lists: '),
    write(Result), nl.