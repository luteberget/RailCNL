resource RailCNLParadigmsNor = open
  SyntaxNor, (Syn = SyntaxNor),
  ParadigmsNor, (Par = ParadigmsNor),
  (Struct = StructuralNor),
  (Diff = DiffNor),
  (Lex = LexiconNor),
  (CommonScand = CommonScand),
  (RailLex = RailCNLLexiconNor), RailCNLLexiconNor
 in {


  oper

    -- vv_have : VV -> NP -> VP = \vv,np -> mkVP vv (mkVP np) 
    -- vv_have : VV -> NP -> VP = \vv,np -> mkVP vv (mkVP RailLex.have_V2 np);
    forall_CN : CN -> NP = \n -> mkNP a_Det n | mkNP all_Predet (mkNP aPl_Det n);
    conj_NP : Syn.Conj -> NP -> NP -> NP = \conj,a,b -> mkNP conj a b ;


    x_of_y : NP -> NP -> NP
     = \mother,king -> mkNP mother (Syn.mkAdv possess_Prep king) ;

    strPN : DiffNor.NGenderNor -> Str -> PN
      = \g,str -> lin PN { s = \\_ => str; g = Diff.ngen2gen g } ;

     strN : DiffNor.NGenderNor -> Str -> N
     = \g,str -> 
lin N { s = \\_ => \\_ => \\_  => str ; g = g ; co = str }
     ;

    strCN : DiffNor.NGenderNor -> Str -> CN = \g,str -> mkCN (strN g str);

    strNP : DiffNor.NGenderNor -> Str -> NP = \g,str -> mkNP (strPN g str);

    strNP_m : Str -> NP = \s -> strNP Par.masculine s;


    cmpCl = overload {
       cmpCl : A -> NP -> NP -> Cl  =
         \adj,a,b -> mkCl a (mkAP adj b) ;

       cmpCl : A2 -> NP -> NP -> Cl
	 = \adj,a,b -> mkCl a (mkAP adj b) ;
    };

    negCl : Cl -> S = mkS presentTense negativePol;
    andS : S -> S -> S = mkS and_Conj;

};
