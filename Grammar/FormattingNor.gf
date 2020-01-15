
concrete FormattingNor of Formatting = OntologyNor ** open
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
    Dimension = CN;
    Unit = CN;
    RoundingFactor = Str;

  lin

    StringRoundingFactor s = s.s;

    LengthDimension = mkCN (Par.mkN "lengde");
    AreaDimension = mkCN (Par.mkN "areal");
    TimeDimension = mkCN (Par.mkN "tid");

    MeterUnit = mkCN (Par.mkN "m");
    MillimeterUnit = mkCN (Par.mkN "mm");
    KilometerUnit = mkCN (Par.mkN "km");

    DisplayQuantity cls dim unit factor = mkUtt(mkS(mkCl
     (mkNP cls) (mkVP RailLex.have_V2 (conj_NP and_Conj (conj_NP and_Conj (mkNP (mkCN (strA "dimensjon") dim)) (mkNP (mkCN (strA "enhet") unit))) (mkNP (mkCN (strA "faktor") (strCN Par.masculine factor)))))
   ));

}




