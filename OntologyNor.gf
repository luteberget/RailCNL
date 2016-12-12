concrete OntologyNor of Ontology = DatalogNor ** open 
  SyntaxNor, (Syn = SyntaxNor),
  ParadigmsNor, (Par = ParadigmsNor),
  (Struct = StructuralNor),
  (Diff = DiffNor),
  (Lex = LexiconNor),
  (CommonScand = CommonScand),
  MyParadigmsNor
in {

  lincat
    Class = Str;
    Property = Str;
    Value = Str;
    Subject = NP;
    Condition = NP; -- ??
    PropertyRestriction = CN;
    Statement = Utt;

   oper

  lin
    StringClass rts = rts.s;
    -- StringAdjective rts class = rts.s ++ class;
    StringProperty rts = rts.s;

    MkValue t = t;
    
    SubjectClass cls = forall_CN (strCN cls);
    SubjectPropertyRestriction cls restr = mkNP a_Det (mkCN (strCN cls)  
      (mkRS (mkRCl which_RP restr)));

    GtProperty prop value = mkCN (strCN prop)
      (mkRS (mkRCl which_RP (mkAP big_A (mkNP (strCN value)))));

    EqProperty prop value = mkCN (strCN prop)
      (mkRS (mkRCl which_RP (strNP value)));


    ConditionClass cls = mkNP a_Det (strCN cls) ;
    ConditionPropertyRestriction = mkNP ;

    AndCond = conj_NP and_Conj;
    OrCond =  conj_NP or_Conj;
    

    DefineClass subj cls = mkUtt (mkS (
      mkCl subj (strNP cls)
    ));

    Obligation subj cond = mkUtt (mkS (
      mkCl subj (must_VP cond)
    ));

    Constraint subj cond = mkUtt (mkS (
      mkCl subj cond
    ));

    Recommendation subj cond = mkUtt (mkS (
      mkCl subj (should_VP cond)
    ));
}
