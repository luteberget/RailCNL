
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

  lincat Area = CN;

  oper

    areaAdv : CN -> Adv = \a -> Syn.mkAdv in_Prep (mkNP a) ;

  lin

    TunnelArea = tunnel_CN;
    BridgeArea = bridge_CN;
    LocalReleaseArea = localreleasearea_CN;

    NamedArea s = strCN s.s;
    SpecificArea s a = mkCN a (strNP s.s);

    AreaPropertyRestriction area restr = mkCN area
     (mkRS (mkRCl which_RP Syn.have_V2 (restr))) ;

    ObjectArea obj area = mkCN obj (areaAdv area) ;
    SubjectArea subj area = mkNP subj (areaAdv area); 
    AreaCondition a = { np = mkNP (strN "plassering"); cls = OnlyProperty };

}


    

