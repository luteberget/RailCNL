concrete DatalogNor of Datalog = open
  SyntaxNor, (Syn=SyntaxNor),
  ParadigmsNor,  (Par=ParadigmsNor),
  RailCNLParadigmsNor,
  RailCNLLexiconNor
in {

  lincat
    Rule = Phr;
    Conjunction = S;
    Literal = Cl;
    Term = Str;
    Predicate = CN;


  lin

    --StringTerm rs = strCN (Par.masculine) rs.s;
    StringTerm rs = rs.s;

    -- Commenting these out for now, to reduce
    -- this type of trivial ambiguity.
    --IntTerm i = i.s;
    --FloatTerm f = f.s;


    StringPredicate rs = strCN (Par.masculine) rs.s;

    Literal0 pred = mkCl (pred);
    Literal1 pred a = mkCl (strNP_m a) (pred);
    Literal2 pred a b = mkCl (strNP_m b) (x_of_y (mkNP pred) (strNP_m a)) ;
    -- Literal3 pred a b c = mkCl (mkNP pred)
    -- Literal 4

    GtLit  a b = mkS (cmpCl big_A           (strNP_m a) (strNP_m b) );
    GteLit a b = mkS (cmpCl gte_A2           (strNP_m a) (strNP_m b)  );
    LtLit  a b = mkS (cmpCl small_A           (strNP_m a) (strNP_m b) );
    LteLit a b = mkS (cmpCl lte_A2            (strNP_m a) (strNP_m b) );
    EqLit  a b = mkS (cmpCl equal_to_A2       (strNP_m a) (strNP_m b) );
    NeqLit a b = negCl (cmpCl equal_to_A2      (strNP_m a) (strNP_m b) ) |
              mkS (cmpCl not_equal_to_A2  (strNP_m a) (strNP_m b) );


    SimpleConj = mkS;
    Negation = negCl;
    Conj = andS;

    MkRule head body =
     mkPhr (mkS (Syn.mkAdv if_Subj body) (mkS then_Adv (mkS head)) );

}
