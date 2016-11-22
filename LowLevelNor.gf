concrete LowLevelNor of LowLevel = open (Pre=Prelude), SyntaxNor, (CS=CommonScand), (Syn = SyntaxNor), ParadigmsNor, (S=StructuralNor), (P=ParadigmsNor), (D=DiffNor) in {
  lincat
    Document, Id  = {s : Str};
    Constraint, Obligation = Utt;
    Compound = S;
    Literal = Cl;
    Term = NP;
    Predicate = N;

  oper
    then_Adv : Adv = P.mkAdv "så" ;
    of_Prep : Prep = P.mkPrep "til" ;

    x_of_y : NP -> NP -> NP -- Mother of the king -- Moren til kongen
     = \mother,king -> mkNP mother (Syn.mkAdv possess_Prep king) ;

    mkPN_x : Str -> PN
     = \s -> lin PN {s = \\_ =>  s ; g = D.ngen2gen neutrum } ** {lock_PN = <>} ;

    mkN_x : Str -> N
     = \str -> lin N {s = \\_ => \\_ => \\_ => str ; g = masculine
-- ; co = \\_ => str
; co = str
};

    and_S : S -> S -> S = \a,b -> mkS and_Conj a b ;

--     mkN_x : Str -> N
--      = \s -> {s = \\_ =>  s ; g = D.ngen2gen neutrum } ** {lock_N = <>} ;

    sStr : S -> Str = \sen -> sen.s ! CS.Main ; -- Hovedsetning

    det_N : N -> NP = \n -> mkNP n ;
    det_PN : PN -> NP = \n -> mkNP n ;
    det_CN : CN -> NP = \n -> mkNP n ;

  lin
    -- Fact l = mkS l ;
    -- Implies head body = mkS (Syn.mkAdv if_Subj  body) (mkS then_Adv (mkS head));

    CatDocument a b = {s = a.s ++ "\n" ++ b.s};
    MkConstraintDocument id c = {s = "<constraint id=" ++ id.s ++ ">" ++ c.s ++ "</constraint>"};
    MkObligationDocument id c = {s = "<obligation id=" ++ id.s ++ ">" ++ c.s ++ "</obligation>"};

    MkConstraint head body = mkUtt (mkS (Syn.mkAdv if_Subj body) (mkS then_Adv (mkS head)));
    MkObligation facts conds = mkUtt (mkS (Syn.mkAdv if_Subj facts) (mkS then_Adv conds));

    SimpleCompound l = mkS l;
    Conjunction l1 l2 = and_S l1 l2 ;
    Negation l = mkS presentTense negativePol l ;

    StringPredicate x =  (mkN_x x.s );
    StringTerm x = mkNP (mkPN_x x.s );
    IntTerm x = mkNP (mkPN_x x.s);
    FloatTerm x = mkNP (mkPN_x x.s);
    StringId x = x;

    Literal0 pred = mkCl (det_N pred) ;
    Literal1 pred a = mkCl (a) (det_N pred) ;
    Literal2 pred a b = mkCl (b) (x_of_y (det_N pred) (a)) ;
}
