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

    ClassRestriction;

    Restriction;        -- "less than 200 m"
                        -- "red"
                        -- "red or blue"

  fun

  -- Classes, properties, values
    StringClass : String -> Class;
    StringClassGen1 : String -> Class;
    StringClassGen2 : String -> Class;
    StringAdjective : String -> Class -> Class;
    StringProperty : String -> Property;
    MkValue : Term -> Value; -- ConstTerm?

  -- Value restrictions
    Gt, Gte, Lt, Lte, Eq, Neq
      : Value -> Restriction;
    AndRestr, OrRestr : Restriction -> Restriction -> Restriction;

  -- Property value restrictions
   MkPropertyRestriction : Property -> Restriction -> PropertyRestriction;
   AndPropRestr, OrPropRestr : PropertyRestriction -> PropertyRestriction -> PropertyRestriction;

   MkClassRestriction : Class -> ClassRestriction;
   AndClassRestr, OrClassRestr : ClassRestriction -> ClassRestriction -> ClassRestriction;

  -- Subjects

    -- alle spor / et spor ...
    SubjectClass : Class -> Subject;

    -- alle spor som har ...
    SubjectPropertyRestriction : Class -> PropertyRestriction -> Subject;
    SubjectClassRestriction : Class -> ClassRestriction -> Subject;
    SubjectClassAndPropertyRestriction : Class -> ClassRestriction -> PropertyRestriction -> Subject;


  -- Conditions
    ConditionClass : Class -> Condition;
    ConditionPropertyRestriction : PropertyRestriction -> Condition;
    DatalogCondition : Literal -> Condition;

    -- Condition operations
    AndCond, OrCond : Condition -> Condition -> Condition;


  -- Statements
    Obligation, Constraint, Recommendation : Subject -> Condition -> Statement;

}
