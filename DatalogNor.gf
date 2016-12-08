concrete DatalogNor of Datalog = open 
  SyntaxNor, (Syn = SyntaxNor), 
  ParadigmsNor, (Par = ParadigmsNor),
  (Struct = StructuralNor), 
  (Diff = DiffNor),
  (Lex = LexiconNor), MyParadigmsNor

in {

  lincat
    Rule = Phr;
    Conjunction = S;
    Literal = Cl;
    Term = Str;
    Predicate = Str;



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
