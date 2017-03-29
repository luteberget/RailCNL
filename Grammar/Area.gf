abstract Area = Graph ** {

  cat
    BaseArea;
    NamedArea;
    SingleArea;
    AreaConj;
    Area; -- Closed for modifiers
 fun
 
 -- Any area of built-in type
  TunnelArea, BridgeArea, LocalReleaseArea : BaseArea;

 -- Any area of named type
  MkNamedArea : String -> BaseArea;

 -- Area has given name.
  SpecificArea : String -> BaseArea -> NamedArea;
  NonSpecificArea : BaseArea -> NamedArea;

  -- Property restriction on area
  AreaPropertyRestriction : NamedArea -> PropertyRestriction -> SingleArea;
  NoRestrictionArea : NamedArea -> SingleArea;

  SingleAreaConj : SingleArea -> AreaConj;
  OrArea, AndArea : AreaConj -> AreaConj -> AreaConj;

  MkArea : AreaConj -> Area;

  SubjectArea : OpenSubject -> Area -> Subject;

  PlacementRestriction : Modality -> Subject -> Area -> Statement;
}
