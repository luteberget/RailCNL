concrete RailCNLLexiconNor of RailCNLLexicon = CatNor **
  open MorphoNor, ParadigmsNor, (X = ConstructX), IrregNor, Prelude,
  (Struct = StructuralNor),
  (Lex = LexiconNor),
  (Syn = SyntaxNor)
   in {

  lin
    should_VV = lin VV ((mkV "burde" "bør" "bør" "burde" "burdet" "bør") ** {c2 = mkComplement []});


    must_VV = Struct.must_VV;
    have_V2 = Struct.have_V2;

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

 other_A = mkA "annen" "annet" "andre";
 another_CN = Syn.mkCN (mkN "annen");


--Directionality
      same_A = mkA "samme" "samme" "samme";
      direction_N = mkN "retning";
      driving_direction_N = mkN "kjøreretning";
      opposite_A = mkA "motsatt" "motsatt" "motsatte";

      -- Path
      pass_V2 = mkV2 "passere";
      path_N = mkN "vei";
      first_A = mkA "først" "først" "første";
      distance_N3 = mkN3 (mkN "avstand") (mkPrep "fra") (mkPrep "til");

      --- Graph objects
      facingSwitch_CN   = Syn.mkCN (mkA "motrettet") (mkN "sporveksel");
      trailingSwitch_CN = Syn.mkCN (mkA "medrettet") (mkN "sporveksel");


      tunnel_CN = Syn.mkCN (mkN "tunnel") ;
      bridge_CN = Syn.mkCN (mkN "bro") ;
      localreleasearea_CN = Syn.mkCN (mkN "lokalområde" );

}
