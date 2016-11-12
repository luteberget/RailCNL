concrete IfThenNor of IfThen = open Prelude, TryNor, (P=ParadigmsNor) in {
  lincat
    Sentence = Utt;
    Clause = S;

oper 
  mkLiteral : Pol -> Cl -> S
   = \pol,cl -> mkS presentTense pol cl ;

  lin

LiteralPos = mkLiteral positivePol (mkCl (mkNP (mkN "fisk" ))) ;
LiteralNeg = mkLiteral negativePol (mkCl she_NP woman_N);

--     SomeClause = variants {
-- mkCl (mkNP (mkN "fisk"));
-- mkCl (mkNP (mkN "skalldyr"));
-- mkCl (mkNP (mkN "fugl"));
-- mkCl (mkNP (mkN "fe"))
-- }
-- ;
    -- CondSentence a b = mkUtt (mkS (mkCl (mkAdv if_Subj (mkS a)) (mkS b))) ;
    -- CondSentence a b = mkUtt (mkAdV if_Subj (mkS (mkCl (mkNP (mkN "fisk")))) ) ;
    -- CondSentence a b = mkUtt (mkAdv if_Subj (mkNP the_Det house_N)) ;

-- oper
  -- mkSubj : Str -> Subj
   -- = \s -> lin Subj (ss s) ;

  CondSentence a b =
  -- om det finns fisk så finns det fisk
  mkUtt (mkS (mkAdv if_Subj b) (mkS (P.mkAdv "så") a)) ;
}
