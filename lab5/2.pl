start :-
    write('Enter the list in the format [1,2,3]: '),
    read(List),              
    (sort(List) ->      
        write('The list is growing.');
        write('The list does not grow.')
    ),
    nl.

sort([]).
sort([_]). 

sort([X, Y | Tail]) :-
    X =< Y,               
    sort([Y | Tail]). 