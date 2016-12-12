concrete GraphNor of Graph = OntologyNor ** open
  SyntaxNor, (Syn = SyntaxNor),
  ParadigmsNor, (Par = ParadigmsNor),
  (Struct = StructuralNor),
  (Diff = DiffNor),
  (Lex = LexiconNor),
  (CommonScand = CommonScand),
  RailCNLParadigmsNor,
  (RailLex = RailCNLLexiconNor), RailCNLLexiconNor
in {

  lincat
    Object = CN;
    DirectionalObject = CN;

    PathCondition = VP;
    GoalObject = NP;

  oper
    -- Alt: "den samme"
    --sameDir_NP : NP     = mkNP the_Det (mkCN same_A direction_N);
    --oppositeDir_NP : NP = mkNP the_Det (mkCN opposite_A direction_N);
    sameDir_NP : NP     = mkNP the_Det (mkCN same_A direction_N);
    oppositeDir_NP : NP = mkNP the_Det (mkCN opposite_A direction_N);

  lin

  -- Objects in general
    ObjectClass cls =  (strCN cls);
    ObjectPropertyRestriction cls restr =  (mkCN (strCN cls)
     (mkRS (mkRCl which_RP Syn.have_V2 (restr))) );


  -- Directional objects.
    FacingSwitch   =  facingSwitch_CN;
    TrailingSwitch =  trailingSwitch_CN;

    SameDirectionObject obj     = mkCN obj (Syn.mkAdv in_Prep (sameDir_NP));
    OppositeDirectionObject obj = mkCN obj (Syn.mkAdv in_Prep (oppositeDir_NP));

    AnyDirectionObject obj = obj;

    SearchDirectionObject obj = mkCN obj (Syn.mkAdv in_Prep (mkNP the_Det driving_direction_N));

    --- OppositeSearchDirection ???


-- Search goals
  FirstFound obj = mkNP the_Det (mkCN first_A obj);
  AnyFound obj = mkNP a_Det obj;


-- Path obligations
   PathContains obj = mkVP pass_V2 (mkNP a_Det obj); --- Why does this one generate so many empty strings?

   AllPathsObligation fromSubj toObject cond_VP = mkUtt (mkS (
     mkCl (mkNP (mkNP
       (mkNP all_Predet (mkNP aPl_Det path_N))
       (Syn.mkAdv from_Prep fromSubj))
       (Syn.mkAdv to_Prep toObject)
     )
        (mkVP RailLex.must_VV cond_VP)
   ));

-- Distance obligations

   DistanceObligation fromSubj toObject restr = mkUtt (mkS (
mkCl (mkNP the_Det (mkCN distance_N3
      --(mkNP all_Predet (mkNP aPl_Det fromSubj))
      fromSubj
      toObject))

      (mkVP RailLex.must_VV (case restr.typ of {
        RestrRS => mkVP restr.ap;
        RestrNP => mkVP restr.np
      }))
   ));

}
