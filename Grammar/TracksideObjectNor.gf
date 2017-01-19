
concrete TracksideObjectNor of TracksideObject = OntologyNor ** open
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
    Vector = CN;

  lin
    TrackTangent = mkCN (Par.mkN "sportangent");
    OrientationAngleTo vec = mkCN (mkCN (Par.mkN "vinkel")) (Syn.mkAdv to_Prep (mkNP the_Det vec));
}
