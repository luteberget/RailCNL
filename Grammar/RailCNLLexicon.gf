abstract RailCNLLexicon = Cat ** {

  fun
  -- Rules
    then_Adv : Adv ;
    of_Prep  : Prep;


  -- Statement
    should_VV : VV;
    must_VV  :VV;
    have_V : V;
    have_V2  :V2;

  -- Comparison
    small_A : A ;
    big_A : A  ;

    equal_to_A2 : A2;
    not_equal_to_A2 : A2;

    gte_A2 : A2;
    lte_A2 : A2;


    -- Directionality
    direction_N : N;
    driving_direction_N : N;
    same_A : A;
    opposite_A : A;

    -- Path
    pass_V2 : V2;
    path_N : N;
    first_A : A;
    distance_N3 : N3;

    -- Classes
    other_A : A; -- From a signal to another signal.
                -- From one signal to another??
    another_CN : CN;

    -- ... (get from XSD)
    -- Properties
    -- ... (get from XSD)

    -- Special case objects (in Graph.gf)
    facingSwitch_CN : CN;
    trailingSwitch_CN : CN;

}
