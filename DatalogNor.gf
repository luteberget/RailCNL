concrete DatalogNor of Datalog = open Prelude, SyntaxSwe, ParadigmsSwe in {
  lincat
      Rule = S ;
      Compound = S ;
      Literal = Cl ;
      Term = NP;


  lin
    --if_then_Conj = {s1 = "om" ; s2 = "så" ; n = singular ; isDiscont = False } ;

    -- track(T)
    TrackClassPredicate t =  (mkCl t (mkNP (mkN "spor"))) ;

    -- trackQuality(T,Q)
    TrackQualityPredicate t q =  (mkCl (mkNP (mkCN (mkN2 (mkN "kvalitetsklasse") (mkPrep "til")) t)) q) ;

    -- distance(A,B,L)
    DistancePredicate a b l =  (mkCl 
	(mkNP (mkCN (mkN3 (mkN "avstand") (mkPrep "fra") (mkPrep "til")) a b))
	l
	) ;

    UnknownPredicate =  (mkCl (mkN "predikat"));

    X = mkNP (mkN "X");
    Y = mkNP (mkN "Y");
    Z = mkNP (mkN "Z");
    a = mkNP (mkN "a");
    b = mkNP (mkN "b");
    c = mkNP (mkN "c");

    Negation l = mkS presentTense negativePol l ;
    Conjunction l1 l2 = mkS and_Conj l1 l2 ;
    SimpleCompound l = mkS l;
    Fact l = mkS l ;
    Implies head body = mkS if_then_Conj body (mkS head) ;
}
