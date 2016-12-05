concrete DatalogNor of Datalog = open (Pre=Prelude), SyntaxNor, (Syn = SyntaxNor), ParadigmsNor, (S=StructuralNor), (P=ParadigmsNor), (D=DiffNor) in {
  lincat
      Rule = S ;
      Compound = S ;
      Literal = Cl;
      Term = NP;
      Predicate = NP;

  oper
    then_Adv : Adv = P.mkAdv "så" ;
    of_Prep : Prep = P.mkPrep "til" ;

    x_of_y : NP -> NP -> NP -- Mother of the king -- Moren til kongen
     = \mother,king -> mkNP mother (Syn.mkAdv possess_Prep king) ;

    mkPN_x : Str -> PN
     = \s -> {s = \\_ =>  s ; g = D.ngen2gen neutrum } ** {lock_PN = <>} ;

--     mkN_x : Str -> N
--      = \s -> {s = \\_ =>  s ; g = D.ngen2gen neutrum } ** {lock_N = <>} ;

  lin
    --if_then_Conj = {s1 = "om" ; s2 = "så" ; n = singular ; isDiscont = False } ;

    -- track(T)
    TrackClassPredicate t =  (mkCl  t (mkNP (mkN "spor"))) ;

    -- trackQuality(T,Q)
    TrackQualityPredicate t q =  (mkCl (mkNP (mkCN (mkN2 (mkN "kvalitetsklasse") (mkPrep "til"))  t))  q) ;

    -- distance(A,B,L)
    DistancePredicate a b l =  (mkCl 
	(mkNP (mkCN (mkN3 (mkN "avstand") (mkPrep "fra") (mkPrep "til")) a  b))
	 l
	) ;

    Negation l = mkS presentTense negativePol l ;
    Conjunction l1 l2 = mkS and_Conj l1 l2 ;
    SimpleCompound l = mkS l;
    Fact l = mkS l ;

    Implies head body = mkS (Syn.mkAdv if_Subj  body) (mkS then_Adv (mkS head));

    StringPredicate x = mkNP (mkPN_x x.s );
    StringTerm x = mkNP (mkPN_x x.s );

    CustomLiteral0 pred = mkCl pred ;
    CustomLiteral1 pred a = mkCl a pred ;
    CustomLiteral2 pred a b = mkCl b (x_of_y pred a) ;
}
