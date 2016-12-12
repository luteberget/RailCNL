abstract Ontology = RailCNLStatement, Datalog ** {
  -- Partial grammar in the Railway CNL for expressing classes and 
  -- properties of classes.

  flags startcat=Statement ;


  cat
    Class; Property; Value;
    -- SimpleSubject; -- a track, a red track, a track of quality class X.
    -- Try without this for now.
    Subject; -- a track, a track of quality class X, a track which has length greater than 200,
             -- an object which is red.
    Condition;
    PropertyRestriction; -- has a length which is less than 200 m

  fun

  -- Classes, properties, values
    StringClass : String -> Class;
    StringAdjective : String -> Class -> Class;
    StringProperty : String -> Property;
    MkValue : Term -> Value; -- ConstTerm?
    GtProperty, GteProperty, LtProperty, LteProperty, EqProperty, NeqProperty  
      : Property -> Value -> PropertyRestriction; 

  -- Subjects

    -- alle spor / et spor ...
    SubjectClass : Class -> Subject;

    -- alle spor som har ...
    SubjectPropertyRestriction : Class -> PropertyRestriction -> Subject;

    -- SubjectPropertyValue : Subject -> Property -> Value -> Subject;
    AndRestr, OrRestr : PropertyRestriction -> PropertyRestriction -> PropertyRestriction;


  -- Conditions 
    ConditionClass : Class -> Condition;
    ConditionPropertyRestriction : PropertyRestriction -> Condition;
    DatalogCondition : Literal -> Condition;

    -- Condition operations
    AndCond, OrCond : Condition -> Condition -> Condition;
  
    
  -- Statements 
    DefineClass : Subject -> Class -> Statement;
    -- DefineProperty : Subject -> SubjectValue -> Property -> Definition;
    Obligation : Subject -> Condition -> Statement;
    Constraint : Subject -> Condition -> Statement;
    Recommendation : Subject -> Condition -> Statement;
    Heuristic : Subject -> Condition -> Statement;
  
}
