check(A, B, C, D) :-

    (A == true -> B == true; true),
    (B == true -> (C == true; A == false); true),
    (D == false -> (A == true, C == false); true),
    (D == true -> A == true; true).

start :-
    
    member(A, [true, false]),
    member(B, [true, false]),
    member(C, [true, false]),
    member(D, [true, false]),
    
    check(A, B, C, D),
    
    write('Violated the rules: '),
    (A == true -> write('Antipov '); true),
    (B == true -> write('Borisov '); true),
    (C == true -> write('Cvetkov '); true),
    (D == true -> write('Dmitriev '); true),
    (A == false, B == false, C == false, D == false -> write('No violators'); true),
    nl.