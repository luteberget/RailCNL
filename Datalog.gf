abstract Datalog = {
  flags startcat = Rule;
  
  cat
    Rule ; Compound ; Literal ; Term ; Predicate;
    

  fun 
    Implies : Literal -> Compound -> Rule ;
    Fact : Literal -> Rule ;

    SimpleCompound : Literal -> Compound ;
    Conjunction : Compound -> Compound -> Compound ;
    Negation : Literal -> Compound ;

    StringPredicate : String -> Predicate;
    StringTerm : String -> Term;
    -- IntTerm : Int -> Term;
    -- FloatTerm : Float -> Term;

    CustomLiteral0 : Predicate -> Literal;
    CustomLiteral1 : Predicate -> Term -> Literal;
    CustomLiteral2 : Predicate -> Term -> Term -> Literal;

    DistancePredicate : Term -> Term -> Term -> Literal ;
    TrackClassPredicate : Term -> Literal ;
    TrackQualityPredicate : Term -> Term -> Literal ;
}
