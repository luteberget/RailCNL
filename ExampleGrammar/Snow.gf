abstract Snow = {
  cat Modifier; Subject; Sentence;

  fun
    Snow : Subject;
    First : Modifier;
 
    SentenceUndet : Subject -> Sentence;
    SentenceDet : Subject -> Sentence;
    SentenceMod : Modifier -> Subject -> Sentence;
}
