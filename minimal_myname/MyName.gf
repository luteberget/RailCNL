abstract MyName = {
  flags startcat=Sentence;
  cat Name; Sentence;
  fun 
    CustomName : String -> Name;
    MyNameSentence : Name -> Sentence;
}
