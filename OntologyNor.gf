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
    RestrictionType = RestrNP | RestrRS;


  lincat
    Class = Str;
    Property = Str;
    Value = Str;
    Subject = NP;
    Condition = { np : NP ; cls : ConditionRec };
    PropertyRestriction = NP;
    Restriction = { ap : AP; np : NP; typ : RestrictionType} ;
    Statement = Utt;

  oper
    mkCmpRS : AP -> RS
      = \a ->
        (mkRS (mkRCl which_RP a));

    is_or_has : { np : NP ; cls:ConditionRec } -> VP
      = \cond -> case cond.cls of {
        WithClass => mkVP cond.np;
        OnlyProperty => mkVP RailLex.have_V2 cond.np
      };

      conj_Restriction : Syn.Conj -> Restriction -> Restriction -> Restriction
       = \conj,r1,r2 ->  lin Restriction  {
         ap = mkAP conj r1.ap r2.ap ;
         np = mkNP conj r1.np r2.np ;
         typ = case <r1.typ,r2.typ> of {
           <RestrNP,RestrNP> => RestrNP;
           _ => RestrRS
         }
       };

       conj_Condition : Syn.Conj -> Condition -> Condition -> Condition
        = \conj,c1,c2 -> lin Condition {
          np = conj_NP conj c1.np c2.np;
          cls = case <c1.cls,c2.cls> of {
            <OnlyProperty,OnlyProperty> => OnlyProperty;
            _ => WithClass
          }
        };

  lin
    StringClass rts = rts.s;
    -- StringAdjective rts class = rts.s ++ class;
    StringProperty rts = rts.s;

    MkValue t = t;

    SubjectClass cls = forall_CN (strCN cls);
    SubjectPropertyRestriction cls restr = forall_CN (mkCN (strCN cls)
     (mkRS (mkRCl which_RP Syn.have_V2 (restr))) );

    Gt val =  { ap = mkAP big_A (strNP val);       np = strNP val; typ = RestrRS };
    Gte val =  { ap = mkAP gte_A2 (strNP val);     np = strNP val; typ = RestrRS };
    Lt val =  { ap = mkAP small_A (strNP val);     np = strNP val; typ = RestrRS };
    Lte val =  { ap = mkAP lte_A2 (strNP val);     np = strNP val; typ = RestrRS };
    Eq val =  { ap = mkAP equal_to_A2 (strNP val); np = strNP val; typ = RestrNP };
    Neq val =  { ap = mkAP not_equal_to_A2 (strNP val); np = strNP val; typ = RestrRS };

    AndRestr = conj_Restriction and_Conj;
    OrRestr = conj_Restriction or_Conj;

    AndPropRestr = conj_NP and_Conj;
    OrPropRestr = conj_NP or_Conj;

    MkPropertyRestriction prop restr = case restr.typ of {
      RestrRS => mkNP (mkCN (strCN prop) (mkCmpRS restr.ap));
      RestrNP => mkNP (mkCN (strCN prop) restr.np)
    };

    ConditionClass cls = { np = mkNP a_Det (strCN cls) ; cls = WithClass };
    ConditionPropertyRestriction prop = { np = prop ; cls = OnlyProperty };

    AndCond = conj_Condition and_Conj;
    OrCond =  conj_Condition or_Conj;


    Constraint subj cond = mkUtt (mkS (
        mkCl subj (is_or_has cond)
    ));

    Obligation subj cond = mkUtt (mkS (
      mkCl subj (mkVP RailLex.must_VV (is_or_has cond))
    ));

    Recommendation subj cond = mkUtt (mkS (
      mkCl subj (mkVP RailLex.should_VV (is_or_has cond))
    ));
}
