
concrete AreaNor of Area = GraphNor ** open
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
    AreaConj = NP;
    Area = CN;
    BaseArea = CN;
    NamedArea = CN;

  oper
    areaAdv : NP -> Adv = \a -> Syn.mkAdv in_Prep a ;
    placed_A : A = Par.mkA "plassert" "plassert";
    place_V : V = Par.mkV "plassere" "plasserer" "plasseres" "plasserte" "plassert" "plassér";
    place_V2 : V2 = Par.mkV2 (Par.mkV "plassere" "plasserer" "plasseres" "plasserte" "plassert" "plassér") in_Prep;

  lin

    TunnelArea = tunnel_CN;
    BridgeArea = bridge_CN;
    LocalReleaseArea = localreleasearea_CN;

    MkNamedArea s = strCN Par.masculine s.s;
    SpecificArea s a = mkCN a (strNP Par.masculine s.s);
    NonSpecificArea a = a;

    AreaPropertyRestriction area restr = mkCN area
     (mkRS (mkRCl which_RP Syn.have_V2 (restr))) ;
    NoRestrictionArea a = a;

    SingleArea a = mkNP a;
    OrArea  = conj_NP or_Conj ;
    AndArea  = conj_NP and_Conj;

    SubjectArea subj area = (mkCN subj (areaAdv area));

    --ObjectArea obj area = mkCN obj (areaAdv area) ;
    -- SubjectArea subj area = Syn.mkNP (Syn.mkCN subj (areaAdv area));
    -- AreaCondition a = { np = mkNP (mkNP (Par.mkN "plassering")) (areaAdv a); cls = OnlyProperty };


    PlacementRestriction mod subj area = mkUtt(mkS
      (case mod.typ of {MNeg => negativePol ; MPos => positivePol})
      (mkCl (forall_CN subj) (mkVP mod.vv (mkVP (mkVP placed_A) (areaAdv area)))));

-- Using passiveVP for the "to be placed in ..." 
-- linearizes to "må bli plassert" instead of "må være plassert".
--
--    PlacementRestriction mod subj area = mkUtt(mkS
--      (case mod.typ of {MNeg => negativePol ; MPos => positivePol})
--      (mkCl subj (mkVP mod.vv (mkVP (Syn.passiveVP place_V2) (areaAdv area)))));
}




