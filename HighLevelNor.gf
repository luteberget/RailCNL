concrete HighLevelNor of HighLevel = LowLevelNor**
open SyntaxNor, (P=ParadigmsNor), (Try=TryNor) in {
   -- oper
     -- lessThan_A2 : A2 = P.mkA2 (P.mkA  )

   oper
     dist_CN : NP -> NP -> CN = \a,b ->
       (mkCN (P.mkN3 (P.mkN "avstand") (P.mkPrep "fra") (P.mkPrep "til")) a b);

     forall_N : N -> NP = \n -> mkNP a_Det n | mkNP all_Predet (mkNP aPl_Det n);
     and_NP : NP -> NP -> NP = \a,b -> mkNP and_Conj a b ;

     must_VP : NP -> VP = \np -> mkVP must_VV (mkVP np) | mkVP must_VV (mkVP have_V2 np);

 
   lincat
     Restriction = {n : CN; a : A};
     -- ImplicitySubjectLiteral = Cl;

     Class = N;
     Property = N;

     ImplicitSubject = NP;
     LiteralWithImplicitSubject = NP;
     -- CompoundWithImplicitSubject = NP;

     PropertySpec = NP;

   lin

   MkImplicitSubjectClass cls = forall_N cls;
   -- MkImplicitSubjectProperty subj p t = mkNP subj (mkAdv with_Prep (mkNP (mkCN p t))) ;
   MkImplicitSubjectProperty subj prop = mkNP subj (mkRS (mkRCl which_RP prop)) ;
   MkImplicitSubjectOtherClass subj cls = mkNP subj (mkRS (mkRCl which_RP (mkNP cls))) ;


   MkPropertySpec prop val = (mkNP (mkCN prop (mkNP val)));
   -- MkPropertyRestriction prop restr = (mkNP (mkCN restr.a restr.n));
   -- MkPropertyRestriction prop restr = mkNP (mkNP prop) (mkRS (mkRCl which_RP restr.a restr.n));
   MkCompoundProperty = and_NP;


   MkPropertyConstraintWImplSubj subj prop = mkUtt (mkS (mkCl subj (must_VP prop )) );

   -- MkPropertyWImplSubj n2 = mkCl 

   -- MkImplicitConstraint subj prop = mkUtt (mkS (  )) ;

   -- MkSimpleCompoundWImplSubj x = x;
   -- MkCompoundWImplSubj = and_NP;

   -- MkImplicitConstraint subj is = mkUtt (mkS (mkCl subj is));

   -- MkImplicitSubjectClass cls stmt = mkS (mkCl (mkNP a_Det cls) stmt)
   -- MkImplSubjProperty prop t = 
   -- MkImplSubjSimpleCompound = mkS;
   -- MkImplSubjCompound = and_S;

   MkProperty p = p; -- P.mkN2 p (P.mkPrep ("til" |"av" | "for") );
   MkClass    p = p ;

   -- MkSubClass a b = mkUtt ( (mkS (mkCl (mkNP a_Det a) (mkNP a_Det b)))
   --                 | mkS (mkCl (mkNP all_Predet (mkNP aPl_Det a)) (mkNP aPl_Det b)))
   -- ;



   Distance a b l =             (mkCl (mkNP the_Det (dist_CN (mkNP a) (mkNP b))) (mkNP l)) ;
   DistanceRestriction a b r =  (mkCl (mkNP the_Det (dist_CN (mkNP a) (mkNP b))) r.a (mkNP r.n)) ;

   AnonArithmeticLessThan x = lin Restriction {n = x; a = Try.small_A} ;
   AnonArithmeticGreaterThan x = lin Restriction {n = x; a = Try.big_A} ;

   Track = P.mkN "spor" P.neutrum;
   Signal = P.mkN "signal" P.neutrum |
            P.mkN "signal" "signalet" "signaler" "signalene";
   Balise = P.mkN "balise" P.masculine;
}
