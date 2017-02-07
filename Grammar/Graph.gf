abstract Graph = Ontology ** {
  -- Graph property language.
  flags startcat=Statement;

  cat
    DirectionalObject;
    GoalObject;
    PathCondition;
    SearchSubject;
    PathQuantifier;

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


    AllPaths, ExistsPath, UniquePath, NoPath : PathQuantifier;

   -- Statements

    PathObligation : PathQuantifier -> Subject -> GoalObject -> PathCondition -> Statement;


-- Attempts at Relation-defining Path:
--   ""Veier fra et forsignal til det første påfølgende hovedsignalet 
--     i kjøreretningen er dets/forsignalets påfølgende hovedsignal. ""
--     Explicit "path", but repeats "forsignalet". Requires genitive.
--
--   ""Det første påfølgende hovedsignalet i kjøreretningen er et 
--     forsignals påfølgende hovedsignal."" -- Awkward ordering.
--
--   ""Tilhørende hovedsignal for et forsignal bør være det første
--     påfølgende hovedsignalet i kjøreretningen. """"
--     This one avoids genitive! Puts defined term in front. 
--     Same ordering as PathObligation. Seems good.

    RelationDefiningPath : Class -> Subject -> GoalObject -> Statement;
    RelationPathRestriction : Modality -> Class -> Subject -> GoalObject -> Statement;


    DistanceRestriction : Modality -> Subject -> GoalObject -> Restriction -> Statement;
    DistanceRelationRestriction : Modality -> Subject -> Class -> Restriction -> Statement;

  -- Path Conditions
    PathContains : DirectionalObject -> PathCondition;

}
