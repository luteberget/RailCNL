abstract Area = Graph ** {

  cat
    Area;


 fun
 
 -- Any area of built-in type
  TunnelArea, BridgeArea, LocalReleaseArea : Area;

 -- Any area of named type
  NamedArea : String -> Area;

 -- Area has given name.
  SpecificArea : String -> Area -> Area;

  AreaPropertyRestriction : Area -> PropertyRestriction -> Area;


  ObjectArea : Object -> Area -> Object;
  SubjectArea : Subject -> Area -> Subject;
  AreaCondition : Area -> Condition;

}