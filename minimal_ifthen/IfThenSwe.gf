concrete IfThenSwe of IfThen = open Prelude, SyntaxSwe, ParadigmsSwe in {
  lincat
    Sentence = S;
    Statement = Cl;

  lin
    StatementA = mkCl (mkNP (mkN "fisk"));
    SSentence a b = mkS if_then_Conj (mkS a) (mkS b) ;
}
