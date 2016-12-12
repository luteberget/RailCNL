abstract Graph = Ontology ** {
  -- Graph property language.


  cat
    DirectionalSubject;
    PathCondition;

  fun

-- Subjects which are direction-dependent.

  -- Special terminology for switch goal
  FacingSwitch : DirectionalSubject;
  TrailingSwitch : DirectionalSubject;

  -- General terminology for goals: signals, derailers, etc.
  SameDirectionSubject : Subject -> DirectionalSubject;
  OppositeDirectionSubject : Subject -> DirectionalSubject;

  AnyDirectionSubject : Subject -> DirectionalSubject;

  SearchDirectionSubject : Subject -> DirectionalSubject;
  OppositeSearchDirecitonSubject : Subject -> DirectionalSubject;


-- Distance

--    Distance : Term -> Term -> PropertyRestriction -> Literal;
    -- Avstanden fra X til Y er Z.

    -- A home main signal shall be placed at least 200 m in
    -- front of the first controlled, facing switch
    -- in the entry train path
    -- --->
    -- Alle veier fra en stasjonsgrense til første motrettet sporveksel
    -- må passere et innkjørhovedsignal i kjøreretningen.
    --
    -- Avstanden fra et innkjørhovedsignal til første motrettede sporveksel
    -- må være større enn 200.

    -- Balise spacing
    -- Avstanden mellom baliser må være større enn 3.

    AllPathsObligation : Subject -> DirectionalSubject -> PathCondition -> Obligation;
    -- ExistsPathObligation : Subject -> DirectionalSubject -> PathCondition;

    DistanceObligation : Subject -> DirectionalSubject -> PropertyRestriction -> Obligation;


}
