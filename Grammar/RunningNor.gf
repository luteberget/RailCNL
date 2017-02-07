concrete RunningNor of Running = GraphNor ** open
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
    VelocitySpec = CN;

  lin

    NominalSpeed = mkCN (mkAP (mkA "nominell")) (mkN "hastighet");
    RunningTimeObligation vel fromSubj toObject restr = mkUtt (mkS (

mkCl 
(mkNP
  (mkNP 
    (mkNP (mkNP the_Det runningtime_CN)
          (Syn.mkAdv in_Prep (mkNP vel)))
          (Syn.mkAdv from_Prep (forall_CN fromSubj)))
          (Syn.mkAdv to_Prep   toObject))
  
      (mkVP RailLex.must_VV (case restr.typ of {
        RestrRS => mkVP restr.ap;
        RestrNP => mkVP restr.np
      }))
   ));

}
