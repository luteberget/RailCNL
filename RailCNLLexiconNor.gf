concrete RailCNLLexiconNor of RailCNLLexicon = CatNor ** 
  open MorphoNor, ParadigmsNor, (X = ConstructX), IrregNor, Prelude,
  (Lex = LexiconNor) in {

  lin
    should_VV = lin VV ((mkV "burde" "bør" "bør" "burde" "burdet" "bør") ** {c2 = mkComplement []}); 


    then_Adv   = mkAdv  "så";
    of_Prep   = mkPrep "til";

    small_A   = Lex.small_A;
    big_A     = Lex.big_A;

    equal_to_A2  = mkA2 (mkA "lik" "lik") (mkPrep "");
    not_equal_to_A2  = 
-- mkA2 (mkA "ikke lik" "ikke lik") (mkPrep "")
    -- not_equal_to_A2  = 
           mkA2 (mkA "ulik" "ulik") (mkPrep "");

    gte_A2  = mkA2 (mkA 
      "større enn eller lik"
      "større enn eller lik"
      ) (mkPrep "") ;

    lte_A2  = mkA2 (mkA 
      "mindre enn eller lik"
      "mindre enn eller lik"
      ) (mkPrep "") ;

}
