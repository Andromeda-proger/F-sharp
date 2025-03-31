start :-
    write('Enter number: '),
    read(Number),       
    count_steps(Number, Steps),
    write('Number of steps: '), write(Steps), nl.

sum_digits(0, 0).
sum_digits(N, Sum) :-
    N > 0,
    Digit is N mod 10,
    Next is N // 10,
    sum_digits(Next, SumNext),
    Sum is SumNext + Digit.

count_steps(0, 0).
count_steps(N, Steps) :-
    N > 0,
    sum_digits(N, Sum),
    Next is N - Sum,
    count_steps(Next, StepsNext),
    Steps is StepsNext + 1.