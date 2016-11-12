concrete IfThenSwe of IfThen = open TrySwe in {
  lincat
    Sentence = Utt;
    Clause = Cl;
  lin
    SomeClause = mkCl (mkNP (mkN "fisk"));
    -- CondSentence a b = mkUtt (mkS (mkCl (mkAdv if_Subj (mkS a)) (mkS b))) ;
    -- CondSentence a b = mkUtt (mkAdV if_Subj (mkS (mkCl (mkNP (mkN "fisk")))) ) ;
    -- CondSentence a b = mkUtt (mkAdv if_Subj (mkNP the_Det house_N)) ;

CondSentence a b =

--  det är om det finns fisk det finns fisk
-- mkUtt (mkCl (mkAdv if_Subj (mkS b)) (mkS a))

-- om det finns fisk finns det fisk
-- mkUtt (mkS (mkAdv if_Subj (mkS b)) (mkS a))

-- om det finns fisk så finns det fisk
mkUtt (mkS (mkAdv if_Subj (mkS b)) (mkS (mkAdv "så") (mkS a)))

;
}
