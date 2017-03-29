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
    ModalityType = MNeg | MPos ;

  lincat
    Class = CN;
    BaseClass = CN;
    Property = CN;
    Value = Str;
    Subject = CN;
    OpenSubject = CN;
    Condition = VP;
    ConsequentCondition = VP;
    PropertyRestriction = NP;
    ClassRestriction = NP;
    Restriction = { ap : AP; np : NP; typ : RestrictionType} ;
    Statement = Utt;
    Modality = { vv : VV ; typ : ModalityType };
    RelationMultiplicity = Digits;

  oper 
      conj_Restriction : Syn.Conj -> Restriction -> Restriction -> Restriction
       = \conj,r1,r2 ->  lin Restriction  {
         ap = mkAP conj r1.ap r2.ap ;
         np = mkNP conj r1.np r2.np ;
         typ = case <r1.typ,r2.typ> of {
           <RestrNP,RestrNP> => RestrNP;
           _ => RestrRS
         }
       };


  lin
    StringClassMasculine rts = strCN Par.masculine rts.s;
    StringClassFeminine rts = strCN Par.feminine rts.s;
    StringClassNeutrum rts = strCN Par.neutrum rts.s;

    StringClassAdjective rts cls = mkCN (strA rts.s) cls;
    StringClassNoAdjective cls = cls;

    StringProperty rts = strCN Par.masculine rts.s;

    MkValue t = t;

    SubjectClass cls =  (cls);
    SubjectCondition cls cond =  (mkCN cls
      (mkRS (mkRCl which_RP cond)));
    CloseSubject s = s;

    Gt val =  { ap = mkAP big_A (strNP_m val);       np = strNP_m val; typ = RestrRS };
    Gte val =  { ap = mkAP gte_A2 (strNP_m val);     np = strNP_m val; typ = RestrRS };
    Lt val =  { ap = mkAP small_A (strNP_m val);     np = strNP_m val; typ = RestrRS };
    Lte val =  { ap = mkAP lte_A2 (strNP_m val);     np = strNP_m val; typ = RestrRS };
    Eq val =  { ap = mkAP equal_to_A2 (strNP_m val); np = strNP_m val; typ = RestrNP };
    Neq val =  { ap = mkAP not_equal_to_A2 (strNP_m val); np = strNP_m val; typ = RestrRS };

    AndRestr = conj_Restriction and_Conj;
    OrRestr = conj_Restriction or_Conj;

    AndPropRestr = conj_NP and_Conj;
    OrPropRestr = conj_NP or_Conj;

    MkPropertyRestriction prop restr = case restr.typ of {
      RestrRS => mkNP (mkCN prop (mkRS (mkRCl which_RP restr.ap)));
      RestrNP => mkNP (mkCN prop restr.np)
    };

    MkClassRestriction cls = mkNP a_Det cls;
    AndClassRestr = conj_NP and_Conj;
    OrClassRestr = conj_NP or_Conj;


    ConditionClassRestriction cls = mkVP cls;
    ConditionPropertyRestriction prop = mkVP RailLex.have_V2 prop;
    ConditionClassAndPropertyRestriction cls prop = mkVP (mkNP a_Det 
      (mkCN cls (mkRS (mkRCl which_RP Syn.have_V2 prop))));

    ExistsRelation = lin Digits {s =  \\_ => "et"; n = Par.singular};
    OneRelation = lin Digits {s =  \\_ => "ett"; n = Par.singular};
    ManyRelation = lin Digits {s =  \\_ => "ett eller flere"; n = Par.plural};

    ConditionRelationRestriction mult cls = mkVP RailLex.have_V2 (mkNP mult cls);
    ConditionRelationWithPropertyRestriction mult cls prop = mkVP RailLex.have_V2 (mkNP mult 
      (mkCN cls (mkRS (mkRCl which_RP Syn.have_V2 prop))));

    MkConsequent x = x;

    Obligation             = { vv = RailLex.must_VV;   typ = MPos };
    NegativeObligation     = { vv = RailLex.shall_VV;  typ = MNeg };
    Recommendation         = { vv = RailLex.should_VV; typ = MPos };
    NegativeRecommendation = { vv = RailLex.should_VV; typ = MNeg };

    OntologyAssertion subj cond = mkUtt(mkS(mkCl (forall_CN subj) cond));
    OntologyRestriction mod subj cond = mkUtt(mkS
      (case mod.typ of { MNeg => negativePol; MPos => positivePol })
      (mkCl (forall_CN subj) (mkVP mod.vv cond)));
}
