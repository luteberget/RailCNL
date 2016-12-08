concrete DatalogNor of Datalog = open 
  SyntaxNor, (Syn = SyntaxNor), 
  ParadigmsNor, (Par = ParadigmsNor),
  (Struct = StructuralNor), 
  (Diff = DiffNor),
  (Lex = LexiconNor)

in {

  lincat
    Rule = Phr;
    Conjunction = S;
    Literal = Cl;
    Term = Str;
    Predicate = Str;


  oper
    then_Adv : Adv  = Par.mkAdv  "så";
    of_Prep  : Prep = Par.mkPrep "til";

    small_A : A  = Lex.small_A;
    big_A : A    = Lex.big_A;

    equal_to_A2 : A2 = Par.mkA2 (mkA "lik" "lik") (mkPrep "");
    not_equal_to_A2 : A2 = 
-- Par.mkA2 (mkA "ikke lik" "ikke lik") (mkPrep "")
    -- not_equal_to_A2 : A = 
           Par.mkA2 (mkA "ulik" "ulik") (mkPrep "");

    gte_A2 : A2 = Par.mkA2 (mkA 
      "større enn eller lik"
      "større enn eller lik"
      ) (mkPrep "") ;

    lte_A2 : A2 = Par.mkA2 (mkA 
      "mindre enn eller lik"
      "mindre enn eller lik"
      ) (mkPrep "") ;

    x_of_y : NP -> NP -> NP
     = \mother,king -> mkNP mother (Syn.mkAdv possess_Prep king) ;
    
    strPN : Str -> PN
      = \str -> lin PN { s = \\_ => str; g = Diff.ngen2gen neutrum } ;

    strN : Str -> N
      = \str -> lin N { s = \\_ => \\_ => \\_  => str ; g = masculine ; co = str };

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

  lin

    StringTerm rs = rs.s;
    IntTerm i = i.s;
    FloatTerm f = f.s;

    StringPredicate rs = rs.s;

    Literal0 pred = mkCl (strNP pred);
    Literal1 pred a = mkCl (strNP a) (strNP pred);
    Literal2 pred a b = mkCl (strNP b) (x_of_y (strNP pred) (strNP a)) ;
    -- Literal3 pred a b c = mkCl (strNP pred) 
    -- Literal 4

    Gt  a b = mkS (cmpCl big_A           a b );
    Gte a b = mkS (cmpCl gte_A2          a b );
    Lt  a b = mkS (cmpCl small_A         a b );
    Lte a b = mkS (cmpCl lte_A2          a b );
    Eq  a b = mkS (cmpCl equal_to_A2     a b );
    Neq a b = negCl (cmpCl equal_to_A2     a b ) |
              mkS (cmpCl not_equal_to_A2 a b );


    SimpleConj = mkS;
    Negation = negCl;
    Conj = andS;

    MkRule head body = 
     mkPhr (mkS (Syn.mkAdv if_Subj body) (mkS then_Adv (mkS head)) );

}
