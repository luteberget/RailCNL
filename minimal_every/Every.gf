abstract Every = {
  flags startcat=Statement;
  cat 
    Object; Predicate; Literal; Body; Statement;

  fun
    CustomObject : String -> Object;
    CustomPredicate : String -> Predicate;
    
    Literal0 : Predicate -> Literal;
    Literal1 : Predicate -> Object -> Literal;
    Literal2 : Predicate -> Object -> Object -> Literal;

    Negation : Literal -> Body;
    
    Body0 : Literal -> Body;
    Conjunction : Body -> Body -> Body;

    Rule : Body -> Literal -> Statement;
    Fact : Literal -> Statement;
}
