start :-
    write('Enter the first list [1,2,3]: '),
    read(List1),
    write('Enter the second list [1,2,3]: '),
    read(List2),
    list_to_set(List1, Set1),  
    list_to_set(List2, Set2),
    intersection(Set1, Set2, Result), 
    write('Intersection lists: '),
    write(Result), nl.