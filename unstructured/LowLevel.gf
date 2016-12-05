abstract LowLevel = {
  flags startcat = Document;

  cat
    Compound ; Literal ; Term; Predicate;

    Document; Id;
    Constraint; Obligation;

    -- [Term] {3};

  fun
    CatDocument : Document -> Document -> Document;
    MkConstraintDocument : Id -> Constraint -> Document;
    MkObligationDocument : Id -> Obligation -> Document;

    MkConstraint : Literal -> Compound -> Constraint ;
    MkObligation : Compound -> Compound -> Obligation;

    SimpleCompound : Literal -> Compound ;
    Conjunction : Compound -> Compound -> Compound ;
    Negation : Literal -> Compound ;

    StringId : String -> Id;
    StringPredicate : String -> Predicate;
    StringTerm : String -> Term;
    IntTerm : Int -> Term;
    FloatTerm : Float -> Term;

    Literal0 : Predicate -> Literal;
    Literal1 : Predicate -> Term -> Literal;
    Literal2 : Predicate -> Term -> Term -> Literal;
    Literal3 : Predicate -> Term -> Term -> Term -> Literal;
    Literal4 : Predicate -> Term -> Term -> Term -> Term -> Literal;
    -- LiteralMany : Predicate -> [Term] -> Literal;
}
