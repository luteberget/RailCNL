concrete OntologyExtensionsNor of OntologyExtensions = GraphNor ** open
  SyntaxNor, (Syn = SyntaxNor),
  ParadigmsNor, (Par = ParadigmsNor),
  (MorphoNor=MorphoNor),
  (Struct = StructuralNor),
  (Diff = DiffNor),
  (Lex = LexiconNor),
  (CommonScand = CommonScand),
  RailCNLParadigmsNor,
  (RailLex = RailCNLLexiconNor), RailCNLLexiconNor
in {


  lincat
  RelatedSubjects = NP;
  TwoRelations = NP;

  lin

  MkRelatedSubjects subj obj = mkNP and_Conj (forall_CN subj) (
case obj.o of  {
    ONo => mkNP the_Det  obj.cn;
    OYesNeutr => mkNP it_Pron obj.cn;
    OYesUtr => mkNP den_Pron obj.cn
  });

  TwoRelationsOfSubject cls1 cls2 subj = 
   (mkNP (mkNP and_Conj (mkNP cls1) (mkNP cls2))
         (Syn.mkAdv for_Prep (forall_CN subj)));

  RelatedObjectsToRelatedObjects mod from to = mkUtt (mkS 
      (case mod.typ of { MNeg => negativePol; MPos => positivePol })
      (mkCl from (mkVP mod.vv (mkVP to)))
  );
}
