abstract Datalog = {

  -- Datalog abstract syntax.

  cat
    Term; Predicate; Literal; Conjunction;
    Rule;

  fun
    -- Terms
    StringTerm : String -> Term;
    IntTerm : Int -> Term;
    FloatTerm : Float -> Term;

    -- Predicate
    StringPredicate : String -> Predicate;

    -- Literal (avoiding list types for now...)
    Literal0 : Predicate -> Literal;
    Literal1 : Predicate -> Term -> Literal;
    Literal2 : Predicate -> Term -> Term -> Literal;
    Literal3 : Predicate -> Term -> Term -> Term -> Literal;
    Literal4 : Predicate -> Term -> Term -> Term -> Term -> Literal;

    -- Comparison literals
    -- Conjunction because it can then use the S linearization
    -- category, which allows specifying negation (polarity)
    -- in the resource grammar API.
    GtLit, GteLit, LtLit, LteLit, EqLit, NeqLit :
      Term -> Term -> Conjunction;

    -- Conjunction: from literals to rule body.
    --   Negated literals can only appear in rule body,
    --   so we can consider them a conjunction.
    SimpleConj : Literal -> Conjunction;
    Negation : Literal -> Conjunction;
    Conj : Conjunction -> Conjunction -> Conjunction;

    -- Rule (head -> body -> rule)
    MkRule : Literal -> Conjunction -> Rule;
}
