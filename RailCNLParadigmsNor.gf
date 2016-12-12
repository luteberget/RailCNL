resource RailCNLParadigmsNor = open
  SyntaxNor, (Syn = SyntaxNor),
  ParadigmsNor, (Par = ParadigmsNor),
  (Struct = StructuralNor),
  (Diff = DiffNor),
  (Lex = LexiconNor),
  (CommonScand = CommonScand),
  RailCNLLexiconNor
 in {


  oper

    vv_have : VV -> NP -> VP = \vv,np ->   mkVP vv (mkVP np) | mkVP vv (mkVP have_V2 np);
    forall_CN : CN -> NP = \n -> mkNP a_Det n | mkNP all_Predet (mkNP aPl_Det n);
    conj_NP : Syn.Conj -> NP -> NP -> NP = \conj,a,b -> mkNP conj a b ;


    x_of_y : NP -> NP -> NP
     = \mother,king -> mkNP mother (Syn.mkAdv possess_Prep king) ;

    strPN : Str -> PN
      = \str -> lin PN { s = \\_ => str; g = Diff.ngen2gen neutrum } ;

    strN : Str -> N
      = \str -> lin N { s = \\_ => \\_ => \\_  => str ; g = masculine | feminine | neutrum ; co = str };

    strCN : Str -> CN = \str -> mkCN (strN str);

    strNP : Str -> NP = \str -> mkNP (strPN str);

    cmpCl = overload {
       cmpCl : A -> Str -> Str -> Cl  =
         \adj,a,b -> mkCl (strNP a) (mkAP adj (strNP b)) ;

       cmpCl : A2 -> Str -> Str -> Cl
	 = \adj,a,b -> mkCl (strNP a) (mkAP adj (strNP b)) ;
    };

    negCl : Cl -> S = mkS presentTense negativePol;
    andS : S -> S -> S = mkS and_Conj;

};
