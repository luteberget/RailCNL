concrete OntologyNor of Ontology = DatalogNor ** open
  SyntaxNor, (Syn = SyntaxNor),
  ParadigmsNor, (Par = ParadigmsNor),
  (Struct = StructuralNor),
  (Diff = DiffNor),
  (Lex = LexiconNor),
  (CommonScand = CommonScand),
  RailCNLParadigmsNor,
  RailCNLLexiconNor
in {

  param
    IsSimple = Simple | NotSimple;

  lincat
    Class = Str;
    Property = Str;
    Value = Str;
    Subject = NP;

    Condition = NP; -- ??
    -- TODO Condition: add field to decide is/has

    PropertyRestriction = {cn : CN; prop : Str; value : Str; simple:IsSimple };
    Statement = Utt;


  lin
    StringClass rts = rts.s;
    -- StringAdjective rts class = rts.s ++ class;
    StringProperty rts = rts.s;

    MkValue t = t;

    SubjectClass cls = forall_CN (strCN cls);
    SubjectPropertyRestriction cls restr = case restr.simple of {
      NotSimple => forall_CN (mkCN (strCN cls)
       (mkRS (mkRCl which_RP Syn.have_V2 (mkNP restr.cn))) );

       Simple => forall_CN (mkCN (strCN cls)
        (mkRS (mkRCl which_RP Syn.have_V2 ((mkNP restr.cn ))) ))
    };

    GtProperty prop value = {
      cn = mkCN (strCN prop) (mkRS (mkRCl which_RP (mkAP big_A (mkNP (strCN value)))));
      prop = prop;
      value = value;
      simple = NotSimple};

    EqProperty prop value = {
      cn = (mkCN (strCN prop) (strNP value)); -- mkCN (strCN prop) (mkRS (mkRCl which_RP (strNP value)));
      prop = prop;
      value = value;
      simple = Simple};


    ConditionClass cls = mkNP a_Det (strCN cls) ;
    ConditionPropertyRestriction prop = mkNP prop.cn;

    AndCond = conj_NP and_Conj;
    OrCond =  conj_NP or_Conj;


    DefineClass subj cls = mkUtt (mkS (
      mkCl subj (strNP cls)
    ));

    Obligation subj cond = mkUtt (mkS (
      mkCl subj (vv_have must_VV cond)
    ));

    Constraint subj cond = mkUtt (mkS (
      mkCl subj cond | mkCl subj have_V2 cond
    ));

    Recommendation subj cond = mkUtt (mkS (
      mkCl subj (vv_have should_VV cond)
    ));
}
