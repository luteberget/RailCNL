abstract Graph = Ontology ** {
  -- Graph property language.
  flags startcat=Statement;

  cat
    DirectionalObject;
    GoalObject;
    PathCondition;
    SearchSubject;

  fun

-- Objects which are direction-dependent.

  SubjectOtherImplied : SearchSubject;
  SubjectRelationToOneMascFem : Class -> SearchSubject;
  SubjectRelationToOneNeutrum : Class -> SearchSubject;
  AnySearchSubject : Subject -> SearchSubject;

  -- Special terminology for switch goal
  FacingSwitch : DirectionalObject;
  TrailingSwitch : DirectionalObject;

  -- General terminology for goals: signals, derailers, etc.
  SameDirectionObject : SearchSubject -> DirectionalObject;
  OppositeDirectionObject : SearchSubject -> DirectionalObject;
  AnyDirectionObject : SearchSubject -> DirectionalObject;

  SearchDirectionObject : SearchSubject -> DirectionalObject;
  OppositeSearchDirecitonObject : SearchSubject -> DirectionalObject;

-- Search termination
  FirstFound : DirectionalObject -> GoalObject;
  AnyFound : DirectionalObject -> GoalObject; -- Any or All?

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

    AllPathsObligation : Subject -> GoalObject -> PathCondition -> Statement;
    -- ExistsPathObligation : Object -> GoalObject -> PathCondition;
    -- UniquePPathObligation : Object -> GoalObject -> PathCondition;
    -- NoPathObligation : Object -> GoalObject -> PathCondition;

    DistanceObligation : Subject -> GoalObject -> Restriction -> Statement;

  -- Path Conditions
    PathContains : DirectionalObject -> PathCondition;

}
