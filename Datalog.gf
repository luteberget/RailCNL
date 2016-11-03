abstract Datalog = {
  flags startcat = Rule;
  
  cat
    Rule ; Compound ; Literal ; Term ;
    

  fun 
    Implies : Literal -> Compound -> Rule ;
    Fact : Literal -> Rule ;

    SimpleCompound : Literal -> Compound ;
    Conjunction : Compound -> Compound -> Compound ;
    Negation : Literal -> Compound ;

    -- PredicateLiteral : Predicate -> Terms -> Literal ;

    -- EmptyTerms : Terms;
    -- SimpleTerm : Term -> Terms;
    -- CompoundTerms : Term -> Terms -> Terms ;
    -- IntTerm : Int -> Term;
    -- FloatTerm : Float -> Term;

    X, Y, Z : Term ;
    a, b, c : Term ;
    UnknownPredicate : Literal ;

    DistancePredicate : Term -> Term -> Term -> Literal ;
    TrackClassPredicate : Term -> Literal ;
    TrackQualityPredicate : Term -> Term -> Literal ;
}
