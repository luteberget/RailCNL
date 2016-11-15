concrete IfThenNor of IfThen = open Prelude, TryNor, (P=ParadigmsNor) in {
  lincat
    Sentence = Utt;
    Clause = S;
    Predicate = N;
    Identifier = N;
    Polarity = Pol;

oper 

  constN : Str -> N
   = \s -> mkN s ;

  mkPredCl0 : N -> Cl 
   = \pred -> mkCl (mkNP pred) ;

--   mkPredCl2 : N -> N -> N -> Cl 
--    = \pred,a,b -> 
--       mkCl (mkNP (mkCN (mkN2 pred                    (P.mkPrep "til")) (mkNP a) )) (mkNP b) ;
--   -- (mkCl (mkNP (mkCN (mkN2 (mkN "kvalitetsklasse") (mkPrep   "til")) t)) q) ;
-- 
--   mkPredCl1 : N -> N  ->  Cl 
--    = \pred,a -> mkPredCl2 pred a (mkN "hei") ;

--   mkTerm : Str -> NP
--    = \s -> mkNP (mkN s) ;
-- 
   mkLiteral : Pol -> Cl -> S
    = \pol,cl -> mkS presentTense pol cl ; 
-- 
--   mkPredCl0 : Str -> Cl
--    = \pred -> mkCl (mkNP (mkN pred)) ;
-- 
--   mkPredCl2 : Str -> Str -> Str -> Cl
--    = \pred,a,b -> mkCl (mkNP (mkCN (mkN2 (mkN pred)              (P.mkPrep "til")) (mkTerm a))) (mkTerm b) ;
-- 
--   mkPredCl1 : Str -> Str -> Cl
--    = \pred,a -> mkPredCl2 pred a "kjeks" ;
-- 
lin


-- LiteralPos = mkLiteral positivePol (mkCl (mkNP (mkN "fisk" ))) ;
-- LiteralNeg = mkLiteral negativePol (mkCl she_NP woman_N);
Literal0 pred pol = mkLiteral pol (mkPredCl0 pred) ;
-- Literal1 pred pol a = mkLiteral pol (mkPredCl1 pred a) ;
-- Literal2 pred pol a b = mkLiteral pol (mkPredCl2 pred a b) ;

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

  CustomPredicate sh = constN "skeks" ;
  CustomIdentifier sh = constN "fleks" ;

  Positive = positivePol;
  Negative = negativePol;

  CondSentence a b =
  -- om det finns fisk så finns det fisk
  mkUtt (mkS (mkAdv if_Subj b) (mkS (P.mkAdv "så") a)) ;

  Combo a b = mkS and_Conj a b ;
}
