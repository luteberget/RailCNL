abstract Ontology = RailCNLStatement, Datalog ** {
  -- Partial grammar in the Railway CNL for expressing classes and
  -- properties of classes.

  flags startcat=Statement ;


  cat
    Class; Property; Value;
    Subject; -- "a track", "a track of quality class X",
             -- "a track which has length greater than 200",
             -- "an object which is red".

    Condition; -- Same as subject, but can also be just a property restriction,
               -- "a track which has color red" or just "color red".

    PropertyRestriction; -- "has a length which is less than 200 m"
                         -- "color red"
                         -- "color red or blue"
                         -- "color red or length 15.0"

  fun

  -- Classes, properties, values
    StringClass : String -> Class;
    StringAdjective : String -> Class -> Class;
    StringProperty : String -> Property;
    MkValue : Term -> Value; -- ConstTerm?

  -- Property restrictions
    GtProperty, GteProperty, LtProperty, LteProperty, EqProperty, NeqProperty
      : Property -> Value -> PropertyRestriction;
      AndRestr, OrRestr : PropertyRestriction -> PropertyRestriction -> PropertyRestriction;


  -- Subjects

    -- alle spor / et spor ...
    SubjectClass : Class -> Subject;

    -- alle spor som har ...
    SubjectPropertyRestriction : Class -> PropertyRestriction -> Subject;


  -- Conditions
    ConditionClass : Class -> Condition;
    ConditionPropertyRestriction : PropertyRestriction -> Condition;
    DatalogCondition : Literal -> Condition;

    -- Condition operations
    AndCond, OrCond : Condition -> Condition -> Condition;


  -- Statements
    DefineClass : Subject -> Class -> Statement;
    -- -- DefineProperty : Subject -> SubjectValue -> Property -> Definition;

    Obligation : Subject -> Condition -> Statement;
    Constraint : Subject -> Condition -> Statement;
    Recommendation : Subject -> Condition -> Statement;
    Heuristic : Subject -> Condition -> Statement;

}
