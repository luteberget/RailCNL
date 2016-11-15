resource DatalogParadigmsNor =  {

  oper
    PredArgNo : Type ;
    Pred0 : PredArgNo;
    Pred1 : PredArgNo;
    Pred2 : PredArgNo;
    Pred3 : PredArgNo;
    Pred4 : PredArgNo;
    PredMany : PredArgNo;

    -- Literals without parameters
    -- Not widely used, but example:
    --  high_quality :- count(signal_score(X, Y), Y < 10) == 0.
    mkLit0 : N -> Cl ;
    mkLit1 : 
}
