concrete OntologyNor of Ontology = DatalogNor ** open
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
    ConditionRec = WithClass | OnlyProperty ;


  lincat
    Class = Str;
    Property = Str;
    Value = Str;
    Subject = NP;
    Condition = { np : NP ; cls : ConditionRec };
    PropertyRestriction = CN;
    Statement = Utt;

  oper
    mkCmpA : A -> Str -> Str -> CN
      = \a,prop,value -> mkCN (strCN prop)
        (mkRS (mkRCl which_RP (mkAP a (mkNP (strCN value)))));

    is_or_has : { np : NP ; cls:ConditionRec } -> VP
      = \cond -> case cond.cls of {
        WithClass => mkVP cond.np;
        OnlyProperty => mkVP RailLex.have_V2 cond.np
      };

  lin
    StringClass rts = rts.s;
    -- StringAdjective rts class = rts.s ++ class;
    StringProperty rts = rts.s;

    MkValue t = t;

    SubjectClass cls = forall_CN (strCN cls);
    SubjectPropertyRestriction cls restr = forall_CN (mkCN (strCN cls)
     (mkRS (mkRCl which_RP Syn.have_V2 (mkNP restr))) );

    GtProperty = mkCmpA big_A;
    LtProperty = mkCmpA small_A;
    EqProperty prop value = mkCN (strCN prop) (strNP value);

    ConditionClass cls = { np = mkNP a_Det (strCN cls) ; cls = WithClass };
    ConditionPropertyRestriction prop = { np = mkNP prop ; cls = OnlyProperty };

    --AndCond = conj_NP and_Conj;
    --OrCond =  conj_NP or_Conj;


    DefineClass subj cls = mkUtt (mkS (
      mkCl subj (strNP cls)
    ));

    Obligation subj cond = mkUtt (mkS (
      -- mkCl subj (vv_have RailLex.must_VV cond)
      mkCl subj (mkVP RailLex.must_VV (is_or_has cond))
    ));

    Constraint subj cond = mkUtt (mkS (
      mkCl subj (is_or_has cond)
    ));

    Recommendation subj cond = mkUtt (mkS (
      mkCl subj (mkVP RailLex.should_VV (is_or_has cond))
    ));
}
