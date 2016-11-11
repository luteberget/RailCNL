abstract IfThen =  {
 flags startcat = Sentence;
 cat Sentence; Clause;
  fun
   SomeClause : Clause ;
   CondSentence : Clause -> Clause -> Sentence;
}
