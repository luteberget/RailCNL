abstract IfThen =  {
 flags startcat = Sentence;
 cat Sentence; Clause;
  fun
   LiteralPos : Clause ;
   LiteralNeg : Clause ;
   CondSentence : Clause -> Clause -> Sentence;
}
