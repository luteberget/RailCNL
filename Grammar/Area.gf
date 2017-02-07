abstract Area = Graph ** {

  cat
    BaseArea;
    NamedArea;
    Area;
    AreaConj;

 fun
 
 -- Any area of built-in type
  TunnelArea, BridgeArea, LocalReleaseArea : BaseArea;

 -- Any area of named type
  MkNamedArea : String -> BaseArea;

 -- Area has given name.
  SpecificArea : String -> BaseArea -> NamedArea;
  NonSpecificArea : BaseArea -> NamedArea;

  -- Property restriction on area
  AreaPropertyRestriction : NamedArea -> PropertyRestriction -> Area;
  NoRestrictionArea : NamedArea -> Area;

  SingleArea : Area -> AreaConj;
  OrArea, AndArea : AreaConj -> AreaConj -> AreaConj;

  SubjectArea : Subject -> AreaConj -> Subject;
  --AreaCondition : AreaConj -> Condition;

  PlacementRestriction : Modality -> Subject -> AreaConj -> Statement;
}
