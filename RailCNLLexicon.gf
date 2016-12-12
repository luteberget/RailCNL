abstract RailCNLLexicon = Cat ** {

  fun 
  -- Rules
    then_Adv : Adv ;
    of_Prep  : Prep;


  -- Statement
    should_VV : VV;

  -- Comparison
    small_A : A ;
    big_A : A  ;

    equal_to_A2 : A2;
    not_equal_to_A2 : A2;

    gte_A2 : A2;
    lte_A2 : A2;
}
