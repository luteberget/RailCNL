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

  param
    Owned = ONo|OYesUtr|OYesNeutr;

  lincat
    SearchSubject = {cn: CN; o : Owned} ;
    DirectionalObject = {cn: CN; o : Owned};

    PathCondition = VP;
    GoalObject = NP;

  oper
    -- Alt: "den samme"
    --sameDir_NP : NP     = mkNP the_Det (mkCN same_A direction_N);
    --oppositeDir_NP : NP = mkNP the_Det (mkCN opposite_A direction_N);
    sameDir_NP : NP     = mkNP the_Det (mkCN same_A direction_N);
    oppositeDir_NP : NP = mkNP the_Det (mkCN opposite_A direction_N);

  lin

    SubjectOtherImplied = { cn = another_CN; o = ONo };
    SubjectRelationToOneMascFem cls = { cn = cls; o = OYesUtr };
    SubjectRelationToOneNeutrum cls = { cn = cls; o = OYesNeutr };
    AnySearchSubject s = {cn = s; o = ONo };

  -- Directional objects.
    FacingSwitch   =  { cn = facingSwitch_CN; o = ONo };
    TrailingSwitch =  { cn = trailingSwitch_CN; o = ONo };

    SameDirectionObject obj     = { cn = mkCN obj.cn (Syn.mkAdv in_Prep (sameDir_NP)); o = obj.o};
    OppositeDirectionObject obj = { cn = mkCN obj.cn (Syn.mkAdv in_Prep (oppositeDir_NP)); o = obj.o};


    AnyDirectionObject obj = obj;

    SearchDirectionObject obj = { cn = mkCN obj.cn (Syn.mkAdv in_Prep (mkNP the_Det driving_direction_N)); o = obj.o };

    --- OppositeSearchDirection ???


-- Search goals
  FirstFound obj = case obj.o of  {
    ONo => mkNP the_Det (mkCN first_A obj.cn);
    OYesNeutr => mkNP it_Pron (mkCN first_A obj.cn);
    OYesUtr => mkNP den_Pron (mkCN first_A obj.cn)
  };

  AnyFound obj = case obj.o of {
    ONo => mkNP a_Det obj.cn;
    OYesNeutr => mkNP it_Pron obj.cn;
    OYesUtr => mkNP den_Pron obj.cn
  };

-- Path obligations
   PathContains obj = mkVP pass_V2 (case obj.o of {
     ONo => (mkNP a_Det obj.cn);
     OYesNeutr => (mkNP it_Pron obj.cn);
     OYesUtr => (mkNP den_Pron obj.cn)
   });

   AllPathsObligation fromSubj toObject cond_VP = mkUtt (mkS (
     mkCl (mkNP (mkNP
       (mkNP all_Predet (mkNP aPl_Det path_N))
       (Syn.mkAdv from_Prep (forall_CN fromSubj)))
       (Syn.mkAdv to_Prep toObject)
     )
        (mkVP RailLex.must_VV cond_VP)
   ));

-- Distance obligations

   DistanceObligation fromSubj toObject restr = mkUtt (mkS (
mkCl (mkNP the_Det (mkCN distance_N3
      --(mkNP all_Predet (mkNP aPl_Det fromSubj))
      (forall_CN fromSubj)
      toObject))

      (mkVP RailLex.must_VV (case restr.typ of {
        RestrRS => mkVP restr.ap;
        RestrNP => mkVP restr.np
      }))
   ));

}
