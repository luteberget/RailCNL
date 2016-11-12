abstract IfThen =  {
 flags startcat = Sentence;
 cat Sentence; Clause; Predicate; Polarity; Identifier;
  fun
   Positive : Polarity;
   Negative : Polarity;
   CustomPredicate : String -> Predicate;
   CustomIdentifier : String -> Identifier;
   Literal0 : Predicate -> Polarity -> Clause ;
   --Literal1 : Predicate -> Polarity -> Identifier ->Clause ;
   --Literal2 : Predicate -> Polarity -> Identifier -> Identifier ->Clause ;
   CondSentence : Clause -> Clause -> Sentence;
}
